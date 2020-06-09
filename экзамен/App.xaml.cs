using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            Working_Environment window = new Working_Environment();
            window.ShowDialog();
        }

        


        //bool done = false;

        //App()
        //{
        //    while (!done)
        //    {
        //        main();
        //        done = true;
        //    }
        //}

        //[STAThread]

        //static void main()
        //{
        //    Program program = new Program();


        //    if (program.set_user())
        //    {
        //        program.show_greeting();
        //        program.start_work_env();
        //    }
        //}
    }
}
