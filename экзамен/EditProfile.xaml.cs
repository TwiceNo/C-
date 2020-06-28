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
        public string path;
        public Current_User user;
        public ImageBrush mw_photo;
        List<Action> delegates;         // список делегатов, которые будут вызваны для изменения данных
        

        public EditProfile(Current_User user, ImageBrush photo)
        {
            InitializeComponent();

            delegates = new List<Action>();
            this.user = user;
            this.mw_photo = photo;
            this.username.Text = String.Join(" ", new string[3] { user.surname, user.name, user.patronymic });
            this.newpassword.IsEnabled = false;
            set_photo();
            if (this.user.privileged)
                this.extras.Visibility = Visibility.Visible;
            else
                this.extras.Visibility = Visibility.Hidden;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void browser_Click(object sender, RoutedEventArgs e)        // для смены иконки потребуется перезапуск программы
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Filter = "Изображения (*.jpeg; *.jpg; *.png)|*.jpeg; *.jpg; *.png";
            if (browse.ShowDialog() == true)
            {
                path = browse.FileName;
                if (!delegates.Contains(change_photo))
                    delegates.Add(update_photo);
                change_photo();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.user.photo = null;
            set_photo();
            if (!delegates.Contains(delete_photo))
                delegates.Add(update_photo);
        }

        private void user_edit_Click(object sender, RoutedEventArgs e)
        {
            UsersEdit window = new UsersEdit();
            window.Show();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.photo.ImageSource = null;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (this.login_check.IsOpen || this.newpass.IsOpen || this.not_match.IsOpen)
                MessageBox.Show("Не все данные введены корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                foreach (Action item in delegates)
                    item.Invoke();
                user.write_down();
                this.Close();
            }
        }

        private void newpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!proper_password())
                this.newpass.IsOpen = true;
            else this.newpass.IsOpen = false;

            if(!delegates.Contains(change_password))
                delegates.Add(change_password);
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)     // новый пароль может быть установлен только при введенном старом
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

            if (!delegates.Contains(change_login))
                delegates.Add(change_login);
        }

        private void change_photo()       //"загрузка" картинки на "сервер"
        {
            string ext = path.Substring(path.LastIndexOf('.'));
            string new_path = "z:\\user_photos\\" + generate() + ext;

            File.Copy(path, new_path);

            this.user.photo = new_path;

            set_photo();
        }

        private void update_photo()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET photo = ?p WHERE login = ?l";
            comm.Parameters.AddWithValue("?p", user.photo);
            comm.Parameters.AddWithValue("?l", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }

        private void delete_photo()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `personal data` SET photo = NULL WHERE login = ?l";
            comm.Parameters.AddWithValue("?l", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();
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
                List<string> restricted = new List<string>() { " ", "\"", "\\", "\'", "`" };    // запрещены символы, которые могут быть неверно интерпретированы
                foreach (string item in restricted)
                    if (some.Contains(item)) return false;
                return true;
            }
        }

        private bool unique_check()     // проверка на уникальность логина
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT login FROM users WHERE login = ?l";
            comm.Parameters.AddWithValue("?l", this.login.Text);
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
            comm.Parameters.AddWithValue("?np", this.newpassword.Password);
            comm.Parameters.AddWithValue("?cl", user.login);
            comm.ExecuteNonQuery();
            db.connection.Close();

            user.password = this.newpassword.Password;
        }

        private void set_photo()    //установка пользовательской картинки сразу на главном окне и в окне профиля
        {
            if(this.user.photo != null)
            {
                this.photo.ImageSource = new BitmapImage(new Uri(user.photo, UriKind.Relative));
                this.photo_holder.Visibility = Visibility.Visible;
                this.mw_photo.ImageSource = new BitmapImage(new Uri(user.photo, UriKind.Relative));
            }
            else
            {
                this.photo_holder.Visibility = Visibility.Collapsed;
                this.mw_photo.ImageSource = new BitmapImage(new Uri(@"z:\\user_photos\\no_user_photo.png", UriKind.Relative));
            }
        }

        private string generate()   //генерация имени файла
        {
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            string name = "";
            Random random = new Random();
            for (int i = 0; i < 16; i++)
                name += chars[random.Next(chars.Length)];
            return name;
        }

    }
}
