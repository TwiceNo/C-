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
    class Current_User
    {
        public string login, password;
        bool privileged;

        public string surname, name, patronymic, nickname, photo;
        int ticket_window;

        public Current_User()
        {
            string file = "temp\\usr.txt";
            StreamReader reader = new StreamReader(file);

            login = reader.ReadLine();         
            password = reader.ReadLine();         

            get_priviledge();
            get_extra_fields();
        }

        public Current_User(string login, string password, bool privilege, bool stay)
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

        public void logout()
        {
            string file = "temp\\usr.txt";
            File.Delete(file);
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
            if (reader[5].ToString() != "") nickname = reader[5].ToString();
            if (reader[6].ToString() != "") photo = reader[6].ToString();

            db.connection.Close();
        }
    }
}
