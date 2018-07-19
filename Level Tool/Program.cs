using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Level_Tool
{
    class Program
    {
        static string WD = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;

        static Dictionary<string, Action> MODES = new Dictionary<string, Action> {
            { "1. Create a level", CreateLevel },
            { "2. Edit a level", EditLevel},
            { "3. Extract a level", ExtractLevel}
        };

        static string[] difficulty = new string[] { "0 = Easy", "1 = Medium", "2 = Hard", "3 = Extreme" };

        static void Main(string[] args)
        { 
            string[] keys = MODES.Keys.ToArray<string>();
            while (true) {
                Print.Reset();

                try {
                    int index = int.Parse(Print.Prompt(keys, "Enter a number:"));
                    MODES[keys[index - 1]].Invoke();
                }
                catch (Exception) {
                    Print.Log("Please enter a valid input");
                    Print.Pause();
                }
                
            }
        }

        static void CreateLevel()
        {
            Print.Reset();

            LevelAssetBINARY level = new LevelAssetBINARY
            {
                name = Print.Prompt("Level name:"),
                difficulty = int.Parse(Print.Prompt(difficulty, "Enter a number:"))
            };

            string PATH = WD + "/Textures/" + Print.Prompt("Name of image (include the file extension):");
            level.image = LevelFactory.GetImageBytes(PATH);
            string saveName = Print.Prompt("file name:");
            LevelFactory.WriteLevel(WD + saveName + ".level", level);
        }

        static void EditLevel()
        {
            Print.Reset();

            string PATH = Print.Prompt("Path to level file:");
            LevelAssetBINARY level = LevelFactory.ReadLevel(PATH);

            if (Print.YesOrNo("Change level name?")) {
                level.name = Print.Prompt("Level name:");
            }

            if (Print.YesOrNo("Change level difficulty?")) {
                level.difficulty = int.Parse(Print.Prompt(difficulty, "Enter a number:"));
            }

            if (Print.YesOrNo("Change level map?")) {
                string image = Print.Prompt("Path to image:");
                level.image = LevelFactory.GetImageBytes(image);
            }

            if (Print.Prompt("Confirm changes Y/N?").ToLower() == "y") {
                LevelFactory.WriteLevel(PATH, level);
            }
        }

        static void ExtractLevel()
        {

        }
    }

    static class Print {

        public static void Reset()
        {
            Console.Clear();
            Header();
        }

        public static void Header()
        {
            Console.Title = "Level Asset Tool";
            Console.WriteLine("================================");
            Console.WriteLine("        ORBIS LEVEL TOOL        ");
            Console.WriteLine("  Angus Barnes (Astr0) © 2018   ");
            Console.WriteLine("================================");
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static string Prompt(string[] lines, string leader)
        {
            PrintLines(lines);
            Console.Write(leader + " ");
            return Console.ReadLine();
        }

        public static string Prompt(string leader)
        {
            Console.Write(leader + " ");
            return Console.ReadLine();
        }

        public static void PrintLines(string[] lines)
        {
            foreach(string line in lines) {
                Console.WriteLine(line);
            }
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static bool YesOrNo(string question)
        {
            if (Prompt(question + "(Y/N)").ToLower() == "y") {
                return true;
            }
            else return false;
        }

    }

}
