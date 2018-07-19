using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbis.LevelTools.Binary
{
    static class Binary
    {
        public static void WriteString(string path, string value)
        {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(value);
                }
            }
                
        }

        public static void ReadBinary(string path, string value)
        {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader writer = new BinaryReader(stream))
                {
                    writer.ReadString();
                }
            }

        }
    }
}
