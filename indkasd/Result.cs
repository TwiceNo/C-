﻿using System;
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
    public partial class Result : Form
    {
        public Result(int task, string answer)
        {
            InitializeComponent();
            this.current_task_num.Text = "Задача " + task;
            this.current_answer.Text = "Ответ: \n" + answer;
        }

        private void Result_Load(object sender, EventArgs e)
        {

        }
    }
}
