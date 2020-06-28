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
        byte[] amountOfMonthlyRentPDF, amountOfMonthlyElectricBillPDF, amountOfTwoMonthlyWaterBillPDF,
            amountOfYearlyArnonaPDF, totalSchoolsFeesPDF, totalUniversitiesFeesPDF, studentMonthlyTranportaionPDF,
            expensesPDF1, expensesPDF2, expensesPDF3, expensesPDF4, expensesPDF5;

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                totalSchoolsFeesPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                totalUniversitiesFeesPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                studentMonthlyTranportaionPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF1 = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF2 = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF3 = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF4 = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF5 = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                amountOfYearlyArnonaPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                amountOfTwoMonthlyWaterBillPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                amountOfMonthlyElectricBillPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                amountOfMonthlyRentPDF = System.IO.File.ReadAllBytes(path);
            }
        }

        int n = 0, m = 58, locationx = 620, locationy = 157, count = 0, error = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            locationy = locationy + m;
            panel1.Location = new Point(locationx, locationy);
            n++; if (n == 4) { m = 59; }
            if (n >= 5) { m = 0; }
            if (count != 5) { count++; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "") { textBox22.Text = "0"; }
            if (textBox24.Text == "") { textBox24.Text = "0"; }
            if (textBox27.Text == "") { textBox27.Text = "0"; }
            if (textBox30.Text == "") { textBox30.Text = "0"; }
            if (textBox43.Text == "") { textBox43.Text = "0"; }


            string AmountOfMonthlyRent ;         if (amountOfMonthlyRentTxtBx.Text == "") { amountOfMonthlyRentTxtBx.Text = "0"; } AmountOfMonthlyRent = amountOfMonthlyRentTxtBx.Text;
            string AmountOfMonthlyElectricBill ; if (amountOfMonthlyElectricBillTxtBx.Text == "") { amountOfMonthlyElectricBillTxtBx.Text = "0"; } AmountOfMonthlyElectricBill = amountOfMonthlyElectricBillTxtBx.Text;
            string AmountOfTwoMonthlyWaterBill ; if (amountOfTwoMonthlyWaterBillTxtBx.Text == "") { amountOfTwoMonthlyWaterBillTxtBx.Text = "0"; } AmountOfTwoMonthlyWaterBill = amountOfTwoMonthlyWaterBillTxtBx.Text;
            string AmountOfYearlyArnona;         if (amountOfYearlyArnonaTxtBx.Text == "") { amountOfYearlyArnonaTxtBx.Text = "0"; } AmountOfYearlyArnona = amountOfYearlyArnonaTxtBx.Text;
            string TotalSchoolsFees;             if (totalSchoolsFeesTxtBx.Text == "") { totalSchoolsFeesTxtBx.Text = "0"; } TotalSchoolsFees = totalSchoolsFeesTxtBx.Text;
            string TotalUniversitiesFees ;       if (totalUniversitiesFeesTxtBx.Text == "") { totalUniversitiesFeesTxtBx.Text = "0"; } TotalUniversitiesFees = totalUniversitiesFeesTxtBx.Text;
            string StudentMonthlyTranportaion ;  if (studentMonthlyTranportaionTxtBx.Text == "") { studentMonthlyTranportaionTxtBx.Text = "0"; } StudentMonthlyTranportaion = studentMonthlyTranportaionTxtBx.Text;

            string husbandFirstName = hLastNameTxtBx.Text;            string WifeFirstName = wLastNameTxtBx.Text;
            string husbandPhoneNUMber = hPohneNumberTxtBx.Text;           string WifePhoneNumber = wPhoneNumberTxtBx.Text;
            string husbandIdentityNumber = hIdentityNumberTxtBx.Text;        string WifeIdentityNumber = wIdentityNumberTxtBx.Text;
            string FamilyNumOfMember = familyNumberTxtBx.Text;            string LivingLocation = adressTxtBx.Text;
            string Adress = adressDetailsTxtBx.Text;                       string husbandSalary = hSalaryTxtBx.Text;
            string WifeSalary = wSalaryTxtBx.Text;                  string TotalChildrenInsurance = totalChildrenInsuranceTxtBx.Text;
            string FamilyKind=""; string HusbandOrWife="";       string EmployeesNote = employeesNoteTxtBx.Text;
            string NumChildtackInsurance = numChildtackInsuranceTxtBx.Text;             string WifeLastName = wFirstNameTxtBx.Text;                string HusbandLastName = hFirstNameTxtBx.Text;
            
            if (checkBox1.Checked == true) { FamilyKind = "عائلة ايتام"; }
            else if (checkBox2.Checked == true) { FamilyKind = "عائلة متعففة"; }
            if (checkBox4.Checked == true) { HusbandOrWife = "الزوج"; }
            else if (checkBox3.Checked == true) { HusbandOrWife = "الزوجة"; }

            try
            {
                
                int numofChildTackInsurance = int.Parse(NumChildtackInsurance);
                int totalChildrenInsurance = int.Parse(TotalChildrenInsurance);
                int TotalOfExpenses = int.Parse(AmountOfMonthlyRent) + int.Parse(AmountOfMonthlyElectricBill) +
                    int.Parse(AmountOfTwoMonthlyWaterBill) + int.Parse(AmountOfYearlyArnona) + int.Parse(TotalSchoolsFees) +
                    int.Parse(TotalUniversitiesFees) + int.Parse(StudentMonthlyTranportaion) + int.Parse(textBox22.Text) +
                    int.Parse(textBox24.Text) + int.Parse(textBox27.Text) + int.Parse(textBox30.Text) +
                    int.Parse(textBox43.Text);
                int MonthlyAverageSalaryOfPerson = TotalOfExpenses;
            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ ما، الرجاء التأكد من القيم المدخلة", "خطأ");
                error = 1;
            }

            try
            {
               
                if (error != 1)
                {
                    if (hFirstNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوج اولا"; hFirstNameTxtBx.Focus(); }
                    else if (hLastNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوج اولا"; hLastNameTxtBx.Focus(); }
                    else if (wLastNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوجة اولا"; wLastNameTxtBx.Focus(); }
                    else if (wFirstNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوجة اولا"; wFirstNameTxtBx.Focus(); }
                    else if (hPohneNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوج اولا"; hPohneNumberTxtBx.Focus(); }
                    else if (wPhoneNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوجة اولا"; wPhoneNumberTxtBx.Focus(); }
                    else if (hIdentityNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوج اولا"; hIdentityNumberTxtBx.Focus(); }
                    else if (wIdentityNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوجة اولا"; wIdentityNumberTxtBx.Focus(); }
                    else if (familyNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل عدد افراد العائلة اولا"; familyNumberTxtBx.Focus(); }
                    else if (adressTxtBx.Text == "") { richTextBox2.Text = "ادخل مكان السكن اولا"; adressTxtBx.Focus(); }
                    else if (adressDetailsTxtBx.Text == "") { richTextBox2.Text = "ادخل العنوان المفصل اولا"; adressDetailsTxtBx.Focus(); }
                    else if (hSalaryTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوج اولا"; hSalaryTxtBx.Focus(); }
                    else if (wSalaryTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوجة اولا"; wSalaryTxtBx.Focus(); }
                    else if (totalChildrenInsuranceTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار مخصصات الاولاد اولا"; totalChildrenInsuranceTxtBx.Focus(); }
                    else if (numChildtackInsuranceTxtBx.Text == "") { richTextBox2.Text = "ادخل عدد الاولاد الحاصلين على مخصصات اولا"; numChildtackInsuranceTxtBx.Focus(); }

                    else if (Employee2.IfTheFamilyThere(husbandFirstName, WifeFirstName) == true)
                    { richTextBox2.Text = ""; MessageBox.Show("this family is there"); }
                    else if (Employee2.IfTheFamilyThere(husbandFirstName, WifeFirstName) == false)
                    {
                        richTextBox2.Text = "";
                        Employee2.AddFamily(id, husbandFirstName, WifeFirstName, husbandPhoneNUMber, HusbandLastName,
                            WifeLastName, WifePhoneNumber, husbandIdentityNumber, WifeIdentityNumber, int.Parse(
                                FamilyNumOfMember), LivingLocation, Adress, int.Parse(husbandSalary), int.Parse(WifeSalary),
                            int.Parse(TotalChildrenInsurance), FamilyKind, int.Parse(NumChildtackInsurance), HusbandOrWife);
                        Employee2.AddExpenses(husbandIdentityNumber, WifeIdentityNumber, AmountOfMonthlyRent
                            , AmountOfMonthlyElectricBill, AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("حدث خطأ ما، الرجاء التأكد من القيم المدخلة", "خطأ");
            }
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

       
    }
}
