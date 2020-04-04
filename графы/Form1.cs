using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace графы
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Graph g = new Graph();
            if (adjnode.Text != "")
                g.read_matrix(adjnode.Text);
            else
                g.read_list(adjnodelist.Text);


            adjnode.Text = g.print_matrix();
            adjnodelist.Text = g.print_list();
            adjedgelist.Text = g.edge_list();
            adjedge.Text = g.edge_matrix();
            incmatrix.Text = g.inc_matrix();
            g.path_tree(); pathtree.Text = g.s;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            adjnode.Text = "";
            adjnodelist.Text = "";
            adjedgelist.Text = "";
            adjedge.Text = "";
            pathtree.Text = "";
            incmatrix.Text = "";
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }


    public struct Edge
    {
        int a, b;

        public void set(int na, int nb)
        {
            a = na; b = nb;
        }

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }
    }


    public class Graph
    {
        int[][] nodes; Edge[] list;
        bool oriented;

        private bool isOrientedM()
        {
            for (int i = 0; i < nodes.Length; i++)
                for (int j = i; j < nodes.Length; j++)
                    if (nodes[i][j] != nodes[j][i])
                        return true;
            return false;
        }

        private bool isOrientedL()
        {
            for (int i = 0; i < nodes.Length; i++)
                for (int j = i; j < nodes.Length; j++)
                    if (nodes[i][j] != 0 && nodes[i][j] == nodes[j][i])
                        return true;
            return false;
        }

        public void read_matrix(string content)
        {
            string[] rows, columns;
            rows = content.Split('\n');

            nodes = new int[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                columns = rows[i].Split(' ');
                nodes[i] = new int[rows.Length];
                for (int j = 0; j < columns.Length; j++)
                    nodes[i][j] = int.Parse(columns[j]);
            }

            oriented = isOrientedM();
            make_list();
        }

        private int max(string[] rows)
        {
            int m = 0; string[] columns;

            for (int i = 0; i < rows.Length; i++)
            {
                columns = rows[i].Split(' ');
                for (int j = 0; j < columns.Length; j++)
                    if (int.Parse(columns[j]) > m)
                        m = int.Parse(columns[j]);
            }
            return m;
        }

        public void read_list(string content)
        {
            string[] rows, columns;
            rows = content.Split('\n');

            nodes = new int[max(rows)][];
            for (int i = 0; i < nodes.Length; i++)
                nodes[i] = new int[nodes.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                columns = rows[i].Split(' ');

                for (int j = 1; j < columns.Length; j++)
                    nodes[int.Parse(columns[0]) - 1][int.Parse(columns[j]) - 1] = 1;
            }

            oriented = isOrientedL();

            if (!oriented)
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = i; j < nodes.Length; j++)
                        nodes[j][i] = nodes[i][j];

            make_list();
        }

        private int edge_num()
        {
            int k = 0, e = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!oriented) k = i;
                for (int j = k; j < nodes.Length; j++)
                    if (nodes[i][j] != 0) e++;
            }
            return e;
        }

        private void make_list()
        {
            list = new Edge[edge_num()];
            int k = 0, n = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!oriented) k = i;
                for (int j = k; j < nodes.Length; j++)
                    if (nodes[i][j] != 0)
                    {
                        list[n].set(i + 1, j + 1);
                        n++;
                    }
            }
        }

        public string print_matrix()
        {
            string s = "";
            for (int i = 0; i < nodes.Length; i++)
            {
                for (int j = 0; j < nodes.Length; j++)
                    s += nodes[i][j] + " ";
                s += "\n";
            }
            return s;
        }

        public string print_list()
        {
            string s = ""; int k = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!oriented)
                {
                    k = i;
                    if (i == nodes.Length - 2)
                        return s;
                }
                s += (i + 1) + " ";

                for (int j = k; j < nodes.Length; j++)
                    if (nodes[i][j] == 1)
                        s += (j + 1) + " ";
                s += "\n";
            }
            return s;
        }

        public string edge_list()
        {
            string s = "";
            for (int i = 0; i < list.Length - 1; i++)
            {
                if (!oriented && i == list.Length - 1)
                    return s;
                s += list[i].A; s += list[i].B + " ";
                int j = i + 1;
                while (j < list.Length && list[j].A == list[i].A)
                {
                    s += list[j].A; s += list[j].B + " ";
                    j++;
                }
                for (int k = i + 1; k < list.Length; k++)
                    if (list[i].B == list[k].B || list[i].B == list[k].A)
                    {
                        s += list[k].A; s += (list[k].B) + " ";
                    }
                s += "\n";
            }
            return s;
        }

        public string edge_matrix()
        {
            string s = "";
            int[][] matrix = new int[list.Length][];
            for (int i = 0; i < list.Length; i++)
                matrix[i] = new int[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                int j = i + 1;
                while (j < list.Length && list[j].A == list[i].A)
                {
                    matrix[i][j] = 1;
                    matrix[j][i] = 1;
                    j++;
                }
                for (j = i + 1; j < list.Length; j++)
                    if (list[i].B == list[j].B || list[i].B == list[j].A)
                    {
                        matrix[i][j] = 1;
                        matrix[j][i] = 1;
                    }
                for (j = 0; j < list.Length; j++)
                    s += matrix[i][j] + " ";
                s += "\n";
            }
            return s;
        }

        public string inc_matrix()
        {
            string s = "";
            int[][] matrix = new int[nodes.Length][];
            for (int i = 0; i < nodes.Length; i++)
                matrix[i] = new int[list.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[j].A == i + 1) matrix[i][j] = 1;
                    if (list[j].B == i + 1)
                        if (!oriented) matrix[i][j] = 1;
                        else matrix[i][j] = -1;
                    s += matrix[i][j] + " ";
                }
                s += "\n";
            }
            return s;
        }

        public void path_tree()
        {
            Queue<int> q = new Queue<int>(); q.Enqueue(0);
            int[] path = new int[nodes.Length];
            bool[] vis = new bool[nodes.Length];
            bfs(q, path, 0, vis);
        }

        public string s = "";

        private void bfs(Queue<int> q, int[] p, int k, bool[] visited)
        {
            if (visited[nodes.Length - 1] == false)
            {
                while (q.Count != 0)
                {
                    Queue<int> nq = new Queue<int>();
                    int node = q.Dequeue();
                    p[k] = node + 1; k++; visited[node] = true;
                    for (int i = 0; i < nodes.Length; i++)
                        if (nodes[node][i] == 1 && visited[i] == false)
                            nq.Enqueue(i);
                    bfs(nq, p, k, visited);
                    k--; visited[node] = false;
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                    s += p[i] + " ";
                s += "\n";
            }
        }

    }
}