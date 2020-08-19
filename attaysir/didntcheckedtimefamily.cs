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
    public partial class didntcheckedtimefamily : Form
    {
        //bool f = false;
        private adminmain form = null;
        public didntcheckedtimefamily(Form form)
        {
            InitializeComponent();
            this.form = form as adminmain;
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            listView1.Location = new Point(4,4);
            button1.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width - 15) / 2) - 13, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width / 2), (int.Parse(this.Height.ToString()) - 67));
        }

        private void didntcheckedtimefamily_Load(object sender, EventArgs e)
        {
            small();
        }

        public void big()
        {
            listView1.Columns.Clear();
            string[] k1 = { "رقم العائلة", "الاسم الاول للزوج", "الاسم الاخير للزوج",
                "الاسم الاول للزوجة", "الاسم الاخير للزوجة", "مكان السكن", "العنوان المفصل",
                "رقم هوية الزوج", "رقم هوية الزوجة", "رقم هاتف الزوج", "رقم هاتف الزوجة",
                "عدد افراد الاسرة", "معاش الزوج", "معاش الزوجة", "مقدار مخصصات الاولاد",
                "عدد الاولاد الحاصلين على مخصصات", "الاسم الاول للموظف المسجل",
                "الاسم الاخير للموظف المسجل", "تاريخ و وقت التسجيل", "معدل الدخل الفردي للعائلة",
                "نوع العائلة", "تاريخ انتهاء فعالية الملف", "التواصل مع الزوج ام الزوجة",
                "تمت معاينة الملف ام لا" };
            string[] k = { "FamilyNumber", "HusbandFirstName", "HusbandLastName", "WifeFirstName",
                "WifeLastName", "LivingLocation", "Adress", "HusbandIdentificationNumber",
                "WifeIdentificationNumber", "HusbandPhoneNumber", "WifePhoneNumber",
                "NumberOfFamilyMembers", "HusbandSalary", "WifeSalary", "TotalChildrenInsurance",
                "NumberOfChildrenTackingInsurance", "RegisterEmployeesFirstName", "RegisterEmployeesLastName",
                "RegisteretionDateTime", "MonthlyAverageSalaryOfPerson", "KindOfFamily", "ExpiryDateOfFile",
                "HusbandOrWife", "CheckedOrNot" };
            listView1.Columns.Add("");
            for (int i = 0; i < k1.LongLength; i++)
            {
                listView1.Columns.Add(k1[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewer(listView1, "faydalananaile where CheckedOrNot ='false'", k);
        }

        public void small()
        {
            listView1.Columns.Clear();
            string[] k1 = { "رقم العائلة", "الاسم الاول للزوج", "الاسم الاخير للزوج",
                "الاسم الاول للزوجة", "الاسم الاخير للزوجة", "رقم هوية الزوج",
                "رقم هوية الزوجة", "رقم هاتف الزوج", "رقم هاتف الزوجة",
                "معدل الدخل الفردي للعائلة" };
            string[] k = { "FamilyNumber", "HusbandFirstName", "HusbandLastName",
                "WifeFirstName", "WifeLastName", "HusbandIdentificationNumber",
                "WifeIdentificationNumber", "HusbandPhoneNumber", "WifePhoneNumber",
                "MonthlyAverageSalaryOfPerson" };
            listView1.Columns.Add("");
            for (int i = 0; i < k1.LongLength; i++)
            {
                listView1.Columns.Add(k1[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewer(listView1, "faydalananaile where CheckedOrNot ='false'", k);
        }

        private void didntcheckedtimefamily_Resize(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            listView1.Location = new Point(4, 4);
            button1.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width - 15) / 2) - 13, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width / 2), (int.Parse(this.Height.ToString()) - 67));
        }
        public bool bigorsmall=false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (bigorsmall == true) { small(); bigorsmall = false; button1.Text = "اظهار تفاصيل اكثر"; }
            else if (bigorsmall==false) { big();bigorsmall = true;button1.Text = "اظهار تفاصيل اقل"; }

        }

        public string IdentificetionNumber1 = "";
        public string IdentificetionNumber2 = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (bigorsmall == true)
            {
                IdentificetionNumber1 = listView1.SelectedItems[0].SubItems[8].Text;
                IdentificetionNumber2 = listView1.SelectedItems[0].SubItems[9].Text;
            }
            else if (bigorsmall == false)
            {
                IdentificetionNumber1 = listView1.SelectedItems[0].SubItems[6].Text;
                IdentificetionNumber2 = listView1.SelectedItems[0].SubItems[7].Text;
            }
            GivingExpiryDate n = new GivingExpiryDate(this);n.Show();
        }

        private void didntcheckedtimefamily_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.k();
        }
    }
}
/*
 ملاحظة مهمة يجب على البرنامج ان يقارن تاريخ الانتهاء مع التاريخ الحالي و ارجاعة الى ملفات تحتاج الى تاريخ انتهاء ان لزم الامر
*/

