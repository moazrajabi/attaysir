using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attaysir
{
    public partial class TheMessage : Form
    {
        public TheMessage(string message,int id)
        {
            InitializeComponent();
            this.message = message;
            this.id = id;
        }
        string message ;
        int id;

        private void TheMessage_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = message;
        }

        private void TheMessage_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
