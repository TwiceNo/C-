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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Working_Environment.xaml
    /// </summary>
    public partial class Working_Environment : Window
    {
        bool StateClosed = false;

        public Working_Environment()
        {
            InitializeComponent();
        }


        private void credits_Click(object sender, RoutedEventArgs e)
        {

        }

        private void all_routes_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void search_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void summary_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void last_routes_MouseDown(object sender, MouseButtonEventArgs e)
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
    }
}
