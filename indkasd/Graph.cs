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

        public Graph(string dir)
        {
            StreamReader read = new StreamReader(dir);
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
                    nodes[i] = j;
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

        //public string cycle_representation(int[] cycle)
        //{
        //    if (check_existence(cycle))
        //        return build_representation(cycle);
        //    else
        //        return "Cycle does not exist";
        //}

        //private bool check_existence(int[] cycle)
        //{
        //    int start = cycle[0], end = cycle[cycle.Length - 1];
        //    for (int i = 1; i < cycle.Length; i++)
        //        if (matrix[cycle[i - 1]][cycle[i]] == 0)
        //            return false;
        //    if (matrix[start][end] == 0)
        //        return false;
        //    return true;
        //}

        //private string build_representation(int[] cycle)
        //{
        //    List<int[]> fcycle_set = read_fcycles();
        //    List<int> sum_cycles = new List<int>();
        //    List<int> curr_cycle = new List<int>();
        //    cycle_selection(fcycle_set, sum_cycles, curr_cycle, cycle);
        //    string output = "";
        //    for (int i = 0; i < sum_cycles.Count; i++)
        //    {
        //        output += "C" + sum_cycles[i];
        //        if (i != sum_cycles.Count - 1)
        //            output += " ⊕ ";
        //    }
        //    return output;
        //}

        //private List<int[]> read_fcycles(string dir)
        //{
        //    List<int[]> cycles = new List<int[]>();
        //    StreamReader read = new StreamReader(dir);
        //    string line;
        //    do
        //    {
        //        line = read.ReadLine();
        //        if (line != null)
        //        {
        //            string[] splitted = line.Split(' ');
        //            int[] curr_cycle = new int[splitted.Length];
        //            for (int i = 0; i < splitted.Length; i++)
        //                curr_cycle[i] = int.Parse(splitted[i]);
        //            cycles.Add(curr_cycle);
        //        }
        //    } while (line != null);
        //    return cycles;
        //}

        //private void cycle_selection(List<int[]> set, List<int> sum, List<int> curr, int[] cycle)
        //{
        //    if (!same(curr, cycle))
        //    {
        //        int first = sum.Count; int last;
        //        if (first == cycle.Length - 1) last = 0;
        //        else last = first + 1;
        //        Queue<int> possible = find_all(set, sum, cycle[first], cycle[last]);
        //        while (possible.Count != 0)
        //        {
        //            sum.Add(possible.Dequeue());
        //            cycle_selection(set, sum, build_cycle(set, sum), cycle);
        //        }
        //    }
        //}

        //private bool same(List<int> curr, int[] cycle)
        //{
        //    if (curr.Count != cycle.Length) return false;
        //    for (int i = 0; i < curr.Count; i++)
        //        if (curr[i] != cycle[i]) return false;
        //    return true;
        //}

        //private Queue<int> find_all(List<int[]> set, List<int> sum, int first, int last)
        //{
        //    Queue<int> occurences = new Queue<int>();
        //    for (int i = 0; i < set.Count; i++)
        //    {
        //        for (int j = 0; j < set[i].Length - 1; j++)
        //            if (set[i][j] == first && set[i][j + 1] == last || set[i][j] == last && set[i][j + 1] == first)
        //                if (!sum.Contains(i)) occurences.Enqueue(i);
        //        if (set[i][0] == first && set[i][set[i].Length - 1] == last || set[i][0] == last && set[i][set[i].Length - 1] == first)
        //            if (!sum.Contains(i)) occurences.Enqueue(i);
        //    }
        //    return occurences;
        //}

        //private List<int> build_cycle(List<int[]> set, List<int> sum)
        //{
        //    bool[][] building_matrix = new bool[matrix.Length][];
        //    for (int i = 0; i < matrix.Length; i++)
        //        building_matrix[i] = new bool[matrix.Length];
        //    for (int i = 0; i < sum.Count; i++)
        //    {
        //        for (int j = 0; j < set[i].Length - 1; j++)
        //        {
        //            building_matrix[set[i][j]][set[i][j + 1]] = invert(building_matrix[set[i][j]][set[i][j + 1]]);
        //            building_matrix[set[i][j + 1]][set[i][j]] = invert(building_matrix[set[i][j + 1]][set[i][j]]);
        //        }
        //        building_matrix[set[i][0]][set[i][set[i].Length - 1]] = invert(building_matrix[set[i][0]][set[i][set[i].Length - 1]]);
        //        building_matrix[set[i][set[i].Length - 1]][set[i][0]] = invert(building_matrix[set[i][set[i].Length - 1]][set[i][0]]);
        //    }
        //    List<int> cycle = new List<int>();
        //    bool[] visited = new bool[matrix.Length];
        //    for (int i = 0; i < matrix.Length; i++)
        //        for (int j = i; j < matrix.Length; j++)
        //            if (building_matrix[i][j])
        //            {
        //                if (!visited[i])
        //                {
        //                    cycle.Add(i); visited[i] = true;
        //                }
        //                if (!visited[j])
        //                {
        //                    cycle.Add(j); visited[j] = true;
        //                }
        //            }
        //    return cycle;
        //}

        //private bool invert(bool val)
        //{
        //    if (val) return false;
        //    else return true;
        //}

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