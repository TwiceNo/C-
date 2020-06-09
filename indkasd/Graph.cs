using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace indkasd
{
    class Graph
    {
        public int[][] matrix;
        private bool f = false;

        public Graph(string dir)
        {
            StreamReader read = new StreamReader(dir);
            string line = read.ReadLine();
            string[] splitted = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            matrix = new int[splitted.Length][];
            for (int k = 0; k < splitted.Length; k++)
            {
                matrix[k] = new int[splitted.Length];
                for (int i = 0; i < splitted.Length; i++)
                    matrix[k][i] = int.Parse(splitted[i]);
                if (k != splitted.Length - 1)
                {
                    line = read.ReadLine();
                    splitted = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            read.Close();
        }

        ~Graph()
        {

        }


        //~~~~~~~~~~~~~~~~Part 1~~~~~~~~~~~~~~~~


        private bool degrees_check()
        {
            int[] degrees = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if (matrix[i][j] != 0)
                        degrees[i]++;

            for (int i = 0; i < matrix.Length; i++)
                if (degrees[i] % 2 == 1)
                    return false;
            return true;
        }

        public bool components_check(int[][] matrix)
        {
            int[] nodes = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
                nodes[i] = -1;

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if (matrix[i][j] != 0)
                        if (nodes[j] == -1)
                            components(nodes, j, i);
                        else
                            components(nodes, i, j);

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] != nodes[0])
                    return false;
            }

            return true;
        }

        private void components(int[] nodes, int i, int j)
        {
            if (nodes[i] == -1)
                if (nodes[j] == -1)
                {
                    nodes[i] = i; nodes[j] = i;
                }
                else
                    nodes[i] = nodes[j];
            else
            {
                int old = i;
                for (int k = 0; k < matrix.Length; k++)
                    if (nodes[k] == old)
                        nodes[k] = j;
            }
        }

        public string euler()
        {
            if (components_check(this.matrix) && degrees_check())
                return "Граф эйлеров";
            else return "Граф не эйлеров";
        }


        //~~~~~~~~~~~~~~~~Part 2~~~~~~~~~~~~~~~~


        public string clique(int node)
        {
            List<int> prep = new List<int>();
            List<int> clique = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
                if (matrix[node][i] != 0)
                    prep.Add(i);

            clique.Add(node);
            while (prep.Count != 0)
            {
                int next_node = prep[0]; bool f = true;
                for (int i = 1; i < prep.Count; i++)
                    if (matrix[next_node][prep[i]] == 0)
                    {
                        f = false; break;
                    }
                if (f)
                    clique.Add(next_node);
                prep.Remove(next_node);
            }

            string output = "";
            for (int i = 0; i < clique.Count; i++)
                output += clique[i] + " ";
            return output;
        }


        //~~~~~~~~~~~~~~~~Part 3~~~~~~~~~~~~~~~~


        public string topological_sort()
        {
            if (cycles_check())
                return "Граф содержит циклы, сортировка невозможна.";
            else
                return "Граф может быть отсортирован.";
        }


        private bool cycles_check()
        {
            bool[] visited = new bool[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
                if (!visited[i] && !f)
                    cycles_check(visited, i);
            return f;
        }

        private void cycles_check(bool[] visited, int node)
        {
            Queue<int> nodes_to_check = new Queue<int>();

            visited[node] = true;
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[node][i] != 0)
                    if (visited[i] == true)
                    {
                        f = true; break;
                    }
                    else
                        nodes_to_check.Enqueue(i);
            while (nodes_to_check.Count != 0 && !f)
                cycles_check(visited, nodes_to_check.Dequeue());

        }



        //~~~~~~~~~~~~~~~~Part 4~~~~~~~~~~~~~~~~


        public string cycle_representation(int[] cycle, string dir)
        {
            if (check_existence(cycle))
                return build_representation(cycle, dir);
            else return "Цикл не существует";
        }

        private bool check_existence(int[] cycle)
        {
            int start = cycle[0], end = cycle[cycle.Length - 1];
            for (int i = 1; i < cycle.Length; i++)
                if (matrix[cycle[i - 1]][cycle[i]] == 0)
                    return false;
            if (matrix[start][end] == 0)
                return false;
            return true;
        }

        private string build_representation(int[] cycle, string dir)
        {
            List<int[]> all_cycles = read_cycles(dir);
            List<int> sum = sum_cycles(all_cycles, cycle);
            string ans = "";
            for (int i = 0; i < sum.Count; i++)
            {
                ans += "C" + sum[i];
                if (i != sum.Count - 1)
                    ans += " ⊕ ";
            }
            return ans;
        }

        private List<int[]> read_cycles(string dir)
        {
            List<int[]> cycles = new List<int[]>();
            StreamReader read = new StreamReader(dir);
            string[] lines = read.ReadToEnd().Split('\n');
            for (int k = 0; k < lines.Length; k++)
            {
                string[] content = lines[k].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] cycle = new int[content.Length];
                for (int i = 0; i < content.Length; i++)
                    cycle[i] = int.Parse(content[i]);
                cycles.Add(cycle);
            }
            read.Close();
            return cycles;
        }

        private List<int> sum_cycles(List<int[]> all, int[] sample)
        {
            List<List<int[]>> all_queues = new List<List<int[]>>();
            List<int[]> edges = new List<int[]>();
            for (int i = 0; i < sample.Length; i++)
            {
                int a, b; int[] edge = new int[2];
                if (i == sample.Length - 1)
                {
                    a = i; b = 0;
                }
                else
                {
                    a = i; b = i + 1;
                }
                List<int[]> edge_List = new List<int[]>();
                for (int j = 0; j < all.Count; j++)
                    if (contains_edge(all[j], sample[a], sample[b]))
                        edge_List.Add(all[j]);
                all_queues.Add(edge_List);
                edge[0] = sample[a]; edge[1] = sample[b];
                edges.Add(edge);
            }
            List<int[]> list = search(all_queues, sample);
            return restore(all, list);
        }

        private bool contains_edge(int[] list, int v1, int v2)
        {
            for (int i = 0; i < list.Length; i++)
            {
                int a, b;
                if (i == list.Length - 1)
                {
                    a = i; b = 0;
                }
                else
                {
                    a = i; b = i + 1;
                }
                if ((list[a] == v1 && list[b] == v2) || (list[b] == v1 && list[a] == v2))
                    return true;
            }
            return false;
        }

        private List<int[]> search(List<List<int[]>> list, int[] cycle)
        {
            List<int[]> main_list = new List<int[]>();
            for (int i = 0; i < list.Count; i++)
                if (list[i].Count == 1)
                    main_list.Add(list[i][0]);
            return main_list;
        }

        private List<int> restore(List<int[]> all, List<int[]> used)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < all.Count; i++)
                for (int j = 0; j < used.Count; j++)
                    if (all[i] == used[j])
                        indexes.Add(i);
            return indexes;
        }


        //~~~~~~~~~~~~~~~~Part 5~~~~~~~~~~~~~~~~


        public string a_star(int start, int goal)
        {
            Priority_Queue open = new Priority_Queue();
            List<Node> closed = new List<Node>();
            int[] heuristics = new int[matrix.Length];
            heuristics[goal] = -1; depth(heuristics, goal); heuristics[goal] = 0;
            Node start_node = new Node(start, 0, heuristics[start], int.MaxValue);
            Node working_node;

            open.Add(start_node);

            while (open.Length() != 0)
            {
                working_node = open.Pick();
                if (working_node.node == goal)
                {
                    closed.Add(working_node); return restore_path(closed);
                }
                else
                {
                    for (int i = 0; i < matrix.Length; i++)
                        if (matrix[working_node.node][i] != 0)
                            if (!contains(i, closed))
                            {
                                int distance = working_node.distance + matrix[working_node.node][i];
                                Node new_node = new Node(i, distance, distance + heuristics[i], working_node.node);
                                open.Add(new_node);
                            }
                    closed.Add(working_node);
                }
            }
<<<<<<< HEAD
            return "Путь не существует";
=======
            return "Path does not exists";
>>>>>>> master
        }

        private void depth(int[] list, int goal)
        {
            Queue<int> set = new Queue<int>();
            for (int i = 0; i < matrix.Length; i++)
                if (list[i] == 0)
                    if (matrix[goal][i] != 0)
                    {
                        if (list[goal] == -1) list[i] = 1;
                        else list[i] += list[goal] + 1;
                        set.Enqueue(i);
                    }
            while (set.Count != 0)
            {
                int next = set.Dequeue();
                depth(list, next);
            }
        }

        private string restore_path(List<Node> list)
        {
            string path = ""; path += list[list.Count - 1].node;
            int parent = list[list.Count - 1].parent;
            for (int i = list.Count - 2; i >= 0; i--)
                if (list[i].node == parent)
                {
                    path = list[i].node + " " + path;
                    parent = list[i].parent;
                }
            return path;
        }

        private bool contains(int node, List<Node> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].node == node) return true;
            return false;
        }


        //~~~~~~~~~~~~~~~~~~~~Other~~~~~~~~~~~~~~~~~~~~~~~

        public bool oriented(int[][] graph)
        {
            for (int i = 0; i < graph.Length; i++)
                for (int j = i; j < graph.Length; j++)
                    if (graph[i][j] != graph[j][i])
                        return true;
            return false;
        }
    }
}