namespace ModManager.Gui
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ModNameLabel = new System.Windows.Forms.Label();
			this.ModBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.PresenterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.DescriptionWebBrowser = new System.Windows.Forms.WebBrowser();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.browseFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openWorkshopPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ReloadButton = new System.Windows.Forms.Button();
			this.ModPictureBox = new System.Windows.Forms.PictureBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.ModsListView = new ModManager.Gui.Components.ReorderableTreeListView();
			this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.InactiveDownloadedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.InactiveModListFilterTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.AvailableModsFooterLabel = new System.Windows.Forms.Label();
			this.ActiveModsListView = new ModManager.Gui.Components.ReorderableTreeListView();
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.ActiveModListFilterTextBox = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.ActiveModsFooterLabel = new System.Windows.Forms.Label();
			this.menuStrip3 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.expansionsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.workshopFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModsListView)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ActiveModsListView)).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			this.menuStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.ModNameLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.DescriptionWebBrowser, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.ModPictureBox, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.10186F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.89814F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 450);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// ModNameLabel
			// 
			this.ModNameLabel.AutoSize = true;
			this.ModNameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ModNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ModBindingSource, "Caption", true));
			this.ModNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModNameLabel.Location = new System.Drawing.Point(0, 0);
			this.ModNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.ModNameLabel.Name = "ModNameLabel";
			this.ModNameLabel.Padding = new System.Windows.Forms.Padding(5);
			this.ModNameLabel.Size = new System.Drawing.Size(459, 23);
			this.ModNameLabel.TabIndex = 0;
			this.ModNameLabel.Text = "Mod Name";
			this.ModNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ModBindingSource
			// 
			this.ModBindingSource.AllowNew = false;
			this.ModBindingSource.DataMember = "SelectedMod";
			this.ModBindingSource.DataSource = this.PresenterBindingSource;
			// 
			// PresenterBindingSource
			// 
			this.PresenterBindingSource.DataSource = typeof(ModManager.Logic.Main.MainPresenter);
			// 
			// DescriptionWebBrowser
			// 
			this.DescriptionWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionWebBrowser.Location = new System.Drawing.Point(3, 171);
			this.DescriptionWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.DescriptionWebBrowser.Name = "DescriptionWebBrowser";
			this.DescriptionWebBrowser.Size = new System.Drawing.Size(453, 240);
			this.DescriptionWebBrowser.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseFolderToolStripMenuItem,
            this.openWorkshopPageToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 144);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.ShowItemToolTips = true;
			this.menuStrip1.Size = new System.Drawing.Size(459, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// browseFolderToolStripMenuItem
			// 
			this.browseFolderToolStripMenuItem.Name = "browseFolderToolStripMenuItem";
			this.browseFolderToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.browseFolderToolStripMenuItem.Text = "Directory";
			this.browseFolderToolStripMenuItem.ToolTipText = "Browse local directory";
			this.browseFolderToolStripMenuItem.Click += new System.EventHandler(this.BrowseFolderToolStripMenuItem_Click);
			// 
			// openWorkshopPageToolStripMenuItem
			// 
			this.openWorkshopPageToolStripMenuItem.Name = "openWorkshopPageToolStripMenuItem";
			this.openWorkshopPageToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
			this.openWorkshopPageToolStripMenuItem.Text = "Steam workshop";
			this.openWorkshopPageToolStripMenuItem.ToolTipText = "Open workshop page";
			this.openWorkshopPageToolStripMenuItem.Click += new System.EventHandler(this.OpenWorkshopPageToolStripMenuItem_Click);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.Controls.Add(this.SaveButton);
			this.flowLayoutPanel2.Controls.Add(this.ReloadButton);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(331, 417);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(125, 30);
			this.flowLayoutPanel2.TabIndex = 3;
			// 
			// SaveButton
			// 
			this.SaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SaveButton.Enabled = false;
			this.SaveButton.Location = new System.Drawing.Point(3, 3);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(56, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ReloadButton
			// 
			this.ReloadButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ReloadButton.Location = new System.Drawing.Point(65, 3);
			this.ReloadButton.Name = "ReloadButton";
			this.ReloadButton.Size = new System.Drawing.Size(57, 23);
			this.ReloadButton.TabIndex = 0;
			this.ReloadButton.Text = "Reload";
			this.ReloadButton.UseVisualStyleBackColor = true;
			this.ReloadButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// ModPictureBox
			// 
			this.ModPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ModPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.PresenterBindingSource, "PreviewImage", true));
			this.ModPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModPictureBox.Location = new System.Drawing.Point(3, 26);
			this.ModPictureBox.Name = "ModPictureBox";
			this.ModPictureBox.Size = new System.Drawing.Size(453, 115);
			this.ModPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ModPictureBox.TabIndex = 4;
			this.ModPictureBox.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip3);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(1238, 450);
			this.splitContainer1.SplitterDistance = 775;
			this.splitContainer1.TabIndex = 2;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.splitContainer2, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(775, 426);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.ModsListView);
			this.splitContainer2.Panel1.Controls.Add(this.InactiveModListFilterTextBox);
			this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.ActiveModsListView);
			this.splitContainer2.Panel2.Controls.Add(this.ActiveModListFilterTextBox);
			this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel3);
			this.splitContainer2.Size = new System.Drawing.Size(769, 420);
			this.splitContainer2.SplitterDistance = 378;
			this.splitContainer2.TabIndex = 1;
			// 
			// ModsListView
			// 
			this.ModsListView.AllColumns.Add(this.olvColumn4);
			this.ModsListView.AllColumns.Add(this.InactiveDownloadedColumn);
			this.ModsListView.AllColumns.Add(this.olvColumn6);
			this.ModsListView.AllowDrop = true;
			this.ModsListView.AutoGenerateColumns = false;
			this.ModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn4,
            this.InactiveDownloadedColumn,
            this.olvColumn6});
			this.ModsListView.Cursor = System.Windows.Forms.Cursors.Default;
			this.ModsListView.DataSource = null;
			this.ModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModsListView.FullRowSelect = true;
			this.ModsListView.HideSelection = false;
			this.ModsListView.IsSimpleDragSource = true;
			this.ModsListView.IsSimpleDropSink = true;
			this.ModsListView.KeyAspectName = "";
			this.ModsListView.Location = new System.Drawing.Point(0, 20);
			this.ModsListView.Name = "ModsListView";
			this.ModsListView.RootKeyValueString = "";
			this.ModsListView.RowData = null;
			this.ModsListView.ShowCommandMenuOnRightClick = true;
			this.ModsListView.ShowFilterMenuOnRightClick = false;
			this.ModsListView.ShowGroups = false;
			this.ModsListView.Size = new System.Drawing.Size(378, 381);
			this.ModsListView.SuspendSorting = false;
			this.ModsListView.TabIndex = 4;
			this.ModsListView.UseCompatibleStateImageBehavior = false;
			this.ModsListView.View = System.Windows.Forms.View.Details;
			this.ModsListView.VirtualMode = true;
			this.ModsListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.ListView_CellRightClick);
			this.ModsListView.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.ModsListView_CellToolTipShowing);
			this.ModsListView.Filter += new System.EventHandler<BrightIdeasSoftware.FilterEventArgs>(this.ListView_Filter);
			this.ModsListView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ModsListView_FormatRow);
			this.ModsListView.ItemsAdding += new System.EventHandler<BrightIdeasSoftware.ItemsAddingEventArgs>(this.ModsListView_ItemsAdding);
			this.ModsListView.ItemsRemoving += new System.EventHandler<BrightIdeasSoftware.ItemsRemovingEventArgs>(this.ModsListView_ItemsRemoving);
			this.ModsListView.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.ListView_ModelDropped);
			this.ModsListView.SelectedIndexChanged += new System.EventHandler(this.ModsListView_SelectedIndexChanged);
			this.ModsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ModsListView_DoubleClick);
			// 
			// olvColumn4
			// 
			this.olvColumn4.AspectName = "Caption";
			this.olvColumn4.FillsFreeSpace = true;
			this.olvColumn4.Text = "Name";
			this.olvColumn4.Width = 226;
			// 
			// InactiveDownloadedColumn
			// 
			this.InactiveDownloadedColumn.AspectName = "Downloaded";
			this.InactiveDownloadedColumn.Text = "Downloaded";
			this.InactiveDownloadedColumn.Width = 73;
			// 
			// olvColumn6
			// 
			this.olvColumn6.AspectName = "SupportedVersions";
			this.olvColumn6.Text = "Supports";
			// 
			// InactiveModListFilterTextBox
			// 
			this.InactiveModListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.InactiveModListFilterTextBox.Location = new System.Drawing.Point(0, 0);
			this.InactiveModListFilterTextBox.Name = "InactiveModListFilterTextBox";
			this.InactiveModListFilterTextBox.Size = new System.Drawing.Size(378, 20);
			this.InactiveModListFilterTextBox.TabIndex = 4;
			this.InactiveModListFilterTextBox.TextChanged += new System.EventHandler(this.InactiveModListFilterTextBox_TextChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.AvailableModsFooterLabel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 401);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(378, 19);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// AvailableModsFooterLabel
			// 
			this.AvailableModsFooterLabel.AutoSize = true;
			this.AvailableModsFooterLabel.Location = new System.Drawing.Point(3, 3);
			this.AvailableModsFooterLabel.Margin = new System.Windows.Forms.Padding(3);
			this.AvailableModsFooterLabel.Name = "AvailableModsFooterLabel";
			this.AvailableModsFooterLabel.Size = new System.Drawing.Size(45, 13);
			this.AvailableModsFooterLabel.TabIndex = 0;
			this.AvailableModsFooterLabel.Text = "Loading";
			// 
			// ActiveModsListView
			// 
			this.ActiveModsListView.AllColumns.Add(this.olvColumn1);
			this.ActiveModsListView.AllColumns.Add(this.olvColumn2);
			this.ActiveModsListView.AllColumns.Add(this.olvColumn3);
			this.ActiveModsListView.AllowDrop = true;
			this.ActiveModsListView.AutoGenerateColumns = false;
			this.ActiveModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
			this.ActiveModsListView.Cursor = System.Windows.Forms.Cursors.Default;
			this.ActiveModsListView.DataSource = null;
			this.ActiveModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ActiveModsListView.FullRowSelect = true;
			this.ActiveModsListView.HideSelection = false;
			this.ActiveModsListView.IsSimpleDragSource = true;
			this.ActiveModsListView.IsSimpleDropSink = true;
			this.ActiveModsListView.KeyAspectName = "";
			this.ActiveModsListView.Location = new System.Drawing.Point(0, 20);
			this.ActiveModsListView.Name = "ActiveModsListView";
			this.ActiveModsListView.RootKeyValueString = "";
			this.ActiveModsListView.RowData = null;
			this.ActiveModsListView.ShowCommandMenuOnRightClick = true;
			this.ActiveModsListView.ShowFilterMenuOnRightClick = false;
			this.ActiveModsListView.ShowGroups = false;
			this.ActiveModsListView.Size = new System.Drawing.Size(387, 381);
			this.ActiveModsListView.SuspendSorting = false;
			this.ActiveModsListView.TabIndex = 3;
			this.ActiveModsListView.UseCompatibleStateImageBehavior = false;
			this.ActiveModsListView.UseFiltering = true;
			this.ActiveModsListView.View = System.Windows.Forms.View.Details;
			this.ActiveModsListView.VirtualMode = true;
			this.ActiveModsListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.ListView_CellRightClick);
			this.ActiveModsListView.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.ModsListView_CellToolTipShowing);
			this.ActiveModsListView.Filter += new System.EventHandler<BrightIdeasSoftware.FilterEventArgs>(this.ListView_Filter);
			this.ActiveModsListView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ModsListView_FormatRow);
			this.ActiveModsListView.ItemsAdding += new System.EventHandler<BrightIdeasSoftware.ItemsAddingEventArgs>(this.ActiveModsListView_ItemsAdding);
			this.ActiveModsListView.ItemsRemoving += new System.EventHandler<BrightIdeasSoftware.ItemsRemovingEventArgs>(this.ActiveModsListView_ItemsRemoving);
			this.ActiveModsListView.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.ListView_ModelDropped);
			this.ActiveModsListView.SelectedIndexChanged += new System.EventHandler(this.ModsListView_SelectedIndexChanged);
			this.ActiveModsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ActiveModsListView_DoubleClick);
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Caption";
			this.olvColumn1.FillsFreeSpace = true;
			this.olvColumn1.Text = "Name";
			this.olvColumn1.Width = 240;
			// 
			// olvColumn2
			// 
			this.olvColumn2.AspectName = "Downloaded";
			this.olvColumn2.Text = "Downloaded";
			this.olvColumn2.Width = 73;
			// 
			// olvColumn3
			// 
			this.olvColumn3.AspectName = "SupportedVersions";
			this.olvColumn3.Text = "Supports";
			// 
			// ActiveModListFilterTextBox
			// 
			this.ActiveModListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.ActiveModListFilterTextBox.Location = new System.Drawing.Point(0, 0);
			this.ActiveModListFilterTextBox.Name = "ActiveModListFilterTextBox";
			this.ActiveModListFilterTextBox.Size = new System.Drawing.Size(387, 20);
			this.ActiveModListFilterTextBox.TabIndex = 3;
			this.ActiveModListFilterTextBox.TextChanged += new System.EventHandler(this.ActiveModListFilterTextBox_TextChanged);
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add(this.ActiveModsFooterLabel);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 401);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(387, 19);
			this.flowLayoutPanel3.TabIndex = 2;
			// 
			// ActiveModsFooterLabel
			// 
			this.ActiveModsFooterLabel.AutoSize = true;
			this.ActiveModsFooterLabel.Location = new System.Drawing.Point(3, 3);
			this.ActiveModsFooterLabel.Margin = new System.Windows.Forms.Padding(3);
			this.ActiveModsFooterLabel.Name = "ActiveModsFooterLabel";
			this.ActiveModsFooterLabel.Size = new System.Drawing.Size(45, 13);
			this.ActiveModsFooterLabel.TabIndex = 0;
			this.ActiveModsFooterLabel.Text = "Loading";
			// 
			// menuStrip3
			// 
			this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.browseToolStripMenuItem});
			this.menuStrip3.Location = new System.Drawing.Point(0, 0);
			this.menuStrip3.Name = "menuStrip3";
			this.menuStrip3.Size = new System.Drawing.Size(775, 24);
			this.menuStrip3.TabIndex = 2;
			this.menuStrip3.Text = "menuStrip3";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationsToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.fileToolStripMenuItem.Text = "Edit";
			// 
			// configurationsToolStripMenuItem
			// 
			this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
			this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.configurationsToolStripMenuItem.Text = "Configurations";
			this.configurationsToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationsToolStripMenuItem_Click);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.importToolStripMenuItem.Text = "Import mod list";
			this.importToolStripMenuItem.ToolTipText = "Import active mods from either an exported list or a rimworld save";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.exportToolStripMenuItem.Text = "Export mod list";
			this.exportToolStripMenuItem.ToolTipText = "Export active mods as an importable mod list";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
			// 
			// browseToolStripMenuItem
			// 
			this.browseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configFolderToolStripMenuItem,
            this.expansionsFolderToolStripMenuItem,
            this.workshopFolderToolStripMenuItem,
            this.modsFolderToolStripMenuItem});
			this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
			this.browseToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.browseToolStripMenuItem.Text = "Browse";
			// 
			// configFolderToolStripMenuItem
			// 
			this.configFolderToolStripMenuItem.Name = "configFolderToolStripMenuItem";
			this.configFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.configFolderToolStripMenuItem.Text = "Config folder";
			this.configFolderToolStripMenuItem.Click += new System.EventHandler(this.ConfigFolderToolStripMenuItem_Click);
			// 
			// expansionsFolderToolStripMenuItem
			// 
			this.expansionsFolderToolStripMenuItem.Name = "expansionsFolderToolStripMenuItem";
			this.expansionsFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.expansionsFolderToolStripMenuItem.Text = "Expansions folder";
			this.expansionsFolderToolStripMenuItem.Click += new System.EventHandler(this.ExpansionsFolderToolStripMenuItem_Click);
			// 
			// workshopFolderToolStripMenuItem
			// 
			this.workshopFolderToolStripMenuItem.Name = "workshopFolderToolStripMenuItem";
			this.workshopFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.workshopFolderToolStripMenuItem.Text = "Workshop folder";
			this.workshopFolderToolStripMenuItem.Click += new System.EventHandler(this.WorkshopFolderToolStripMenuItem_Click);
			// 
			// modsFolderToolStripMenuItem
			// 
			this.modsFolderToolStripMenuItem.Name = "modsFolderToolStripMenuItem";
			this.modsFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.modsFolderToolStripMenuItem.Text = "Mods folder";
			this.modsFolderToolStripMenuItem.Click += new System.EventHandler(this.ModsFolderToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1238, 450);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.ShowIcon = false;
			this.Text = "Rimworld Mod Manager";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ModPictureBox)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ModsListView)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ActiveModsListView)).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.menuStrip3.ResumeLayout(false);
			this.menuStrip3.PerformLayout();
			this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ModNameLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label AvailableModsFooterLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.PictureBox ModPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem browseFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWorkshopPageToolStripMenuItem;
        private System.Windows.Forms.BindingSource PresenterBindingSource;
        private System.Windows.Forms.BindingSource ModBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label ActiveModsFooterLabel;
        private System.Windows.Forms.WebBrowser DescriptionWebBrowser;
		private System.Windows.Forms.MenuStrip menuStrip3;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expansionsFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem workshopFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modsFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn InactiveDownloadedColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private Components.ReorderableTreeListView ActiveModsListView;
        private Components.ReorderableTreeListView ModsListView;
        private System.Windows.Forms.TextBox ActiveModListFilterTextBox;
        private System.Windows.Forms.TextBox InactiveModListFilterTextBox;
    }
}