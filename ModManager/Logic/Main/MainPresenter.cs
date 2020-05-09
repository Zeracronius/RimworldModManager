using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Logic.Main
{
    public class MainPresenter
    {
        public readonly Color IncompatibleColor = Color.Red;
        public readonly Color WarningColor = Color.Orange;

        Model.ModsConfigData _config;
        Dictionary<string, Model.ModMetaData> _activeMods;
        Dictionary<string, Model.ModMetaData> _availableMods;
        Model.ModMetaData _selectedMod;

        public event EventHandler LoadComplete;
        public bool Loaded { get; private set; }

        private bool _loading;

        public Model.ModMetaData SelectedMod
        {
            get => _selectedMod;

            set
            {
                _selectedMod = value;

                if (String.IsNullOrWhiteSpace(value?.PreviewPath) == false)
                    PreviewImage = System.Drawing.Image.FromFile(value.PreviewPath);
                else
                    PreviewImage = null;
            }
        }
        public System.Drawing.Image PreviewImage { get; private set; }


        public Model.ModsConfigData Config => _config;
        public Dictionary<string, Model.ModMetaData> AvailableMods => _availableMods;
        public Dictionary<string, Model.ModMetaData> ActiveMods => _activeMods;




        public MainPresenter()
        {
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
                Task<Dictionary<string, Model.ModMetaData>> loadModsTask = Task.Run(() => LoadMods());

                await Task.WhenAll(loadConfigTask, loadModsTask);


                _config = loadConfigTask.Result;

                Dictionary<string, Model.ModMetaData> mods = loadModsTask.Result;

                _activeMods = new Dictionary<string, Model.ModMetaData>();
                if (_config != null)
                {
                    foreach (string mod in _config.ActiveMods)
                    {
                        Model.ModMetaData meta = null;
                        if (mods.ContainsKey(mod))
                            meta = mods[mod];
                        else
                        {
                            meta = mods.Values.FirstOrDefault(x => x.Directory.Name == mod);
                            if (meta == null)
                                continue;
                        }

                        _activeMods.Add(meta.PackageId, meta);
                        mods.Remove(mod);
                    }

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
            FileInfo modConfig = new FileInfo(Path.Combine(Settings.Default.ConfigPath, Resources.ConfigFilename));
            modConfig.IsReadOnly = false;

            // If rolling backups are enabled in configuration
            if (Settings.Default.RollingBackups > 0)
            {
                int currentBackup = Settings.Default.CurrentBackup % Settings.Default.RollingBackups;

                modConfig.CopyTo(Path.Combine(modConfig.Directory.FullName, modConfig.Name + $"_Backup{currentBackup + 1}.xml"), true);

                Settings.Default.CurrentBackup += 1;
                Settings.Default.Save();
            }

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModsConfigData));
            try
            {
                using (FileStream file = modConfig.Open(FileMode.Create, FileAccess.Write))
                    xmlSerializer.Serialize(file, _config);
            }
	        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                MessageBox.Show("Unable to save the changes because config file was locked by another program.");
	        }
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

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModsConfigData));


            Model.ModsConfigData config = null;
            try
            {
                using (FileStream file = modConfig.Open(FileMode.Open, FileAccess.Read))
                    config = xmlSerializer.Deserialize(file) as Model.ModsConfigData;
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                MessageBox.Show("Unable to load mod list because config file was locked by another program.");
            }

            return config;
        }


        public Dictionary<string, Model.ModMetaData> LoadMods()
        {
            Dictionary<string, Model.ModMetaData> availableMods = new Dictionary<string, Model.ModMetaData>(200);
            Settings settings = Settings.Default;

            if (Directory.Exists(settings.WorkshopPath))
            {
                // Load workshop mods
                foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.WorkshopPath).Select(x => new DirectoryInfo(x)))
                {
                    if (availableMods.ContainsKey(modDirectory.Name))
                        continue;

                    Model.ModMetaData modMeta = LoadModMeta(modDirectory);
                    if (modMeta != null)
                    {
                        modMeta.WorkshopPath = "steam://url/CommunityFilePage/" + modDirectory.Name;
                        modMeta.Downloaded = modDirectory.CreationTime;
                        availableMods.Add(modMeta.PackageId ?? modMeta.Directory.Name, modMeta);
                    }
                }
            }


            List<DirectoryInfo> modDirectories = new List<DirectoryInfo>();
            
            // Load local mods
            if (Directory.Exists(settings.LocalModsPath))
                modDirectories.AddRange(Directory.GetDirectories(settings.LocalModsPath).Select(x => new DirectoryInfo(x)));

            // Load expansions
            modDirectories.AddRange(Directory.GetDirectories(settings.ExpansionsPath).Select(x => new DirectoryInfo(x)));


            foreach (DirectoryInfo modDirectory in modDirectories)
            {
                if (availableMods.ContainsKey(modDirectory.Name))
                    continue;

                Model.ModMetaData modMeta = LoadModMeta(modDirectory);
                if (modMeta != null)
                {
                    modMeta.Downloaded = modDirectory.CreationTime;

                    if (modDirectory.Name == "Core")
                    {
                        modMeta.Name = "Core";
                        modMeta.TargetVersion = File.ReadAllText(Path.Combine(settings.InstallationPath, "Version.txt"));
                    }
                    else
                        modMeta.Name += " (local)";

                    availableMods.Add(modMeta.PackageId ?? modDirectory.Name, modMeta);
                }
            }


            return availableMods;
        }

        private Model.ModMetaData LoadModMeta(DirectoryInfo modDirectory)
        {
            string aboutPath = Path.Combine(modDirectory.FullName, "About", "About.xml");

            if (File.Exists(aboutPath) == false)
                return null;

            Model.ModMetaData modMeta;
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModMetaData));
            using (FileStream file = File.Open(aboutPath, FileMode.Open, FileAccess.Read))
                modMeta = xmlSerializer.Deserialize(file) as Model.ModMetaData;

            string imagePath = Path.Combine(modDirectory.FullName, "About", "Preview.png");
            if (File.Exists(imagePath))
                modMeta.PreviewPath = imagePath;

            modMeta.Directory = modDirectory;
            modMeta.PackageId = modMeta.PackageId?.ToLower();

            return modMeta;
        }

    }
}
