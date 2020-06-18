using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    public class Current_User
    {
        public string login, password;
        public bool privileged;

        public string surname, name, patronymic, photo;
        public int ticket_window;

        public Current_User()
        {
            if (!File.Exists("temp\\usr.txt"))
                log_in();
            else
                authorize();
        }

        private void log_in()
        {
            Login_Window window = new Login_Window();
            window.ShowDialog();
            if (window.connected)
            {
                get_user(window.login_text, window.password_text, window.privilege, window.check_stay);
                get_extra_fields();
            }
        }

        private void authorize()
        {
            string file = "temp\\usr.txt";
            StreamReader reader = new StreamReader(file);

            login = reader.ReadLine();
            password = reader.ReadLine();

            get_extra_fields();
            get_priviledge();
        }

        public void logout()
        {
            string file = "temp\\usr.txt";
            File.Delete(file);
        }

        public void get_user(string login, string password, bool privilege, bool stay)
        {
            this.login = login;
            this.password = password;
            this.privileged = privilege;

            if (stay)
            {
                string file = "temp\\usr.txt";
                StreamWriter writer = new StreamWriter(file, false);
                writer.WriteLine(login);
                writer.WriteLine(password);
                writer.Close();
            }
            get_extra_fields();
        }

        private void get_priviledge()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT privileged FROM users WHERE login = ?log AND password = ?pas";
            comm.Parameters.AddWithValue("?log", login);
            comm.Parameters.AddWithValue("?pas", password);

            privileged = bool.Parse(comm.ExecuteScalar().ToString());

            db.connection.Close();
        }

        private void get_extra_fields()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT * FROM `personal data` WHERE login = ?log";
            comm.Parameters.AddWithValue("?log", login);

            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            surname = reader[1].ToString();
            name = reader[2].ToString();

            if (reader[3].ToString() != "") patronymic = reader[3].ToString();
            if (reader[4].ToString() != "") ticket_window = int.Parse(reader[4].ToString());
            if (reader[5].ToString() != "") photo = reader[5].ToString();

            db.connection.Close();
        }
    }
}
