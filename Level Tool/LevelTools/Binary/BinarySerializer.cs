using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Orbis.LevelTools.Binary
{
    class BinarySerializer<T>
    {

        public BinarySerializer(string path)
        {

        }

        public static void Write(T item)
        {
            foreach (PropertyInfo variable in item.GetType().GetProperties())
            {
                variable.GetValue(item);
            }
            
        }
    }
}
