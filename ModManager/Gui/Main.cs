using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ModManager.Gui.Components;
using ModManager.Logic.Configuration;
using ModManager.Logic.Main;
using ModManager.Logic.Main.ViewModels;
using ModManager.Logic.TextDialog;
using ModManager.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ModManager.Gui
{
    public partial class Main : Form
    {
        private readonly MainPresenter _presenter;
        private readonly List<ITreeListViewItem> _activeModItems = new List<ITreeListViewItem>();
        private readonly List<ITreeListViewItem> _passiveModItems = new List<ITreeListViewItem>();
        private bool _initializing;

        public Main(MainPresenter presenter)
        {
            _initializing = true;
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
            ActiveModsListView.CanExpandGetter = x => ((ITreeListViewItem)x).FilteredChildren.Any();
            ActiveModsListView.ChildrenGetter = x => ((ITreeListViewItem)x).FilteredChildren;

            // Configure the second tree
            ModsListView.CanExpandGetter = x => ((ITreeListViewItem)x).FilteredChildren.Any();
            ModsListView.ChildrenGetter = x => ((ITreeListViewItem)x).FilteredChildren;

            ModsListView.PrimarySortColumn = InactiveDownloadedColumn;
            ModsListView.PrimarySortOrder = SortOrder.Descending;

            this.Activate();
        }


        private void InitConfiguration()
        {
//#if DEBUG
//            Settings.Default.Reset();
//#else
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
//#endif

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

        private void ClearList(List<ITreeListViewItem> collection)
        {
            foreach (ITreeListViewItem item in FlattenList(collection).ToList())
            {
                item.Children.Clear();
            }
            collection.Clear();
        }

        private void Presenter_LoadComplete(object sender, EventArgs e)
        {
            GroupViewModel.ResetSeed();

            ClearList(_activeModItems);
            ClearList(_passiveModItems);

            if (Settings.Default.Parenting == null)
                Settings.Default.Parenting = new StringCollection();

            Dictionary<string, string> parents = new Dictionary<string, string>(Settings.Default.Parenting.Count);
            foreach (string parentPair in Settings.Default.Parenting)
            {
                string[] parentParts = parentPair.Split(new char[]{ '\\' }, 2);
                parents[parentParts[0]] = parentParts[1];
            }

            _activeModItems.AddRange(LoadMods(_presenter.ActiveMods, parents, true));
            _passiveModItems.AddRange(LoadMods(_presenter.AvailableMods, parents));

            ActiveModsListView.RowData = _activeModItems;
            ModsListView.RowData = _passiveModItems;
            ActiveModsListView.Reload();
            ModsListView.Reload();

            ActiveModsListView.ExpandAll();
            ModsListView.ExpandAll();

            if (_initializing)
            {

                if (Settings.Default.HiddenColumnsActive == null)
                    Settings.Default.HiddenColumnsActive = new StringCollection();

                foreach (string column in Settings.Default.HiddenColumnsActive)
                    if (String.IsNullOrWhiteSpace(column) == false)
                        ActiveModsListView.AllColumns.Single(x => x.Text == column).IsVisible = false;

                if (Settings.Default.HiddenColumnsInactive == null)
                    Settings.Default.HiddenColumnsInactive = new StringCollection();

                foreach (string column in Settings.Default.HiddenColumnsInactive)
                    if (String.IsNullOrWhiteSpace(column) == false)
                        ModsListView.AllColumns.Single(x => x.Text == column).IsVisible = false;
            }

            ActiveModsListView.ApplyFilter(ActiveModListFilterTextBox.Text);
            ModsListView.ApplyFilter(InactiveModListFilterTextBox.Text);

            RefreshInterface();
            SaveButton.Enabled = true;
            _initializing = false;
        }

        private List<ITreeListViewItem> LoadMods(IEnumerable<KeyValuePair<string, ModViewModel>> mods, Dictionary<string, string> parents, bool orderSensitive = false)
        {
            Dictionary<string, GroupViewModel> groups = new Dictionary<string, GroupViewModel>();
            List<ITreeListViewItem> result = new List<ITreeListViewItem>();

            foreach (var mod in mods)
            {
                if (mod.Value == null)
                    continue;

                if (mod.Value.SupportedVersions.Contains(_presenter.CoreVersion) == false)
                {
                    mod.Value.Tooltip = "Incompatible with current version.";
                    mod.Value.Background = _presenter.IncompatibleColor;
                }

                // Does current mod have a parent assigned.
                if (parents.ContainsKey(mod.Key))
                {
                    // Find parent
                    ITreeListViewItem parent = GetParent(result, groups, parents, mod.Key, orderSensitive);

                    if (parent != null)
                    {
                        parent.Children.Add(mod.Value);
                        mod.Value.Parent = parent;
                        continue;
                    }
                }

                result.Add(mod.Value);
            }

            return result;
        }

        private ITreeListViewItem GetParent(List<ITreeListViewItem> targetCollection, Dictionary<string, GroupViewModel> groups, Dictionary<string, string> parents, string key, bool orderSensitive)
        {
            key = parents[key];

            // Is it a group?
            if (key.Contains('\\'))
            {
                string[] keyParts = key.Split('\\');
                string groupCaption = keyParts[1];
                string groupKey = keyParts[0];

                ITreeListViewItem result = null;
                if (orderSensitive)
                {
                    // If order sensitive then check if the immediate group above is matching caption.
                    if (targetCollection.Count > 0)
                    {
                        result = targetCollection[targetCollection.Count - 1];
                        if (result is GroupViewModel == false || result.Caption != groupCaption)
                        {
                            ITreeListViewItem found = result;
                            result = null;

                            foreach (var item in FlattenList(found.Children))
                            {
                                if (item is GroupViewModel && item.Caption == groupCaption)
                                    result = item;
                            }
                        }
                    }
                }
                else
                {
                    // Else check if a group has already been added of matching caption.
                    result = groups.FirstOrDefault(x => x.Value.Caption == groupCaption).Value;
                }

                if (result == null)
                {
                    result = new GroupViewModel(groupCaption);

                    if (parents.ContainsKey(groupKey))
                        result.Parent = GetParent(targetCollection, groups, parents, groupKey, orderSensitive);

                    if (result.Parent != null)
                        result.Parent.Children.Add(result);
                    else
                        targetCollection.Add(result);

                    groups.Add(result.Key, result as GroupViewModel);
                }

                return result;
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

            Settings.Default.HiddenColumnsActive.Clear();
            Settings.Default.HiddenColumnsActive.AddRange(ActiveModsListView.AllColumns.Where(x => x.IsVisible == false).Select(x => x.Text).ToArray());

            Settings.Default.HiddenColumnsInactive.Clear();
            Settings.Default.HiddenColumnsInactive.AddRange(ModsListView.AllColumns.Where(x => x.IsVisible == false).Select(x => x.Text).ToArray());



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
            int outdatedMods = disabledMods.Count(x => x.Background == _presenter.IncompatibleColor);

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
            ToggleSelectedMod(ActiveModsListView, ModsListView);
        }

        private void ModsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            ToggleSelectedMod(ModsListView, ActiveModsListView);
        }

        private void ToggleSelectedMod(ReorderableTreeListView source, ReorderableTreeListView target)
        {
            if (source.SelectedObjects.Count != 1)
                return;

            ITreeListViewItem selectedItem = (ITreeListViewItem)source.SelectedObject;

            ITreeListViewItem parent = selectedItem.Parent;
            if (parent != null)
            {
                ITreeListViewItem targetParent = FlattenList(target.RowData.Cast<ITreeListViewItem>()).FirstOrDefault(x => parent is GroupViewModel ? parent.Caption == x.Caption : x.Key == parent.Key);

                if (targetParent == null && parent is GroupViewModel)
                {
                    parent = new GroupViewModel(parent.Caption);
                    target.RowData.Add(parent);
                }
                else
                    parent = targetParent;
            }

            source.DetachItem(selectedItem);
            if (parent != null)
            {
                selectedItem.Parent = parent;
                parent.Children.Add(selectedItem);
            }
            else
                target.RowData.Add(selectedItem);

            source.Reload();
            target.Reload();

			ActiveModsListView.ApplyFilter(ActiveModListFilterTextBox.Text);
			ModsListView.ApplyFilter(InactiveModListFilterTextBox.Text);

			RefreshInterface();

			if (parent != null)
                target.Expand(parent);
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
            IEnumerable<ITreeListViewItem> selectedItems = e.SourceModels.OfType<ITreeListViewItem>();
            ITreeListViewItem targetItem = (ITreeListViewItem)e.TargetModel;

            if (targetItem?.Parent != null)
                targetCollection = targetItem.Parent.Children;

            sourceListView.DetachItems(selectedItems);
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
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Rightclicked background
            switch (e.Model)
            {
                case GroupViewModel _:
                    contextMenu.Items.Add(new ToolStripMenuItem("Rename group", null, Group_Context_Rename_Click));
                    contextMenu.Items.Add(new ToolStripMenuItem("Delete group", null, Group_Context_Delete_Click));
                    break;

                case ModViewModel _:
                    break;
            }

            if (contextMenu.Items.Count > 0)
                contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripMenuItem("New group", null, Context_CreateGroup_Click));
            contextMenu.Items.Add(new ToolStripMenuItem("Expand all", null, Group_Context_ExpandAll_Click));
            contextMenu.Items.Add(new ToolStripMenuItem("Collapse all", null, Group_Context_CollapseAll_Click));

            e.MenuStrip = contextMenu;
            e.MenuStrip.Tag = e.Model;
        }

        private void Group_Context_Delete_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = (sender as ToolStripItem).GetCurrentParent() as ContextMenuStrip;
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.SourceControl;

            List<ITreeListViewItem> collection = listView.RowData as List<ITreeListViewItem>;
            GroupViewModel group = contextMenu.Tag as GroupViewModel;

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

            listView.Reload();
        }

        private void Group_Context_Rename_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = (sender as ToolStripItem).GetCurrentParent() as ContextMenuStrip;
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.SourceControl;
            GroupViewModel selectedGroup = contextMenu.Tag as GroupViewModel;

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


        private void Group_Context_ExpandAll_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = (sender as ToolStripItem).GetCurrentParent() as ContextMenuStrip;
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.SourceControl;
            listView.ExpandAll();
        }

        private void Group_Context_CollapseAll_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = (sender as ToolStripItem).GetCurrentParent() as ContextMenuStrip;
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.SourceControl;
            listView.CollapseAll();
        }


        private void Context_CreateGroup_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = (sender as ToolStripItem).GetCurrentParent() as ContextMenuStrip;
            ReorderableTreeListView listView = (ReorderableTreeListView)contextMenu.SourceControl;
            ITreeListViewItem selectedItem = contextMenu.Tag as ITreeListViewItem;

            TextDialogPresenter presenter = new TextDialogPresenter("New group", String.Empty, "Group name:");
            using (TextDialog dialog = new TextDialog(presenter))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    GroupViewModel group = new GroupViewModel(presenter.Value);

                    if (selectedItem != null)
                    {
                        System.Collections.IList targetCollection = listView.RowData;
                        if (selectedItem.Parent != null)
                            targetCollection = selectedItem.Parent.Children;

                        targetCollection.Insert(targetCollection.IndexOf(selectedItem), group);
                    }
                    else
                    {
                        listView.RowData.Add(group);
                    }

                    IEnumerable<ITreeListViewItem> selectedItems = listView.SelectedObjects.OfType<ITreeListViewItem>();
                    if (selectedItems.Any())
                    {
                        listView.DetachItems(selectedItems);
                        MoveItemsToGroup(group, selectedItems);
                        listView.DeselectAll();
                    }

                    listView.Reload();
                    listView.Expand(group);
                }
            }


        }

		private void ListView_Filter(object sender, FilterEventArgs e)
		{
            ObjectListView list = sender as ObjectListView;

            var filter = list.ListFilter;
            var modelFilter = list.ModelFilter;

            List<ITreeListViewItem> result = new List<ITreeListViewItem>();
            foreach (ITreeListViewItem item in e.Objects)
            {
                if (modelFilter.Filter(item))
                {
                    result.Add(item);
                    if (item.Children != null)
                    {
                        result.AddRange(item.Children);
                    }
				}
            }

            e.FilteredObjects = result.Distinct().ToList();
            return;
		}
	}
}
