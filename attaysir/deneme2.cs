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
    public partial class deneme2 : Form
    {
        public deneme2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deneme1 frm = new deneme1(this);
            frm.Show();
        }
        
        public void LabelText(string s)
        {
            Lbl.Text = s;
        }
        /*
        public string LabelText
        {
            get { return Lbl.Text; }
            set { Lbl.Text = value; }
        }*/
    }
}
