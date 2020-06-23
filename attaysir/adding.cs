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
    public partial class adding : Form
    {
        public adding(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        
        public adding(int id,bool IfYouAdminGiveATrueValueToThis)
        {
            InitializeComponent();
            this.id = id;
            this.AdminOrNot = IfYouAdminGiveATrueValueToThis; 
        }
        bool AdminOrNot = false;
        int id;
        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox4.Checked = true;
            panel1.Location = new Point(620, 157);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "") { textBox22.Text = "0"; }
            if (textBox24.Text == "") { textBox24.Text = "0"; }
            if (textBox27.Text == "") { textBox27.Text = "0"; }
            if (textBox30.Text == "") { textBox30.Text = "0"; }
            if (textBox43.Text == "") { textBox43.Text = "0"; }

            string AmountOfMonthlyRent ;         if (textBox14.Text == "") { textBox14.Text = "0"; } AmountOfMonthlyRent = textBox14.Text;
            string AmountOfMonthlyElectricBill ; if (textBox15.Text == "") { textBox15.Text = "0"; } AmountOfMonthlyElectricBill = textBox15.Text;
            string AmountOfTwoMonthlyWaterBill ; if (textBox16.Text == "") { textBox16.Text = "0"; } AmountOfTwoMonthlyWaterBill = textBox16.Text;
            string AmountOfYearlyArnona;         if (textBox17.Text == "") { textBox17.Text = "0"; } AmountOfYearlyArnona = textBox17.Text;
            string TotalSchoolsFees;             if (textBox18.Text == "") { textBox18.Text = "0"; } TotalSchoolsFees = textBox18.Text;
            string TotalUniversitiesFees ;       if (textBox19.Text == "") { textBox19.Text = "0"; } TotalUniversitiesFees = textBox19.Text;
            string StudentMonthlyTranportaion ;  if (textBox20.Text == "") { textBox20.Text = "0"; } StudentMonthlyTranportaion = textBox20.Text;

            string husbandFirstName = textBox10.Text;            string WifeFirstName = textBox9.Text;
            string husbandPhoneNUMber = textBox8.Text;           string WifePhonrNumber = textBox7.Text;
            string husbandIdentityNumber = textBox6.Text;        string WifeIdentityNumber = textBox5.Text;
            string FamilyNumOfMember = textBox4.Text;            string LivingLocation = textBox3.Text;
            string Adress = textBox2.Text;                       string husbandSalary = textBox1.Text;
            string WifeSalary = textBox11.Text;                  string TotalChildrenInsurance = textBox12.Text;
            string FamilyKind=""; string HusbandOrWife="";       string EmployeesNote = richTextBox1.Text;
            string NumChiltackInsurance = textBox13.Text;        string WifeLastName = textBox39.Text;                string HusbandLastName = textBox38.Text;
            
            if (checkBox1.Checked == true) { FamilyKind = "عائلة ايتام"; }
            else if (checkBox2.Checked == true) { FamilyKind = "عائلة متعففة"; }
            if (checkBox4.Checked == true) { HusbandOrWife = "الزوج"; }
            else if (checkBox3.Checked == true) { HusbandOrWife = "الزوجة"; }

            if (textBox38.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوج اولا"; textBox38.Focus(); }
            else if (textBox10.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوج اولا"; textBox10.Focus(); }
            else if (textBox9.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوجة اولا"; textBox9.Focus(); }
            else if (textBox39.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوجة اولا"; textBox39.Focus(); }
            else if (textBox8.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوج اولا"; textBox8.Focus(); }
            else if (textBox7.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوجة اولا"; textBox7.Focus(); }
            else if (textBox6.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوج اولا"; textBox6.Focus(); }
            else if (textBox5.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوجة اولا"; textBox5.Focus(); }
            else if (textBox4.Text == "") { richTextBox2.Text = "ادخل عدد افراد العائلة اولا"; textBox4.Focus(); }
            else if (textBox3.Text == "") { richTextBox2.Text = "ادخل مكان السكن اولا"; textBox3.Focus(); }
            else if (textBox2.Text == "") { richTextBox2.Text = "ادخل العنوان المفصل اولا"; textBox2.Focus(); }
            else if (textBox1.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوج اولا"; textBox1.Focus(); }
            else if (textBox11.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوجة اولا"; textBox11.Focus(); }
            else if (textBox12.Text == "") { richTextBox2.Text = "ادخل مقدار مخصصات الاولاد اولا"; textBox12.Focus(); }
            else if (textBox13.Text == "") { richTextBox2.Text = "ادخل عدد الاولاد الحاصلين على مخصصات اولا"; textBox13.Focus(); }

            else if (Employee2.IfTheFamilyThere(husbandFirstName, WifeFirstName) == true)
            { richTextBox2.Text = ""; MessageBox.Show("this family is there"); }
            else if (Employee2.IfTheFamilyThere(husbandFirstName, WifeFirstName) == false)
            {
                richTextBox2.Text = "";
                Employee2.AddFamily(id, husbandFirstName, WifeFirstName, husbandPhoneNUMber, HusbandLastName,
                    WifeLastName, WifePhonrNumber, husbandIdentityNumber, WifeIdentityNumber, int.Parse(
                        FamilyNumOfMember), LivingLocation, Adress, int.Parse(husbandSalary), int.Parse(WifeSalary),
                    int.Parse(TotalChildrenInsurance), FamilyKind, int.Parse(NumChiltackInsurance), HusbandOrWife);
                Employee2.AddExpenses(husbandIdentityNumber, WifeIdentityNumber, AmountOfMonthlyRent
                    , AmountOfMonthlyElectricBill, AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona);
            }
            //اخر اشي اشتغلت هون
            int TotalOfExpenses=int.Parse(AmountOfMonthlyRent)+ int.Parse(AmountOfMonthlyElectricBill)+
                int.Parse(AmountOfTwoMonthlyWaterBill)+int.Parse(AmountOfYearlyArnona)+int.Parse(TotalSchoolsFees)+
                int.Parse(TotalUniversitiesFees)+int.Parse(StudentMonthlyTranportaion)+int.Parse(textBox22.Text)+
                int.Parse(textBox24.Text)+int.Parse(textBox27.Text)+int.Parse(textBox30.Text)+
                int.Parse(textBox43.Text);
            int MonthlyAverageSalaryOfPerson=TotalOfExpenses;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { checkBox3.Checked = false; }
            if (checkBox4.Checked == false) { checkBox3.Checked = true; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) { checkBox4.Checked = false; }
            if (checkBox3.Checked == false) { checkBox4.Checked = true; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { checkBox1.Checked = false; }
            if (checkBox2.Checked == false) { checkBox1.Checked = true; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { checkBox2.Checked = false; }
            if (checkBox1.Checked == false) { checkBox2.Checked = true; }
        }

        int n = 0, m = 58, locationx = 620, locationy = 157;
        private void button9_Click(object sender, EventArgs e)
        {
            locationy = locationy + m;
            panel1.Location = new Point(locationx, locationy );
            n++; if (n==4) { m = 59; }
            if (n==5) { m = 0; }
        }
    }
}
