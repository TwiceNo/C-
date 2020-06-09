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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            login_text = username.Text;
            password_text = password.Password;
            connection_check(login_text, password_text);
           
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
            this.Close();
        }

        private void connection_check(string login, string password)
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
                    privilege = temp;
                    connected = true;
                    this.Close();
                }
            }
            catch
            {
                MessageBox error = new MessageBox("Ошибка", "Неверный логин или пароль");
                error.Owner = this;
                error.ShowDialog();
                connected = false;
            }

            db.connection.Close();
        }
    }
}
