using ModManager.Logic.Model;
using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Main.ViewModels
{
	public class ModViewModel
	{
		public enum ModType
		{
			Local = 1,
			Workshop = 2,
			Expansion = 3,
		}


		public ModViewModel(ModMetaData modMeta, DirectoryInfo directory, ModType type)
		{
			Type = type;
			Directory = directory;
			PackageId = modMeta.PackageId?.ToLower();
			if (String.IsNullOrWhiteSpace(PackageId))
				PackageId = directory.Name;

			Downloaded = directory.CreationTime.ToString("yyyy/MM/dd hh:mm");
			SupportedVersions = modMeta.SupportedVersions != null ? String.Join(", ", modMeta.SupportedVersions.Select(x => x.Trim())) : modMeta.TargetVersion;
			Description = modMeta.Description;

			if (modMeta.LoadBefore != null)
				LoadBefore = modMeta.LoadBefore.Select(x => x.ToLower()).ToArray();

			if (modMeta.LoadAfter != null)
				LoadAfter = modMeta.LoadAfter.Select(x => x.ToLower()).ToArray();

			if (modMeta.Dependencies != null)
				Dependencies = modMeta.Dependencies.ToDictionary(x => x.PackageId.ToLower(), x => x.Name);


			string imagePath = Path.Combine(directory.FullName, "About", "Preview.png");
			if (File.Exists(imagePath))
				PreviewPath = imagePath;

			if (String.IsNullOrWhiteSpace(modMeta.Name))
				Caption = directory.Name;
			else
				Caption = modMeta.Name;

			switch (type)
			{
				case ModType.Local:
					Caption += " (local)";
					break;

				case ModType.Workshop:
					WorkshopPath = "steam://url/CommunityFilePage/" + directory.Name;
					break;

				case ModType.Expansion:
					string coreVersion = File.ReadAllText(Path.Combine(Settings.Default.InstallationPath, "Version.txt"));
					SupportedVersions = coreVersion.Substring(0, coreVersion.LastIndexOf("."));
					break;
			}

		}

		public string Caption { get; private set; }
		public string PackageId { get; private set; }

		public ModType Type { get; private set; }

		public string Description { get; private set; }


		public Dictionary<string, string> Dependencies { get; set; }
		public string[] LoadBefore { get; set; }
		public string[] LoadAfter { get; set; }


		public string SupportedVersions { get; private set; }

		public string PreviewPath { get; private set; }

        public DirectoryInfo Directory { get; private set; }

        public string WorkshopPath { get; private set; }

        public string Downloaded { get; private set; }
    }
}
