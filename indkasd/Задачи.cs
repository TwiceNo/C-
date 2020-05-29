using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            {
                graph = new Graph(dir_graph);
                int max_node = graph.matrix.Length - 1;
                string answer = "";
                List<int[]> vars;
                Additional_Input window;
                PopUp err_window;
                string input_error = "Некорректный граф.";

                switch (task)
                {
                    case 1:
                        if (graph_check(false))
                        {
                            answer = graph.euler();
                            res_pop_up(task, answer);
                            to_file(dir_graph, task, answer);
                        }
                        else
                        {
                            err_window = new PopUp(input_error);
                            err_window.ShowDialog();
                        }
                        break;

                    case 2:
                        if (graph_check(false))
                        { 
                            vars = new List<int[]>();
                            window = new Additional_Input(task, vars, max_node);
                            window.ShowDialog(); vars = window.vars;
                            answer = graph.clique(vars[0][0]);
                            res_pop_up(task, answer);
                            to_file(dir_graph, task, answer);
                        }
                        else
                        {
                            err_window = new PopUp(input_error);
                            err_window.ShowDialog();
                        }
                        break;

                    case 3:
                        if (graph_check(true, false))
                        {
                            answer = graph.topological_sort();
                            res_pop_up(task, answer);
                            to_file(dir_graph, task, answer);
                        }
                        else
                        {
                            err_window = new PopUp(input_error);
                            err_window.ShowDialog();
                        }
                        break;

                    //case 4:
                    //    if (dir_fcycles == null)
                    //        no_file_chosen("cycles");
                    //    else
                    //    {
                    //        window = new Additional_Input(task);
                    //        window.ShowDialog();
                            
                    //    }
                    //    break;

                    case 5:
                        vars = new List<int[]>();
                        window = new Additional_Input(task, vars, max_node);
                        window.ShowDialog(); vars = window.vars;
                        answer = graph.a_star(vars[0][0],vars[1][0]);
                        res_pop_up(task, answer);
                        to_file(dir_graph, task, answer);
                        break;
                }
            }
        }

        private void no_file_chosen(string source)
        {
            string error = "Не выбран исходный файл для ";
            if (source == "cycles") error += "циклов.";
            else error += "графа.";
            PopUp popup = new PopUp(error);
            popup.ShowDialog();
        }

        private void res_pop_up(int task_num, string answer)
        {
            Result window = new Result(task_num, answer);
            window.ShowDialog();
        }

        private void to_file(string dir, int task, string answer)
        {
            string file_name = dir.Substring(0, dir.LastIndexOf("."));
            file_name += " - Задача " + task + ".txt";
            StreamWriter write = new StreamWriter(file_name);
            write.WriteLine(answer);
            write.Close();
        }

        private void choose_graph_Click(object sender, EventArgs e)
        {
            OpenFileDialog choose_file = new OpenFileDialog();
            choose_file.Filter = "txt files (*.txt)|*.txt";
            choose_file.FilterIndex = 1;
            choose_file.RestoreDirectory = true;

            if (choose_file.ShowDialog() == DialogResult.OK)
            {
                this.dir_graph = choose_file.FileName;
                this.path_to_graph.Text = this.dir_graph;

                StreamReader content = new StreamReader(this.dir_graph);
                this.preview.Text = content.ReadToEnd();
                content.Close();
            }
        }

        private void choose_cycles_Click(object sender, EventArgs e)
        {
            OpenFileDialog choose_file = new OpenFileDialog();
            choose_file.Filter = "txt files (*.txt)|*.txt";
            choose_file.FilterIndex = 1;
            choose_file.RestoreDirectory = true;

            if (choose_file.ShowDialog() == DialogResult.OK)
            {
                this.dir_fcycles = choose_file.FileName;
                this.path_to_cycles.Text = this.dir_graph;

                StreamReader content = new StreamReader(this.dir_graph);
                this.preview.Text = content.ReadToEnd();
                content.Close();
            }
        }

        private bool graph_check(bool oriented, bool comp = true)
        {
            if (oriented == graph.oriented(graph.matrix))
                if (!comp)
                {
                    int[][] graph_to_check = make_oriented(graph.matrix);
                    if (graph.components_check(graph_to_check))
                        return true;
                }
                else return true;
            return false;
        }

        private int[][] make_oriented(int[][] source)
        {
            int[][] new_graph = new int[source.Length][];
            for (int i=0; i<source.Length; i++)
            {
                new_graph[i] = new int[source.Length];
                for (int j = 0;j < source.Length; j++)
                    if (source[i][j] != 0)
                    {
                        new_graph[i][j] = 1;
                        new_graph[j][i] = 1;
                    }    
            }
            return new_graph;
        }

        public Задачи()
        {
            InitializeComponent();
        }

    }
}
