using attaysir.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attaysir
{
    public partial class CheckTheDatasForTheListUNIV : Form
    {
        ArrayList univList = new ArrayList();
        int idOfList;
        public CheckTheDatasForTheListUNIV(int idOfList)
        {
            InitializeComponent();
            this.idOfList = idOfList;

            univList.Add("FirstName");
            univList.Add("FatherName");
            univList.Add("MotherName");
            univList.Add("LastName");
            univList.Add("IdentityNu");
            univList.Add("UnivName");
            univList.Add("KolejName");
            univList.Add("DepartmentName");
            univList.Add("YearlyFees");
            univList.Add("whichyear");
            univList.Add("PhoneNu");
            univList.Add("SecondPhoneNu");
            univList.Add("Email");

            GetFaydalananIdes();
        }

        ArrayList ids = new ArrayList();
        void GetFaydalananIdes()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", this.idOfList), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ids.Add(read["Faydalananlae_id"].ToString());
            }
            con.Close();
        }

        ArrayList sqlCommands = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList selectedColumns = new ArrayList();
            if (checkBox1.Checked) { selectedColumns.Add(0); }
            if (checkBox2.Checked) { selectedColumns.Add(1); }
            if (checkBox3.Checked) { selectedColumns.Add(2); }
            if (checkBox4.Checked) { selectedColumns.Add(3); }
            if (checkBox5.Checked) { selectedColumns.Add(4); }
            if (checkBox6.Checked) { selectedColumns.Add(5); }
            if (checkBox7.Checked) { selectedColumns.Add(6); }
            if (checkBox8.Checked) { selectedColumns.Add(7); }
            if (checkBox9.Checked) { selectedColumns.Add(8); }
            if (checkBox10.Checked) { selectedColumns.Add(9); }
            if (checkBox11.Checked) { selectedColumns.Add(10); }
            if (checkBox12.Checked) { selectedColumns.Add(11); }
            if (checkBox13.Checked) { selectedColumns.Add(12); }

            for (int i = 0; i < ids.Count; i++)
            {
                sqlCommands.Add(createSqlCommand(selectedColumns, (String)ids[i]));
            }

            sevdigim_yusufun_istedigi s = new sevdigim_yusufun_istedigi(sqlCommands, selectedColumns, univList);
            s.Show();
            this.Close();
            s.BringToFront();

        }

        private String createSqlCommand(ArrayList selectedList, String id)
        {

            String command = "";
            for (int i = 0; i < selectedList.Count; i++)
            {
                if (i < selectedList.Count - 1)
                {
                    command += univList[(int)selectedList[i]]/* + " as " + uniList[(int)selectedList[i]]*/ + ", ";
                }
                else
                {
                    command += univList[(int)selectedList[i]] /* " as "+ uniList[(int)selectedList[i]]*/;
                }

            }
            String finalCommand = "select " + command + "  from attaysir1.dbo.UnivStud where id =" + id;

            return finalCommand;
        }
    }
}

/*
            if (checkBox2.Checked) { selectedColumns.Add("FirstName"); }
            if (checkBox2.Checked) { selectedColumns.Add("FatherName"); }
            if (checkBox2.Checked) { selectedColumns.Add("MotherName"); }
            if (checkBox2.Checked) { selectedColumns.Add("LastName"); }
            if (checkBox2.Checked) { selectedColumns.Add("IdentityNu"); }
            if (checkBox2.Checked) { selectedColumns.Add("UnivName"); }
            if (checkBox2.Checked) { selectedColumns.Add("KolejName"); }
            if (checkBox2.Checked) { selectedColumns.Add("DepartmentName"); }
            if (checkBox2.Checked) { selectedColumns.Add("YearlyFees"); }
            if (checkBox2.Checked) { selectedColumns.Add("whichyear"); }
            if (checkBox2.Checked) { selectedColumns.Add("PhoneNu"); }
            if (checkBox2.Checked) { selectedColumns.Add("SecondPhoneNu"); }
            if (checkBox2.Checked) { selectedColumns.Add("Email"); }
*/

