using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModManager.Logic.Model
{
    public class ModsConfigData
    {
        [XmlElement("version")]
        public string Version;

        [XmlArrayItem("li", IsNullable = false)]
        [XmlArray("activeMods")]
        public string[] ActiveMods;

        [XmlArrayItem("li", IsNullable = false)]
        [XmlArray("knownExpansions")]
        public string[] Expansions;
    }
}
