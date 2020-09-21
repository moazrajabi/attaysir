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
            this.yalnizcami = true;
        }
        private adding d = null;
        public AddUnivStud(Form d)
        {
            this.d = d as adding;
            InitializeComponent();
        }

        bool yalnizcami = false;

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
                    this.d.arrayfilling(FirstNametxtbx.Text, FatherNametxtbx.Text, MotherNametxtbx.Text, LastNametxtbx.Text, IdentityNotxtbx.Text, UnivNametxtbx.Text, KolejNametxtbx.Text, DepartmentNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString(), YearlyFeestxtbx.Text, PhoneNotxtbx.Text, SecondPhoneNotxtbx.Text, Emailtxtbx.Text);
                    this.d.f += 1;
                    this.d.Enabled = true;
                    this.d.ControlBox = true;
                    this.Close();
                    MessageBox.Show("تمت اضافة الطالب الجامعي لملف العائلة بنجاح", "تمت الاضافة");
                }
                if (yalnizcami==true)
                {
                    damj();
                }
            }
        }

        void damj()
        {
            string fathername = dataAccess.reader(string.Format("select FatherName from Attaysir1.dbo.univstud where FatherName = '{0}'", FatherNametxtbx.Text), "FatherName");
            string mothername = dataAccess.reader(string.Format("select MotherName from Attaysir1.dbo.univstud where MotherName = '{0}'", MotherNametxtbx.Text), "MotherName");
            string lastname = dataAccess.reader(string.Format("select LastName from Attaysir1.dbo.univstud where LastName = '{0}'", LastNametxtbx.Text),"LastName");

            if (FatherNametxtbx.Text == fathername)
            {
                if (MotherNametxtbx.Text == mothername)
                {
                    if (LastNametxtbx.Text == lastname)
                    {
                        hal_turid_damj_alikhwacs k = new hal_turid_damj_alikhwacs(this); k.Show();
                    }
                }
            }
            else
            {
                l();
            }
        }

        public void k()
        {
            string fathername = dataAccess.reader(string.Format("select FatherName from Attaysir1.dbo.univstud where FatherName = '{0}'", FatherNametxtbx.Text), "FatherName");
            string mothername = dataAccess.reader(string.Format("select MotherName from Attaysir1.dbo.univstud where MotherName = '{0}'", MotherNametxtbx.Text), "MotherName");
            string lastname = dataAccess.reader(string.Format("select LastName from Attaysir1.dbo.univstud where LastName = '{0}'", LastNametxtbx.Text), "LastName");

            string groupid = dataAccess.reader(string.Format("Select GroupId from attaysir1.dbo.univstud where fathername='{0}' and mothername='{1}' and lastname ='{2}'", fathername, mothername,lastname), "GroupId");
            string familyid = dataAccess.reader(string.Format("Select familyid from attaysir1.dbo.univstud where fathername='{0}' and mothername='{1}' and lastname ='{2}'", fathername, mothername, lastname), "familyid");
            Employee2.AddUnivStudWithOutFamily(FirstNametxtbx.Text, FatherNametxtbx.Text, MotherNametxtbx.Text, LastNametxtbx.Text, IdentityNotxtbx.Text, UnivNametxtbx.Text, KolejNametxtbx.Text, DepartmentNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString(), YearlyFeestxtbx.Text, PhoneNotxtbx.Text, SecondPhoneNotxtbx.Text, Emailtxtbx.Text);
            string idofnewone = dataAccess.reader(string.Format("select Id from attaysir1.dbo.univstud where IdentityNu = '{0}'", IdentityNotxtbx.Text), "Id");

            if (dataAccess.reader(string.Format("select univstudid1 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid1") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId1 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid2 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid2") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId2 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid3 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid3") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId3 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid4 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid4") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId4 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid5 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid5") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId5 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid6 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid6") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId6 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid7 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid7") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId7 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }
            else if (dataAccess.reader(string.Format("select univstudid8 from attaysir1.dbo.groups where GroupId ='{0}'", groupid), "univstudid8") == "") { dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.groups SET UnivStudId8 = '{0}' WHERE GroupId = '{1}'", idofnewone, groupid)); }

            dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.univstud SET groupid = '{0}' WHERE id = '{1}'",groupid,idofnewone));
            if (familyid != "") {dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.univstud SET familyid = '{0}' WHERE id = '{1}'", familyid, idofnewone));}
        }

        public void l()
        {
            Employee2.AddUnivStudWithOutFamily(FirstNametxtbx.Text, FatherNametxtbx.Text, MotherNametxtbx.Text, LastNametxtbx.Text, IdentityNotxtbx.Text, UnivNametxtbx.Text, KolejNametxtbx.Text, DepartmentNametxtbx.Text, whichyearcmbbx.SelectedItem.ToString(), YearlyFeestxtbx.Text, PhoneNotxtbx.Text, SecondPhoneNotxtbx.Text, Emailtxtbx.Text);
            string idofnewone = dataAccess.reader(string.Format("select Id from attaysir1.dbo.univstud where IdentityNu = '{0}'", IdentityNotxtbx.Text), "Id");
            dataAccess.Executequery(string.Format("INSERT INTO Attaysir1.dbo.groups(univstudid1) VALUES('{0}')",idofnewone));
            string groupid = dataAccess.reader(string.Format("select groupid from attaysir1.dbo.groups where univstudid1 = '{0}'",idofnewone),"groupid");
            dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.univstud SET groupid = '{0}' WHERE id = '{1}'", groupid, idofnewone));
            MessageBox.Show("تمت اضافة الطالب الجامعي بنجاح", "تمت الاضافة");
            this.Close();
        }

        public string j()
        {
            string fathername0 = dataAccess.reader(string.Format("select FatherName from Attaysir1.dbo.univstud where FatherName = '{0}'", FatherNametxtbx.Text), "FatherName");
            string mothername0 = dataAccess.reader(string.Format("select MotherName from Attaysir1.dbo.univstud where MotherName = '{0}'", MotherNametxtbx.Text), "MotherName");
            string lastname0 = dataAccess.reader(string.Format("select LastName from Attaysir1.dbo.univstud where LastName = '{0}'", LastNametxtbx.Text), "LastName");
            string groupid0 = dataAccess.reader(string.Format("Select GroupId from attaysir1.dbo.univstud where fathername='{0}' and mothername='{1}' and lastname ='{2}'", fathername0, mothername0, lastname0), "GroupId");
            string id = dataAccess.reader(string.Format("select univstudid1 from attaysir1.dbo.groups where GroupId ='{0}'", groupid0), "univstudid1");

            string firstname = dataAccess.reader(string.Format("select firstname from attaysir1.dbo.UnivStud where id = '{0}'", id),"firstname");
            string fathername = dataAccess.reader(string.Format("select FatherName from attaysir1.dbo.UnivStud where id = '{0}'", id),"fathername");
            string mothername = dataAccess.reader(string.Format("select MotherName from attaysir1.dbo.UnivStud where id = '{0}'", id),"mothername");
            string lastname = dataAccess.reader(string.Format("select LastName from attaysir1.dbo.UnivStud where id = '{0}'", id),"lastname");
            string themessage1 = "هاذا الشخص يتشابه مع ";
            string themessage2 = string.Format("{0} {1} {2} ",firstname,fathername,lastname);
            string themessage3 = "اسم الام";
            string themessage4 = string.Format(" {0} ",mothername);
            string themessage5 = "في اسماء الام و الاب و العائلة هل تريد ضبطهما كاخوة ؟";
            string themessage = themessage1 + themessage2 + themessage3 + themessage4 + themessage5;
            return themessage;
        }
    }
}
