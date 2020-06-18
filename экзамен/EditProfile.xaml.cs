using Microsoft.Win32;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        public Current_User user;
        List<Action> delegates;         // список делегатов, которые будут вызваны для изсенения данных
        string path, name;

        public EditProfile(Current_User user)
        {
            InitializeComponent();

            delegates = new List<Action>();
            this.user = user;
            this.username.Text = String.Join(" ", new string[3] { user.surname, user.name, user.patronymic });
            if (this.user.privileged)
                this.extras.Visibility = Visibility.Visible;
            else
                this.extras.Visibility = Visibility.Hidden;
            this.newpassword.IsEnabled = false;
        }

        private void browser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Filter = "Изображения (*.jpeg; *.jpg; *.png)|*.jpeg; *.jpg; *.png";
            if (browse.ShowDialog() == true)
            {
                path = browse.FileName;
                name = browse.SafeFileName;
                delegates.Add(change_photo);
            }
        }

        private void user_edit_Click(object sender, RoutedEventArgs e)
        {
            UsersEdit window = new UsersEdit();
            window.Show();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (this.login_check.IsOpen || this.newpass.IsOpen || this.not_match.IsOpen)
                MessageBox.Show("Не все данные введены корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                delegates.Distinct();
                foreach (Action item in delegates)
                    item.Invoke();
                this.Close();
            }
        }

        private void newpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!proper_password())
                this.newpass.IsOpen = true;
            else this.newpass.IsOpen = false;

            delegates.Add(change_password);
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!password_check())
                this.not_match.IsOpen = true;
            else
            {
                this.not_match.IsOpen = false;
                this.newpassword.IsEnabled = true;
            }
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!check_login())
                this.login_check.IsOpen = true;
            else this.login_check.IsOpen = false;

            delegates.Add(change_login);
        }

        private void copy_photo()
        {
            delete_photo();
            string new_path = "z:\\user_photos\\" + path.Replace(name, user.login).Substring(path.LastIndexOf('\\'));
            File.Copy(path, new_path);

            user.photo = new_path;

            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET photo = ?p WHERE login = ?l";
            comm.Parameters.AddWithValue("?p", new_path);
            comm.Parameters.AddWithValue("?l", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }

        private void delete_photo()
        {
            if (user.photo != null) File.Delete(user.photo);
        }

        private bool check_login()
        {
            if (spell_check(this.login.Text))
                if (unique_check())
                    return true;
                else
                    this.login_popup_text.Text = "Имя пользователя уже занято";
            else this.login_popup_text.Text = "Неподходящий логин: минимум 4 символа, буквы и/или цифры";
            return false;
        }

        private bool password_check()
        {
            return user.password == this.password.Password;
        }

        private bool proper_password()
        {
            return spell_check(this.newpassword.Password);
        }

        private bool spell_check(string some)
        {
            if (some.Length < 4) return false;
            else
            {
                List<string> restricted = new List<string>() { " ", "\"", "\\", "\'", "`" };
                foreach (string item in restricted)
                    if (some.Contains(item)) return false;
                return true;
            }
        }

        private bool unique_check()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT login FROM users WHERE login = ?l";

            try 
            {
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                string similar = reader[0].ToString();
                return false;
            }
            catch 
            {
                return true;
            }
        }

        private void change_login()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE users SET login = ?nl WHERE login = ?cl";
            comm.Parameters.AddWithValue("?nl", this.login.Text);
            comm.Parameters.AddWithValue("?cl", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();

            user.login = this.login.Text;
        }

        private void change_password()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE users SET password = ?np WHERE login = ?cl";
            comm.Parameters.AddWithValue("?nl", this.password.Password);
            comm.Parameters.AddWithValue("?cl", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();

            user.password = this.password.Password;
        }

        private void change_photo()
        {
            copy_photo();
        }
    }
}
