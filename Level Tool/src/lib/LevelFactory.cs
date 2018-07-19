using System.IO;
using System.Xml.Serialization;

namespace LevelTooling
{
    public static class LevelFactory
    {
        public static void WriteLevel(string PATH, LevelAssetBINARY level)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LevelAssetBINARY));

            using(Stream stream = new FileStream(PATH, FileMode.Create, FileAccess.Write, FileShare.None)) {
                serializer.Serialize(stream, level);
            }
        }

        public static LevelAssetBINARY ReadLevel(string PATH)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LevelAssetBINARY));

            using(Stream stream = new FileStream(PATH, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                LevelAssetBINARY level = (LevelAssetBINARY) serializer.Deserialize(stream);
                return level;
            }
        }

        public static byte[] GetImageBytes(string PATH)
        {
            return File.ReadAllBytes(PATH);
        }
    }
}
