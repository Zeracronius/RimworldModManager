using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Main
{
    public class MainPresenter
    {
        const string RimworldSteamId = "294100";
        const string ConfigFile = "ModsConfig.xml";

        public readonly Color IncompatibleColor = Color.Red;
        public readonly Color WarningColor = Color.Orange;


        readonly string _installationPath;
        readonly string _configPath;
        Model.ModsConfigData _config;
        Dictionary<string, Model.ModMetaData> _activeMods;
        Dictionary<string, Model.ModMetaData> _availableMods;
        Model.ModMetaData _selectedMod;

        public event EventHandler LoadComplete;
        public bool Loaded { get; private set; }

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




        public MainPresenter(string installationPath)
        {
            _installationPath = installationPath;
            _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low", "Ludeon Studios", "RimWorld by Ludeon Studios", "Config", ConfigFile);
        }


        public async void LoadData()
        {
            Loaded = false;

            Task<Model.ModsConfigData> loadConfigTask = Task.Run(() => LoadConfig());
            Task<Dictionary<string, Model.ModMetaData>> loadModsTask = Task.Run(() => LoadMods());

            await Task.WhenAll(loadConfigTask, loadModsTask);


            _config = loadConfigTask.Result;

            Dictionary<string, Model.ModMetaData> mods = loadModsTask.Result;

            _activeMods = new Dictionary<string, Model.ModMetaData>();
            foreach (string mod in _config.ActiveMods)
            {
                Model.ModMetaData meta = null;
                if (mods.ContainsKey(mod))
                    meta = mods[mod];
                else
                {
                    meta = mods.Values.FirstOrDefault(x => x.DirectoryName == mod);
                    if (meta == null)
                        continue;
                }

                _activeMods.Add(meta.PackageId, meta);
                mods.Remove(mod);
            }

            _availableMods = mods;

            Loaded = true;
            LoadComplete?.Invoke(this, new EventArgs());
        }


        public void SaveConfig()
        {
            FileInfo modConfig = new FileInfo(_configPath);

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModsConfigData));
            using (FileStream file = modConfig.Open(FileMode.Create, FileAccess.Write))
                xmlSerializer.Serialize(file, _config);

        }


        public void BrowseFolder()
        {
            if (SelectedMod == null)
                return;

            System.Diagnostics.Process.Start(SelectedMod.DirectoryPath);
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
            FileInfo modConfig = new FileInfo(_configPath);

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Model.ModsConfigData));

            Model.ModsConfigData config = null;
            using (FileStream file = modConfig.Open(FileMode.Open, FileAccess.Read))
                config = xmlSerializer.Deserialize(file) as Model.ModsConfigData;

            return config;
        }


        public Dictionary<string, Model.ModMetaData> LoadMods()
        {
            Dictionary<string, Model.ModMetaData> availableMods = new Dictionary<string, Model.ModMetaData>(200);


            // Load workshop mods
            DirectoryInfo steamApps = Directory.GetParent(_installationPath).Parent;
            string modsFolderPath = Path.Combine(steamApps.FullName, "workshop", "content", RimworldSteamId);
            foreach (DirectoryInfo modDirectory in Directory.GetDirectories(modsFolderPath).Select(x => new DirectoryInfo(x)))
            {
                if (availableMods.ContainsKey(modDirectory.Name))
                    continue;

                Model.ModMetaData modMeta = LoadModMeta(modDirectory);
                if (modMeta != null)
                {
                    modMeta.WorkshopPath = "steam://url/CommunityFilePage/" + modDirectory.Name;
                    modMeta.Downloaded = modDirectory.CreationTime;
                    modMeta.DirectoryName = modDirectory.Name;
                    availableMods.Add(modMeta.PackageId ?? modMeta.DirectoryName, modMeta);
                }
            }

            // Load local mods
            string localMods = Path.Combine(_installationPath, "Mods");
            List<DirectoryInfo> modDirectories = Directory.GetDirectories(localMods).Select(x => new DirectoryInfo(x)).ToList();

            // Load expansions
            string expansions = Path.Combine(_installationPath, "Data");
            modDirectories.AddRange(Directory.GetDirectories(expansions).Select(x => new DirectoryInfo(x)));


            foreach (DirectoryInfo modDirectory in modDirectories)
            {
                if (availableMods.ContainsKey(modDirectory.Name))
                    continue;

                Model.ModMetaData modMeta = LoadModMeta(modDirectory);
                if (modMeta != null)
                {
                    modMeta.Downloaded = modDirectory.CreationTime;
                    modMeta.DirectoryName = modDirectory.Name;

                    if (modDirectory.Name == "Core")
                    {
                        modMeta.Name = "Core";
                        modMeta.TargetVersion = File.ReadAllText(Path.Combine(_installationPath, "Version.txt"));
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

            modMeta.DirectoryPath = modDirectory.FullName;
            modMeta.PackageId = modMeta.PackageId?.ToLower();

            return modMeta;
        }

    }
}
