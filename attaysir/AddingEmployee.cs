using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class AddingEmployee : Form
    {
        public AddingEmployee()
        {
            InitializeComponent();
        }

        private void AddingEmployee_Load(object sender, EventArgs e)
        {
            textBox8.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox5.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox6.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox1.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox2.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
        }

        string path = null;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "select employee picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string PicPath = dlg.FileName.ToString();
                pictureBox1.ImageLocation = PicPath;
                this.path = PicPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { richTextBox1.Text = "الرجاء ادخال الاسم الاول اولا";textBox1.Focus(); }
            else if (textBox2.Text == "") { richTextBox1.Text = "الرجاء ادخال اسم العائلة اولا";textBox2.Focus(); }
            else if (i == false) { richTextBox1.Text = "الرجاء ادخال تاريخ الميلاد اولا";dateTimePicker1.Focus(); }
            else if (textBox7.Text == "") { richTextBox1.Text = "الرجاء ادخال البريد الالكتروني اولا";textBox7.Focus(); }
            else if (textBox4.Text == "") { richTextBox1.Text = "الرجاء ادخال كلمة المرور اولا";textBox4.Focus(); }
            else if (textBox8.Text == "") { richTextBox1.Text = "الرجاء ادخال رقم الهوية اولا";textBox8.Focus(); }
            else if (textBox5.Text == "") { richTextBox1.Text = "الرجاء ادخال رقم الهاتف اولا";textBox5.Focus(); }
            else if (this.path==null) { richTextBox1.Text = "الرجاء اختيار صورة اولا";button2.Focus(); }
            //else if () { }
            else
            {
                if (IfTheEmployeeThere(textBox8.Text)==false) {
                    if (IfTheAdminThere(textBox8.Text) == false)
                    {
                        try
                        {
                            richTextBox1.Text = "";
                            string query = string.Format("insert into Attaysir1.dbo.Employee(firstName,lastName" +
                                ",email,password,birthday,identityNo,MobileNum1,MobileNum2)values('{0}','{1}'," +
                                "'{2}','{3}','{4}','{5}','{6}','{7}')", textBox1.Text, textBox2.Text, textBox7.Text,
                                textBox4.Text, dateTimePicker1.Text, textBox8.Text, textBox5.Text, textBox6.Text);
                            dataAccess.executenonquery(query);

                            FileStream fStream = File.OpenRead(this.path);
                            int length1 = (int)fStream.Length;
                            byte[] variable = new byte[length1];
                            fStream.Read(variable, 0, length1);
                            string id = string.Format("select id from Attaysir1.dbo.Employee where identityNo='{0}'", textBox8.Text);
                            dataAccess.SavePDFsAndimage(variable, "Employee", "image", int.Parse(dataAccess.reader(id, "id")));
                            richTextBox1.Text = "تمت عملية الاضافة بنجاح"; i = false; MessageBox.Show("تمت عملية الاضافة بنجاح", "الاضافة تمت"); this.Close();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
            }
        }
        public static bool i = false;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            i = true;
        }

        public static bool IfTheEmployeeThere(string identityNo)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.Employee WHERE identityNo ='{0}'", identityNo);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static bool IfTheAdminThere(string identityNo)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.Admin WHERE identityNo ='{0}'", identityNo);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }
    }
}
