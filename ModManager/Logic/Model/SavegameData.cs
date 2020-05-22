using System.Xml.Serialization;

namespace ModManager.Logic.Model
{
    [XmlType("savegame")]
	public class SavegameData
	{
        public class Meta
        {
            [XmlElement("gameVersion")]
            public string Version;

            [XmlArrayItem("li", IsNullable = false)]
            [XmlArray("modIds")]
            public string[] ModPackageIds;

            [XmlArrayItem("li", IsNullable = false)]
            [XmlArray("modNames")]
            public string[] ModNames;
        }

        [XmlElement("meta")]
        public Meta SaveMeta;
    }
}
