namespace ModManager.Gui
{
	partial class Configuration
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
            this.RollingBackupsLabel = new System.Windows.Forms.Label();
            this.RimworldConfigPathLabel = new System.Windows.Forms.Label();
            this.RimworldConfigPathTextBox = new System.Windows.Forms.TextBox();
            this.PresenterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.WorkshopPathPathLabel = new System.Windows.Forms.Label();
            this.WorkshopPathTextBox = new System.Windows.Forms.TextBox();
            this.LocalModPathLabel = new System.Windows.Forms.Label();
            this.LocalModPathTextBox = new System.Windows.Forms.TextBox();
            this.ConfigPathButton = new System.Windows.Forms.Button();
            this.WorkshopPathButton = new System.Windows.Forms.Button();
            this.LocalModPathButton = new System.Windows.Forms.Button();
            this.ExpansionPathTextBox = new System.Windows.Forms.TextBox();
            this.ExpansionPathLabel = new System.Windows.Forms.Label();
            this.ExpansionsPathButton = new System.Windows.Forms.Button();
            this.RollingBackupsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FormCancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RollingBackupsNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.RimworldConfigPathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RimworldConfigPathTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WorkshopPathPathLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WorkshopPathTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LocalModPathLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LocalModPathTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ConfigPathButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.WorkshopPathButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LocalModPathButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExpansionPathTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ExpansionPathLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ExpansionsPathButton, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 116);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RollingBackupsLabel
            // 
            this.RollingBackupsLabel.AutoSize = true;
            this.RollingBackupsLabel.Location = new System.Drawing.Point(3, 5);
            this.RollingBackupsLabel.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.RollingBackupsLabel.Name = "RollingBackupsLabel";
            this.RollingBackupsLabel.Size = new System.Drawing.Size(86, 13);
            this.RollingBackupsLabel.TabIndex = 0;
            this.RollingBackupsLabel.Text = "Rolling backups:";
            // 
            // RimworldConfigPathLabel
            // 
            this.RimworldConfigPathLabel.AutoSize = true;
            this.RimworldConfigPathLabel.Location = new System.Drawing.Point(3, 5);
            this.RimworldConfigPathLabel.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.RimworldConfigPathLabel.Name = "RimworldConfigPathLabel";
            this.RimworldConfigPathLabel.Size = new System.Drawing.Size(114, 13);
            this.RimworldConfigPathLabel.TabIndex = 0;
            this.RimworldConfigPathLabel.Text = "Rimworld config folder:";
            // 
            // RimworldConfigPathTextBox
            // 
            this.RimworldConfigPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PresenterBindingSource, "ConfigPath", true));
            this.RimworldConfigPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RimworldConfigPathTextBox.Location = new System.Drawing.Point(125, 3);
            this.RimworldConfigPathTextBox.Name = "RimworldConfigPathTextBox";
            this.RimworldConfigPathTextBox.ReadOnly = true;
            this.RimworldConfigPathTextBox.Size = new System.Drawing.Size(407, 20);
            this.RimworldConfigPathTextBox.TabIndex = 1;
            // 
            // PresenterBindingSource
            // 
            this.PresenterBindingSource.DataSource = typeof(ModManager.Logic.Configuration.ConfigurationPresenter);
            // 
            // WorkshopPathPathLabel
            // 
            this.WorkshopPathPathLabel.AutoSize = true;
            this.WorkshopPathPathLabel.Location = new System.Drawing.Point(3, 34);
            this.WorkshopPathPathLabel.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.WorkshopPathPathLabel.Name = "WorkshopPathPathLabel";
            this.WorkshopPathPathLabel.Size = new System.Drawing.Size(111, 13);
            this.WorkshopPathPathLabel.TabIndex = 0;
            this.WorkshopPathPathLabel.Text = "Workshop mod folder:";
            // 
            // WorkshopPathTextBox
            // 
            this.WorkshopPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PresenterBindingSource, "WorkshopPath", true));
            this.WorkshopPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkshopPathTextBox.Location = new System.Drawing.Point(125, 32);
            this.WorkshopPathTextBox.Name = "WorkshopPathTextBox";
            this.WorkshopPathTextBox.ReadOnly = true;
            this.WorkshopPathTextBox.Size = new System.Drawing.Size(407, 20);
            this.WorkshopPathTextBox.TabIndex = 1;
            // 
            // LocalModPathLabel
            // 
            this.LocalModPathLabel.AutoSize = true;
            this.LocalModPathLabel.Location = new System.Drawing.Point(3, 63);
            this.LocalModPathLabel.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.LocalModPathLabel.Name = "LocalModPathLabel";
            this.LocalModPathLabel.Size = new System.Drawing.Size(88, 13);
            this.LocalModPathLabel.TabIndex = 0;
            this.LocalModPathLabel.Text = "Local mod folder:";
            // 
            // LocalModPathTextBox
            // 
            this.LocalModPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PresenterBindingSource, "LocalModPath", true));
            this.LocalModPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalModPathTextBox.Location = new System.Drawing.Point(125, 61);
            this.LocalModPathTextBox.Name = "LocalModPathTextBox";
            this.LocalModPathTextBox.ReadOnly = true;
            this.LocalModPathTextBox.Size = new System.Drawing.Size(407, 20);
            this.LocalModPathTextBox.TabIndex = 1;
            // 
            // ConfigPathButton
            // 
            this.ConfigPathButton.Location = new System.Drawing.Point(538, 3);
            this.ConfigPathButton.Name = "ConfigPathButton";
            this.ConfigPathButton.Size = new System.Drawing.Size(75, 23);
            this.ConfigPathButton.TabIndex = 2;
            this.ConfigPathButton.Text = "Change";
            this.ConfigPathButton.UseVisualStyleBackColor = true;
            this.ConfigPathButton.Click += new System.EventHandler(this.ConfigPathButton_Click);
            // 
            // WorkshopPathButton
            // 
            this.WorkshopPathButton.Location = new System.Drawing.Point(538, 32);
            this.WorkshopPathButton.Name = "WorkshopPathButton";
            this.WorkshopPathButton.Size = new System.Drawing.Size(75, 23);
            this.WorkshopPathButton.TabIndex = 2;
            this.WorkshopPathButton.Text = "Change";
            this.WorkshopPathButton.UseVisualStyleBackColor = true;
            this.WorkshopPathButton.Click += new System.EventHandler(this.WorkshopPathButton_Click);
            // 
            // LocalModPathButton
            // 
            this.LocalModPathButton.Location = new System.Drawing.Point(538, 61);
            this.LocalModPathButton.Name = "LocalModPathButton";
            this.LocalModPathButton.Size = new System.Drawing.Size(75, 23);
            this.LocalModPathButton.TabIndex = 2;
            this.LocalModPathButton.Text = "Change";
            this.LocalModPathButton.UseVisualStyleBackColor = true;
            this.LocalModPathButton.Click += new System.EventHandler(this.LocalModPathButton_Click);
            // 
            // ExpansionPathTextBox
            // 
            this.ExpansionPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PresenterBindingSource, "ExpansionsPath", true));
            this.ExpansionPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpansionPathTextBox.Location = new System.Drawing.Point(125, 90);
            this.ExpansionPathTextBox.Name = "ExpansionPathTextBox";
            this.ExpansionPathTextBox.ReadOnly = true;
            this.ExpansionPathTextBox.Size = new System.Drawing.Size(407, 20);
            this.ExpansionPathTextBox.TabIndex = 1;
            // 
            // ExpansionPathLabel
            // 
            this.ExpansionPathLabel.AutoSize = true;
            this.ExpansionPathLabel.Location = new System.Drawing.Point(3, 92);
            this.ExpansionPathLabel.Margin = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.ExpansionPathLabel.Name = "ExpansionPathLabel";
            this.ExpansionPathLabel.Size = new System.Drawing.Size(88, 13);
            this.ExpansionPathLabel.TabIndex = 0;
            this.ExpansionPathLabel.Text = "Expansion folder:";
            // 
            // ExpansionsPathButton
            // 
            this.ExpansionsPathButton.Location = new System.Drawing.Point(538, 90);
            this.ExpansionsPathButton.Name = "ExpansionsPathButton";
            this.ExpansionsPathButton.Size = new System.Drawing.Size(75, 23);
            this.ExpansionsPathButton.TabIndex = 2;
            this.ExpansionsPathButton.Text = "Change";
            this.ExpansionsPathButton.UseVisualStyleBackColor = true;
            this.ExpansionsPathButton.Click += new System.EventHandler(this.ExpansionsPathButton_Click);
            // 
            // RollingBackupsNumericUpDown
            // 
            this.RollingBackupsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.PresenterBindingSource, "RollingBackups", true));
            this.RollingBackupsNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.RollingBackupsNumericUpDown.Location = new System.Drawing.Point(97, 3);
            this.RollingBackupsNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RollingBackupsNumericUpDown.Name = "RollingBackupsNumericUpDown";
            this.RollingBackupsNumericUpDown.Size = new System.Drawing.Size(167, 20);
            this.RollingBackupsNumericUpDown.TabIndex = 3;
            // 
            // FormCancelButton
            // 
            this.FormCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.FormCancelButton.Location = new System.Drawing.Point(544, 3);
            this.FormCancelButton.Name = "FormCancelButton";
            this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
            this.FormCancelButton.TabIndex = 1;
            this.FormCancelButton.Text = "Cancel";
            this.FormCancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(463, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 135);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Directories";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.RollingBackupsLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RollingBackupsNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 116);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(628, 317);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.FormCancelButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 285);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(622, 29);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // Configuration
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FormCancelButton;
            this.ClientSize = new System.Drawing.Size(628, 317);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Configuration";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod manager configuration";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RollingBackupsNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button FormCancelButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Label RimworldConfigPathLabel;
		private System.Windows.Forms.TextBox RimworldConfigPathTextBox;
		private System.Windows.Forms.Label WorkshopPathPathLabel;
		private System.Windows.Forms.TextBox WorkshopPathTextBox;
		private System.Windows.Forms.Label LocalModPathLabel;
		private System.Windows.Forms.TextBox LocalModPathTextBox;
		private System.Windows.Forms.Button ConfigPathButton;
		private System.Windows.Forms.Button WorkshopPathButton;
		private System.Windows.Forms.Button LocalModPathButton;
		private System.Windows.Forms.TextBox ExpansionPathTextBox;
		private System.Windows.Forms.Label ExpansionPathLabel;
		private System.Windows.Forms.Button ExpansionsPathButton;
		private System.Windows.Forms.BindingSource PresenterBindingSource;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Label RollingBackupsLabel;
		private System.Windows.Forms.NumericUpDown RollingBackupsNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}