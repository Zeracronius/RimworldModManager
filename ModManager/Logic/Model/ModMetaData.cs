using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public class ByVersion<T>
        {
            [XmlArray("v1.0")]
            [XmlArrayItem("li")]
            public T[] V10 { get; set; }


            [XmlArray("v1.1")]
            [XmlArrayItem("li")]
            public T[] V11 { get; set; }
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
