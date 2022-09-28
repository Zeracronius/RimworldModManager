using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ModManager.Gui.Components;
using ModManager.Logic.Configuration;
using ModManager.Logic.Main;
using ModManager.Logic.Main.ViewModels;
using ModManager.Logic.Model;
using ModManager.Logic.TextDialog;
using ModManager.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModManager.Gui
{
    public partial class Main : Form
    {
        private readonly MainPresenter _presenter;
        private readonly List<ITreeListViewItem> _activeModItems = new List<ITreeListViewItem>();
        private readonly List<ITreeListViewItem> _passiveModItems = new List<ITreeListViewItem>();
        private readonly Dictionary<string, GroupViewModel> _groups = new Dictionary<string, GroupViewModel>();

        public Main(MainPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.LoadComplete += Presenter_LoadComplete;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitConfiguration();
            _presenter.LoadData();
            PresenterBindingSource.DataSource = _presenter;


            SimpleDropSink sink1 = (SimpleDropSink)ActiveModsListView.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            sink1.CanDropOnBackground = true;
            sink1.CanDropOnItem = true;

            sink1 = (SimpleDropSink)ModsListView.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            sink1.CanDropOnBackground = true;
            sink1.CanDropOnItem = true;



            // Configure the first tree
            ActiveModsListView.CanExpandGetter = x => ((ITreeListViewItem)x).Children.Count > 0;
            ActiveModsListView.ChildrenGetter = x => ((ITreeListViewItem)x).Children;

            // Configure the second tree
            ModsListView.CanExpandGetter = x => ((ITreeListViewItem)x).Children.Count > 0;
            ModsListView.ChildrenGetter = x => ((ITreeListViewItem)x).Children;

            this.Activate();
        }


        private void InitConfiguration()
        {
#if DEBUG
            Settings.Default.Reset();
#else
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
#endif

            if (String.IsNullOrWhiteSpace(Settings.Default.InstallationPath) || System.IO.File.Exists(System.IO.Path.Combine(Settings.Default.InstallationPath, "Version.txt")) == false)
            {
                OpenFileDialog fileDialog = new OpenFileDialog()
                {
                    Filter = "RimWorld.exe (*.exe)|*.exe",
                    Title = "Select rimworld directory"
                };


                using (fileDialog)
                {
                    System.IO.FileInfo exeFile = null;
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                        exeFile = new System.IO.FileInfo(fileDialog.FileName);



                    if (exeFile != null && exeFile.Exists)
                    {
                        Settings settings = Settings.Default;
                        settings.InstallationPath = exeFile.DirectoryName;

                        settings.ConfigPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low", "Ludeon Studios", "RimWorld by Ludeon Studios", "Config");

                        System.IO.DirectoryInfo steamApps = System.IO.Directory.GetParent(settings.InstallationPath).Parent;
                        settings.WorkshopPath = System.IO.Path.Combine(steamApps.FullName, "workshop", "content", Resources.SteamId);
                        settings.LocalModsPath = System.IO.Path.Combine(settings.InstallationPath, "Mods");
                        settings.ExpansionsPath = System.IO.Path.Combine(settings.InstallationPath, "Data");


                        settings.Save();
                    }
                    else
                        Close();
                }

            }


            if (System.IO.Directory.Exists(Settings.Default.ConfigPath) == false || System.IO.Directory.Exists(Settings.Default.ExpansionsPath) == false)
            {
                ConfigurationPresenter configPresenter = new ConfigurationPresenter();
                using (Configuration configDialog = new Configuration(configPresenter))
                {
                    if (configDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("The program cannot work without a valid path to the configuration file and core expansion, and will now close.");
                        Close();
                    }
                }
            }
        }


        private void Presenter_LoadComplete(object sender, EventArgs e)
        {
            int activeMods = _presenter.Config.ActiveMods.Length;
            int availableMods = _presenter.AvailableMods.Count + activeMods;

            GroupViewModel.ResetSeed();

            _activeModItems.Clear();
            _passiveModItems.Clear();

            if (Settings.Default.Parenting == null)
                Settings.Default.Parenting = new StringCollection();

            Dictionary<string, string> parents = new Dictionary<string, string>(Settings.Default.Parenting.Count);
            foreach (string parentPair in Settings.Default.Parenting)
            {
                string[] parentParts = parentPair.Split(new char[]{ '\\' }, 2);
                parents[parentParts[0]] = parentParts[1];
            }


            Dictionary<string, string> groupMapping = new Dictionary<string, string>();

            _groups.Clear();
            groupMapping.Clear();
            foreach (var mod in _presenter.ActiveMods)
            {
                if (parents.ContainsKey(mod.Key))
                {
                    ITreeListViewItem parent = GetParent(_activeModItems, groupMapping, parents, mod.Key);
                    
                    if (parent != null)
                    {
                        parent.Children.Add(mod.Value);
                        mod.Value.Parent = parent;
                        continue;
                    }
                }
                _activeModItems.Add(mod.Value);
            }

            groupMapping.Clear();
            foreach (var mod in _presenter.AvailableMods.OrderByDescending(x => _presenter.AvailableMods[x.Key].Downloaded))
            {
                if (parents.ContainsKey(mod.Key))
                {
                    ITreeListViewItem parent = GetParent(_passiveModItems, groupMapping, parents, mod.Key);

                    if (parent != null)
                    {
                        parent.Children.Add(mod.Value);
                        mod.Value.Parent = parent;
                        continue;
                    }
                }
                _passiveModItems.Add(mod.Value);
            }

            ActiveModsListView.RowData = _activeModItems;
            ModsListView.RowData = _passiveModItems;
            ActiveModsListView.Reload();
            ModsListView.Reload();

            ActiveModsListView.ExpandAll();
            ModsListView.ExpandAll();

            RefreshInterface();
            SaveButton.Enabled = true;
        }

        private ITreeListViewItem GetParent(List<ITreeListViewItem> targetCollection, Dictionary<string, string> groupTranslationMap, Dictionary<string, string> parents, string key)
        {
            key = parents[key];

            // Is it a group?
            if (key.Contains('\\'))
            {
                string[] keyParts = key.Split('\\');
                string groupKey = keyParts[0];


                if (groupTranslationMap.ContainsKey(groupKey))
                    groupKey = groupTranslationMap[groupKey];

                if (_groups.TryGetValue(groupKey, out GroupViewModel group) == false)
                {
                    group = new GroupViewModel(keyParts[1]);
                    groupTranslationMap.Add(keyParts[0], groupKey);

                    if (parents.ContainsKey(keyParts[0]))
                        group.Parent = GetParent(targetCollection, groupTranslationMap, parents, keyParts[0]);

                    if (group.Parent != null)
                        group.Parent.Children.Add(group);
                    else
                        targetCollection.Add(group);

                    _groups.Add(groupKey, group);
                }

                return group;
            }
            else
            {
                return FlattenList(targetCollection).FirstOrDefault(x => x.Key == key);
            }
        }

        private void ModsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update mod meta section
            Components.ReorderableTreeListView view = sender as Components.ReorderableTreeListView;
            if (view.SelectedIndices.Count == 1)
            {
                if (view.SelectedObject is ModViewModel selectedMod)
                {
                    menuStrip1.Enabled = true;
                    _presenter.SelectedMod = selectedMod;

                    if (String.IsNullOrWhiteSpace(selectedMod.WorkshopPath))
                        openWorkshopPageToolStripMenuItem.Visible = false;
                    else
                        openWorkshopPageToolStripMenuItem.Visible = true;


                    // Convert Unity rich text format to HTML
                    string richFormat = "<html><body>" + selectedMod.Description + "</body></html>";

                    // Parse size tags
                    richFormat = Regex.Replace(richFormat, "<size=([-e,0-9.]*?)>(.*?)</size>", new MatchEvaluator(x =>
                    {
                        string size = x.Groups[1].Value;

                        int integerSize = int.Parse(size) / 3;

                        return $"<font size=\"{integerSize}\">{x.Groups[2].Value}</font>";
                    }));

                    // Parse color tags
                    richFormat = Regex.Replace(richFormat, "<color=(.*?)>(.*?)</color>", "<font color=\"$1\">$2</font>");

                    // Parse color tags
                    richFormat = Regex.Replace(richFormat, "\n", "<br />");
                    richFormat = Regex.Replace(richFormat, @"\\n", "<br />");


                    DescriptionWebBrowser.DocumentText = richFormat;
                    PresenterBindingSource.ResetBindings(false);
                    return;
                }
            }

            menuStrip1.Enabled = false;
            _presenter.SelectedMod = null;
            DescriptionWebBrowser.DocumentText = String.Empty;
            PresenterBindingSource.ResetBindings(false);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ModViewModel[] issues = FlattenList(_activeModItems).OfType<ModViewModel>().Where(x => x.Background != Color.Transparent).ToArray();
            if (issues.Length > 0)
            {
                int warnings = issues.Count(x => x.Background == _presenter.WarningColor);
                int incompatibles = issues.Count(x => x.Background == _presenter.IncompatibleColor);

                DialogResult result = MessageBox.Show($"There is currently {warnings} warnings and {incompatibles} incompatible mods.", "Save mods", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;
            }


            StringCollection parents = Settings.Default.Parenting;
            parents.Clear();

            parents.AddRange(SaveMods(_passiveModItems));
            parents.AddRange(SaveMods(_activeModItems));
            Settings.Default.Parenting = parents;

            _presenter.Config.ActiveMods = FlattenList(_activeModItems).OfType<ModViewModel>().Select(x => x.PackageId).ToArray();
            _presenter.SaveConfig();
            _presenter.LoadData();
        }


        private string[] SaveMods(List<ITreeListViewItem> collection)
        {
            return FlattenList(collection).Where(x => x.Parent != null).Select(x => x.Key + "\\" + x.Parent.Key + (x.Parent is GroupViewModel ? "\\" + x.Parent.Caption : "")).ToArray();
        }

        private IEnumerable<ITreeListViewItem> FlattenList(IEnumerable<ITreeListViewItem> list)
        {
            foreach (ITreeListViewItem item in list)
            {
                yield return item;

                foreach (ITreeListViewItem subMod in FlattenList(item.Children))
                {
                    yield return subMod;
                }
            }
        }

        private void BrowseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.BrowseFolder();
        }

        private void OpenWorkshopPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OpenWorkshopPage();
        }

        private void RefreshInterface()
        {
            PresenterBindingSource.ResetBindings(false);

            List<ModViewModel> disabledMods = FlattenList(_passiveModItems).OfType<ModViewModel>().ToList();
            int availableMods = disabledMods.Count;
            int outdatedMods = disabledMods.OfType<ModViewModel>().Count(x => x.Background == _presenter.IncompatibleColor);

            AvailableModsFooterLabel.Text = $"{availableMods} inactive.";
            if (outdatedMods > 0)
                AvailableModsFooterLabel.Text += $" ({outdatedMods} incompatible)";

            List<ModViewModel> activeMods = FlattenList(_activeModItems).OfType<ModViewModel>().ToList();
            availableMods = activeMods.Count;
            outdatedMods = activeMods.Count(x => x.Background == _presenter.IncompatibleColor);

            ActiveModsFooterLabel.Text = $"{availableMods} active.";
            if (outdatedMods > 0)
                ActiveModsFooterLabel.Text += $" ({outdatedMods} incompatible)";


            foreach (ModViewModel mod in activeMods)
            {
                if (mod.Background == _presenter.IncompatibleColor)
                    continue; 

                StringBuilder tooltip = new StringBuilder();

                if (mod.Dependencies != null)
                {
                    foreach (KeyValuePair<string, string> dependancy in mod.Dependencies)
                    {
                        ModViewModel referencedMod = activeMods.FirstOrDefault(x => x.PackageId == dependancy.Key);
                        if (referencedMod == null)
                            tooltip.AppendLine("Missing dependancy: " + dependancy.Value);
                    }
                }

                int currentIndex = activeMods.IndexOf(mod);

                if (mod.LoadAfter != null)
                {
                    foreach (string loadAfter in mod.LoadAfter)
                    {
                        ModViewModel referencedMod = activeMods.FirstOrDefault(x => x.PackageId == loadAfter);
                        if (referencedMod != null)
                        {
                            int dependentIndex = activeMods.IndexOf(referencedMod);
                            if (dependentIndex > currentIndex)
                            {
                                tooltip.AppendLine("This should be loaded after " + referencedMod.Caption);
                            }
                        }
                    }
                }

                if (mod.LoadBefore != null)
                {
                    foreach (string loadBefore in mod.LoadBefore)
                    {
                        ModViewModel referencedMod = activeMods.FirstOrDefault(x => x.PackageId == loadBefore);
                        if (referencedMod != null)
                        {
                            int dependentIndex = activeMods.IndexOf(referencedMod);
                            if (dependentIndex < currentIndex)
                            {
                                tooltip.AppendLine("This should be loaded before " + referencedMod.Caption);
                            }
                        }
                    }
                }

                mod.Tooltip = tooltip.ToString();
                if (mod.Tooltip.Length > 0)
                    mod.Background = _presenter.WarningColor;
                else
                    mod.Background = Color.Transparent;
            }
        }

        private void ActiveModsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (ActiveModsListView.SelectedObjects.Count > 1)
                return;

            // Move mod to disabled list
            ModViewModel selectedItem = (ModViewModel)ActiveModsListView.SelectedObject;
            _activeModItems.Remove(selectedItem);
            _passiveModItems.Add(selectedItem);

            ActiveModsListView.Reload();
            ModsListView.Reload();
            RefreshInterface();
        }

        private void ModsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (ModsListView.SelectedObjects.Count > 1)
                return;

            // Move mod to activated list
            ModViewModel selectedItem = (ModViewModel)ModsListView.SelectedObject;
            _passiveModItems.Remove(selectedItem);
            _activeModItems.Add(selectedItem);

            ActiveModsListView.Reload();
            ModsListView.Reload();
            RefreshInterface();
        }

        private void ConfigurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationPresenter configPresenter = new ConfigurationPresenter();
            using (Configuration configDialog = new Configuration(configPresenter))
            {
                configDialog.ShowDialog(this);
            }
        }

        private void ConfigFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseFolder(Settings.Default.ConfigPath);
        }

        private void ExpansionsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseFolder(Settings.Default.ExpansionsPath);
        }

        private void WorkshopFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseFolder(Settings.Default.WorkshopPath);
        }

        private void ModsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseFolder(Settings.Default.LocalModsPath);
        }

        private void BrowseFolder(string path)
        {
            if (System.IO.Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageBox.Show("Browse folder", "Folder does not exist.", MessageBoxButtons.OK);
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.AddExtension = true;
                dialog.Filter = "mod list (*.modlist)|*.modlist";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    _presenter.ExportModlist(dialog.FileName);
            }
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow", "Ludeon Studios", "RimWorld by Ludeon Studios", "Saves");
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.AddExtension = true;
                dialog.Filter = "All|*.modlist;*.rws|mod list (*.modlist)|*.modlist|rimworld save (*.rws)|*.rws";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                dialog.FilterIndex = 1;

                if (Directory.Exists(savePath))
                    dialog.InitialDirectory = savePath;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    _presenter.ImportModlist(dialog.FileName);
            }
        }

        private void ActiveModsListView_ItemsAdding(object sender, ItemsAddingEventArgs e)
        {
            if (e.Canceled)
                return;

            _activeModItems.InsertRange(e.Index, e.ObjectsToAdd.OfType<ITreeListViewItem>());
        }

        private void ActiveModsListView_ItemsRemoving(object sender, ItemsRemovingEventArgs e)
        {
            if (e.Canceled)
                return;

            foreach (var item in e.ObjectsToRemove.OfType<ITreeListViewItem>())
                _activeModItems.Remove(item);
        }

        private void ModsListView_ItemsRemoving(object sender, ItemsRemovingEventArgs e)
        {
            if (e.Canceled)
                return;

            foreach (var item in e.ObjectsToRemove.OfType<ITreeListViewItem>())
                _passiveModItems.Remove(item);
        }

        private void ModsListView_ItemsAdding(object sender, ItemsAddingEventArgs e)
        {
            if (e.Canceled)
                return;

            _passiveModItems.InsertRange(e.Index, e.ObjectsToAdd.OfType<ITreeListViewItem>());
        }

        private void ListView_ModelDropped(object sender, ModelDropEventArgs e)
        {
            ReorderableTreeListView targetListView = e.ListView as ReorderableTreeListView;
            ReorderableTreeListView sourceListView = e.SourceListView as ReorderableTreeListView;

            List<ITreeListViewItem> targetCollection = targetListView.RowData as List<ITreeListViewItem>;
            List<ITreeListViewItem> sourceCollection = sourceListView.RowData as List<ITreeListViewItem>;
            IEnumerable<ITreeListViewItem> selectedItems = e.SourceModels.OfType<ITreeListViewItem>();
            ITreeListViewItem targetItem = (ITreeListViewItem)e.TargetModel;

            if (targetItem?.Parent != null)
                targetCollection = targetItem.Parent.Children;


            // Detach
            foreach (ITreeListViewItem x in selectedItems)
            {
                if (x.Parent != null)
                {
                    x.Parent.Children.Remove(x);
                    x.Parent = null;
                }
                else
                    sourceCollection.Remove(x);
            }


            switch (e.DropTargetLocation)
            {
                // Add to bottom
                case DropTargetLocation.Background:
                    MoveObjectsToRoots(targetCollection, selectedItems);
                    break;

                // Create group
                case DropTargetLocation.Item:
                    MoveItemsToGroup(targetItem, selectedItems);
                    targetListView.Expand(targetItem);
                    break;

                // Move items to index
                case DropTargetLocation.AboveItem:
                    MoveObjectsToItem(targetCollection, targetItem, selectedItems);
                    break;

                // Move items to index
                case DropTargetLocation.BelowItem:
                    MoveObjectsToItem(targetCollection, targetItem, selectedItems, false);
                    break;
            }

            e.SourceListView.DeselectAll();
            targetListView.Reload();
            if (sourceListView != targetListView)
                sourceListView.Reload();
            RefreshInterface();
        }


        private void MoveItemsToGroup(ITreeListViewItem target, IEnumerable<ITreeListViewItem> selectedItems)
        {
            target.Children.AddRange(selectedItems);
            foreach (var item in selectedItems)
                item.Parent = target;
        }

        private void MoveObjectsToRoots(List<ITreeListViewItem> targetCollection, IEnumerable<ITreeListViewItem> selectedItems)
        {
            targetCollection.AddRange(selectedItems);
        }

        private void MoveObjectsToItem(List<ITreeListViewItem> targetCollection, ITreeListViewItem target, IEnumerable<ITreeListViewItem> selectedItems, bool above = true)
        {
            int offset = above ? 0 : 1;
            if (target.Parent != null)
            {
                int index = target.Parent.Children.IndexOf(target);
                target.Parent.Children.InsertRange(index + offset, selectedItems);
                foreach (var item in selectedItems)
                    item.Parent = target.Parent;
            }
            else
            {
                int index = targetCollection.IndexOf(target);
                targetCollection.InsertRange(index + offset, selectedItems);
            }
        }

        private void ActiveModListFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            ActiveModsListView.ApplyFilter(ActiveModListFilterTextBox.Text);
        }

        private void InactiveModListFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            ModsListView.ApplyFilter(InactiveModListFilterTextBox.Text);
        }


        private void ModsListView_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Model is ModViewModel mod && mod.Background != Color.Transparent)
                e.Item.BackColor = mod.Background;
        }

        private void ModsListView_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (e.Item.RowObject is ModViewModel mod)
                e.Text = mod.Tooltip;
            
        }

        private void ListView_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            // Rightclicked background
            if (e.Model == null)
            {
                e.MenuStrip = BackgroundContextMenuStrip;
            }
            else
            {
                switch (e.Model)
                {
                    case GroupViewModel _:
                        e.MenuStrip = GroupContextMenuStrip;
                        break;

                    default:
                        e.Handled = true;
                        return;
                }
            }

            e.MenuStrip.Tag = e.ListView;
        }

        private void Group_Context_Delete_Click(object sender, EventArgs e)
        {
            ToolStrip contextMenu = (sender as ToolStripItem).GetCurrentParent();
            ReorderableTreeListView listView = contextMenu.Tag as ReorderableTreeListView;

            List<ITreeListViewItem> collection = listView.RowData as List<ITreeListViewItem>;
            GroupViewModel group = listView.SelectedObject as GroupViewModel;

            if (group.Parent != null)
            {
                MoveObjectsToItem(group.Parent.Children, group.Parent, group.Children, false);
                group.Parent.Children.Remove(group);
            }
            else
            {
                MoveObjectsToRoots(collection, group.Children);
                collection.Remove(group);
            }

            _groups.Remove(group.Key);
            listView.Reload();
        }

        private void Group_Context_Rename_Click(object sender, EventArgs e)
        {
            ToolStrip contextMenu = (sender as ToolStripItem).GetCurrentParent();
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.Tag;
            GroupViewModel selectedGroup = listView.SelectedObject as GroupViewModel;

            TextDialogPresenter presenter = new TextDialogPresenter("Rename group", selectedGroup.Caption, "New name:");
            using (TextDialog dialog = new TextDialog(presenter))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    selectedGroup.Caption = presenter.Value;
                    listView.Reload();
                }
            }
        }

        private void TreeView_Context_CreateGroup_Click(object sender, EventArgs e)
        {
            ToolStrip contextMenu = (sender as ToolStripItem).GetCurrentParent();
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.Tag;

            TextDialogPresenter presenter = new TextDialogPresenter("New group", String.Empty, "Group name:");
            using (TextDialog dialog = new TextDialog(presenter))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    GroupViewModel group = new GroupViewModel(presenter.Value);
                    listView.RowData.Add(group);
                    listView.Reload();
                }
            }
        }
    }
}
