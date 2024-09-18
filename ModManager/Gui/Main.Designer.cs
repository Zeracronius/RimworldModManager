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
			components = new System.ComponentModel.Container();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			ModNameLabel = new System.Windows.Forms.Label();
			ModBindingSource = new System.Windows.Forms.BindingSource(components);
			PresenterBindingSource = new System.Windows.Forms.BindingSource(components);
			DescriptionWebBrowser = new System.Windows.Forms.WebBrowser();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			browseFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openWorkshopPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			SaveButton = new System.Windows.Forms.Button();
			ReloadButton = new System.Windows.Forms.Button();
			ModPictureBox = new System.Windows.Forms.PictureBox();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			ModsListView = new Components.ReorderableTreeListView();
			olvColumn4 = new BrightIdeasSoftware.OLVColumn();
			InactiveDownloadedColumn = new BrightIdeasSoftware.OLVColumn();
			olvColumn6 = new BrightIdeasSoftware.OLVColumn();
			InactiveModListFilterTextBox = new System.Windows.Forms.TextBox();
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			AvailableModsFooterLabel = new System.Windows.Forms.Label();
			ActiveModsListView = new Components.ReorderableTreeListView();
			olvColumn1 = new BrightIdeasSoftware.OLVColumn();
			olvColumn2 = new BrightIdeasSoftware.OLVColumn();
			olvColumn3 = new BrightIdeasSoftware.OLVColumn();
			ActiveModListFilterTextBox = new System.Windows.Forms.TextBox();
			flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			ActiveModsFooterLabel = new System.Windows.Forms.Label();
			menuStrip3 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			configFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			expansionsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			workshopFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			modsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			AutoSortButton = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ModBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)PresenterBindingSource).BeginInit();
			menuStrip1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ModPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ModsListView).BeginInit();
			flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ActiveModsListView).BeginInit();
			flowLayoutPanel3.SuspendLayout();
			menuStrip3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(ModNameLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(DescriptionWebBrowser, 0, 3);
			tableLayoutPanel1.Controls.Add(menuStrip1, 0, 2);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 4);
			tableLayoutPanel1.Controls.Add(ModPictureBox, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.10186F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.89814F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(536, 519);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// ModNameLabel
			// 
			ModNameLabel.AutoSize = true;
			ModNameLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			ModNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", ModBindingSource, "Caption", true));
			ModNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			ModNameLabel.Location = new System.Drawing.Point(0, 0);
			ModNameLabel.Margin = new System.Windows.Forms.Padding(0);
			ModNameLabel.Name = "ModNameLabel";
			ModNameLabel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			ModNameLabel.Size = new System.Drawing.Size(536, 27);
			ModNameLabel.TabIndex = 0;
			ModNameLabel.Text = "Mod Name";
			ModNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ModBindingSource
			// 
			ModBindingSource.AllowNew = false;
			ModBindingSource.DataMember = "SelectedMod";
			ModBindingSource.DataSource = PresenterBindingSource;
			// 
			// PresenterBindingSource
			// 
			PresenterBindingSource.DataSource = typeof(Logic.Main.MainPresenter);
			// 
			// DescriptionWebBrowser
			// 
			DescriptionWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			DescriptionWebBrowser.Location = new System.Drawing.Point(4, 196);
			DescriptionWebBrowser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			DescriptionWebBrowser.MinimumSize = new System.Drawing.Size(23, 23);
			DescriptionWebBrowser.Name = "DescriptionWebBrowser";
			DescriptionWebBrowser.Size = new System.Drawing.Size(528, 280);
			DescriptionWebBrowser.TabIndex = 1;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { browseFolderToolStripMenuItem, openWorkshopPageToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 169);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip1.ShowItemToolTips = true;
			menuStrip1.Size = new System.Drawing.Size(536, 24);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// browseFolderToolStripMenuItem
			// 
			browseFolderToolStripMenuItem.Name = "browseFolderToolStripMenuItem";
			browseFolderToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			browseFolderToolStripMenuItem.Text = "Directory";
			browseFolderToolStripMenuItem.ToolTipText = "Browse local directory";
			browseFolderToolStripMenuItem.Click += BrowseFolderToolStripMenuItem_Click;
			// 
			// openWorkshopPageToolStripMenuItem
			// 
			openWorkshopPageToolStripMenuItem.Name = "openWorkshopPageToolStripMenuItem";
			openWorkshopPageToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
			openWorkshopPageToolStripMenuItem.Text = "Steam workshop";
			openWorkshopPageToolStripMenuItem.ToolTipText = "Open workshop page";
			openWorkshopPageToolStripMenuItem.Click += OpenWorkshopPageToolStripMenuItem_Click;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.Controls.Add(AutoSortButton);
			flowLayoutPanel2.Controls.Add(SaveButton);
			flowLayoutPanel2.Controls.Add(ReloadButton);
			flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
			flowLayoutPanel2.Location = new System.Drawing.Point(302, 482);
			flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new System.Drawing.Size(230, 34);
			flowLayoutPanel2.TabIndex = 3;
			// 
			// SaveButton
			// 
			SaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			SaveButton.Enabled = false;
			SaveButton.Location = new System.Drawing.Point(87, 3);
			SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new System.Drawing.Size(65, 27);
			SaveButton.TabIndex = 0;
			SaveButton.Text = "Save";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// ReloadButton
			// 
			ReloadButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			ReloadButton.Location = new System.Drawing.Point(160, 3);
			ReloadButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ReloadButton.Name = "ReloadButton";
			ReloadButton.Size = new System.Drawing.Size(66, 27);
			ReloadButton.TabIndex = 0;
			ReloadButton.Text = "Reload";
			ReloadButton.UseVisualStyleBackColor = true;
			ReloadButton.Click += RefreshButton_Click;
			// 
			// ModPictureBox
			// 
			ModPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			ModPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", PresenterBindingSource, "PreviewImage", true));
			ModPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			ModPictureBox.Location = new System.Drawing.Point(4, 30);
			ModPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ModPictureBox.Name = "ModPictureBox";
			ModPictureBox.Size = new System.Drawing.Size(528, 136);
			ModPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			ModPictureBox.TabIndex = 4;
			ModPictureBox.TabStop = false;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(tableLayoutPanel3);
			splitContainer1.Panel1.Controls.Add(menuStrip3);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
			splitContainer1.Size = new System.Drawing.Size(1444, 519);
			splitContainer1.SplitterDistance = 903;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 2;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(splitContainer2, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(0, 24);
			tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel3.Size = new System.Drawing.Size(903, 495);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer2.Location = new System.Drawing.Point(4, 3);
			splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(ModsListView);
			splitContainer2.Panel1.Controls.Add(InactiveModListFilterTextBox);
			splitContainer2.Panel1.Controls.Add(flowLayoutPanel1);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(ActiveModsListView);
			splitContainer2.Panel2.Controls.Add(ActiveModListFilterTextBox);
			splitContainer2.Panel2.Controls.Add(flowLayoutPanel3);
			splitContainer2.Size = new System.Drawing.Size(895, 489);
			splitContainer2.SplitterDistance = 439;
			splitContainer2.SplitterWidth = 5;
			splitContainer2.TabIndex = 1;
			// 
			// ModsListView
			// 
			ModsListView.AllColumns.Add(olvColumn4);
			ModsListView.AllColumns.Add(InactiveDownloadedColumn);
			ModsListView.AllColumns.Add(olvColumn6);
			ModsListView.AllowDrop = true;
			ModsListView.AutoGenerateColumns = false;
			ModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { olvColumn4, InactiveDownloadedColumn, olvColumn6 });
			ModsListView.DataSource = null;
			ModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			ModsListView.FilteredRowData = null;
			ModsListView.FullRowSelect = true;
			ModsListView.IsSimpleDragSource = true;
			ModsListView.IsSimpleDropSink = true;
			ModsListView.KeyAspectName = "";
			ModsListView.Location = new System.Drawing.Point(0, 23);
			ModsListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ModsListView.Name = "ModsListView";
			ModsListView.RootKeyValueString = "";
			ModsListView.RowData = null;
			ModsListView.ShowCommandMenuOnRightClick = true;
			ModsListView.ShowFilterMenuOnRightClick = false;
			ModsListView.ShowGroups = false;
			ModsListView.Size = new System.Drawing.Size(439, 445);
			ModsListView.SuspendSorting = false;
			ModsListView.TabIndex = 4;
			ModsListView.UseCompatibleStateImageBehavior = false;
			ModsListView.View = System.Windows.Forms.View.Details;
			ModsListView.VirtualMode = true;
			ModsListView.CellRightClick += ListView_CellRightClick;
			ModsListView.CellToolTipShowing += ModsListView_CellToolTipShowing;
			ModsListView.Filter += ListView_Filter;
			ModsListView.FormatRow += ModsListView_FormatRow;
			ModsListView.ItemsAdding += ModsListView_ItemsAdding;
			ModsListView.ItemsRemoving += ModsListView_ItemsRemoving;
			ModsListView.ModelDropped += ListView_ModelDropped;
			ModsListView.SelectedIndexChanged += ModsListView_SelectedIndexChanged;
			ModsListView.MouseDoubleClick += ModsListView_DoubleClick;
			// 
			// olvColumn4
			// 
			olvColumn4.AspectName = "Caption";
			olvColumn4.FillsFreeSpace = true;
			olvColumn4.Text = "Name";
			olvColumn4.Width = 226;
			// 
			// InactiveDownloadedColumn
			// 
			InactiveDownloadedColumn.AspectName = "Downloaded";
			InactiveDownloadedColumn.Text = "Downloaded";
			InactiveDownloadedColumn.Width = 73;
			// 
			// olvColumn6
			// 
			olvColumn6.AspectName = "SupportedVersions";
			olvColumn6.Text = "Supports";
			// 
			// InactiveModListFilterTextBox
			// 
			InactiveModListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			InactiveModListFilterTextBox.Location = new System.Drawing.Point(0, 0);
			InactiveModListFilterTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			InactiveModListFilterTextBox.Name = "InactiveModListFilterTextBox";
			InactiveModListFilterTextBox.Size = new System.Drawing.Size(439, 23);
			InactiveModListFilterTextBox.TabIndex = 4;
			InactiveModListFilterTextBox.TextChanged += InactiveModListFilterTextBox_TextChanged;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.Controls.Add(AvailableModsFooterLabel);
			flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			flowLayoutPanel1.Location = new System.Drawing.Point(0, 468);
			flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new System.Drawing.Size(439, 21);
			flowLayoutPanel1.TabIndex = 1;
			// 
			// AvailableModsFooterLabel
			// 
			AvailableModsFooterLabel.AutoSize = true;
			AvailableModsFooterLabel.Location = new System.Drawing.Point(4, 3);
			AvailableModsFooterLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			AvailableModsFooterLabel.Name = "AvailableModsFooterLabel";
			AvailableModsFooterLabel.Size = new System.Drawing.Size(50, 15);
			AvailableModsFooterLabel.TabIndex = 0;
			AvailableModsFooterLabel.Text = "Loading";
			// 
			// ActiveModsListView
			// 
			ActiveModsListView.AllColumns.Add(olvColumn1);
			ActiveModsListView.AllColumns.Add(olvColumn2);
			ActiveModsListView.AllColumns.Add(olvColumn3);
			ActiveModsListView.AllowDrop = true;
			ActiveModsListView.AutoGenerateColumns = false;
			ActiveModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { olvColumn1, olvColumn2, olvColumn3 });
			ActiveModsListView.DataSource = null;
			ActiveModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			ActiveModsListView.FilteredRowData = null;
			ActiveModsListView.FullRowSelect = true;
			ActiveModsListView.IsSimpleDragSource = true;
			ActiveModsListView.IsSimpleDropSink = true;
			ActiveModsListView.KeyAspectName = "";
			ActiveModsListView.Location = new System.Drawing.Point(0, 23);
			ActiveModsListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ActiveModsListView.Name = "ActiveModsListView";
			ActiveModsListView.RootKeyValueString = "";
			ActiveModsListView.RowData = null;
			ActiveModsListView.ShowCommandMenuOnRightClick = true;
			ActiveModsListView.ShowFilterMenuOnRightClick = false;
			ActiveModsListView.ShowGroups = false;
			ActiveModsListView.Size = new System.Drawing.Size(451, 445);
			ActiveModsListView.SuspendSorting = false;
			ActiveModsListView.TabIndex = 3;
			ActiveModsListView.UseCompatibleStateImageBehavior = false;
			ActiveModsListView.View = System.Windows.Forms.View.Details;
			ActiveModsListView.VirtualMode = true;
			ActiveModsListView.CellRightClick += ListView_CellRightClick;
			ActiveModsListView.CellToolTipShowing += ModsListView_CellToolTipShowing;
			ActiveModsListView.Filter += ListView_Filter;
			ActiveModsListView.FormatRow += ModsListView_FormatRow;
			ActiveModsListView.ItemsAdding += ActiveModsListView_ItemsAdding;
			ActiveModsListView.ItemsRemoving += ActiveModsListView_ItemsRemoving;
			ActiveModsListView.ModelDropped += ListView_ModelDropped;
			ActiveModsListView.SelectedIndexChanged += ModsListView_SelectedIndexChanged;
			ActiveModsListView.MouseDoubleClick += ActiveModsListView_DoubleClick;
			// 
			// olvColumn1
			// 
			olvColumn1.AspectName = "Caption";
			olvColumn1.FillsFreeSpace = true;
			olvColumn1.Text = "Name";
			olvColumn1.Width = 240;
			// 
			// olvColumn2
			// 
			olvColumn2.AspectName = "Downloaded";
			olvColumn2.Text = "Downloaded";
			olvColumn2.Width = 73;
			// 
			// olvColumn3
			// 
			olvColumn3.AspectName = "SupportedVersions";
			olvColumn3.Text = "Supports";
			// 
			// ActiveModListFilterTextBox
			// 
			ActiveModListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			ActiveModListFilterTextBox.Location = new System.Drawing.Point(0, 0);
			ActiveModListFilterTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ActiveModListFilterTextBox.Name = "ActiveModListFilterTextBox";
			ActiveModListFilterTextBox.Size = new System.Drawing.Size(451, 23);
			ActiveModListFilterTextBox.TabIndex = 3;
			ActiveModListFilterTextBox.TextChanged += ActiveModListFilterTextBox_TextChanged;
			// 
			// flowLayoutPanel3
			// 
			flowLayoutPanel3.AutoSize = true;
			flowLayoutPanel3.Controls.Add(ActiveModsFooterLabel);
			flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			flowLayoutPanel3.Location = new System.Drawing.Point(0, 468);
			flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			flowLayoutPanel3.Name = "flowLayoutPanel3";
			flowLayoutPanel3.Size = new System.Drawing.Size(451, 21);
			flowLayoutPanel3.TabIndex = 2;
			// 
			// ActiveModsFooterLabel
			// 
			ActiveModsFooterLabel.AutoSize = true;
			ActiveModsFooterLabel.Location = new System.Drawing.Point(4, 3);
			ActiveModsFooterLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ActiveModsFooterLabel.Name = "ActiveModsFooterLabel";
			ActiveModsFooterLabel.Size = new System.Drawing.Size(50, 15);
			ActiveModsFooterLabel.TabIndex = 0;
			ActiveModsFooterLabel.Text = "Loading";
			// 
			// menuStrip3
			// 
			menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, browseToolStripMenuItem });
			menuStrip3.Location = new System.Drawing.Point(0, 0);
			menuStrip3.Name = "menuStrip3";
			menuStrip3.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip3.Size = new System.Drawing.Size(903, 24);
			menuStrip3.TabIndex = 2;
			menuStrip3.Text = "menuStrip3";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { configurationsToolStripMenuItem, importToolStripMenuItem, exportToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			fileToolStripMenuItem.Text = "Edit";
			// 
			// configurationsToolStripMenuItem
			// 
			configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
			configurationsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			configurationsToolStripMenuItem.Text = "Configurations";
			configurationsToolStripMenuItem.Click += ConfigurationsToolStripMenuItem_Click;
			// 
			// importToolStripMenuItem
			// 
			importToolStripMenuItem.Name = "importToolStripMenuItem";
			importToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			importToolStripMenuItem.Text = "Import mod list";
			importToolStripMenuItem.ToolTipText = "Import active mods from either an exported list or a rimworld save";
			importToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
			// 
			// exportToolStripMenuItem
			// 
			exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			exportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			exportToolStripMenuItem.Text = "Export mod list";
			exportToolStripMenuItem.ToolTipText = "Export active mods as an importable mod list";
			exportToolStripMenuItem.Click += ExportToolStripMenuItem_Click;
			// 
			// browseToolStripMenuItem
			// 
			browseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { configFolderToolStripMenuItem, expansionsFolderToolStripMenuItem, workshopFolderToolStripMenuItem, modsFolderToolStripMenuItem });
			browseToolStripMenuItem.Name = "browseToolStripMenuItem";
			browseToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			browseToolStripMenuItem.Text = "Browse";
			// 
			// configFolderToolStripMenuItem
			// 
			configFolderToolStripMenuItem.Name = "configFolderToolStripMenuItem";
			configFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			configFolderToolStripMenuItem.Text = "Config folder";
			configFolderToolStripMenuItem.Click += ConfigFolderToolStripMenuItem_Click;
			// 
			// expansionsFolderToolStripMenuItem
			// 
			expansionsFolderToolStripMenuItem.Name = "expansionsFolderToolStripMenuItem";
			expansionsFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			expansionsFolderToolStripMenuItem.Text = "Expansions folder";
			expansionsFolderToolStripMenuItem.Click += ExpansionsFolderToolStripMenuItem_Click;
			// 
			// workshopFolderToolStripMenuItem
			// 
			workshopFolderToolStripMenuItem.Name = "workshopFolderToolStripMenuItem";
			workshopFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			workshopFolderToolStripMenuItem.Text = "Workshop folder";
			workshopFolderToolStripMenuItem.Click += WorkshopFolderToolStripMenuItem_Click;
			// 
			// modsFolderToolStripMenuItem
			// 
			modsFolderToolStripMenuItem.Name = "modsFolderToolStripMenuItem";
			modsFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			modsFolderToolStripMenuItem.Text = "Mods folder";
			modsFolderToolStripMenuItem.Click += ModsFolderToolStripMenuItem_Click;
			// 
			// AutoSortButton
			// 
			AutoSortButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			AutoSortButton.Location = new System.Drawing.Point(4, 3);
			AutoSortButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			AutoSortButton.Name = "AutoSortButton";
			AutoSortButton.Size = new System.Drawing.Size(75, 27);
			AutoSortButton.TabIndex = 1;
			AutoSortButton.Text = "Autosort";
			AutoSortButton.UseVisualStyleBackColor = true;
			AutoSortButton.Click += AutoSortButton_Click;
			// 
			// Main
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1444, 519);
			Controls.Add(splitContainer1);
			MainMenuStrip = menuStrip1;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "Main";
			ShowIcon = false;
			Text = "Rimworld Mod Manager";
			Load += Main_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ModBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)PresenterBindingSource).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ModPictureBox).EndInit();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ModsListView).EndInit();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ActiveModsListView).EndInit();
			flowLayoutPanel3.ResumeLayout(false);
			flowLayoutPanel3.PerformLayout();
			menuStrip3.ResumeLayout(false);
			menuStrip3.PerformLayout();
			ResumeLayout(false);
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
		private System.Windows.Forms.Button AutoSortButton;
	}
}