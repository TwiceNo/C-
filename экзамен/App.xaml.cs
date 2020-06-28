using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]

        static void Main()
        {
            App app = new App();
            server_clean();
            session_check();
            var window = new MainWindow();
            if (window.connected)
                app.Run(window);
            else Application.Current.Shutdown();
        }

        static void server_clean()
        {
            List<string> filenames = new List<string>();

            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT DISTINCT photo FROM `personal data`";
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
                if (reader[0].ToString() != "")
                    filenames.Add(reader[0].ToString());
                else
                    filenames.Add("z:\\user_photos\\no_user_photo.png");
            db.connection.Close();

            List<string> all_files = Directory.GetFiles("z:\\user_photos").ToList();
            foreach (string file in all_files)
                if (!filenames.Contains(file))
                    File.Delete(file);
        }

        static void session_check()
        {
            DateTime time = DateTime.Now;

            if (File.Exists("z:\\last_session.txt"))
            {
                DateTime last = DateTime.Parse(File.ReadAllText("z:\\last_session.txt"));
                if (time.ToString("dd/MM/yyyy") != last.ToString("dd/MM/yyyy"))
                    reset_database();
            }

            File.WriteAllText("z:\\last_session.txt", time.ToString("dd/MM/yyyy"));
        }

        static void reset_database()
        {
            Users db1 = new Users();
            db1.connection.Open();
            MySqlCommand comm1 = db1.connection.CreateCommand();
            comm1.CommandText = "UPDATE `sold tickets` SET sold = 0, sum = 0";
            comm1.ExecuteNonQuery();
            db1.connection.Close();

            Database db2 = new Database();
            db2.connection.Open();
            MySqlCommand comm2 = db2.connection.CreateCommand();
            comm2.CommandText = "UPDATE trains SET `left` = total";
            comm2.ExecuteNonQuery();
            db2.connection.Close();

            db2.connection.Open();
            comm2.CommandText = "UPDATE `all traffic` SET `left` = total";
            comm2.ExecuteNonQuery();
            db2.connection.Close();
        }
    }
}
