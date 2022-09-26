using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
using ModManager.Properties;

namespace ModManager.Gui
{
    public partial class Main : Form
    {
        private readonly MainPresenter _presenter;

        List<ModViewModel> _activeModItems = new List<ModViewModel>();
        List<ModViewModel> _passiveModItems = new List<ModViewModel>();

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
            sink1.CanDropOnItem = false;

            sink1 = (SimpleDropSink)ModsListView.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            sink1.CanDropOnBackground = true;
            sink1.CanDropOnItem = false;



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


            ModsListView.BeginUpdate();
            ActiveModsListView.BeginUpdate();
            _activeModItems.Clear();
            _passiveModItems.Clear();

            
            foreach (var mod in _presenter.ActiveMods)
            {
                _activeModItems.Add(mod.Value);
            }

            foreach (var mod in _presenter.AvailableMods.OrderByDescending(x => _presenter.AvailableMods[x.Key].Downloaded))
            {
                _passiveModItems.Add(mod.Value);
            }

            ActiveModsListView.Roots = _activeModItems;
            ModsListView.Roots = _passiveModItems;

            ActiveModsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ActiveModsListView.EndUpdate();

            ModsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ModsListView.EndUpdate();
            PresenterBindingSource.ResetBindings(false);
            
            RefreshInterface();
            SaveButton.Enabled = true;
        }

        private void ModsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update mod meta section
            Components.ReorderableTreeListView view = sender as Components.ReorderableTreeListView;
            if (view.SelectedIndices.Count == 1)
            {
                string modKey = ((ModViewModel)view.SelectedObject).PackageId;

                ModViewModel selectedMod;
                _presenter.ActiveMods.TryGetValue(modKey, out selectedMod);

                if (selectedMod == null)
                    _presenter.AvailableMods.TryGetValue(modKey, out selectedMod);


                if (selectedMod != null)
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
            ModViewModel[] issues = _activeModItems.Where(x => x.Background != Color.Transparent).ToArray();
            if (issues.Length > 0)
            {
                int warnings = issues.Count(x => x.Background == _presenter.WarningColor);
                int incompatibles = issues.Count(x => x.Background == _presenter.IncompatibleColor);

                DialogResult result = MessageBox.Show($"There is currently {warnings} warnings and {incompatibles} incompatible mods.", "Save mods", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;
            }

            _presenter.Config.ActiveMods = _activeModItems.Select(x => x.PackageId).ToArray();
            _presenter.SaveConfig();
            _presenter.LoadData();
        }

        private void BrowseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.BrowseFolder();
        }

