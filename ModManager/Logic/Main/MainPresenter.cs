﻿using ModManager.Logic.Autosorting.CommunityRules;
using ModManager.Logic.Model;
using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Logic.Main
{
    public class MainPresenter
    {
        public event EventHandler LoadComplete;

        public readonly Color IncompatibleColor = Color.Red;
        public readonly Color WarningColor = Color.Orange;

        Model.ModsConfigData _config;
        Dictionary<string, ViewModels.ModViewModel> _activeMods;
        Dictionary<string, ViewModels.ModViewModel> _availableMods;
        ViewModels.ModViewModel _selectedMod;
        private bool _loading;

		public string CoreVersion { get; private set; }

        public bool Loaded { get; private set; }
        public System.Drawing.Image PreviewImage { get; private set; }


		public bool RimsortCommunityRules 
		{ 
			get => Settings.Default.UseRimsortRules; 
			set => Settings.Default.UseRimsortRules = value; 
		}

		public ViewModels.ModViewModel SelectedMod
        {
            get => _selectedMod;

            set
            {
                _selectedMod = value;
                PreviewImage?.Dispose();

                if (String.IsNullOrWhiteSpace(value?.PreviewPath) == false)
                {
					if (File.Exists(value.PreviewPath))
					{
						try
						{
							PreviewImage = Image.FromFile(value.PreviewPath);
							return;
						}
						catch
						{ }
                    }
                }

                PreviewImage = null;
            }
        }

        public Model.ModsConfigData Config => _config;
        public Dictionary<string, ViewModels.ModViewModel> AvailableMods => _availableMods;
        public Dictionary<string, ViewModels.ModViewModel> ActiveMods => _activeMods;

        public MainPresenter()
        {
        }

        /// <summary>
        /// Import active mods from a .rws (rimworld save) or .modlist (exported mod list) and replace the current active mods
        /// </summary>
        /// <param name="filepath"></param>
        public void ImportModlist(string filepath)
        {
            if (Loaded == false)
                return;

            FileInfo file = new FileInfo(filepath);

            if (file.Exists == false)
                throw new FileNotFoundException();

            string[] mods;
            switch (file.Extension)
            {
                case (".rws"):
                    // Rimworld save
                    Model.SavegameData.Meta saveMeta = DeserializeFile<Model.SavegameData>(file)?.SaveMeta;
                    mods = saveMeta?.ModPackageIds;
                    break;

                case (".modlist"):
                    // Exported mod list
                    mods = DeserializeFile<Model.ModlistData>(file)?.ModPackageIds;
                    break;

                default:
                    throw new InvalidOperationException("Unknown file format");
            }


            if (mods != null)
            {
                // Deactivate all current mods
                foreach (var item in _activeMods)
                    _availableMods.Add(item.Value.ModKey, item.Value);
                _activeMods.Clear();

                // Activate mods from loaded file
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string mod in mods)
                {
                    ViewModels.ModViewModel modView = _availableMods.FirstOrDefault(x => x.Value.PackageId == mod).Value;

                    if (modView == null)
                    {
                        // Unable to load active mod
                        stringBuilder.AppendLine("Missing mod: " + mod);
						continue;
					}

					if (_activeMods.ContainsKey(modView.ModKey))
						continue;

					_activeMods.Add(modView.ModKey, modView);
                    _availableMods.Remove(modView.ModKey);
                }

                if (stringBuilder.Length > 0)
                    MessageBox.Show(stringBuilder.ToString(), "Missing mods");

                LoadComplete?.Invoke(this, new EventArgs());
            }
        }

        public void ExportModlist(string filepath)
        {
            ModlistData modlist = new ModlistData();
            modlist.ModPackageIds = _activeMods.Values.Select(x => x.PackageId).ToArray();
            modlist.Version = File.ReadAllText(Path.Combine(Settings.Default.InstallationPath, "Version.txt"));
            SerializeFile(new FileInfo(filepath), modlist);
        }

        private T DeserializeFile<T>(FileInfo file) where T : class
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            T result = null;
            try
            {
                using (FileStream filesStream = file.Open(FileMode.Open, FileAccess.Read))
                    result = xmlSerializer.Deserialize(filesStream) as T;
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                MessageBox.Show($"Unable to open file '{file.FullName}' because it was locked by another program.");
            }

            return result;
        }

        private void SerializeFile<T>(FileInfo file, T serializableObject) where T : class
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            try
            {
                using (FileStream fileStream = file.Open(FileMode.Create, FileAccess.Write))
                    xmlSerializer.Serialize(fileStream, serializableObject);
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                MessageBox.Show($"Unable to overwrite the file '{file.FullName}' because it was locked by another program.");
            }
        }



        public async void LoadData()
        {
            if (_loading)
                return;

            try
            {
                Loaded = false;
                _loading = true;

				Task<Model.ModsConfigData> loadConfigTask = Task.Run(() => LoadConfig());
				Task<Dictionary<string, ViewModels.ModViewModel>> loadModsTask = Task.Run(() => LoadMods());

				await Task.WhenAll(loadConfigTask, loadModsTask);
				_config = loadConfigTask.Result;

                Dictionary<string, ViewModels.ModViewModel> mods = loadModsTask.Result;

                _activeMods = new Dictionary<string, ViewModels.ModViewModel>();
                if (_config != null)
                {

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (string mod in _config.ActiveMods)
                    {
						ViewModels.ModViewModel modView = mods.FirstOrDefault(x => x.Value.PackageId == mod).Value;
						if (modView == null)
						{
							// Unable to load active mod
							stringBuilder.AppendLine("Missing mod: " + mod);
							continue;
						}

                        if (_activeMods.ContainsKey(mod) == false)
						{
                            _activeMods.Add(mod, modView);
	                        mods.Remove(modView.ModKey);
						}
                    }

                    if (stringBuilder.Length > 0 && Settings.Default.SilentLoading == false)
                        MessageBox.Show(stringBuilder.ToString(), "Missing mods");

                    _availableMods = mods;
                    LoadComplete?.Invoke(this, new EventArgs());
                }
            }
            finally
            {
                Loaded = true;
                _loading = false;
            }
        }


        public void SaveConfig()
        {
            _config.Version = ActiveMods.Single(x => x.Value.PackageId == "ludeon.rimworld").Value.SupportedVersions;

            FileInfo modConfig = new FileInfo(Path.Combine(Settings.Default.ConfigPath, Resources.ConfigFilename));
            modConfig.IsReadOnly = false;

            // If rolling backups are enabled in configuration
            if (Settings.Default.RollingBackups > 0)
            {
                int currentBackup = Settings.Default.CurrentBackup % Settings.Default.RollingBackups;

                modConfig.CopyTo(Path.Combine(modConfig.Directory.FullName, modConfig.Name + $"_Backup{currentBackup + 1}.xml"), true);

                Settings.Default.CurrentBackup += 1;
            }

            Settings.Default.Save();
            SerializeFile(modConfig, _config);
        }

        public void BrowseFolder()
        {
            if (SelectedMod == null)
                return;

            System.Diagnostics.Process.Start(SelectedMod.Directory.FullName);
        }

        public void OpenWorkshopPage()
        {
            if (SelectedMod == null)
                return;

            string workshopPath = SelectedMod.WorkshopPath;
            if (String.IsNullOrWhiteSpace(workshopPath) == false)
                System.Diagnostics.Process.Start(workshopPath);
        }

        public Model.ModsConfigData LoadConfig()
        {
            FileInfo modConfig = new FileInfo(Path.Combine(Settings.Default.ConfigPath, Resources.ConfigFilename));
            return DeserializeFile<Model.ModsConfigData>(modConfig);
        }

        public Dictionary<string, ViewModels.ModViewModel> LoadMods()
        {
            Dictionary<string, ViewModels.ModViewModel> availableMods = new Dictionary<string, ViewModels.ModViewModel>(200);
            Settings settings = Settings.Default;



            string coreVersion = File.ReadAllText(Path.Combine(Settings.Default.InstallationPath, "Version.txt"));
            coreVersion = coreVersion.Substring(0, coreVersion.LastIndexOf('.'));
            CoreVersion = coreVersion;

            if (Directory.Exists(settings.WorkshopPath))
            {
                // Load workshop mods
                foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.WorkshopPath).Select(x => new DirectoryInfo(x)))
                {
                    if (availableMods.ContainsKey(modDirectory.Name))
                        continue;

                    ViewModels.ModViewModel mod = LoadModMeta(modDirectory, coreVersion, ViewModels.ModViewModel.ModType.Workshop);
                    if (mod != null)
					{
						availableMods.Add(mod.ModKey, mod);
					}
                }
            }


            List<DirectoryInfo> modDirectories = new List<DirectoryInfo>();
            
            // Load local mods
            if (Directory.Exists(settings.LocalModsPath))
            {
                foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.LocalModsPath).Select(x => new DirectoryInfo(x)))
                {
                    if (availableMods.ContainsKey(modDirectory.Name))
                        continue;

                    ViewModels.ModViewModel mod = LoadModMeta(modDirectory, coreVersion, ViewModels.ModViewModel.ModType.Local);
                    if (mod != null)
                    {
                        //if (availableMods.ContainsKey(mod.PackageId))
                        //    MessageBox.Show("The local version of the mod " + mod.Caption + " was prioritised.");

                        availableMods[mod.ModKey] = mod;
                    }
                }

            }


            // Load expansions
            foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.ExpansionsPath).Select(x => new DirectoryInfo(x)))
            {
                if (availableMods.ContainsKey(modDirectory.Name))
                    continue;

                ViewModels.ModViewModel mod = LoadModMeta(modDirectory, coreVersion, ViewModels.ModViewModel.ModType.Expansion);
                if (mod != null)
                    availableMods.Add(mod.ModKey, mod);
            }


            return availableMods;
        }

        private ViewModels.ModViewModel LoadModMeta(DirectoryInfo modDirectory, string coreVersion, ViewModels.ModViewModel.ModType type)
        {
            string aboutPath = Path.Combine(modDirectory.FullName, "About", "About.xml");

            if (File.Exists(aboutPath) == false)
                return null;

            Model.ModMetaData modMeta;
            try
            {
                modMeta = DeserializeFile<Model.ModMetaData>(new FileInfo(aboutPath));

				return new ViewModels.ModViewModel(modMeta, modDirectory, coreVersion, type);
			}
            catch (Exception e)
            {
                if (Settings.Default.SilentLoading == false)
                    MessageBox.Show($"Failed to read metadata from directory '{modDirectory.FullName}': {e.Message}");

                return null;
            }
        }

		public void Sort()
		{
			var sorter = new Autosorting.ModSorter(_activeMods.Where(x => x.Value != null).Select(x => x.Value.ModMeta), CoreVersion);

			if (RimsortCommunityRules)
				sorter.AddCommunityRules(new Rimsort());

			var ordering = sorter.Sort().Select(x => x.ToLower()).ToList();

			var buffer = _activeMods.OrderBy(x => ordering.IndexOf(x.Value.PackageId.ToLower())).ToList();
			_activeMods.Clear();
			foreach (var item in buffer)
				_activeMods.Add(item.Key, item.Value);
			
			LoadComplete?.Invoke(this, new EventArgs());
		}
    }
}
