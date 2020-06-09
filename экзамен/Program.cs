using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    class Program
    {
        public Current_User user;

        public Program()
        {
        }

        public bool set_user()
        {
            if (File.Exists("temp\\usr.txt"))
            {
                user = new Current_User();
                return true;
            }
            else
            {
                Login_Window LoginWindow = new Login_Window();
                LoginWindow.ShowDialog();
                if (LoginWindow.connected == true)
                {
                    user = new Current_User(LoginWindow.login_text, LoginWindow.password_text,
                                            LoginWindow.privilege, LoginWindow.check_stay);
                    return true;
                }
                else
                    return false;
            }
        }

        public void show_greeting()
        {
            string name = "";
            if (user.nickname == null)
            {
                name = user.name;
                if (user.patronymic != null)
                    name += " " + user.patronymic;
            }
            else name = user.nickname;

            Greetings_Window window = new Greetings_Window(name);
            window.ShowDialog();
        }

        public void start_work_env()
        {
            Working_Environment window = new Working_Environment();
            window.ShowDialog();
        }
    }
}
