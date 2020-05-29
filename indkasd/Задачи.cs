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
    public partial class Задачи : Form
    {
        Graph graph;
        string dir_graph, dir_fcycles;
        int curr_task;

        private void task1_CheckedChanged(object sender, EventArgs e)
        {
            curr_task = 1;
        }

        private void task2_CheckedChanged(object sender, EventArgs e)
        {
            curr_task = 2;
        }

        private void task3_CheckedChanged(object sender, EventArgs e)
        {
            curr_task = 3;
        }

        private void task4_CheckedChanged(object sender, EventArgs e)
        {
            curr_task = 4;
        }

        private void task5_CheckedChanged(object sender, EventArgs e)
        {
            curr_task = 5;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void run_Click(object sender, EventArgs e)
        {
            run_task(curr_task);
        }

        private void run_task(int task)
        {
            if (dir_graph == null)
                no_file_chosen("graph");
            else
                switch(task)
                {
                    case 1:
                        res_pop_up(task, graph.euler());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        if (dir_fcycles == null)
                            no_file_chosen("cycles");
                        break;
                    case 5:
                        break;
                }
        }

        private void no_file_chosen(string source)
        {
            
        }

        private void res_pop_up(int task_num, string answer)
        {

        }

        public Задачи()
        {
            InitializeComponent();
        }

    }
}
