using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModManager.Logic.Configuration;
using ModManager.Logic.Main;
using ModManager.Logic.Model;
using ModManager.Properties;

namespace ModManager.Gui
{
    public partial class Main : Form
    {
        private readonly MainPresenter _presenter;

        public Main(MainPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.LoadComplete += Presenter_LoadComplete;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            _presenter.LoadData();
            PresenterBindingSource.DataSource = _presenter;
            this.Activate();
        }

        private void Presenter_LoadComplete(object sender, EventArgs e)
        {
            int activeMods = _presenter.Config.ActiveMods.Length;
            int availableMods = _presenter.AvailableMods.Count + activeMods;

            ListView.ListViewItemCollection activeModItems = new ListView.ListViewItemCollection(ActiveModsListView);
            ListView.ListViewItemCollection passiveModItems = new ListView.ListViewItemCollection(ModsListView);

            ModsListView.BeginUpdate();
            ActiveModsListView.BeginUpdate();
            ModsListView.Items.Clear();
            ActiveModsListView.Items.Clear();

            
            foreach (var mod in _presenter.ActiveMods)
            {
                activeModItems.Add(CreateItem(mod));
            }

            foreach (var mod in _presenter.AvailableMods.OrderByDescending(x => _presenter.AvailableMods[x.Key].Downloaded))
            {
                passiveModItems.Add(CreateItem(mod));
            }



            ActiveModsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ActiveModsListView.EndUpdate();

            ModsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ModsListView.EndUpdate();
            PresenterBindingSource.ResetBindings(false);
            
            RefreshInterface();
            SaveButton.Enabled = true;
        }

        private ListViewItem CreateItem(KeyValuePair<string, Logic.Model.ModMetaData> mod)
        {
            ListViewItem listItem;

            Logic.Model.ModMetaData modMeta = mod.Value;
            listItem = new ListViewItem(new string[] 
            {
                modMeta.Name,
                modMeta.Downloaded.ToString("yyyy/MM/dd hh:mm"),
                modMeta.SupportedVersions != null ? String.Join(", ", modMeta.SupportedVersions.Select(x => x.Trim())) : modMeta.TargetVersion,
            });


            listItem.Name = mod.Key;
            int minorIndex = _presenter.ActiveMods["ludeon.rimworld"].TargetVersion.LastIndexOf(".");
            string coreVersion = _presenter.ActiveMods["ludeon.rimworld"].TargetVersion.Substring(0, minorIndex);
            if (listItem.SubItems[2].Text.Contains(coreVersion) == false)
                listItem.BackColor = _presenter.IncompatibleColor;

            return listItem;
        }



