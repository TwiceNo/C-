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
        public string path_t;

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
                printable = bool.Parse(reader.ReadLine());
            }
            else
            {
                path_t = "tickets\\";
                printable = true;
                write_down();
            }
        }

        public void write_down()
        {
            File.WriteAllLines("settings.txt", new string[2] { path_t,  printable.ToString() });
        }
    }
}
