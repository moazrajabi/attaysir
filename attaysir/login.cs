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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {
                bool resultAdmin = admin.login(username, password);
                bool resultEmployee = Employee2.login(username, password);

                if (textBox1.Text == "") {  richTextBox1.Text = "الرجاء ادخال اسم المستخدم"; }
                else if (textBox2.Text == "") { richTextBox1.Text = "الرجاء ادخال  كلمة المرور"; }
                else if (resultAdmin == true)
                {
                    richTextBox1.Text = "";
                    int id = int.Parse(admin.idByEmailAndPassword(username, password));
                    adminmain n = new adminmain(id); this.Hide(); n.Show();
                }
                else if (resultEmployee == true)
                {
                    richTextBox1.Text = "";
                    int id = int.Parse(Employee2.idByEmailAndPassword(username, password));
                    officermain n = new officermain(id); this.Hide(); n.Show();
                }
                else
                {
                    richTextBox1.Text = "الرجاء التحقق من اسم المستخدم او كلمة المرور";

                }
            }
            catch(Exception ev)
            {
                MessageBox.Show(ev.Message/*"حدث خطأ ما، الرجاء المحاولة لاجقا"*/);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
