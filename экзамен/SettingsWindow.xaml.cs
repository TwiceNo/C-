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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public GeneralSettings settings;

        public SettingsWindow(GeneralSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
            initialize_content();
        }

        private void initialize_content()
        {
            this.path_s.Text = settings.path_s;
            this.path_t.Text = settings.path_t;
            this.save_tickets.IsChecked = settings.printable;
        }

        private void browser_s_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.path_s.Text = dialog.SelectedPath;
                settings.path_s = dialog.SelectedPath;
            }
        }

        private void browser_t_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.path_t.Text = dialog.SelectedPath;
                settings.path_t = dialog.SelectedPath;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            settings.write_down();
        }

        private void save_tickets_Click(object sender, RoutedEventArgs e)
        {
            settings.printable = !settings.printable;
        }
    }
}
