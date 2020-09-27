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
    public partial class CheckingformUniv : Form
    {
        int id;
        public CheckingformUniv(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void CheckingformUniv_Load(object sender, EventArgs e)
        {
            getinformations();
            button1.Text = "اغلاق";
        }

        void getinformations()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.univstud where id='{0}'",this.id.ToString()), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["FirstName"].ToString();
                textBox2.Text = read["FatherName"].ToString();
                textBox3.Text = read["MotherName"].ToString();
                textBox4.Text = read["LastName"].ToString();
                textBox5.Text = read["IdentityNu"].ToString();
                textBox6.Text = read["UnivName"].ToString();
                textBox7.Text = read["KolejName"].ToString();
                textBox8.Text = read["DepartmentName"].ToString();
                textBox9.Text = read["YearlyFees"].ToString();
                textBox10.Text = read["whichyear"].ToString();
                textBox11.Text = read["PhoneNu"].ToString();
                textBox12.Text = read["SecondPhoneNu"].ToString();
                textBox13.Text = read["Email"].ToString();
                if (read["Familyid"].ToString() != "")
                { textBox14.Text = "نعم"; }
                else { textBox14.Text = "لا"; }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
/*SELECT 
 * "].ToString();
                read["Familyid"].ToString();
                read["GroupId"].ToString();
                read["id"].ToString();
                read["FirstName"].ToString();
                read["FatherName"].ToString();
                read["MotherName"].ToString();
                read["LastName"].ToString();
                read["IdentityNu"].ToString();
                read["UnivName"].ToString();
                read["KolejName"].ToString();
                read["DepartmentName"].ToString();
                read["YearlyFees"].ToString();
                read["whichyear"].ToString();
                read["PhoneNu"].ToString();
                read["SecondPhoneNu"].ToString();
                read["Email"].ToString();
                
    FROM Attaysir1.dbo.UnivStud*/
