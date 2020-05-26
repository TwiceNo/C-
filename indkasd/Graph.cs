using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace indkasd
{
    class Graph
    {
        int[][] matrix;

        public Graph()
        {
            StreamReader read = new StreamReader("graph.txt");
            string line = read.ReadLine();
            string[] splitted = line.Split(' ');
            matrix = new int[splitted.Length][];
            for (int k = 0; k < splitted.Length; k++)
            {
                matrix[k] = new int[splitted.Length];
                for (int i = 0; i < splitted.Length; i++)
                    matrix[k][i] = int.Parse(splitted[i]);
                if (k != splitted.Length - 1)
                {
                    line = read.ReadLine();
                    splitted = line.Split(' ');
                }
            }
            read.Close();
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

        private bool components_check()
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

            int comp = -1;
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i] != -1)
                {
                    comp = nodes[i]; break;
                }

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] != -1 && nodes[i] != comp)
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
                    nodes[i] = j;
            else
            {
                int old = i;
                for (int k = 0; k < matrix.Length; k++)
                    if (nodes[k] == old)
                        nodes[k] = j;
            }
        }

        public bool euler()
        {
            if (components_check() && degrees_check())
                return true;
            else return false;
        }

        //~~~~~~~~~~~~~~~~Part 2~~~~~~~~~~~~~~~~

        public int[] clique(int node)
        {
            node--;
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
            return clique.ToArray();
        }


        //~~~~~~~~~~~~~~~~Part 3~~~~~~~~~~~~~~~~


        public string topological_sort()
        {
            if (cycles_check())
                return "There are cycles. How am I suppose to sort this?";
            else
                return "This graph could be sorted. But it's not mine job";
        }

        private bool cycles_check()
        {
            bool[] visited = new bool[matrix.Length];
            return cycles_check(visited, 0);
        }

        private bool cycles_check(bool[] visited, int node)
        {
            Queue<int> nodes_to_check = new Queue<int>();
            for (int i = 0; i < matrix.Length; i++)
                if (matrix[node][i] != 0)
                    if (visited[i] == true) return true;
                    else
                    {
                        visited[i] = true;
                        nodes_to_check.Enqueue(i);
                    }
            while (nodes_to_check.Count != 0)
                cycles_check(visited, nodes_to_check.Dequeue());
            return false;
        }


        //~~~~~~~~~~~~~~~~Part 4~~~~~~~~~~~~~~~~





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
            return "Path does not exists";
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
    }
}
