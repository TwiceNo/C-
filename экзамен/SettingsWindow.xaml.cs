﻿using System;
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

        private void initialize_content()       // инициализация полей текущими настройками
        {
            this.path_t.Text = settings.path_t;
            this.save_tickets.IsChecked = settings.printable;
        }


        // выбор папок

        private void browser_t_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.path_t.Text = dialog.SelectedPath;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            settings.path_t = this.path_t.Text + "\\";
            settings.write_down();
            this.Close();
        }

        private void save_tickets_Click(object sender, RoutedEventArgs e)
        {
            settings.printable = !settings.printable;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void default_Click(object sender, RoutedEventArgs e)
        {
            this.settings.set_default();
            initialize_content();
        }
    }
}
