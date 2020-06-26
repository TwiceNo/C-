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
        Dictionary<Key, Action> act;

        public MainWindow()
        {
            InitializeComponent();
            if (initialize_user())      // инициализация пользователя
            {
                initialize_act();
                this.Title = "Касса " + user.ticket_window;
                this.username.Text = String.Join(" ", new string[2] { user.name, user.patronymic });
                if (user.photo != null)
                    this.photo.ImageSource = new BitmapImage(new Uri(user.photo, UriKind.Relative));

                gen_settings = new GeneralSettings();
            }
            else this.Close();
        }


        //-----------------------------------
        //-----------INITIALIZE--------------
        //-----------------------------------

        private void initialize_act()
        {
            act = new Dictionary<Key, Action>();
            act.Add(Key.Escape, this.Close);
            act.Add(Key.F1, show_settings);
            act.Add(Key.F2, show_tickets);
            act.Add(Key.F3, show_credits);
            act.Add(Key.F4, show_profile);
            act.Add(Key.A, show_routes);
            act.Add(Key.T, show_table);
            act.Add(Key.S, show_summary);
            act.Add(Key.F, show_search);
        }

        private bool initialize_user()
        {
            user = new Current_User();
            if (user == null) return false;
            else return true;
        }


        //-----------------------------------
        //------------HANDLERS---------------
        //-----------------------------------


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult res = System.Windows.MessageBox.Show("Закрыть приложение?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.No)
                e.Cancel = true;
            else e.Cancel = false;
        }

        private void edit_profile_Click(object sender, RoutedEventArgs e)
        {
            show_profile();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            user.logout();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (act.ContainsKey(e.Key))
                act[e.Key].Invoke();
        }

        //SideMenu

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
            show_search();
        }

        private void summary_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_summary();
        }

        private void last_routes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_table();
        }

        private void all_routes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            show_routes();
        }


        //MainMenu

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            show_settings();
        }

        private void tickets_Click(object sender, RoutedEventArgs e)
        {
            show_tickets();
        }

        private void credits_Click(object sender, RoutedEventArgs e)
        {
            show_credits();
        }


        //-----------------------------------
        //--------------SHOW-----------------
        //-----------------------------------
         
        private void show_profile()
        {
            EditProfile window = new EditProfile(user);
            window.ShowDialog();
            this.user = window.user;
        } 

        //Pages

        private void show_routes()
        {
            AllRoutes page = new AllRoutes();
            this.Page.Navigate(page);
        }

        private void show_table()
        {
            LastRoutes page = new LastRoutes();
            this.Page.Navigate(page);
        }

        private void show_summary()
        {
            Summary page = new Summary();
            this.Page.Navigate(page);
        }

        private void show_search()
        {
            Search page = new Search();
            this.Page.Navigate(page);
        }


        //Windows

        private void show_credits()
        {
            CreditsWindow window = new CreditsWindow();
            window.Owner = this;
            window.Show();
        }

        private void show_tickets()
        {
            SellingWindow window = new SellingWindow(user, gen_settings);
            window.Owner = this;
            window.ShowDialog();
        }

        private void show_settings()
        {
            SettingsWindow window = new SettingsWindow(gen_settings);
            window.Show();
            gen_settings = window.settings;
        }
    }
}
