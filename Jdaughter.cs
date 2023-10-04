using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace To_do_list_wpf
{
    internal class Jdaughter
    {
        public static void Serialize<T>(T zametki)
        {
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zametki.json", JsonConvert.SerializeObject(zametki));
        }
        public static T Deserialize<T>()
        {
            if (!File.Exists((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zametki.json")))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zametki.json");
            }
            var fils = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zametki.json");
            return JsonConvert.DeserializeObject<T>(fils);
        }
    }
}
