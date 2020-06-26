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
    /// Логика взаимодействия для Summary.xaml
    /// </summary>
    public partial class Summary : Page, IInformationalPage
    {
        List<string[]> items;

        public Summary()
        {
            InitializeComponent();
            items = new List<string[]>();
            initialize_content();
        }

        public void initialize_content()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT * FROM `sold tickets`";
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
                items.Add(new string[3] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() });
            this.datagrid.ItemsSource = items;
        }
    }
}
