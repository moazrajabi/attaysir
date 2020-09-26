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
    public partial class Checkingformschool : Form
    {
        int id;
        public Checkingformschool(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Checkingformschool_Load(object sender, EventArgs e)
        {
            getinformations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void getinformations()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.SchoolStud where id ='{0}'",this.id.ToString()), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["Familyid"].ToString();
                textBox2.Text = read["FirstName"].ToString();
                textBox3.Text = read["FatherName"].ToString();
                textBox4.Text = read["MotherName"].ToString();
                textBox6.Text = read["IDNum"].ToString();
                textBox7.Text = read["SchoolName"].ToString();
                textBox8.Text = read["WhichClass"].ToString();
                textBox9.Text = read["YearlyFees"].ToString();
                textBox5.Text = dataAccess.reader(string.Format("select HusbandLastName from attaysir1.dbo.FaydalananAile where id ='{0}'", textBox1.Text), "HusbandLastName");
            }
            con.Close();
        }
    }
}
/*
 * SELECT TOP (1000) [id]
      ,[GroupId]
      
                read["Familyid"].ToString();
                read["FirstName"].ToString();
                read["FatherName"].ToString();
                read["MotherName"].ToString();
                read["IDNum"].ToString();
                read["SchoolName"].ToString();
                read["WhichClass"].ToString();
                read["YearlyFees"].ToString();

  FROM [Attaysir1].[dbo].[SchoolStud]
 */
