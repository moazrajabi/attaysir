using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class CheckingForm : Form
    {
        bool fuck;
        private didntcheckedtimefamily form = null;
        public CheckingForm(Form form,string hid,string wid)
        {
            InitializeComponent();
            this.form = form as didntcheckedtimefamily;
            this.hid = hid;this.wid = wid;
            fuck = true;
        }
        String familyId;
        public CheckingForm(string familyId)
        {
            InitializeComponent();
            this.familyId = familyId;
            fuck = false;
        }
        string hid,wid;

        private void CheckingForm_Load(object sender, EventArgs e)
        {
            if (fuck == true)
            {
                fillThetxtboxes();
                form.lll();
            }

            if (fuck == false)
            {
                fillFamilyBoxes();
                button1.Text = "اغلاق";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fuck == true)
            {
                string query = string.Format("update Attaysir1.dbo.FaydalananAile set CheckedOrNot = 'true' where HusbandIdentificat" +
                    "ionNumber = '{0}' and WifeIdentificationNumber = '{1}'", hid, wid);
                dataAccess.Executequery(query);
                MessageBox.Show("تم تعيين هذا الملف كمرئي");
                this.Close();
                if (form.bigorsmall == false) { form.small(); }
                else if (form.bigorsmall == true) { form.big(); }
            }
            else { this.Close(); }
        }

        private void CheckingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        void fillThetxtboxes()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.FaydalananAile where HusbandIdentificat"+
                "ionNumber = '{0}' and WifeIdentificationNumber = '{1}'",hid,wid), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["FamilyNumber"].ToString();
                textBox2.Text = read["HusbandFirstName"].ToString();
                textBox3.Text = read["HusbandLastName"].ToString();
                textBox4.Text = read["WifeFirstName"].ToString();
                textBox5.Text = read["WifeLastName"].ToString();
                textBox6.Text = read["LivingLocation"].ToString();
                textBox7.Text = read["Adress"].ToString();
                textBox8.Text = read["HusbandIdentificationNumber"].ToString();
                textBox9.Text = read["WifeIdentificationNumber"].ToString();
                textBox10.Text = read["HusbandPhoneNumber"].ToString();
                textBox11.Text = read["WifePhoneNumber"].ToString();
                textBox12.Text = read["NumberOfFamilyMembers"].ToString();
                textBox13.Text = read["HusbandSalary"].ToString();
                textBox14.Text = read["WifeSalary"].ToString();
                textBox15.Text = read["TotalChildrenInsurance"].ToString();
                textBox16.Text = read["NumberOfChildrenTackingInsurance"].ToString();
                textBox17.Text = read["RegisterEmployeesFirstName"].ToString() + read["RegisterEmployeesLastName"].ToString();
                textBox18.Text = read["RegisteretionDateTime"].ToString();
                textBox19.Text = read["MonthlyAverageSalaryOfPerson"].ToString();
                textBox20.Text = read["KindOfFamily"].ToString();
                textBox21.Text = read["ExpiryDateOfFile"].ToString();
                textBox22.Text = read["HusbandOrWife"].ToString();
                textBox23.Text = read["OneMoreColumn"].ToString();
            }
            con.Close();
        }
        private void fillFamilyBoxes()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.FaydalananAile where  id = '{0}'" , familyId), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["FamilyNumber"].ToString();
                textBox2.Text = read["HusbandFirstName"].ToString();
                textBox3.Text = read["HusbandLastName"].ToString();
                textBox4.Text = read["WifeFirstName"].ToString();
                textBox5.Text = read["WifeLastName"].ToString();
                textBox6.Text = read["LivingLocation"].ToString();
                textBox7.Text = read["Adress"].ToString();
                textBox8.Text = read["HusbandIdentificationNumber"].ToString();
                textBox9.Text = read["WifeIdentificationNumber"].ToString();
                textBox10.Text = read["HusbandPhoneNumber"].ToString();
                textBox11.Text = read["WifePhoneNumber"].ToString();
                textBox12.Text = read["NumberOfFamilyMembers"].ToString();
                textBox13.Text = read["HusbandSalary"].ToString();
                textBox14.Text = read["WifeSalary"].ToString();
                textBox15.Text = read["TotalChildrenInsurance"].ToString();
                textBox16.Text = read["NumberOfChildrenTackingInsurance"].ToString();
                textBox17.Text = read["RegisterEmployeesFirstName"].ToString() +" "+ read["RegisterEmployeesLastName"].ToString();
                textBox18.Text = read["RegisteretionDateTime"].ToString();
                textBox19.Text = read["MonthlyAverageSalaryOfPerson"].ToString();
                textBox20.Text = read["KindOfFamily"].ToString();
                textBox21.Text = read["ExpiryDateOfFile"].ToString();
                textBox22.Text = read["HusbandOrWife"].ToString();
                textBox23.Text = read["OneMoreColumn"].ToString();
            }
            con.Close();
        }
    }
}


/*

     */
