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
//////////////
using System.Data.SqlClient;

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
            timer1.Start();
            this.k();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding n = new adding(id, true); n.Show();//this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddingEmployee n = new AddingEmployee(); n.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TheEmployeesList n = new TheEmployeesList(); n.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TheEmployeeList2 n = new TheEmployeeList2(); n.Show();
        }

        bool bo;//this bool for control the ligting of button13(the if there a files needs togiving time) 
                        //if it false its mean no lighting and if it true means lighting
        public void k()
        {
            if (admin.checkedornot() == true) { this.bo = true; }
            else if (admin.checkedornot() == false) { this.bo = false; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sabit_mi_degisken_mi(this.bo);
        }

        bool f = true;
        void sabit_mi_degisken_mi(bool bo)
        {
            if (bo == true)
            {
                if (f == true) { button13.ForeColor = Color.Red; panel2.BackColor = Color.Red; f = false; }
                else if (f == false) { button13.ForeColor = Color.Black; panel2.BackColor = this.BackColor; f = true; }
            }
            if (bo == false) { button13.ForeColor = Color.Black; panel2.BackColor = this.BackColor; }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (bo==true)
            {
                didntcheckedtimefamily n = new didntcheckedtimefamily(this); n.Show();
            }
        }
    }
}
