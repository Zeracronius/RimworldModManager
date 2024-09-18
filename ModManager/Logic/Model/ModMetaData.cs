using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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

            [XmlElement("displayName")]
            public string Name { get; set; }

            [XmlElement("steamWorkshopUrl")]
            public string WorkshopURL { get; set; }
        }

        public class ByVersion<T> : IXmlSerializable
		{
			public Dictionary<string, T[]> _versions = new Dictionary<string, T[]>();

			public T[] this[string version]
			{
				get
				{
					if (_versions.TryGetValue(version, out var value))
						return value;
					return Array.Empty<T>();
				}
			}

			public void ReadXml(XmlReader reader)
			{
				XmlSerializer deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute("li"));

				reader.MoveToContent();
				reader.ReadStartElement();

				while (reader.NodeType != XmlNodeType.EndElement)
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						string name = reader.Name.TrimStart('v');
						reader.ReadStartElement();
						List<T> result = new List<T>();

						while (reader.NodeType != XmlNodeType.EndElement)
						{
							if (reader.NodeType == XmlNodeType.Element && reader.Name == "li")
							{
								// Deserialize each <li> element automatically
								result.Add((T)deserializer.Deserialize(reader));
							}
							else
							{
								reader.Skip();
							}
						}
						reader.ReadEndElement();

						_versions[name] = result.ToArray();
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



        [XmlElement("loadAfterByVersion")]
        public ByVersion<string> LoadAfterByVersion { get; set; }

        [XmlElement("loadBeforeByVersion")]
        public ByVersion<string> LoadBeforeByVersion { get; set; }

        [XmlElement("modDependenciesByVersion")]
        public ByVersion<ModDependancy> DependenciesByVersion { get; set; }

    }
}