        private void ModsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update mod meta section
            Components.ReorderableListView view = sender as Components.ReorderableListView;
            if (view.SelectedIndices.Count == 1)
            {
                string modKey = view.SelectedItems[0].Name;

                ModMetaData selectedMod;
                _presenter.ActiveMods.TryGetValue(modKey, out selectedMod);

                if (selectedMod == null)
                    _presenter.AvailableMods.TryGetValue(modKey, out selectedMod);


                if (selectedMod != null)
                {
                    menuStrip1.Enabled = true;

                    if (String.IsNullOrWhiteSpace(selectedMod.WorkshopPath))
                        openWorkshopPageToolStripMenuItem.Visible = false;
                    else
                        openWorkshopPageToolStripMenuItem.Visible = true;

                    _presenter.SelectedMod = selectedMod;


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
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _presenter.LoadData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ListViewItem[] issues = ActiveModsListView.Items.Cast<ListViewItem>().Where(x => x.BackColor != Color.Transparent).ToArray();
            if (issues.Length > 0)
            {
                int warnings = issues.Count(x => x.BackColor == _presenter.WarningColor);
                int incompatibles = issues.Count(x => x.BackColor == _presenter.IncompatibleColor);

                DialogResult result = MessageBox.Show($"There is currently {0} warnings and {1} incompatible mods.", "Save mods", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;
            }

            _presenter.Config.ActiveMods = ActiveModsListView.Items.Cast<ListViewItem>().Select(x => x.Name).ToArray();
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
            RefreshInterface();
        }

        private void RefreshInterface()
        {

            int availableMods = ModsListView.Items.Count;
            int outdatedMods = ModsListView.Items.Cast<ListViewItem>().Count(x => x.BackColor == _presenter.IncompatibleColor);

            AvailableModsFooterLabel.Text = $"{availableMods} inactive.";
            if (outdatedMods > 0)
                AvailableModsFooterLabel.Text += $" ({outdatedMods} incompatible)";

            availableMods = ActiveModsListView.Items.Count;
            outdatedMods = ActiveModsListView.Items.Cast<ListViewItem>().Count(x => x.BackColor == _presenter.IncompatibleColor);

            ActiveModsFooterLabel.Text = $"{availableMods} active.";
            if (outdatedMods > 0)
                ActiveModsFooterLabel.Text += $" ({outdatedMods} incompatible)";


            foreach (var item in ActiveModsListView.Items.Cast<ListViewItem>())
            {
                if (item.BackColor == _presenter.IncompatibleColor)
                {
                    item.ToolTipText = "Incompatible with current version.";
                    continue;
                }

                ModMetaData mod = _presenter.ActiveMods[item.Name];


                StringBuilder tooltip = new StringBuilder();

                if (mod.Dependencies != null)
                {
                    foreach (ModMetaData.ModDependancy dependancy in mod.Dependencies)
                    {
                        if (ActiveModsListView.Items.ContainsKey(dependancy.PackageId.ToLower()) == false)
                            tooltip.AppendLine("Missing dependancy: " + dependancy.Name);
                    }
                }

                int currentIndex = ActiveModsListView.Items.IndexOf(item);
                if (mod.LoadAfter != null)
                {
                    foreach (string loadAfter in mod.LoadAfter)
                    {
                        if (ActiveModsListView.Items.ContainsKey(loadAfter) && ActiveModsListView.Items.IndexOfKey(loadAfter) > currentIndex)
                        {
                            tooltip.AppendLine("This should be loaded after " + ActiveModsListView.Items[loadAfter].Text);
                        }
                    }
                }

                if (mod.LoadBefore != null)
                {
                    foreach (string loadBefore in mod.LoadBefore)
                    {
                        if (ActiveModsListView.Items.ContainsKey(loadBefore) && ActiveModsListView.Items.IndexOfKey(loadBefore) < currentIndex)
                        {
                            tooltip.AppendLine("This should be loaded before " + ActiveModsListView.Items[loadBefore].Text);
                        }
                    }
                }

                item.ToolTipText = tooltip.ToString();
                if (item.ToolTipText.Length > 0)
                    item.BackColor = _presenter.WarningColor;
                else
                    item.BackColor = Color.Transparent;
            }



        }

        private void ModsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Components.ReorderableListView listView = sender as Components.ReorderableListView;

            if (listView.ListViewItemSorter == null)
                listView.ListViewItemSorter = new Components.ListViewColumnSorter();

            Components.ListViewColumnSorter columnSorter = listView.ListViewItemSorter as Components.ListViewColumnSorter;

            if (e.Column == columnSorter.SortColumn)
            {
                // If column is already sorted, reverse.
                if (columnSorter.Order == SortOrder.Ascending)
                    columnSorter.Order = SortOrder.Descending;
                else
                    columnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Otherwise reset sorting
                columnSorter.SortColumn = e.Column;
                columnSorter.Order = SortOrder.Ascending;
            }

            listView.Sort();
        }

        private void ActiveModsListView_DoubleClick(object sender, EventArgs e)
        {
            if (ActiveModsListView.SelectedItems.Count > 1)
                return;

            // Move mod to disabled list
            ListViewItem selectedItem = ActiveModsListView.SelectedItems[0];
            ActiveModsListView.Items.Remove(selectedItem);
            ModsListView.Items.Add(selectedItem);
            RefreshInterface();
        }

        private void ModsListView_DoubleClick(object sender, EventArgs e)
        {
            if (ModsListView.SelectedItems.Count > 1)
                return;

            // Move mod to activated list
            ListViewItem selectedItem = ModsListView.SelectedItems[0];
            ModsListView.Items.Remove(selectedItem);
            ActiveModsListView.Items.Add(selectedItem);
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
    }
}
