using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ModManager.Logic.Model
{
    /// <summary>
    /// Serialization model matching \About\About.xml
    /// </summary>
    public class ModMetaData
    {
        public struct ModDependancy
        {
            [XmlElement("packageId")]
            public string PackageId { get; set; }

			[XmlArray("alternativePackageIds")]
			[XmlArrayItem("li")]
			public string[] AlternativePackageIds { get; set; }

			[XmlElement("displayName")]
            public string Name { get; set; }

            [XmlElement("steamWorkshopUrl")]
            public string WorkshopURL { get; set; }
        }

        public class ByVersion<T> : IXmlSerializable
		{
			private Dictionary<string, T> _versions = new Dictionary<string, T>();

			public bool GetByVersion(string version, out T value)
			{
				if (version == null)
				{
					value = default;
					return false;
				}

				if (_versions.Count > 0)
				{
					if (_versions.TryGetValue(version, out value))
						return true;

					// If no direct version match, then take latest one that is less than current version.
					decimal versionNumber = decimal.Parse(version);
					T result = default;
					bool found = false;
					foreach (KeyValuePair<string, T> metadataVersions in _versions)
					{
						decimal currentVersion = decimal.Parse(metadataVersions.Key);
						if (currentVersion <= versionNumber)
						{
							found = true;
							result = metadataVersions.Value;
						}
					}

					if (found)
					{
						value = result;
						return true;
					}
				}

				value = default;
				return false;
			}

			public void ReadXml(XmlReader reader)
			{
				Type elementType = null;
				XmlSerializer itemSerializer = null;
				if (typeof(T).IsArray)
				{
					elementType = typeof(T).GetElementType();
					itemSerializer = new XmlSerializer(elementType, new XmlRootAttribute("li"));
				}

				XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("li"));
				List<object> list = new List<object>();


				reader.MoveToContent();
				reader.ReadStartElement();

				while (reader.NodeType != XmlNodeType.EndElement)
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						string name = reader.Name.TrimStart('v');
						reader.ReadStartElement(); // Enter <vX.X>

						if (typeof(T).IsArray)
						{
							// Handle array of T
							list.Clear();

							while (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.Comment)
							{
								if (reader.NodeType == XmlNodeType.Comment)
									reader.Skip();

								var item = itemSerializer.Deserialize(reader);
								list.Add(item);
							}

							// If only one <li>, still works
							var array = Array.CreateInstance(elementType, list.Count);
							list.ToArray().CopyTo(array, 0);
							_versions[name] = (T)(object)array;
						}
						else
						{
							// Handle single object T
							_versions[name] = (T)serializer.Deserialize(reader);
						}

						reader.ReadEndElement(); // Exit </vX.X>
					}
					else
					{
						reader.Skip();
					}
				}

				reader.ReadEndElement();
			}

			public void WriteXml(XmlWriter writer)
			{
				throw new NotImplementedException();
			}

			public XmlSchema GetSchema()
			{
				return null;
			}
		}

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("packageId")]
        public string PackageId { get; set; }

		[XmlArray("supportedVersions")]
        [XmlArrayItem("li")]
        public string[] SupportedVersions { get; set; }

        [XmlElement("targetVersion")]
        public string TargetVersion { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }


        [XmlArray("modDependencies")]
        [XmlArrayItem("li")]
        public ModDependancy[] Dependencies { get; set; }

        [XmlArray("loadBefore")]
        [XmlArrayItem("li")]
        public string[] LoadBefore { get; set; }

        [XmlArray("loadAfter")]
        [XmlArrayItem("li")]
        public string[] LoadAfter { get; set; }

		[XmlArray("forceLoadBefore")]
		[XmlArrayItem("li")]
		public string[] ForceLoadBefore { get; set; }

		[XmlArray("forceLoadAfter")]
		[XmlArrayItem("li")]
		public string[] ForceLoadAfter { get; set; }

		[XmlArray("incompatibleWith")]
		[XmlArrayItem("li")]
		public string[] IncompatibleWith { get; set; }



		[XmlElement("descriptionsByVersion")]
		public ByVersion<string> DescriptionsByVersion { get; set; }

		[XmlElement("loadAfterByVersion")]
        public ByVersion<string[]> LoadAfterByVersion { get; set; }

        [XmlElement("loadBeforeByVersion")]
        public ByVersion<string[]> LoadBeforeByVersion { get; set; }

		[XmlElement("incompatibleWithByVersion")]
		public ByVersion<string[]> IncompatibleWithByVersion { get; set; }

		[XmlElement("modDependenciesByVersion")]
        public ByVersion<ModDependancy[]> DependenciesByVersion { get; set; }

		public string GetDescription(string version)
		{
			if (DescriptionsByVersion?.GetByVersion(version, out string value) == true)
				return value;

			return Description;
		}

		public IEnumerable<string> GetLoadBefore(string version)
		{
			List<string> loadBefore = new List<string>();
			// Add version specific if any
			if (LoadBeforeByVersion?.GetByVersion(version, out string[] value) == true)
				loadBefore.AddRange(value);

			// If no version specific, use default.
			if (loadBefore.Count == 0 && LoadBefore != null)
				loadBefore.AddRange(LoadBefore);

			// Add forced
			if (ForceLoadBefore != null)
				loadBefore.AddRange(ForceLoadBefore);

			return loadBefore.Where(x => x != null).Select(x => x.ToLower());
		}

		public IEnumerable<string> GetLoadAfter(string version)
		{
			List<string> loadAfter = new List<string>();
			// Add version specific if any
			if (LoadAfterByVersion?.GetByVersion(version, out string[] value) == true)
				loadAfter.AddRange(value);

			// If no version specific, use default.
			if (loadAfter.Count == 0 && LoadAfter != null)
				loadAfter.AddRange(LoadAfter);

			// Add forced
			if (ForceLoadAfter != null)
				loadAfter.AddRange(ForceLoadAfter);

			return loadAfter.Where(x => x != null).Select(x => x.ToLower());
		}

		public IEnumerable<ModDependancy> GetDependencies(string version)
		{
			List<ModDependancy> dependencies = new List<ModDependancy>();
			// Add version specific if any
			if (DependenciesByVersion?.GetByVersion(version, out ModDependancy[] value) == true)
					dependencies.AddRange(value);

			// If no version specific, use default.
			if (dependencies.Count == 0 && Dependencies != null)
				dependencies.AddRange(Dependencies);

			return dependencies;
		}

		public IEnumerable<string> GetIncompatible(string version)
		{
			List<string> conflicts = new List<string>();
			// Add version specific if any
			if (IncompatibleWithByVersion?.GetByVersion(version, out string[] value) == true)
				conflicts.AddRange(value);

			// If no version specific, use default.
			if (conflicts.Count == 0 && IncompatibleWith != null)
				conflicts.AddRange(IncompatibleWith);

			return conflicts.Where(x => x != null).Select(x => x.ToLower());
		}
	}
}
