﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        public adding(int id, bool IfYouAdminGiveATrueValueToThis)
        {
            InitializeComponent();
            this.id = id;
            this.AdminOrNot = IfYouAdminGiveATrueValueToThis;
        }
        string TheDateTime;
        bool AdminOrNot = false;
        int id;
        String path;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            checkBox2.Checked = true;
            checkBox4.Checked = true;
            panel1.Location = new Point(620, 157);
            panel2.Location = new Point(872, 157);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            ///////////////////////////////////////////
            hFirstNameTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            hLastNameTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            wFirstNameTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            wLastNameTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            hPohneNumberTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            wPhoneNumberTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            hIdentityNumberTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            wIdentityNumberTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            familyNumberTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            hSalaryTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            wSalaryTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            totalChildrenInsuranceTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            numChildtackInsuranceTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            amountOfMonthlyElectricBillTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            amountOfTwoMonthlyWaterBillTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            amountOfYearlyArnonaTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            amountOfMonthlyRentTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            totalSchoolsFeesTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            totalUniversitiesFeesTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            studentMonthlyTranportaionTxtBx.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox21.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox25.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox28.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox41.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox44.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox3.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox6.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox9.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox12.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox15.KeyPress += new KeyPressEventHandler(Employee2.justCharacters);
            textBox22.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox24.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox27.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox30.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox43.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox2.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox5.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox8.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox11.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            textBox14.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            comboBox11.SelectedIndex = 0;
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

        private void button6_Click(object sender, EventArgs e)
        {
           // totalSchoolsFeesPDF = selectFile();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // expensesPDF1 = selectFile();
        }

        private void button11_Click(object sender, EventArgs e)
        {
           // expensesPDF2 = selectFile();
        }

        private void button12_Click(object sender, EventArgs e)
        {
         //   expensesPDF3 = selectFile();
        }

        private void button13_Click(object sender, EventArgs e)
        {
           // expensesPDF4 = selectFile();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           // expensesPDF5 = selectFile();
        }

        int n2 = 0, m2 = 58, locationx2 = 872, locationy2 = 157, count2 = 0;

        private void button15_Click(object sender, EventArgs e)
        {
            Employee2.inarabic("بالعربي");
            textBox3.Text = Employee2.inarabicreed();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            locationy2 = locationy2 + m2;
            panel2.Location = new Point(locationx2, locationy2);
            n2++; if (n2 == 4) { m2 = 59; }
            if (n2 >= 5) { m2 = 0; }
            if (count2 != 5) { count2++; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //amountOfYearlyArnonaPDF = selectFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // amountOfTwoMonthlyWaterBillPDF = selectFile();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            amountOfMonthlyElectricBillPDF = selectFile();
            textBox36.Text = path;
            Employee2.khara(amountOfMonthlyElectricBillPDF);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        int n = 0, m = 58, locationx = 620, locationy = 157, count = 0;
        

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
            /////////////////////////
            if (textBox2.Text == "") { textBox2.Text = "0"; }
            if (textBox5.Text == "") { textBox5.Text = "0"; }
            if (textBox8.Text == "") { textBox8.Text = "0"; }
            if (textBox11.Text == "") { textBox11.Text = "0"; }
            if (textBox14.Text == "") { textBox14.Text = "0"; }

            if (hFirstNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوج اولا"; hFirstNameTxtBx.Focus(); }
            else if (hLastNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوج اولا"; hLastNameTxtBx.Focus(); }
            else if (wFirstNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاول للزوجة اولا"; wFirstNameTxtBx.Focus(); }
            else if (wLastNameTxtBx.Text == "") { richTextBox2.Text = "ادخل الاسم الاخير للزوجة اولا"; wLastNameTxtBx.Focus(); }
            else if (hPohneNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوج اولا"; hPohneNumberTxtBx.Focus(); }
            else if (wPhoneNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هاتف الزوجة اولا"; wPhoneNumberTxtBx.Focus(); }
            else if (hIdentityNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوج اولا"; hIdentityNumberTxtBx.Focus(); }
            else if (wIdentityNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل رقم هوية الزوجة اولا"; wIdentityNumberTxtBx.Focus(); }
            else if (familyNumberTxtBx.Text == "") { richTextBox2.Text = "ادخل عدد افراد العائلة اولا"; familyNumberTxtBx.Focus(); }
            else if (comboBox11.SelectedIndex == 0) { richTextBox2.Text = "اختر مكان السكن اولا"; comboBox11.Focus(); }
            else if (adressDetailsTxtBx.Text == "") { richTextBox2.Text = "ادخل العنوان المفصل اولا"; adressDetailsTxtBx.Focus(); }
            else if (hSalaryTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوج اولا"; hSalaryTxtBx.Focus(); }
            else if (wSalaryTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار راتب الزوجة اولا"; wSalaryTxtBx.Focus(); }
            else if (totalChildrenInsuranceTxtBx.Text == "") { richTextBox2.Text = "ادخل مقدار مخصصات الاولاد اولا"; totalChildrenInsuranceTxtBx.Focus(); }
            else if (numChildtackInsuranceTxtBx.Text == "") { richTextBox2.Text = "ادخل عدد الاولاد الحاصلين على مخصصات اولا"; numChildtackInsuranceTxtBx.Focus(); }
            else if (checker(textBox21, textBox22, textBox40, comboBox1) == true) { richTextBox2.Text = "املا فراغات المصروف الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox40.Focus(); }
            else if (checker(textBox25, textBox24, textBox23, comboBox2) == true) { richTextBox2.Text = "املا فراغات المصروف الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox23.Focus(); }
            else if (checker(textBox28, textBox27, textBox26, comboBox3) == true) { richTextBox2.Text = "املا فراغات المصروف الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox26.Focus(); }
            else if (checker(textBox41, textBox30, textBox29, comboBox4) == true) { richTextBox2.Text = "املا فراغات المصروف الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox29.Focus(); }
            else if (checker(textBox44, textBox43, textBox42, comboBox5) == true) { richTextBox2.Text = "املا فراغات المصروف الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox42.Focus(); }
            else if (checker(textBox1, textBox2, textBox3, comboBox6) == true) { richTextBox2.Text = "املا فراغات المدخول الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox1.Focus(); }
            else if (checker(textBox4, textBox5, textBox6, comboBox7) == true) { richTextBox2.Text = "املا فراغات المدخول الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox4.Focus(); }
            else if (checker(textBox7, textBox8, textBox9, comboBox8) == true) { richTextBox2.Text = "املا فراغات المدخول الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox7.Focus(); }
            else if (checker(textBox10, textBox11, textBox12, comboBox9) == true) { richTextBox2.Text = "املا فراغات المدخول الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox10.Focus(); }
            else if (checker(textBox13, textBox14, textBox15, comboBox10) == true) { richTextBox2.Text = "املا فراغات المدخول الاضافي الاول بشكل صحيح او اختر الدورة الزمنية له"; textBox13.Focus(); }
            else
            {
                richTextBox2.Text = "";

                string lvngLctnCmbBx = ""; if (comboBox11.SelectedIndex == 1) { lvngLctnCmbBx = "داخل البلدة القديمة"; }
                if (comboBox11.SelectedIndex == 2) { lvngLctnCmbBx = "خارج البلدة القديمة"; }

                string AmountOfMonthlyRent; if (amountOfMonthlyRentTxtBx.Text == "") { amountOfMonthlyRentTxtBx.Text = "0"; }
                AmountOfMonthlyRent = amountOfMonthlyRentTxtBx.Text;
                string AmountOfMonthlyElectricBill; if (amountOfMonthlyElectricBillTxtBx.Text == "") { amountOfMonthlyElectricBillTxtBx.Text = "0"; }
                AmountOfMonthlyElectricBill = amountOfMonthlyElectricBillTxtBx.Text;
                string AmountOfTwoMonthlyWaterBill; if (amountOfTwoMonthlyWaterBillTxtBx.Text == "") { amountOfTwoMonthlyWaterBillTxtBx.Text = "0"; }
                AmountOfTwoMonthlyWaterBill = amountOfTwoMonthlyWaterBillTxtBx.Text;
                string AmountOfYearlyArnona; if (amountOfYearlyArnonaTxtBx.Text == "") { amountOfYearlyArnonaTxtBx.Text = "0"; }
                AmountOfYearlyArnona = amountOfYearlyArnonaTxtBx.Text;
                string TotalSchoolsFees; if (totalSchoolsFeesTxtBx.Text == "") { totalSchoolsFeesTxtBx.Text = "0"; }
                TotalSchoolsFees = totalSchoolsFeesTxtBx.Text;
                string TotalUniversitiesFees; if (totalUniversitiesFeesTxtBx.Text == "") { totalUniversitiesFeesTxtBx.Text = "0"; }
                TotalUniversitiesFees = totalUniversitiesFeesTxtBx.Text;
                string StudentMonthlyTranportaion; if (studentMonthlyTranportaionTxtBx.Text == "") { studentMonthlyTranportaionTxtBx.Text = "0"; }
                StudentMonthlyTranportaion = studentMonthlyTranportaionTxtBx.Text;

                string HusbandLastName = hFirstNameTxtBx.Text;
                string husbandFirstName = hLastNameTxtBx.Text; string WifeFirstName = wLastNameTxtBx.Text;
                string husbandPhoneNUMber = hPohneNumberTxtBx.Text; string WifePhoneNumber = wPhoneNumberTxtBx.Text;
                string husbandIdentityNumber = hIdentityNumberTxtBx.Text; string WifeIdentityNumber = wIdentityNumberTxtBx.Text;
                string FamilyNumOfMember = familyNumberTxtBx.Text; string LivingLocation = lvngLctnCmbBx;
                string Adress = adressDetailsTxtBx.Text; string husbandSalary = hSalaryTxtBx.Text;
                string WifeSalary = wSalaryTxtBx.Text; string TotalChildrenInsurance = totalChildrenInsuranceTxtBx.Text;
                string FamilyKind = ""; string HusbandOrWife = ""; string EmployeesNote = employeesNoteTxtBx.Text;
                string NumChildtackInsurance = numChildtackInsuranceTxtBx.Text; string WifeLastName = wFirstNameTxtBx.Text;

                if (checkBox1.Checked == true) { FamilyKind = "عائلة ايتام"; }
                else if (checkBox2.Checked == true) { FamilyKind = "عائلة متعففة"; }
                if (checkBox4.Checked == true) { HusbandOrWife = "الزوج"; }
                else if (checkBox3.Checked == true) { HusbandOrWife = "الزوجة"; }

                int numofChildTackInsurance = int.Parse(NumChildtackInsurance);
                int TotalOfExpenses = int.Parse(AmountOfMonthlyRent) + int.Parse(AmountOfMonthlyElectricBill) +
                    int.Parse(AmountOfTwoMonthlyWaterBill) + int.Parse(AmountOfYearlyArnona) + int.Parse(TotalSchoolsFees) +
                    int.Parse(TotalUniversitiesFees) + int.Parse(StudentMonthlyTranportaion) + int.Parse(textBox22.Text) +
                    int.Parse(textBox24.Text) + int.Parse(textBox27.Text) + int.Parse(textBox30.Text) +
                    int.Parse(textBox43.Text);
                int TotalOfSalaries = int.Parse(TotalChildrenInsurance) + int.Parse(WifeSalary) + int.Parse(husbandSalary) + int.Parse(textBox2.Text) +
                    int.Parse(textBox5.Text) + int.Parse(textBox8.Text) + int.Parse(textBox11.Text) + int.Parse(textBox14.Text);

                int MonthlyAverageSalaryOfPerson = ((TotalOfSalaries - TotalOfExpenses) / int.Parse(FamilyNumOfMember));

                try
                {
                    richTextBox2.Text = "";
                    if (Employee2.ifthefamilythere1(hIdentityNumberTxtBx.Text.Trim(), wIdentityNumberTxtBx.Text.Trim()) == true)
                    {
                        MessageBox.Show("هذا الملف مسجل فعلا", "خطأ");
                    }
                    else
                    {
                        //////
                        string firstnameofemploadmin = "", lastnameofemploadmin = "";
                        if (AdminOrNot == false) { firstnameofemploadmin = Employee2.FirstNameById(id); lastnameofemploadmin = Employee2.LastNameById(id); }
                        if (AdminOrNot == true) { firstnameofemploadmin = Employee2.FirstNameByIdAdmin(id); lastnameofemploadmin = Employee2.LastNameByIdAdmin(id); }
                        //////
                        Employee2.AddFamily(husbandFirstName, WifeFirstName, husbandPhoneNUMber, HusbandLastName,
                            WifeLastName, WifePhoneNumber, husbandIdentityNumber, WifeIdentityNumber, int.Parse(
                                FamilyNumOfMember), LivingLocation, Adress, int.Parse(husbandSalary), int.Parse(WifeSalary),
                            int.Parse(TotalChildrenInsurance), FamilyKind, int.Parse(NumChildtackInsurance), HusbandOrWife,
                            MonthlyAverageSalaryOfPerson, firstnameofemploadmin, lastnameofemploadmin,this.TheDateTime);
                        Employee2.AddExpenses(husbandIdentityNumber, WifeIdentityNumber, AmountOfMonthlyRent
                            , AmountOfMonthlyElectricBill, AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona);
                        if (employeesNoteTxtBx.Text != ""){Employee2.AddEmployeesNote(husbandIdentityNumber,
                            WifeIdentityNumber, employeesNoteTxtBx.Text, firstnameofemploadmin, lastnameofemploadmin, this.TheDateTime);}
                        if (checker(textBox21, textBox22, textBox40, comboBox1) == false)
                        { Employee2.AddOtherExpenses(husbandIdentityNumber, WifeIdentityNumber, textBox21.Text, int.Parse(textBox22.Text), comboBox1.Text); }
                        if (checker(textBox25, textBox24, textBox23, comboBox2) == false)
                        { Employee2.AddOtherExpenses(husbandIdentityNumber, WifeIdentityNumber, textBox25.Text, int.Parse(textBox24.Text), comboBox2.Text); }
                        if (checker(textBox28, textBox27, textBox26, comboBox3) == false)
                        { Employee2.AddOtherExpenses(husbandIdentityNumber, WifeIdentityNumber, textBox28.Text, int.Parse(textBox27.Text), comboBox3.Text); }
                        if (checker(textBox41, textBox30, textBox29, comboBox4) == false)
                        { Employee2.AddOtherExpenses(husbandIdentityNumber, WifeIdentityNumber, textBox41.Text, int.Parse(textBox30.Text), comboBox4.Text); }
                        if (checker(textBox44, textBox43, textBox42, comboBox5) == false)
                        { Employee2.AddOtherExpenses(husbandIdentityNumber, WifeIdentityNumber, textBox44.Text, int.Parse(textBox43.Text), comboBox5.Text); }
                        if (checker(textBox1, textBox2, textBox3, comboBox6) == false)
                        { Employee2.AddOtherSalaries(husbandIdentityNumber, WifeIdentityNumber, textBox1.Text, int.Parse(textBox2.Text), comboBox6.Text); }
                        if (checker(textBox4, textBox5, textBox6, comboBox7) == false)
                        { Employee2.AddOtherSalaries(husbandIdentityNumber, WifeIdentityNumber, textBox4.Text, int.Parse(textBox5.Text), comboBox7.Text); }
                        if (checker(textBox7, textBox8, textBox9, comboBox8) == false)
                        { Employee2.AddOtherSalaries(husbandIdentityNumber, WifeIdentityNumber, textBox7.Text, int.Parse(textBox8.Text), comboBox8.Text); }
                        if (checker(textBox10, textBox11, textBox12, comboBox9) == false)
                        { Employee2.AddOtherSalaries(husbandIdentityNumber, WifeIdentityNumber, textBox10.Text, int.Parse(textBox11.Text), comboBox9.Text); }
                        if (checker(textBox13, textBox14, textBox15, comboBox10) == false)
                        { Employee2.AddOtherSalaries(husbandIdentityNumber, WifeIdentityNumber, textBox13.Text, int.Parse(textBox14.Text), comboBox10.Text); }
                        MessageBox.Show("تمت اضافة الملف بنجاح");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { checkBox3.Checked = false; }
            if (checkBox4.Checked == false) { checkBox3.Checked = true; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TheDateTime = time.ToString();
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

        public static bool checker(TextBox textBox1, TextBox textBox2, TextBox textBox3, ComboBox comboBox1)
        {
            if (textBox1.Text != "" && (textBox2.Text == "" || textBox2.Text == "0" || textBox3.Text == "" || comboBox1.SelectedIndex == 0)) { return true; }
            else if (textBox2.Text != "" && textBox2.Text != "0" && (textBox1.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == 0)) { return true; }
            else if (textBox3.Text != "" && (textBox2.Text == "" || textBox2.Text == "0" || textBox1.Text == "" || comboBox1.SelectedIndex == 0)) { return true; }
            else if (comboBox1.SelectedIndex != 0 && (textBox1.Text == "" || textBox2.Text == "" || textBox2.Text == "0" || textBox3.Text == "")) { return true; }
            else { return false; }
        }

        byte[] amountOfMonthlyRentPDF, amountOfMonthlyElectricBillPDF, amountOfTwoMonthlyWaterBillPDF,
            amountOfYearlyArnonaPDF, totalSchoolsFeesPDF, totalUniversitiesFeesPDF, studentMonthlyTranportaionPDF,
            expensesPDF1, expensesPDF2, expensesPDF3, expensesPDF4, expensesPDF5;

        private byte[] selectFile1()
        {
            /*
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String path = openFile.FileName;
                expensesPDF2 = System.IO.File.ReadAllBytes(path);
            }
             */
            byte[] variable = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                FileStream fStream = File.OpenRead(path);
                long length = fStream.Length;
                int length1 = (int)length;
                variable = new byte[length1];
                fStream.Read(variable, 0, length1);
                //fStream.Close();
                //variable = System.IO.File.ReadAllBytes(path);
                ////Encoding.ASCII.GetBytes("string")//this for converting from string to byte array
                //  variable = getFileBytes(path);
                this.path = path.Substring(path.LastIndexOf("\\") + 1);
            }
            return variable;
        }

        private byte[] selectFile()
        {
            byte[] variable = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                FileStream fStream = File.OpenRead(path);
                long length = fStream.Length;
                int length1 = (int)length;
                variable = new byte[length1];
                fStream.Read(variable, 0, length1);
                this.path = path.Substring(path.LastIndexOf("\\") + 1);
            }
            return variable;
        }


        private byte[] getFileBytes(String path)
        {
            byte[] ba1;

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            long FileSize = fs.Length;

            BinaryReader br = new BinaryReader(fs);
            ba1 = br.ReadBytes((Int32)FileSize);
            
            br.Close();
            fs.Close();
            Console.WriteLine(ba1);

            return (ba1);
        }


        protected void btnSavePdf_Click(object sender, EventArgs e)
        {
            char[] variable = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "pdf files (*.pdf) |*.pdf;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                /*
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=attaysir;Integrated Security=True");
            cn.Open();
            //Convert pdf in Binary formate
            int lenght = FileUpload1.PostedFile.ContentLength;
            byte[] data = new byte[lenght];
            FileUpload1.PostedFile.InputStream.Read(data, 0, lenght);
            SqlCommand cmd = new SqlCommand("insert into tblPdfData " + "(PdfData) values(@data)", cn);
            cmd.Parameters.Add("@data", data);
            cmd.ExecuteNonQuery();
            Response.Write("Pdf File Save in Dab");
            */
                this.path = path.Substring(path.LastIndexOf("\\") + 1);
            }
        }
    }
}
/*FamilyNumber,RegisteretionDateTime,MonthlyAverageSalaryOfPerson,ExpiryDateOfFile*/