        private void OpenWorkshopPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.OpenWorkshopPage();
        }

        private void ModsListView_DragDrop(object sender, DragEventArgs e)
        {
            //RefreshInterface();
        }

        private void RefreshInterface()
        {
            ActiveModsListView.BuildList(true);
            ModsListView.BuildList(true);

            int availableMods = _passiveModItems.Count;
            int outdatedMods = _passiveModItems.Count(x => x.Background == _presenter.IncompatibleColor);

            AvailableModsFooterLabel.Text = $"{availableMods} inactive.";
            if (outdatedMods > 0)
                AvailableModsFooterLabel.Text += $" ({outdatedMods} incompatible)";

            availableMods = _activeModItems.Count;
            outdatedMods = _activeModItems.Cast<ModViewModel>().Count(x => x.Background == _presenter.IncompatibleColor);

            ActiveModsFooterLabel.Text = $"{availableMods} active.";
            if (outdatedMods > 0)
                ActiveModsFooterLabel.Text += $" ({outdatedMods} incompatible)";


            foreach (var item in _activeModItems)
            {
                if (item.Background == _presenter.IncompatibleColor)
                    continue; 


                ModViewModel mod;
                _presenter.ActiveMods.TryGetValue(item.PackageId, out mod);

                if (mod == null)
                    _presenter.AvailableMods.TryGetValue(item.PackageId, out mod);

                StringBuilder tooltip = new StringBuilder();

                if (mod.Dependencies != null)
                {
                    foreach (KeyValuePair<string, string> dependancy in mod.Dependencies)
                    {
                        ModViewModel referencedMod = _activeModItems.FirstOrDefault(x => x.PackageId == dependancy.Key);
                        if (referencedMod != null)
                            tooltip.AppendLine("Missing dependancy: " + dependancy.Value);
                    }
                }

                int currentIndex = _activeModItems.IndexOf(item);
                if (mod.LoadAfter != null)
                {
                    foreach (string loadAfter in mod.LoadAfter)
                    {
                        ModViewModel referencedMod = _activeModItems.FirstOrDefault(x => x.PackageId == loadAfter);
                        if (referencedMod != null && _activeModItems.IndexOf(referencedMod) > currentIndex)
                        {
                            tooltip.AppendLine("This should be loaded after " + referencedMod.Caption);
                        }
                    }
                }

                if (mod.LoadBefore != null)
                {
                    foreach (string loadBefore in mod.LoadBefore)
                    {
                        ModViewModel referencedMod = _activeModItems.FirstOrDefault(x => x.PackageId == loadBefore);
                        if (referencedMod != null && _activeModItems.IndexOf(referencedMod) < currentIndex)
                        {
                            tooltip.AppendLine("This should be loaded before " + referencedMod.Caption);
                        }
                    }
                }

                item.Tooltip = tooltip.ToString();
                if (item.Tooltip.Length > 0)
                    item.Background = _presenter.WarningColor;
                else
                    item.Background = Color.Transparent;
            }
        }

        //private void ModsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    Components.ReorderableListView listView = sender as Components.ReorderableListView;

        //    if (listView.ModViewModelSorter == null)
        //        listView.ModViewModelSorter = new Components.ListViewColumnSorter();

        //    Components.ListViewColumnSorter columnSorter = listView.ModViewModelSorter as Components.ListViewColumnSorter;

        //    if (e.Column == columnSorter.SortColumn)
        //    {
        //        // If column is already sorted, reverse.
        //        if (columnSorter.Order == SortOrder.Ascending)
        //            columnSorter.Order = SortOrder.Descending;
        //        else
        //            columnSorter.Order = SortOrder.Ascending;
        //    }
        //    else
        //    {
        //        // Otherwise reset sorting
        //        columnSorter.SortColumn = e.Column;
        //        columnSorter.Order = SortOrder.Ascending;
        //    }

        //    listView.Sort();
        //}

        private void ActiveModsListView_DoubleClick(object sender, EventArgs e)
        {
            if (ActiveModsListView.SelectedObjects.Count > 1)
                return;

            // Move mod to disabled list
            ModViewModel selectedItem = (ModViewModel)ActiveModsListView.SelectedObject;
            ActiveModsListView.RemoveObject(selectedItem);
            ModsListView.AddObject(selectedItem);
            RefreshInterface();
        }

        private void ModsListView_DoubleClick(object sender, EventArgs e)
        {
            if (ModsListView.SelectedObjects.Count > 1)
                return;

            // Move mod to activated list
            ModViewModel selectedItem = (ModViewModel)ModsListView.SelectedObject;
            ModsListView.RemoveObject(selectedItem);
            ActiveModsListView.AddObject(selectedItem);
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

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.AddExtension = true;
                dialog.Filter = "mod list (*.modlist)|*.modlist";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    _presenter.ExportModlist(dialog.FileName);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
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

            _activeModItems.InsertRange(e.Index, e.ObjectsToAdd.OfType<ModViewModel>());
        }

        private void ActiveModsListView_ItemsRemoving(object sender, ItemsRemovingEventArgs e)
        {
            if (e.Canceled)
                return;

            foreach (var item in e.ObjectsToRemove.OfType<ModViewModel>())
                _activeModItems.Remove(item);
        }

        private void ModsListView_ItemsRemoving(object sender, ItemsRemovingEventArgs e)
        {
            if (e.Canceled)
                return;

            foreach (var item in e.ObjectsToRemove.OfType<ModViewModel>())
                _passiveModItems.Remove(item);
        }

        private void ModsListView_ItemsAdding(object sender, ItemsAddingEventArgs e)
        {
            if (e.Canceled)
                return;

            _passiveModItems.InsertRange(e.Index, e.ObjectsToAdd.OfType<ModViewModel>());
        }

        private void ListView_ModelDropped(object sender, ModelDropEventArgs e)
        {
            List<ModViewModel> targetCollection = e.ListView == ActiveModsListView ? _activeModItems : _passiveModItems;
            List<ModViewModel> sourceCollection = e.SourceListView == ActiveModsListView ? _activeModItems : _passiveModItems;
            IEnumerable<ModViewModel> selectedItems = e.SourceModels.OfType<ModViewModel>();
            ModViewModel targetItem = (ModViewModel)e.TargetModel;



            // Detach
            foreach (ModViewModel x in selectedItems)
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
                    MoveItemsToGroup(targetCollection, targetItem, selectedItems);
                    break;

                // Move items to index
                case DropTargetLocation.AboveItem:
                    MoveObjectsAboveItem(targetCollection, targetItem, selectedItems);
                    break;
            }

            e.SourceListView.DeselectAll();

            ActiveModsListView.Roots = _activeModItems;
            ModsListView.Roots = _passiveModItems;

            RefreshInterface();
        }


        private void MoveItemsToGroup(List<ModViewModel> targetCollection, ModViewModel target, IEnumerable<ModViewModel> selectedItems)
        {
            // Grouping logic here.
            target.Children.AddRange(selectedItems);
        }

        private void MoveObjectsToRoots(List<ModViewModel> targetCollection, IEnumerable<ModViewModel> selectedItems)
        {
            targetCollection.AddRange(selectedItems);
        }

        private void MoveObjectsAboveItem(List<ModViewModel> targetCollection, ModViewModel target, IEnumerable<ModViewModel> selectedItems)
        {
            if (target.Parent != null)
            {
                int index = target.Parent.Children.IndexOf(target);
                target.Parent.Children.InsertRange(index, selectedItems);

            }
            else
            {
                int index = targetCollection.IndexOf(target);
                targetCollection.InsertRange(index, selectedItems);
            }
        }

        private void ActiveModListFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(ActiveModsListView, ActiveModListFilterTextBox.Text);
        }

        private void InactiveModListFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(ModsListView, InactiveModListFilterTextBox.Text);
        }

        private void ApplyFilter(ReorderableTreeListView listView, string filterText)
        {
            if (String.IsNullOrWhiteSpace(filterText))
            {
                listView.ResetColumnFiltering();
                listView.RebuildColumns();
                return;
            }

            filterText = filterText.ToLower();
            if (listView.ModelFilter == null)
            {
                TextMatchFilter filter = TextMatchFilter.Contains(listView, filterText);
                listView.ModelFilter = filter;
                listView.DefaultRenderer = new HighlightTextRenderer(filter);
            }
            else
            {
                (listView.ModelFilter as TextMatchFilter).ContainsStrings = new string[] { filterText };
            }

            listView.UseFiltering = false;
            listView.UseFiltering = true;
        }
        
    }
}
