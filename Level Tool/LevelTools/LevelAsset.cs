using System;
using System.Xml.Serialization;

namespace Orbis.LevelTools
{
    [Serializable]
    public class LevelAssetBINARY
    {
        [XmlElement("Level Name")]
        public string name;
        [XmlElement("Level Difficulty")]
        public int difficulty;
        [XmlElement("map data")]
        public byte[] image;
    }
}
