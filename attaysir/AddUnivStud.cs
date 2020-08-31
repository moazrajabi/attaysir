using attaysir.models;
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
    public partial class AddUnivStud : Form
    {
        public AddUnivStud()
        {
            InitializeComponent();
        }
        private adding d = null;
        public AddUnivStud(Form d)
        {
            this.d = d as adding;
            InitializeComponent();
        }

        public AddUnivStud(bool yalnizcami)
        {
            InitializeComponent();
            this.yalnizcami = yalnizcami;
        }
        bool yalnizcami = false;

        private void AddUnivStud_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (yalnizcami == false)
            {
                this.d.Enabled = true;
                this.d.ControlBox = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FirstNametxtbx.Text == "") { richTextBox1.Text = "ادخل الاسم الاول اولا"; }
            else if (FatherNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم الاب اولا"; }
            else if (MotherNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم الام اولا"; }
            else if (LastNametxtbx.Text == "") { richTextBox1.Text = "ادخل الاسم الاخير اولا"; }
            else if (IdentityNotxtbx.Text == "") { richTextBox1.Text = "ادخل رقم الهوية اولا"; }
            else if (UnivNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم الجامعة اولا"; }
            else if (KolejNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم الكلية اولا"; }
            else if (DepartmentNametxtbx.Text == "") { richTextBox1.Text = "ادخل اسم التخصص اولا"; }
            else if (whichyearcmbbx.SelectedIndex != 0 && whichyearcmbbx.SelectedIndex != 1 && whichyearcmbbx.SelectedIndex != 2 && whichyearcmbbx.SelectedIndex != 3 && whichyearcmbbx.SelectedIndex != 4 && whichyearcmbbx.SelectedIndex != 5 && whichyearcmbbx.SelectedIndex != 6) { richTextBox1.Text = "اختر السنة الدراسية اولا"; }
            else if (PhoneNotxtbx.Text == "") { richTextBox1.Text = "ادخل رقم الهاتف اولا"; }
            else if (SecondPhoneNotxtbx.Text == "") { richTextBox1.Text = "ادخل رقم الهاتف الاحطياطي اولا"; }
            else if (Emailtxtbx.Text == "") { richTextBox1.Text = "ادخل البريد الالكتروني اولا"; }
            else if (YearlyFeestxtbx.Text == "") { richTextBox1.Text = "ادخل القسط السنوي اولا"; }
            else
            {
                if (yalnizcami == false)
                {
                    this.d.f += 1;
                    this.d.arrayfilling(FirstNametxtbx.Text, FatherNametxtbx.Text, MotherNametxtbx.Text, LastNametxtbx.Text, IdentityNotxtbx.Text, UnivNametxtbx.Text, KolejNametxtbx.Text, DepartmentNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString(), YearlyFeestxtbx.Text, PhoneNotxtbx.Text, SecondPhoneNotxtbx.Text, Emailtxtbx.Text);
                    this.d.Enabled = true;
                    this.d.ControlBox = true;
                    this.Close();
                    MessageBox.Show("تمت اضافة الطالب الجامعي لملف العائلة بنجاح", "تمت الاضافة");
                }
                if (yalnizcami==true)
                {
                    Employee2.AddUnivStudWithOutFamily(FirstNametxtbx.Text, FatherNametxtbx.Text, MotherNametxtbx.Text, LastNametxtbx.Text, IdentityNotxtbx.Text, UnivNametxtbx.Text, KolejNametxtbx.Text, DepartmentNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString(), YearlyFeestxtbx.Text, PhoneNotxtbx.Text, SecondPhoneNotxtbx.Text, Emailtxtbx.Text);
                    this.Close();
                    MessageBox.Show("تمت اضافة الطالب الجامعي بنجاح", "تمت الاضافة");
                }
            }
        }

        private void AddUnivStud_Load(object sender, EventArgs e)
        {
            FirstNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            FatherNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            MotherNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            LastNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            KolejNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            DepartmentNametxtbx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            IdentityNotxtbx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            PhoneNotxtbx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            SecondPhoneNotxtbx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            YearlyFeestxtbx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
        }
    }
}
