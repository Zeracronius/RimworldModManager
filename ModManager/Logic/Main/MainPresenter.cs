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
        Dictionary<string, ViewModels.ModViewModel> _activeMods;
        Dictionary<string, ViewModels.ModViewModel> _availableMods;
        ViewModels.ModViewModel _selectedMod;

        public event EventHandler LoadComplete;
        public bool Loaded { get; private set; }

        private bool _loading;

        public ViewModels.ModViewModel SelectedMod
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
        public Dictionary<string, ViewModels.ModViewModel> AvailableMods => _availableMods;
        public Dictionary<string, ViewModels.ModViewModel> ActiveMods => _activeMods;




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
                        ViewModels.ModViewModel modView = null;
                        if (mods.ContainsKey(mod))
                            modView = mods[mod];
                        else
                        {
                            // Unable to load active mod
                            stringBuilder.AppendLine("Missing mod: " + mod);
                            continue;
                        }

                        _activeMods.Add(modView.PackageId, modView);
                        mods.Remove(mod);
                    }

                    if (stringBuilder.Length > 0)
                        MessageBox.Show("Some mods were missing:" + Environment.NewLine + stringBuilder.ToString());

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


        public Dictionary<string, ViewModels.ModViewModel> LoadMods()
        {
            Dictionary<string, ViewModels.ModViewModel> availableMods = new Dictionary<string, ViewModels.ModViewModel>(200);
            Settings settings = Settings.Default;



            string coreVersion = File.ReadAllText(Path.Combine(Settings.Default.InstallationPath, "Version.txt"));
            coreVersion = coreVersion.Substring(0, coreVersion.LastIndexOf("."));

            if (Directory.Exists(settings.WorkshopPath))
            {
                // Load workshop mods
                foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.WorkshopPath).Select(x => new DirectoryInfo(x)))
                {
                    if (availableMods.ContainsKey(modDirectory.Name))
                        continue;

                    ViewModels.ModViewModel mod = LoadModMeta(modDirectory, coreVersion, ViewModels.ModViewModel.ModType.Workshop);
                    if (mod != null)
                        availableMods.Add(mod.PackageId, mod);
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
                        availableMods.Add(mod.PackageId ?? modDirectory.Name, mod);
                }

            }


            // Load expansions
            foreach (DirectoryInfo modDirectory in Directory.GetDirectories(settings.ExpansionsPath).Select(x => new DirectoryInfo(x)))
            {
                if (availableMods.ContainsKey(modDirectory.Name))
                    continue;

                ViewModels.ModViewModel mod = LoadModMeta(modDirectory, coreVersion, ViewModels.ModViewModel.ModType.Expansion);
                if (mod != null)
                    availableMods.Add(mod.PackageId ?? modDirectory.Name, mod);
            }


            return availableMods;
        }

        private ViewModels.ModViewModel LoadModMeta(DirectoryInfo modDirectory, string coreVersion, ViewModels.ModViewModel.ModType type)
        {
            string aboutPath = Path.Combine(modDirectory.FullName, "About", "About.xml");

            if (File.Exists(aboutPath) == false)
                return null;

            Model.ModMetaData modMeta;
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModMetaData));


            using (FileStream file = File.Open(aboutPath, FileMode.Open, FileAccess.Read))
                modMeta = xmlSerializer.Deserialize(file) as Model.ModMetaData;


            ViewModels.ModViewModel mod = new ViewModels.ModViewModel(modMeta, modDirectory, coreVersion, type);

            return mod;
        }

    }
}
