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
			this.ModsListView = new ModManager.Gui.Components.ReorderableListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.AvailableModsFooterLabel = new System.Windows.Forms.Label();
			this.ActiveModsListView = new ModManager.Gui.Components.ReorderableListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.flowLayoutPanel1.SuspendLayout();
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 450);
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
			this.ModNameLabel.Size = new System.Drawing.Size(450, 23);
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
			this.DescriptionWebBrowser.Size = new System.Drawing.Size(444, 240);
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
			this.menuStrip1.Size = new System.Drawing.Size(450, 24);
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
			this.flowLayoutPanel2.Location = new System.Drawing.Point(322, 417);
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
			this.ModPictureBox.Size = new System.Drawing.Size(444, 115);
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
			this.splitContainer1.Size = new System.Drawing.Size(1217, 450);
			this.splitContainer1.SplitterDistance = 763;
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
			this.tableLayoutPanel3.Size = new System.Drawing.Size(763, 426);
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
			this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.ActiveModsListView);
			this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel3);
			this.splitContainer2.Size = new System.Drawing.Size(757, 420);
			this.splitContainer2.SplitterDistance = 373;
			this.splitContainer2.TabIndex = 1;
			// 
			// ModsListView
			// 
			this.ModsListView.AllowDrop = true;
			this.ModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.ModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ModsListView.FullRowSelect = true;
			this.ModsListView.HideSelection = false;
			this.ModsListView.Location = new System.Drawing.Point(0, 0);
			this.ModsListView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.ModsListView.Name = "ModsListView";
			this.ModsListView.Size = new System.Drawing.Size(373, 401);
			this.ModsListView.TabIndex = 0;
			this.ModsListView.UseCompatibleStateImageBehavior = false;
			this.ModsListView.View = System.Windows.Forms.View.Details;
			this.ModsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ModsListView_ColumnClick);
			this.ModsListView.SelectedIndexChanged += new System.EventHandler(this.ModsListView_SelectedIndexChanged);
			this.ModsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ModsListView_DragDrop);
			this.ModsListView.DoubleClick += new System.EventHandler(this.ModsListView_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 240;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Downloaded";
			this.columnHeader2.Width = 73;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Supports";
			this.columnHeader3.Width = 54;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.AvailableModsFooterLabel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 401);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(373, 19);
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
			this.ActiveModsListView.AllowDrop = true;
			this.ActiveModsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.ActiveModsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ActiveModsListView.FullRowSelect = true;
			this.ActiveModsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ActiveModsListView.HideSelection = false;
			this.ActiveModsListView.Location = new System.Drawing.Point(0, 0);
			this.ActiveModsListView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.ActiveModsListView.Name = "ActiveModsListView";
			this.ActiveModsListView.ShowItemToolTips = true;
			this.ActiveModsListView.Size = new System.Drawing.Size(380, 401);
			this.ActiveModsListView.TabIndex = 1;
			this.ActiveModsListView.UseCompatibleStateImageBehavior = false;
			this.ActiveModsListView.View = System.Windows.Forms.View.Details;
			this.ActiveModsListView.SelectedIndexChanged += new System.EventHandler(this.ModsListView_SelectedIndexChanged);
			this.ActiveModsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ModsListView_DragDrop);
			this.ActiveModsListView.DoubleClick += new System.EventHandler(this.ActiveModsListView_DoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Name";
			this.columnHeader4.Width = 243;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Downloaded";
			this.columnHeader5.Width = 79;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Supports";
			this.columnHeader6.Width = 54;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add(this.ActiveModsFooterLabel);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 401);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(380, 19);
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
			this.menuStrip3.Size = new System.Drawing.Size(763, 24);
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
			this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.configurationsToolStripMenuItem.Text = "Configurations";
			this.configurationsToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationsToolStripMenuItem_Click);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.importToolStripMenuItem.Text = "Import mod list";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportToolStripMenuItem.Text = "Export mod list";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
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
			this.ClientSize = new System.Drawing.Size(1217, 450);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.ShowIcon = false;
			this.Text = "Rimworld mod manager";
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
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
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
        private Gui.Components.ReorderableListView ModsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
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
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Components.ReorderableListView ActiveModsListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
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
	}
}