using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AllRoutes.xaml
    /// </summary>
    public partial class AllRoutes : Page, IInformationalPage
    {
        public AllRoutes()
        {
            InitializeComponent();
            initialize_content();
        }


        public void initialize_content()
        {
            List<string[]> routes = read_routes();

            foreach (string[] rout in routes)
                add_items(rout, get_stations(rout));
        }


        private List<string[]> read_routes()        // чтение всех различных рейсов
        {
            List<string[]> routes = new List<string[]>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT DISTINCT flight, `departure point`, destination FROM `all traffic`";     
            MySqlDataReader reader = comm.ExecuteReader();

            while(reader.Read())
            {
                string[] rout = new string[2] { reader[0].ToString(), reader[1].ToString() + " — " + reader[2].ToString() };
                routes.Add(rout);
            }

            db.connection.Close();

            return routes;
        }


        private List<station> get_stations(string[] flight)     // выбор всех остановок рейса
        {
            List<station> rout = new List<station>();
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT station, `travel time`, `stop time` FROM rout WHERE flight = ?f ORDER BY id";    
            comm.Parameters.AddWithValue("?f", flight[0]);
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                station s = new station(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                rout.Add(s);
            }

            db.connection.Close();

            return rout;
        }


        private void add_items(string[] rout, List<station> stations)   // добавление данных в tree view 
        {
            TreeViewItem header = new TreeViewItem();
            header.Header = rout[0] + ": " + rout[1];
            foreach(station s in stations)
            {
                TreeViewItem subheader = new TreeViewItem();
                subheader.Header = s.city;
                header.Items.Add(subheader);
            }
            this.routs_view.Items.Add(header);
        }
    }

    public struct station
    {
        public string city, time, stop_time;

        public station(string city, string time, string stop_time)
        {
            this.city = city;
            this.time = time;
            this.stop_time = stop_time;
        }
    }
}
