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
    public partial class AddSchoolStud : Form
    {
        public AddSchoolStud()
        {
            InitializeComponent();
        }
        private adding d = null;
        public AddSchoolStud(Form d)
        {
            this.d = d as adding;
            InitializeComponent();
        }

        private void AddSchoolStud_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.d.Enabled = true;
            this.d.ControlBox = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (FirstNametxtbx.Text == "") { richTextBox1.Text = "ادخل الاسم الاول اولا"; }
            else if (IdentityNotxtbx.Text == "") { richTextBox1.Text = "ادخل رقم الهوية اولا"; }
            else if (SchoolNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم المدرسة اولا"; }
            else if (whichyearcmbbx.SelectedIndex != 0 && whichyearcmbbx.SelectedIndex != 1 && whichyearcmbbx.SelectedIndex != 2 && whichyearcmbbx.SelectedIndex != 3 && whichyearcmbbx.SelectedIndex != 4 && whichyearcmbbx.SelectedIndex != 5 && whichyearcmbbx.SelectedIndex != 6 && whichyearcmbbx.SelectedIndex != 7 && whichyearcmbbx.SelectedIndex != 8 && whichyearcmbbx.SelectedIndex != 9 && whichyearcmbbx.SelectedIndex != 10 && whichyearcmbbx.SelectedIndex != 11) { richTextBox1.Text = "اختر السنة الدراسية اولا"; }
            else
            {
                this.d.e += 1;
                this.d.schoolarrayfilling(FirstNametxtbx.Text, IdentityNotxtbx.Text, SchoolNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString());
                this.d.Enabled = true;
                this.d.ControlBox = true;
                this.Close();
                MessageBox.Show("تمت اضافة الطالب المدرسي لملف العائلة بنجاح", "تمت الاضافة");
            }
        }
    }
}
