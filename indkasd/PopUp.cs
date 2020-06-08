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
    public partial class PopUp : Form
    {
        public PopUp(string error)
        {
            InitializeComponent();
            this.error_message.Text = error;
        }

        private void PopUp_Load(object sender, EventArgs e)
        {

        }
    }
}
