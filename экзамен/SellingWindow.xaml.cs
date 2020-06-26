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
using WpfApp2.Properties;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SellingWindow.xaml
    /// </summary>
    /// 

    public struct Rout
    {
        public string name { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public string rout { get; set; }
        public string train { get; set; }
        public string dH { get; set; }
        public string dM { get; set; }
        public string type { get; set; }
        public int left { get; set; }
    }


    public partial class SellingWindow : Window
    {
        Rout curr_rout;
        Current_User user;
        GeneralSettings settings;

        public SellingWindow(Current_User user, GeneralSettings settings)
        {
            InitializeComponent();

            this.user = user;
            this.settings = settings;
            curr_rout = new Rout();
            disable_components();
            initialize_depr();
        }


        //-----------------------------
        //------INITIALIZATION---------
        //-----------------------------

        private void disable_components()
        {
            this.rout.IsEnabled = false;
            this.carriage.IsEnabled = false;
            this.num.IsEnabled = false;
            this.confirm.IsEnabled = false;
        }

        private void initialize_depr()
        {
            this.departure.ItemsSource = new string[1] { "Краснодар" };
            this.departure.SelectedItem = "Краснодар";
        }

        private void initialize_dest()
        {
            string dep = this.departure.SelectedItem.ToString();
            List<string[]> probably = new List<string[]>();
            List<string> possible = new List<string>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT flight, id FROM rout WHERE station = ?s";       // выборка рейсов, включающих пункт отправления
            comm.Parameters.AddWithValue("?s", dep);

            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
                probably.Add(new string[2] { reader[0].ToString(), reader[1].ToString() });

            db.connection.Close();

            foreach (string[] prob in probably)
            {
                db = new Database();
                db.connection.Open();
                MySqlCommand command = db.connection.CreateCommand();

                command.CommandText = "SELECT station FROM rout WHERE flight = ?f AND id > ?id";    // выборка всех остановок, куда можно добраться текущим рейсом
                command.Parameters.AddWithValue("?f", prob[0]);
                command.Parameters.AddWithValue("?id", prob[1]);

                reader = command.ExecuteReader();

                while (reader.Read())
                    possible.Add(reader[0].ToString());

                db.connection.Close();
            }

            possible.Distinct();
            possible.Sort();

            this.destination.ItemsSource = possible;
        }

        private void initialize_rout()
        {
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");

            List<string[]> prob = new List<string[]>();
            List<string> possible = new List<string>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT flight, id FROM rout WHERE station = ?s";        // посик рейса, включающего пункт отправления и его id
            comm.Parameters.AddWithValue("?s", curr_rout.departure);
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
                prob.Add(new string[2] { reader[0].ToString(), reader[1].ToString() });

            db.connection.Close();

            for (int i =0; i<prob.Count; i++)
                try
                {
                    db = new Database();
                    db.connection.Open();
                    MySqlCommand cmd = db.connection.CreateCommand();

                    cmd.CommandText = "SELECT id FROM rout WHERE station = ?d AND flight = ?f AND id > ?id";    // проверка возможности добраться в пункт назначения текущим рейсом
                    cmd.Parameters.AddWithValue("?d", curr_rout.destination);
                    cmd.Parameters.AddWithValue("?f", prob[i][0]);
                    cmd.Parameters.AddWithValue("?id", prob[i][1]);

                    reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        string id = reader[0].ToString();

                        db = new Database();
                        db.connection.Open();
                        MySqlCommand command = db.connection.CreateCommand();

                        command.CommandText = "SELECT departureH, departureM, `departure point`, destination, train FROM `all traffic` " +      // взятие данных о рейсе, если он еще доступен по времени
                        "WHERE flight = ?f AND `left` > 0 AND ((departureH > ?h) OR (departureH = ?h AND departureM > ?m))" +
                        " ORDER BY departureH, departureM";                                                                                     
                        command.Parameters.AddWithValue("?f", prob[i][0]);
                        command.Parameters.AddWithValue("?h", hour);
                        command.Parameters.AddWithValue("?m", minute);

                        MySqlDataReader reader1 = command.ExecuteReader();

                        while (reader1.Read())
                            possible.Add(String.Join(" ", new string[4] { reader1[0].ToString() + ":" + reader1[1].ToString(),
                        prob[i][0], reader1[4].ToString(), reader1[2].ToString() + " — " + reader1[3].ToString()}));

                        db.connection.Close();
                    }
                    
                    db.connection.Close();
                }
                catch
                {
                    prob.Remove(prob[i]);
                }

            if (possible.Count > 0)
                possible.Sort();

            this.rout.ItemsSource = possible;
        }

        private void initialize_carr()
        {
            List<string> possible = new List<string>();

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT type FROM trains " +
                "WHERE departureH = ?h AND departureM = ?m AND flight = ?f AND train = ?t AND `left` > 0 " +        // определение доступных вагонов (их типов)
                "ORDER BY type";
            comm.Parameters.AddWithValue("?h", curr_rout.dH);
            comm.Parameters.AddWithValue("?m", curr_rout.dM);
            comm.Parameters.AddWithValue("?f", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);

            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                db = new Database();
                db.connection.Open();
                MySqlCommand command = db.connection.CreateCommand();

                command.CommandText = "SELECT name FROM types WHERE type = ?с";
                command.Parameters.AddWithValue("?с", reader[0].ToString());

                possible.Add(command.ExecuteScalar().ToString());

                db.connection.Close();
            }

            db.connection.Close();

            this.carriage.ItemsSource = possible;
        }

        private void initialize_numt()
        {
            curr_rout.left = 0;

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT `left` FROM trains " +
                "WHERE departureH = ?h AND departureM = ?m AND flight = ?f AND train = ?t AND `left` > 0 AND type = ?ty " +     // определение количества доступных билетов
                "ORDER BY type";
            comm.Parameters.AddWithValue("?h", curr_rout.dH);
            comm.Parameters.AddWithValue("?m", curr_rout.dM);
            comm.Parameters.AddWithValue("?f", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);
            comm.Parameters.AddWithValue("?ty", curr_rout.type);

            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
                curr_rout.left += int.Parse(reader[0].ToString());

            db.connection.Close();
        }


        //-----------------------------
        //---------HANDLERS------------
        //-----------------------------

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void departure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curr_rout.departure = this.departure.SelectedItem.ToString();
            this.destination.IsEnabled = true;
            initialize_dest();

            if (this.num.Text.Length > 0) calculate_sum(int.Parse(this.num.Text));

        }

        private void destination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curr_rout.destination = this.destination.SelectedItem.ToString();
            this.rout.IsEnabled = true;
            initialize_rout();

            if (this.num.Text.Length > 0) calculate_sum(int.Parse(this.num.Text));

        }

        private void rout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] selected_rout = this.rout.SelectedItem.ToString().Split(' ');
            curr_rout.dH = selected_rout[0].Split(':')[0];
            curr_rout.dM = selected_rout[0].Split(':')[1];
            curr_rout.rout = selected_rout[1];
            curr_rout.train = selected_rout[2];
            curr_rout.name = selected_rout[3] + " — " + selected_rout[5];
            this.carriage.IsEnabled = true;
            initialize_carr();

            if (this.num.Text.Length > 0) calculate_sum(int.Parse(this.num.Text));
        }

        private void carriage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curr_rout.type = get_carriage_type(this.carriage.SelectedItem.ToString());
            
            this.num.IsEnabled = true;
            initialize_numt();
            this.confirm.IsEnabled = true;

            if (this.num.Text.Length > 0) calculate_sum(int.Parse(this.num.Text));
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (check_fields() == 1)
            {
                print_ticket(int.Parse(this.num.Text));
                change_left(int.Parse(this.num.Text));
                update_sum(float.Parse(this.sum.Text));
                this.Close();
            }
            else
                if (check_fields() == 0)
                MessageBox.Show("Выбрано неподходящее количество билетов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Выбраны неверные параметры рейса", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void num_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { calculate_sum(int.Parse(this.num.Text)); }
            catch
            {
                this.sum.Text = null;
            }
        }

        private void num_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.popup_text.Text = "Осталось свободных мест: " + curr_rout.left;
            this.tickets_left.IsOpen = true;
        }

        private void num_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.tickets_left.IsOpen = false;
        }


        //-----------------------------
        //-----------METHODS-----------
        //-----------------------------

        private string get_carriage_type(string name)
        {
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "SELECT type FROM types WHERE name = ?n";
            comm.Parameters.AddWithValue("?n", name);

            string type = comm.ExecuteScalar().ToString();
            db.connection.Close();

            return type;
        }

        private int check_fields()
        {
            if (this.num.Text == "0" || this.num.Text.Length == 0 || int.Parse(this.num.Text) > curr_rout.left)
                return 0;
            if (this.sum.Text.Length == 0 || this.sum.Text == "0")
                return 2;
            return 1;
        }

        private void calculate_sum(int num)
        {
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT cost FROM price WHERE rout = ?r AND train = ?t AND departure = ?a AND destination = ?b AND type = ?c";
            comm.Parameters.AddWithValue("?r", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);
            comm.Parameters.AddWithValue("?a", curr_rout.departure);
            comm.Parameters.AddWithValue("?b", curr_rout.destination);
            comm.Parameters.AddWithValue("?c", curr_rout.type);

            try
            {
                float cost = float.Parse(comm.ExecuteScalar().ToString());
                float total = num * cost;
                this.sum.Text = total.ToString();
            }
            catch
            {
                this.sum.Text = null;
            }
        }

        private void print_ticket(int num)
        {
            if (settings.printable)
                for (int i = 0; i < num; i++)
                {
                    int n = get_ticket_num();
                    int[] c = get_carriage();
                    string ticket = "Билет " + n + "\n";
                    ticket += "Рейс " + curr_rout.rout + " ";
                    ticket += curr_rout.name + "\n";
                    ticket += "Начальная остановка " + curr_rout.departure + "\n";
                    ticket += "Конечная остановка " + curr_rout.destination + "\n";
                    ticket += "Время отправления " + curr_rout.dH +":"+curr_rout.dM + " " + DateTime.Now.ToString("dd/mm/yyyy") + "\n";
                   // ticket += "Время прибытия " + get_time() + "\n";
                    ticket += "Платформа " + get_platform() + "\n";
                    ticket += "Состав " + curr_rout.train + "\n";
                    ticket += "Вагон " + (c[0] + 1) + " " + curr_rout.type + "\n";
                    ticket += "Место " + c[1] + "\n";
                    ticket += "Стоимость " + (float.Parse(this.sum.Text) / num) + "\n";
                    ticket += "Кассир " + user.surname + " " + user.name + " " + user.patronymic;

                    if (!Directory.Exists(settings.path_t))
                        Directory.CreateDirectory(settings.path_t);
                    File.WriteAllText(settings.path_t + "ticket" + n + ".txt", ticket);
                }
        }

        private void change_left(int num)
        {
            int current = get_current_left(1);

            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();
            comm.CommandText = "UPDATE `all traffic` SET `left` = ?l1 WHERE " +
                "flight = ?f AND train = ?t AND departureH = ?h AND departureM = ?m";
            comm.Parameters.AddWithValue("?l1", current - num);
            comm.Parameters.AddWithValue("?f", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);
            comm.Parameters.AddWithValue("?a", curr_rout.departure);
            comm.Parameters.AddWithValue("?b", curr_rout.destination);
            comm.Parameters.AddWithValue("?h", curr_rout.dH);
            comm.Parameters.AddWithValue("?m", curr_rout.dM);
            comm.ExecuteNonQuery();
            db.connection.Close();

            current = get_current_left(2);

            db.connection.Open();
            comm.CommandText = "UPDATE trains SET `left` = ?l2 WHERE " +
                "flight = ?f AND train = ?t AND departureH = ?h AND departureM = ?m AND type = ?c";
            comm.Parameters.AddWithValue("?l2", current - num);
            comm.Parameters.AddWithValue("?c", curr_rout.type);
            comm.ExecuteNonQuery();
            db.connection.Close();
        }

        private int get_current_left(int table)
        {
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            if (table == 1)
            {
                comm.CommandText = "SELECT `left` FROM `all traffic` WHERE " +
                    "flight = ?f AND train = ?t AND  departureH = ?h AND departureM = ?m";
                comm.Parameters.AddWithValue("?f", curr_rout.rout);
                comm.Parameters.AddWithValue("?t", curr_rout.train);
                comm.Parameters.AddWithValue("?h", curr_rout.dH);
                comm.Parameters.AddWithValue("?m", curr_rout.dM);
            }
            else
            {
                comm.CommandText = "SELECT `left` FROM trains WHERE " +
                    "flight = ?f AND train = ?t AND departureH = ?h AND departureM = ?m AND type = ?c";
                comm.Parameters.AddWithValue("?f", curr_rout.rout);
                comm.Parameters.AddWithValue("?t", curr_rout.train);
                comm.Parameters.AddWithValue("?h", curr_rout.dH);
                comm.Parameters.AddWithValue("?m", curr_rout.dM);
                comm.Parameters.AddWithValue("?c", curr_rout.type);
            }

            return int.Parse(comm.ExecuteScalar().ToString());
        }

        private int get_ticket_num()
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT sold FROM `sold tickets`";
            MySqlDataReader reader = comm.ExecuteReader();

            int num = 0;

            while (reader.Read())
                num += int.Parse(reader[0].ToString());

            db.connection.Close();

            db.connection.Open();
            comm.CommandText = "UPDATE `sold tickets` SET sold = sold + 1 WHERE `ticket window` = ?tw";
            comm.Parameters.AddWithValue("?tw", user.ticket_window);
            comm.ExecuteNonQuery();

            db.connection.Close();

            return num + 1;
        }

        private int[] get_carriage()
        {
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT `railway carriage`, total, `left` FROM trains WHERE " +
                "departureH = ?h AND departureM = ?m AND flight = ?f AND train = ?t";
            comm.Parameters.AddWithValue("?h", curr_rout.dH);
            comm.Parameters.AddWithValue("?m", curr_rout.dM);
            comm.Parameters.AddWithValue("?f", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);

            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            int c = int.Parse(reader[0].ToString());
            int t = int.Parse(reader[1].ToString());
            int l = int.Parse(reader[2].ToString());

            return new int[2] { l / (t / c), l % (t / c) };
        }

        private int get_platform()
        {
            Database db = new Database();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "SELECT `platform` FROM `all traffic` WHERE `flight` = ?f AND `train` = ?t AND `departureH` = ?h AND `departureM` = ?m";
            comm.Parameters.AddWithValue("?f", curr_rout.rout);
            comm.Parameters.AddWithValue("?t", curr_rout.train);
            comm.Parameters.AddWithValue("?h", curr_rout.dH);
            comm.Parameters.AddWithValue("?m", curr_rout.dM);

            return int.Parse(comm.ExecuteScalar().ToString());
        }

        //private string get_time()
        //{
        //    Database db = new Database();
        //    db.connection.Open();
        //    MySqlCommand comm = db.connection.CreateCommand();
        //    comm.CommandText = ""
        //}

        private void update_sum(float sold)
        {
            Users db = new Users();
            db.connection.Open();
            MySqlCommand comm = db.connection.CreateCommand();

            comm.CommandText = "UPDATE `sold tickets` SET sum = sum + ?s WHERE `ticket window` = ?t";
            comm.Parameters.AddWithValue("?s", sold);
            comm.Parameters.AddWithValue("?t", user.ticket_window);

            comm.ExecuteNonQuery();

            db.connection.Close();
        }
    }
}
