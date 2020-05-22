using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModManager.Logic.Model
{
	public class ModlistData
	{
        [XmlElement("gameVersion", IsNullable = false)]
        public string Version;

        [XmlArrayItem("li", IsNullable = false)]
        [XmlArray("modPackageIds")]
        public string[] ModPackageIds;
    }
}
