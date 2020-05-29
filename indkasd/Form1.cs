using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace indkasd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            string[] line = textBox1.Text.Split(' ');
            int[] cycle = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
                cycle[i] = int.Parse(line[i]);
            textBox3.Text = graph.cycle_representation(cycle);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
