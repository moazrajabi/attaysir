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
    public partial class deneme1 : Form
    {
        public deneme1()
        {
            InitializeComponent();
        }

        private deneme2 mainForm = null;
        public deneme1(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as deneme2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.mainForm.LabelText = txtMessage.Text;
            this.mainForm.LabelText(txtMessage.Text);
        }
    }
}
