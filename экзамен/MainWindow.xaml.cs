using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool StateClosed = false;
        Current_User user;
        GeneralSettings gen_settings;

        public MainWindow()
        {
            InitializeComponent();
            if (initialize_user())
            {
                this.Title = "Касса " + user.ticket_window;
                this.username.Text = String.Join(" ", new string[2] { user.name, user.patronymic });
                if (user.photo != null)
                    this.photo.ImageSource = new BitmapImage(new Uri(user.photo, UriKind.Relative));
                gen_settings = new GeneralSettings();
                AllRoutes page = new AllRoutes();
                this.Page.Navigate(page);
            }
            else this.Close();
        }


        private void credits_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SideMenuSwitcher_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SideMenuSwitcher.RotationAngle = 0;

                if (StateClosed)
                {
                    Storyboard sb = this.FindResource("SideMenuOpen") as Storyboard;
                    sb.Begin();
                }
                else
                {
                    SideMenuSwitcher.RotationAngle = 180;
                    Storyboard sb = this.FindResource("SideMenuClose") as Storyboard;
                    sb.Begin();
                }

                StateClosed = !StateClosed;
            }
        }

        private void search_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Search page = new Search();
            this.Page.Navigate(page);
        }

        private void summary_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void last_routes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LastRoutes page = new LastRoutes();
            this.Page.Navigate(page);
        }

        private void all_routes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AllRoutes page = new AllRoutes();
            this.Page.Navigate(page);
        }

        private void tickets_Click(object sender, RoutedEventArgs e)
        {
            SellingWindow window = new SellingWindow(user, gen_settings);
            window.Owner = this;
            window.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult res = System.Windows.MessageBox.Show("Закрыть приложение?", "Выход", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.No)
                e.Cancel = true;
            else e.Cancel = false;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow(gen_settings);
            window.Show();
            gen_settings = window.settings;
        }

        private bool initialize_user()
        {
            user = new Current_User();
            if (user == null) return false;
            else return true;
        }

        private void edit_profile_Click(object sender, RoutedEventArgs e)
        {
            EditProfile window = new EditProfile(user);
            window.ShowDialog();
            this.user = window.user;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            user.logout();
            this.Close();
        }
    }
}
