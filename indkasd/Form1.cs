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
            int node = int.Parse(textBox2.Text);
            int[] clique = graph.clique(node);
            string cl = "";
            for (int i =0; i<clique.Length; i++)
                cl += (clique[i] + 1) + " ";
            textBox1.Text = cl;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
