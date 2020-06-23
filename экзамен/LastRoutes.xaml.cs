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
    /// Логика взаимодействия для LastRoutes.xaml
    /// </summary>
    public partial class LastRoutes : Page, IInformationalPage
    {
        public LastRoutes()
        {
            InitializeComponent();
            initialize_content();
        }


        public void initialize_content()
        {
            List<string[]> rows = read_data();
            this.grid.ItemsSource = rows;
        }

        private List<string[]> read_data()
        {
            List<string[]> rows = new List<string[]>();
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");

            Database db = new Database();
            db.connection.Open();

            // выбор всех еще не ушедших рейсов

            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT arrivalH, arrivalM, train, flight, `departure point`, destination, departureH, departureM " +
                "FROM `traffic`.`all traffic` " +
                "WHERE ((arrivalH > ?h) OR (arrivalH = ?h AND arrivalM > ?m)) OR ((departureH > ?h) " +
                "OR (departureH = ?h AND departureM > ?m))";
            comm.Parameters.AddWithValue("?h", hour);
            comm.Parameters.AddWithValue("?m", minute);
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                string[] row = new string[5];
                bool arrives = false;

                // определение статуса рейса - отправляется или прибывает

                if ((int.Parse(reader[0].ToString()) > int.Parse(hour))
                    || (int.Parse(reader[0].ToString()) == int.Parse(hour)
                    && (int.Parse(reader[1].ToString()) > int.Parse(minute))))
                    arrives = true;

                row[1] = reader[2].ToString();
                row[2] = reader[3].ToString();
                row[3] = reader[4].ToString() + " — " + reader[5].ToString();

                if (arrives)
                {
                    row[4] = "Прибывает";
                    row[0] = reader[0].ToString() + ":" + reader[1].ToString();
                }
                else
                {
                    row[4] = "Отправляется";
                    row[0] = reader[6].ToString() + ":" + reader[7].ToString();
                }
                    rows.Add(row);
            }

            db.connection.Close();

            return rows;
        }

    }
}
