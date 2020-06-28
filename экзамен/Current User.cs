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
            if (!File.Exists("temp\\user.txt"))
                log_in();
            else
                authorize();
        }

        private void log_in()       // авторизация через диалоговое окно
        {
            Login_Window window = new Login_Window();
            window.ShowDialog();
            if (window.connected)
                get_user(window.login_text, window.password_text, window.privilege, window.check_stay);
        }

        private void authorize()        // авторизация из файла
        {
            string file = "temp\\user.txt";
            StreamReader reader = new StreamReader(file);

            login = reader.ReadLine();
            password = reader.ReadLine();

            reader.Close();
            try
            {
                get_extra_fields();
                get_priviledge();
            }
            catch       // если что-то пойдет не так
            {
                logout();
                log_in();
            }
        }

        public void logout()    // удаление файла пользователя
        {
            string file = "temp\\user.txt";
            File.Delete(file);
        }

        public void get_user(string login, string password, bool privilege, bool stay)
        {
            this.login = login;
            this.password = password;
            this.privileged = privilege;
            write_down(stay);
            get_extra_fields();
        }

        private void get_priviledge()       // определение привилегий 
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

        private void get_extra_fields()     // взятие информации о пользователе
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

            // некоторые поля таблицы не являются обязательными

            if (reader[3].ToString() != "") patronymic = reader[3].ToString();
            if (reader[4].ToString() != "") ticket_window = int.Parse(reader[4].ToString());
            if (reader[5].ToString() != "") photo = reader[5].ToString();

            db.connection.Close();
        }

        public void write_down(bool stay = false)
        {
            if (!Directory.Exists("temp\\"))
                Directory.CreateDirectory("temp\\");
            if (File.Exists("temp\\user.txt") || stay)
                File.WriteAllLines("temp\\user.txt", new string[2] { login, password });
        }
    }
}
