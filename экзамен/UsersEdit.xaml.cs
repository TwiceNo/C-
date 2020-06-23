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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для UsersEdit.xaml
    /// </summary>
    public partial class UsersEdit : Window
    {
        List<string[]> items;

        public UsersEdit()
        {
            InitializeComponent();
            initialize_items();
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add_item();
            initialize_items();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.datagrid.SelectedItem == null)
            {
                this.popup_text.Text = "Сначала нужно выбрать строку";
                this.popup.IsOpen = true;
            }
            else
            {
                this.popup.IsOpen = false;
                delete_item(this.datagrid.SelectedIndex);
                initialize_items();
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (this.datagrid.SelectedItem == null)
            {
                this.popup_text.Text = "Сначала нужно выбрать строку";
                this.popup.IsOpen = true;
            }
            else
            {
                this.popup.IsOpen = false;
                update(this.datagrid.SelectedIndex);
                initialize_items();
            }
        }


        private void initialize_items()     // чтение данных обо всех пользователях
        {
            items = new List<string[]>();

            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT login, surname, name, patronymic, `ticket window` FROM `personal data` ORDER BY surname, name, patronymic";
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
                items.Add(new string[5] {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString()});
            db.connection.Close();

            this.datagrid.ItemsSource = items;      // связывание с data grid
        }

        private void update(int index)
        {
            string login = items[index][0];

            ItemChange win = new ItemChange(login);
            win.ShowDialog();
        }

        private void add_item()
        {
            ItemChange win = new ItemChange();
            win.ShowDialog();
        }

        private void delete_item(int index)
        {
            string login = items[index][0];

            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "DELETE FROM users WHERE login = ?l";
            comm.Parameters.AddWithValue("?l", login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }
    }
}
