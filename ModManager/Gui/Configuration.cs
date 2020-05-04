using ModManager.Gui.Components;
using ModManager.Logic.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Gui
{
	public partial class Configuration : Form
	{
		private readonly ConfigurationPresenter _presenter;

		public Configuration(ConfigurationPresenter presenter)
		{
			InitializeComponent();
			_presenter = presenter;
			PresenterBindingSource.DataSource = presenter;

			tooltip.SetToolTip(RimworldConfigPathLabel, @"Path to rimworld's expansions folder. (Typically 'steamapps\common\RimWorld\Data').");
			tooltip.SetToolTip(ExpansionPathLabel, @"Path to rimworld's configuration folder. (Typically 'C:\Users\[user]\AppData\LocalLow\Ludeon Studios\RimWorld by Ludeon Studios\Config').");
			tooltip.SetToolTip(WorkshopPathPathLabel, @"Path to rimworld's workshop mods folder. (Typically 'steamapps\workshop\content\294100\').");
			tooltip.SetToolTip(LocalModPathLabel, @"Path to rimworld's local mods folder. (Typically 'steamapps\common\RimWorld\Mods'.");
		}

		private void ExpansionsPathButton_Click(object sender, EventArgs e)
		{
			_presenter.ExpansionsPath = SelectPath(_presenter.ExpansionsPath);
			PresenterBindingSource.ResetBindings(false);
		}

		private void LocalModPathButton_Click(object sender, EventArgs e)
		{
			_presenter.LocalModPath = SelectPath(_presenter.LocalModPath);
			PresenterBindingSource.ResetBindings(false);
		}

		private void WorkshopPathButton_Click(object sender, EventArgs e)
		{
			_presenter.WorkshopPath = SelectPath(_presenter.WorkshopPath);
			PresenterBindingSource.ResetBindings(false);
		}

		private void ConfigPathButton_Click(object sender, EventArgs e)
		{
			_presenter.ConfigPath = SelectPath(_presenter.ConfigPath);
			PresenterBindingSource.ResetBindings(false);
		}

		private string SelectPath(string initialPath)
		{

			if (FolderBrowserDialogVista.IsVistaFolderDialogSupported)
			{
				using (FolderBrowserDialogVista dialog = new FolderBrowserDialogVista())
				{
					dialog.SelectedPath = initialPath;

					if (dialog.ShowDialog(this) == DialogResult.OK)
						return dialog.SelectedPath;
				}
			}
			else
			{
				using (FolderBrowserDialog dialog = new FolderBrowserDialog())
				{
					dialog.SelectedPath = initialPath;

					if (dialog.ShowDialog(this) == DialogResult.OK)
						return dialog.SelectedPath;
				}
			}

			return initialPath;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			StringBuilder issues = new StringBuilder();

			if (Directory.Exists(_presenter.ConfigPath) == false)
				issues.AppendLine($"The path to the configuration folder ({_presenter.ConfigPath}) does not exist.");

			if (Directory.Exists(_presenter.ExpansionsPath) == false)
				issues.AppendLine($"The path to the expansions folder ({_presenter.ExpansionsPath}) does not exist.");


			if (issues.Length > 0)
			{
				MessageBox.Show("Following issues must be resolved for the program to work:" + Environment.NewLine + issues.ToString(), "Save configuration", MessageBoxButtons.OK);
				return;
			}

			if (Directory.Exists(_presenter.LocalModPath) == false)
				issues.AppendLine($"The path to the local mods folder ({_presenter.LocalModPath}) does not exist.");

			if (Directory.Exists(_presenter.WorkshopPath) == false)
				issues.AppendLine($"The path to the workshop mods folder ({_presenter.WorkshopPath}) does not exist.");

			if (issues.Length > 0)
			{
				issues.AppendLine("Do you wish to continue anyway?");
				DialogResult result = MessageBox.Show("Following issues might prevent the program from discovering any mods:" + Environment.NewLine + issues.ToString(), "Save configuration", MessageBoxButtons.YesNo);
				if (result == DialogResult.No)
					return;
			}

			DialogResult = DialogResult.OK;
			_presenter.Save();
			this.Close();
		}
	}
}
