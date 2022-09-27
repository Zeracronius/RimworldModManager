using ModManager.Gui;
using ModManager.Logic.Model;
using ModManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModManager.Gui.Components.ReorderableTreeListView;

namespace ModManager.Logic.Main.ViewModels
{
	public class ModViewModel : Gui.ITreeListViewItem
	{
		public enum ModType
		{
			Local = 1,
			Workshop = 2,
			Expansion = 3,
		}


		private T[] GetByVersion<T>(string coreVersion, ModMetaData.ByVersion<T> versioned)
		{
			switch (coreVersion)
			{
				case "1.0":
					return versioned.V10;

				case "1.1":
					return versioned.V11;

				case "1.2":
					return versioned.V12;
			}

			return null;
		}


		public ModViewModel(ModMetaData modMeta, DirectoryInfo directory, string coreVersion, ModType type)
		{
			Type = type;
			Directory = directory;
			PackageId = modMeta.PackageId?.ToLower();
			if (String.IsNullOrWhiteSpace(PackageId))
				PackageId = directory.Name;

			Downloaded = directory.CreationTime.ToString("yyyy/MM/dd hh:mm");
			SupportedVersions = modMeta.SupportedVersions != null ? String.Join(", ", modMeta.SupportedVersions.Select(x => x.Trim())) : modMeta.TargetVersion;
			Description = modMeta.Description;


			LoadBefore = new List<string>();
			if (modMeta.LoadBefore != null)
				LoadBefore.AddRange(modMeta.LoadBefore.Select(x => x.ToLower()));

			LoadAfter = new List<string>();
			if (modMeta.LoadAfter != null)
				LoadAfter.AddRange(modMeta.LoadAfter.Select(x => x.ToLower()));

			Dependencies = new Dictionary<string, string>();
			if (modMeta.Dependencies != null)
			{
				foreach (ModMetaData.ModDependancy dependancy in modMeta.Dependencies)
					Dependencies[dependancy.PackageId.ToLower()] = dependancy.Name;
			}

			// Couldn't figure out a better way to make xml deserialization dynamically create object members based on available version nodes.
			if (modMeta.LoadBeforeByVersion != null)
			{
				var loadBefore = GetByVersion(coreVersion, modMeta.LoadBeforeByVersion);
				if (loadBefore != null)
					LoadBefore.AddRange(loadBefore.Select(x => x.ToLower()));
			}

			if (modMeta.LoadAfterByVersion != null)
			{
				var loadAfter = GetByVersion(coreVersion, modMeta.LoadAfterByVersion);
				if (loadAfter != null)
					LoadAfter.AddRange(loadAfter.Select(x => x.ToLower()));
			}

			if (modMeta.DependenciesByVersion != null)
			{
				var versionDependancies = GetByVersion(coreVersion, modMeta.DependenciesByVersion);
				if (versionDependancies != null)
				{
					foreach (ModMetaData.ModDependancy dependancy in versionDependancies)
						Dependencies[dependancy.PackageId.ToLower()] = dependancy.Name;
				}
			}


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
					SupportedVersions = coreVersion;
					break;
			}

			Children = new List<ITreeListViewItem>();

        }

		public string Caption { get; private set; }
		public string PackageId { get; private set; }

		public ModType Type { get; private set; }

		public string Description { get; private set; }


		public Dictionary<string, string> Dependencies { get; set; }
		public List<string> LoadBefore { get; set; }
		public List<string> LoadAfter { get; set; }


		public string SupportedVersions { get; private set; }

		public string PreviewPath { get; private set; }

        public DirectoryInfo Directory { get; private set; }

        public string WorkshopPath { get; private set; }

        public string Downloaded { get; private set; }

		public Color Background { get; set; }
		public string Tooltip { get; set; }
		public List<ITreeListViewItem> Children { get; }
		public ITreeListViewItem Parent { get; set; }
		string ITreeListViewItem.Key => PackageId;

		public bool IsAncestorOf(ITreeListViewItem item)
        {
			ITreeListViewItem parent = item.Parent;
            while (parent != null)
			{
				if (parent == this)
					return true;

				parent = parent.Parent;
			}
			return false;
        }
    }
}
