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
    public partial class CheckTheDatasForTheListSCHOOL : Form
    {
        int listid;
        int count = 0;
        public CheckTheDatasForTheListSCHOOL(int listid)
        {
            InitializeComponent();
            this.listid = listid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillthecolumnssayisi();
            if (columnssayisi > 1)
            {
                sevdigim_yusufun_istedigi l = new sevdigim_yusufun_istedigi(getcolumns(), ColumnsArr()); l.ShowDialog();
            }
            else { MessageBox.Show("يجب عليك اختيار اكثر من خيار اولا (اثنان على الاقل ) "); }
        }

        int[] getids()
        {/*
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", listid), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { count++; }
            con.Close();*/
            count = int.Parse(dataAccess.reader(string.Format("select * from attaysir1.dbo.TheLists where id='{0}'",listid), "faydalananlarsayisi"));

            int[] ids = new int[count];
            SqlConnection con1 = new SqlConnection(dataAccess.conString);
            con1.Open();int i = 0;
            SqlCommand cmd1 = new SqlCommand(string.Format("select * from Attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", listid), con1);
            SqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read()){ ids[i] = int.Parse(read1["Faydalananlae_id"].ToString());i++; }
            con1.Close();
            return ids;
        }

        ListViewItem[] getcolumns()
        {
            int[] ides = getids();
            int attartib = 0;
            string query="select";
            if (checkBox1.Checked) { query += " FirstName"; attartib++; }
            if (checkBox2.Checked) { if (attartib > 0) { query += " ,FatherName"; } else { query += " FatherName";attartib++; } }
            if (checkBox3.Checked) { if (attartib > 0) { query += " ,MotherName"; } else { query += " MotherName"; attartib++; } }
            if (checkBox4.Checked) { if (attartib > 0) { query += " ,IDNum"; } else { query += " IDNum"; attartib++; } }
            if (checkBox5.Checked) { if (attartib > 0) { query += " ,SchoolName"; } else { query += " SchoolName"; attartib++; } }
            if (checkBox6.Checked) { if (attartib > 0) { query += " ,WhichClass"; } else { query += " WhichClass"; attartib++; } }
            if (checkBox7.Checked) { if (attartib > 0) { query += " ,YearlyFees"; } else { query += " YearlyFees"; attartib++; } }
            if (checkBox8.Checked) { if (attartib > 0) { query += " ,Familyid"; } else { query += " Familyid"; attartib++; } }
            query += string.Format(" from Attaysir1.dbo.SchoolStud where ");
            for (int i=0;i<count;i++)
            {
                if (i == 0) { query += string.Format(" id = '{0}'", ides[i]); } else { query += string.Format(" or id = '{0}'", ides[i]); }
            }
            //MessageBox.Show(count.ToString());
            //MessageBox.Show(query);

            ListViewItem[] itemlist = new ListViewItem[count]; 
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();int k = 0;
            SqlCommand cmd = new SqlCommand(query/*string.Format(query, listid)*/, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                int attartib1 = 0;
                ListViewItem item=null;
                if (checkBox1.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["FirstName"].ToString()); } else {item = new ListViewItem(read["FirstName"].ToString()); attartib1++; } }
                if (checkBox2.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["FatherName"].ToString()); } else { item = new ListViewItem(read["FatherName"].ToString()); attartib1++; } }
                if (checkBox3.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["MotherName"].ToString()); } else { item = new ListViewItem(read["MotherName"].ToString()); attartib1++; } }
                if (checkBox4.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["IDNum"].ToString()); } else { item = new ListViewItem(read["IDNum"].ToString()); attartib1++; } }
                if (checkBox5.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["SchoolName"].ToString()); } else { item = new ListViewItem(read["SchoolName"].ToString()); attartib1++; } }
                if (checkBox6.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["WhichClass"].ToString()); } else { item = new ListViewItem(read["WhichClass"].ToString()); attartib1++; } }
                if (checkBox7.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["YearlyFees"].ToString()); } else { item = new ListViewItem(read["YearlyFees"].ToString()); attartib1++; } }
                if (checkBox8.Checked) { if (attartib1 > 0) { item.SubItems.Add(read["Familyid"].ToString()); } else { item = new ListViewItem(read["Familyid"].ToString()); attartib1++; } }
                itemlist[k] = item;k++;
            }
            con.Close();
            return itemlist;
        }
        int columnssayisi=0;
        void fillthecolumnssayisi()
        {
            if (checkBox1.Checked) { columnssayisi++; }
            if (checkBox2.Checked) { columnssayisi++; }
            if (checkBox3.Checked) { columnssayisi++; }
            if (checkBox4.Checked) { columnssayisi++; }
            if (checkBox5.Checked) { columnssayisi++; }
            if (checkBox6.Checked) { columnssayisi++; }
            if (checkBox7.Checked) { columnssayisi++; }
            if (checkBox8.Checked) { columnssayisi++; }
        }
        string[] ColumnsArr()
        {
            int columnssayisi = 0;
            string[] columns;int count2=0;
            if (checkBox1.Checked) { columnssayisi++; }
            if (checkBox2.Checked) { columnssayisi++; }
            if (checkBox3.Checked) { columnssayisi++; }
            if (checkBox4.Checked) { columnssayisi++; }
            if (checkBox5.Checked) { columnssayisi++; }
            if (checkBox6.Checked) { columnssayisi++; }
            if (checkBox7.Checked) { columnssayisi++; }
            if (checkBox8.Checked) { columnssayisi++; }
            columns = new string[columnssayisi];
            if (checkBox1.Checked) { columns[count2] = "FirstName";count2++; }
            if (checkBox2.Checked) { columns[count2] = "FatherName"; count2++; }
            if (checkBox3.Checked) { columns[count2] = "MotherName"; count2++; }
            if (checkBox4.Checked) { columns[count2] = "IDNum"; count2++; }
            if (checkBox5.Checked) { columns[count2] = "SchoolName"; count2++; }
            if (checkBox6.Checked) { columns[count2] = "WhichClass"; count2++; }
            if (checkBox7.Checked) { columns[count2] = "YearlyFees"; count2++; }
            if (checkBox8.Checked) { columns[count2] = "Familyid"; count2++; }
            return columns;
        }


        private void CheckTheDatasForTheListSCHOOL_Load(object sender, EventArgs e)
        {
            getids();
        }
    }
}

/* 
      ,[FirstName]
      ,[FatherName]
      ,[MotherName]
      ,[IDNum]
      ,[SchoolName]
      ,[WhichClass]
      ,[YearlyFees]
      ,[Familyid]     
*/
