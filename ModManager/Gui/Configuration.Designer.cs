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
			this.RimworldConfigPathLabel = new System.Windows.Forms.Label();
			this.RimworldConfigPathTextBox = new System.Windows.Forms.TextBox();
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
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.PresenterBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 280);
			this.tableLayoutPanel1.TabIndex = 0;
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
			this.RimworldConfigPathTextBox.Size = new System.Drawing.Size(427, 20);
			this.RimworldConfigPathTextBox.TabIndex = 1;
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
			this.WorkshopPathTextBox.Size = new System.Drawing.Size(427, 20);
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
			this.LocalModPathTextBox.Size = new System.Drawing.Size(427, 20);
			this.LocalModPathTextBox.TabIndex = 1;
			// 
			// ConfigPathButton
			// 
			this.ConfigPathButton.Location = new System.Drawing.Point(558, 3);
			this.ConfigPathButton.Name = "ConfigPathButton";
			this.ConfigPathButton.Size = new System.Drawing.Size(75, 23);
			this.ConfigPathButton.TabIndex = 2;
			this.ConfigPathButton.Text = "Change";
			this.ConfigPathButton.UseVisualStyleBackColor = true;
			this.ConfigPathButton.Click += new System.EventHandler(this.ConfigPathButton_Click);
			// 
			// WorkshopPathButton
			// 
			this.WorkshopPathButton.Location = new System.Drawing.Point(558, 32);
			this.WorkshopPathButton.Name = "WorkshopPathButton";
			this.WorkshopPathButton.Size = new System.Drawing.Size(75, 23);
			this.WorkshopPathButton.TabIndex = 2;
			this.WorkshopPathButton.Text = "Change";
			this.WorkshopPathButton.UseVisualStyleBackColor = true;
			this.WorkshopPathButton.Click += new System.EventHandler(this.WorkshopPathButton_Click);
			// 
			// LocalModPathButton
			// 
			this.LocalModPathButton.Location = new System.Drawing.Point(558, 61);
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
			this.ExpansionPathTextBox.Size = new System.Drawing.Size(427, 20);
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
			this.ExpansionsPathButton.Location = new System.Drawing.Point(558, 90);
			this.ExpansionsPathButton.Name = "ExpansionsPathButton";
			this.ExpansionsPathButton.Size = new System.Drawing.Size(75, 23);
			this.ExpansionsPathButton.TabIndex = 2;
			this.ExpansionsPathButton.Text = "Change";
			this.ExpansionsPathButton.UseVisualStyleBackColor = true;
			this.ExpansionsPathButton.Click += new System.EventHandler(this.ExpansionsPathButton_Click);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(573, 298);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 1;
			this.FormCancelButton.Text = "Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(492, 298);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// PresenterBindingSource
			// 
			this.PresenterBindingSource.DataSource = typeof(ModManager.Logic.Configuration.ConfigurationPresenter);
			// 
			// Configuration
			// 
			this.AcceptButton = this.SaveButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(660, 333);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Configuration";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Mod manager configuration";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PresenterBindingSource)).EndInit();
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
	}
}