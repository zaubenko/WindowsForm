using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WindowsFormsApp1
{
    static class TeacherList
    {
        public static List<Teacher> teacherlist = new List<Teacher>();
        public static string directory = PathToFiles();
        public static string SaveDirectory = PathToFiles() + "TeachersList.json";

        public static string PathToFiles()
        {
            string file = Environment.CurrentDirectory;
            string sendfile = file.Substring(0, file.LastIndexOf("bin")) + "Info" + "\\";
            return sendfile;
        }
        public static void Load()
        {
            teacherlist = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText(SaveDirectory));
        }
    }
}
