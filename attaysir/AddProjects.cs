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
    public partial class AddProjects : Form
    {
        public AddProjects()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            { richTextBox2.Text = "ادخل اسم للمشروع اولا"; }
            else if (textBox3.Text == "")
            { richTextBox2.Text = "ادخل عدد المستفيدين اولا"; }
            else if (textBox4.Text == "")
            { richTextBox2.Text = "ادخل رابط المشروع اولا"; }
            else if (richTextBox1.Text == "")
            { richTextBox2.Text = "ادخل وصف للمشروع اولا"; }
            else if (comboBox1.SelectedIndex>=0)
            { richTextBox2.Text = "اختر قائمة مستفيدين اولا"; }
            else
            {
                richTextBox2.Text = "";



            }
        }
    }
}
