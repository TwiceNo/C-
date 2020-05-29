using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace indkasd
{
    public partial class Additional_Input : Form
    {
        public List<int[]> vars; int task, max_node;

        public Additional_Input(int task, List<int[]> vars, int max_node)
        {
            InitializeComponent();

            this.vars = vars;
            this.task = task;
            this.max_node = max_node;
            task_num.Text = "Задача " + task;

            switch (task)
            {
                case 2:
                    variable_1.Text = "Введите вершину:";
                    break;
                case 4:
                    variable_1.Text = "Искомый цикл:";
                    break;
                case 5:
                    this.variable_2.Visible = true;
                    this.variable_2_input.Visible = true;
                    variable_1.Text = "Начальная вершина:";
                    variable_2.Text = "Конечная вершина:";
                    break;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (check_data())
            {
                get_var(variable_1_input.Text);
                if (this.task == 5)
                    get_var(variable_2_input.Text);
                this.Close();
            }
            else
            {
                PopUp window = new PopUp("Неверно введены данные.");
                window.Show();
            }
        }

        private bool check_data()
        {
            if (check_string(variable_1_input.Text))
            {
                if (this.task == 5)
                    if (!check_string(variable_2_input.Text))
                        return false;
                    else return true;
                else return true;
            }
            else return false;
        }

        private bool check_string(string text)
        {
            int output;
            if (text != null)
            {
                string[] splitted = text.Split(' ');
                for (int i = 0; i < splitted.Length; i++)
                    if (int.TryParse(splitted[i], out output))
                    {
                        if (output > this.max_node || output < 0)
                            return false;
                    }
                    else return false;
                return true;
            }
            else return false;
        }

        private void get_var(string text)
        {
            string[] splitted = text.Split(' ');
            int[] conv = new int[splitted.Length];
            for (int i = 0; i < splitted.Length; i++)
                conv[i] = int.Parse(splitted[i]);
            this.vars.Add(conv);
        }
    }
}
