﻿using ModManager.Gui;
using ModManager.Logic.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;

namespace ModManager.Logic.Main.ViewModels
{
	public class ModViewModel : FilterableTreeNodeBase
	{
		internal ModMetaData ModMeta { get; }

		public enum ModType
		{
			Local = 1,
			Workshop = 2,
			Expansion = 3,
		}

		public ModViewModel(ModMetaData modMeta, DirectoryInfo directory, string coreVersion, ModType type)
			: base()
		{
			ModKey = directory.Name;

			ModMeta = modMeta;
			Type = type;
			Directory = directory;
			PackageId = modMeta.PackageId?.ToLower();
			if (String.IsNullOrWhiteSpace(PackageId))
				PackageId = directory.Name;

			Downloaded = directory.CreationTime.ToString("yyyy/MM/dd hh:mm");
			SupportedVersions = modMeta.SupportedVersions != null ? String.Join(", ", modMeta.SupportedVersions.Select(x => x.Trim())) : modMeta.TargetVersion;
			Description = modMeta.GetDescription(coreVersion);
			LoadBefore = modMeta.GetLoadBefore(coreVersion).ToList();
			LoadAfter = modMeta.GetLoadAfter(coreVersion).ToList();

			Dependencies = new Dictionary<string, string>();
			foreach (ModMetaData.ModDependancy dependancy in modMeta.GetDependencies(coreVersion))
				Dependencies[dependancy.PackageId.ToLower()] = dependancy.Name;

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

			SearchString = Caption + " " + SupportedVersions;
        }

		public string ModKey { get; }

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
		public override string Key => PackageId;

    }
}
