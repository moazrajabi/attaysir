using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class adminmain : Form
    {
        public adminmain(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        int id;

        private void adminmain_Load(object sender, EventArgs e)
        {
            string f = Employee2.NameByIdAdmin(id);
            richTextBox1.Text = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding n = new adding(id,true); n.Show();//this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddingEmployee n = new AddingEmployee();n.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TheEmployeesList n = new TheEmployeesList();n.Show();
        }
    }
}
