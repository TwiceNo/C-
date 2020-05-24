using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
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
            for (int k=0; k< splitted.Length; k++)
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



    }
}
