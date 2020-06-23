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
using System.Globalization;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ItemChange.xaml
    /// </summary>
    public partial class ItemChange : Window
    {
        bool update_mode;
        string login;
        List<Action> delegates;

        public ItemChange()
        {
            InitializeComponent();
            this.login = generate();
            this.delegates = new List<Action>();
        }

        public ItemChange(string login)
        {
            InitializeComponent();
            this.update_mode = true;
            this.login = login;
            this.delegates = new List<Action>();
            initialize_fields();
        }

        private void initialize_fields()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT surname, name, patronymic, `ticket window` FROM `personal data` WHERE login = ?l";
            comm.Parameters.AddWithValue("?l", this.login);
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            this.surname.Text = reader[0].ToString();
            this.name.Text = reader[1].ToString();
            this.patronymic.Text = reader[2].ToString();
            this.twind.Text = reader[3].ToString();
            db.connection.Close();
        }

        private void name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Char.IsDigit(e.Text, 0);
        }

        private void name_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextInfo t = new CultureInfo("ru-RU", false).TextInfo;
            this.name.Text = t.ToTitleCase(this.name.Text);
        }

        private void surname_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextInfo t = new CultureInfo("ru-RU", false).TextInfo;
            this.surname.Text = t.ToTitleCase(this.surname.Text);
        }

        private void surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Char.IsDigit(e.Text, 0);
        }

        private void patronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Char.IsDigit(e.Text, 0);
        }

        private void patronymic_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextInfo t = new CultureInfo("ru-RU", false).TextInfo;
            this.patronymic.Text = t.ToTitleCase(this.patronymic.Text);
        }

        private void twind_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private string generate()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT COUNT(*) FROM users";

            int index = int.Parse(comm.ExecuteScalar().ToString()) + 1;

            string log = index.ToString();
            while (log.Length < 4)
                log = "0" + log;
            return "e" + log;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (!update_mode)
                add_all();
            else
                foreach (Action action in delegates)
                    action.Invoke();
            this.Close();
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!delegates.Contains(update_s))
                delegates.Add(update_s);
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!delegates.Contains(update_n))
                delegates.Add(update_n);
        }

        private void patronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!delegates.Contains(update_p))
                delegates.Add(update_p);
        }

        private void twind_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!delegates.Contains(update_t))
                delegates.Add(update_t);
        }

        private void add_all() 
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "INSERT INTO users (login) VALUES (?l)";
            comm.Parameters.AddWithValue("?l", this.login);
            comm.ExecuteNonQuery();
            db.connection.Close();

            db.connection.Open();
            comm.CommandText = "INSERT INTO `personal data` (login, surname, name, patronymic, `ticket window`) " +
                "VALUES (?l, ?s, ?n, ?p, ?t)";
            comm.Parameters.AddWithValue("?s", this.surname.Text);
            comm.Parameters.AddWithValue("?n", this.name.Text);
            comm.Parameters.AddWithValue("?p", this.patronymic.Text);
            comm.Parameters.AddWithValue("?t", this.twind.Text);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }

        private void update_n() 
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET name = ?n WHERE login = ?l";
            comm.Parameters.AddWithValue("?n", this.name.Text);
            comm.Parameters.AddWithValue("?l", this.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }

        private void update_s() 
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET surname = ?n WHERE login = ?l";
            comm.Parameters.AddWithValue("?n", this.surname.Text);
            comm.Parameters.AddWithValue("?l", this.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }
        
        private void update_p()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET patronymic = ?n WHERE login = ?l";
            comm.Parameters.AddWithValue("?n", this.patronymic.Text);
            comm.Parameters.AddWithValue("?l", this.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }
        
        private void update_t() 
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET `ticket window` = ?n WHERE login = ?l";
            comm.Parameters.AddWithValue("?n", this.twind.Text);
            comm.Parameters.AddWithValue("?l", this.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }
    }
}
