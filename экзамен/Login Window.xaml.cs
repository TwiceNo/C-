using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public bool connected, check_stay, privilege;
        public string login_text, password_text;


        public Login_Window()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)    // возможность перемещать окно
        {
            if (this.error.IsOpen)
                this.error.IsOpen = false;

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            connection_check(username.Text, password.Password);
        }

        private void stay_Checked(object sender, RoutedEventArgs e)
        {
            check_stay = true;
        }

        private void stay_Unchecked(object sender, RoutedEventArgs e)
        {
            check_stay = false;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            connected = false;
            Close();
        }
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void connection_check(string login, string password)    // пытается найти соответствующего пользователя
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT privileged FROM users WHERE login = ?log AND password = ?pas";
            comm.Parameters.AddWithValue("?log", login);
            comm.Parameters.AddWithValue("?pas", password);

            MySqlDataReader reader = comm.ExecuteReader();

            reader.Read();
            try
            {
                if (bool.TryParse(reader[0].ToString(), out bool temp))
                {
                    this.privilege = temp;
                    this.connected = true;
                    this.login_text = login;
                    this.password_text = password;
                    this.Close();
                }
            }
            catch   // показ сообщения об ошибке
            {
                this.error.IsOpen = true;
                connected = false;
            }

            db.connection.Close();
        }
    }
}
