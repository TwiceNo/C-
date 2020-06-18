using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class GeneralSettings
    {
        public bool printable;
        public string path_t, path_s;

        public GeneralSettings()
        {
            set_values();
        }

        private void set_values()
        {
            if (File.Exists("settings.txt"))
            {
                StreamReader reader = new StreamReader("settings.txt");
                path_t = reader.ReadLine();
                path_s = reader.ReadLine();
                printable = bool.Parse(reader.ReadLine());
            }
            else
            {
                path_t = "tickets\\";
                path_s = "summary.txt";
                printable = true;
                write_down();
            }
        }

        public void write_down()
        {
            File.WriteAllLines("settings.txt", new string[3] { path_t, path_s, printable.ToString() });
        }
    }
}
