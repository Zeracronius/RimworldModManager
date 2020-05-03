using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModManager.Logic.Model
{
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




        [XmlIgnore]
        public string PreviewPath { get; set; }

        [XmlIgnore]
        public string DirectoryPath { get; set; }

        [XmlIgnore]
        public string WorkshopPath { get; set; }

        [XmlIgnore]
        public DateTime Downloaded { get; set; }

        [XmlIgnore]
        public string DirectoryName { get; set; }
    }
}
