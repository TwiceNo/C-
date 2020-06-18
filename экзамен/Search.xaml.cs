using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
            initialize_from();
            this.to.IsEnabled = false;
        }

        private void initialize_from()
        {
            List<string> items = new List<string>();
            List<string[]> routs_length = new List<string[]>();


            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT DISTINCT flight FROM rout";
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string[] len = new string[2];
                len[0] = reader[0].ToString();
                routs_length.Add(len);
            }

            db.connection.Close();

            foreach (string[] flight in routs_length)
            {
                db = new Database();
                db.connection.Open();
                MySqlCommand command = db.connection.CreateCommand();

                command.CommandText = "SELECT id FROM rout WHERE flight = ?f ORDER BY id DESC";
                command.Parameters.AddWithValue("?f", flight[0]);

                flight[1] = command.ExecuteScalar().ToString();

                db.connection.Close();


                db.connection.Open();

                command.CommandText = "SELECT station FROM rout WHERE flight = ?f AND id < ?id";
                command.Parameters.AddWithValue("?id", flight[1]);

                reader = command.ExecuteReader();

                while (reader.Read())
                    items.Add(reader[0].ToString());

                db.connection.Close();
            }

            items.Distinct();
            items.Sort();

            this.from.ItemsSource = items;
        }

        private void initialize_to()
        {
            string dep = this.from.SelectedItem.ToString();
            List<string[]> probably = new List<string[]>();
            List<string> possible = new List<string>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT flight, id FROM rout WHERE station = ?s";
            comm.Parameters.AddWithValue("?s", dep);

            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
                probably.Add(new string[2] { reader[0].ToString(), reader[1].ToString() });

            db.connection.Close();

            foreach (string[] prob in probably)
            {
                db = new Database();
                db.connection.Open();
                MySqlCommand command = db.connection.CreateCommand();

                command.CommandText = "SELECT station FROM rout WHERE flight = ?f AND id > ?id";
                command.Parameters.AddWithValue("?f", prob[0]);
                command.Parameters.AddWithValue("?id", prob[1]);

                reader = command.ExecuteReader();

                while (reader.Read())
                    possible.Add(reader[0].ToString());

                db.connection.Close();
            }

            possible.Distinct();
            possible.Sort();

            this.to.ItemsSource = possible;
        }

        private void initialize_rout()
        {
            List<string[]> prob = new List<string[]>();
            List<string[]> possible = new List<string[]>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT flight, id FROM rout WHERE station = ?s";
            comm.Parameters.AddWithValue("?s", this.from.SelectedItem.ToString());
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
                prob.Add(new string[2] { reader[0].ToString(), reader[1].ToString() });

            db.connection.Close();

            for (int i = 0; i < prob.Count; i++)
                try
                {
                    db = new Database();
                    db.connection.Open();
                    MySqlCommand command = db.connection.CreateCommand();

                    command.CommandText = "SELECT `departure point`, destination FROM `all traffic` WHERE flight = ?f";
                    command.Parameters.AddWithValue("?f", prob[i][0]);
                    reader = command.ExecuteReader();
                    reader.Read();
                    string rout = reader[0].ToString() + " — " + reader[1].ToString();
                    db.connection.Close();

                    db.connection.Open();
                    command.CommandText = "SELECT id FROM rout WHERE station = ?d AND flight = ?f AND id > ?id";
                    command.Parameters.AddWithValue("?d", this.to.SelectedItem.ToString());
                    command.Parameters.AddWithValue("?id", prob[i][1]);

                    MySqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        string id = read[0].ToString();

                        db = new Database();
                        db.connection.Open();
                        MySqlCommand cmd = db.connection.CreateCommand();
                        cmd.CommandText = "SELECT `travel time`, `stop time` FROM rout WHERE flight = ?f AND id > ?id AND id < ?id2";
                        cmd.Parameters.AddWithValue("?id2", id);

                        reader = cmd.ExecuteReader();

                        int[] time = new int[3];
                        while (reader.Read())
                        {
                            time[1] += int.Parse(reader[0].ToString().Split(':')[0]);
                            time[2] += int.Parse(reader[0].ToString().Split(':')[1]) + int.Parse(reader[1].ToString());
                            if (time[2] >= 60)
                            {
                                time[2] = time[2] % 60;
                                time[1]++;
                            }
                            if (time[1] >= 24)
                            {
                                time[1] = time[1] % 24;
                                time[0]++;
                            }
                        }

                        db.connection.Close();

                        db.connection.Open();
                        command.CommandText = "SELECT train, type, cost FROM rout WHERE flight = ?f AND departure = ?s AND destination = ?d";
                        command.Parameters.AddWithValue("?s", this.from.SelectedItem.ToString());
                        reader = command.ExecuteReader();

                        while (reader.Read())
                            possible.Add(new string[7] { prob[i][0], reader[0].ToString(), rout, (int.Parse(id) - int.Parse(prob[i][1])).ToString(),
                            String.Join(":", time), reader[1].ToString(), reader[2].ToString()});
                        db.connection.Close();
                    }
                }
                catch
                {
                    prob.Remove(prob[i]);
                }


            this.search_result.ItemsSource = possible;
        }


        private void start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                initialize_rout();
            }
            catch
            {
                MessageBox.Show("Ничего не найдено", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.to.IsEnabled = true;
            initialize_to();
        }
    }
}
