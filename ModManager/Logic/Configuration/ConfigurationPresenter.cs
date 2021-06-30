using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Configuration
{
	public class ConfigurationPresenter
	{

		public string ConfigPath { get; set; }
		public string ExpansionsPath { get; set; }
		public string LocalModPath { get; set; }
		public string WorkshopPath { get; set; }
		public int RollingBackups { get; set; }
        public bool SilentLoading { get; set; }


        public ConfigurationPresenter()
		{
			ConfigPath = Settings.Default.ConfigPath;
			ExpansionsPath = Settings.Default.ExpansionsPath;
			LocalModPath = Settings.Default.LocalModsPath;
			WorkshopPath = Settings.Default.WorkshopPath;
			RollingBackups = Settings.Default.RollingBackups;
			SilentLoading = Settings.Default.SilentLoading;
		}

		public void Save()
		{
			Settings settings = Settings.Default;
			settings.ConfigPath = ConfigPath;
			settings.ExpansionsPath = ExpansionsPath;
			settings.LocalModsPath = LocalModPath;
			settings.WorkshopPath = WorkshopPath;
			settings.RollingBackups = RollingBackups;
			settings.SilentLoading = SilentLoading;
			settings.Save();
		}
	}
}
