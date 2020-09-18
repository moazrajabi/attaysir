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
    public partial class officermain : Form
    {
        public officermain(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        int id;

        private void button1_Click(object sender, EventArgs e)
        {
            adding n = new adding(id); n.Show();
        }
        
        private void officermain_Load(object sender, EventArgs e)
        {
            string f = Employee2.NameById(id);
            richTextBox1.Text = f;

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FullRowSelect = true;
            timer1.Start();
            getMessages();
        }

        bool bo1;//this bool for control the ligting of button13(the if there a files needs togiving time) 
                 //if it false its mean no lighting and if it true means lighting
        public void k1()
        {
            if (admin.checkedornot() == true) { this.bo1 = true; }
            else if (admin.checkedornot() == false) { this.bo1 = false; }
        }
        //هاد اللي بالفنكشن اللي فوق ني واحد لازم اغيرهم هدول ضلهم زي ما همن من لما نقلتهم من واجهة الادمن

        bool f1 = true;
        void sabit_mi_degisken_mi1(bool bo)
        {
            if (bo == true)
            {
                if (f1 == true) { button.ForeColor = Color.Red; panel.BackColor = Color.Red; f1 = false; }
                else if (f1 == false) { button.ForeColor = Color.Black; panel.BackColor = this.BackColor; f1 = true; }
            }
            if (bo == false) { button.ForeColor = Color.Black; panel.BackColor = this.BackColor; }
        }
        private void button_Click(object sender, EventArgs e) {}
        
        int n = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sabit_mi_degisken_mi1(this.bo1);
            k1();
            if (n % 7 == 0)
            {
                getMessages();
            }
            n++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] TheIdsList; int h = 0;
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.faydalananaile where CheckedOrNot = 'true' ", con);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read()) { h++; }
            read.Close();
            SqlDataReader read1 = cmd.ExecuteReader();
            TheIdsList = new int[h]; int g = 0;
            while (read1.Read())
            {
                TheIdsList[g] = int.Parse(read1["id"].ToString());
                g++;
            }
            con.Close();

            if (LivingLocationCmbbx.SelectedIndex == 0 || LivingLocationCmbbx.SelectedIndex == 1)
            { TheIdsList = LivingLocationFilter(TheIdsList); }
            if (KindOfFamilyCmbbx.SelectedIndex == 0 || KindOfFamilyCmbbx.SelectedIndex == 1)
            { TheIdsList = kindOfFamilyFilter(TheIdsList); }
            if (MinSalarytxtbx.Text != "")
            { TheIdsList = MinSalaryFilter(TheIdsList); }
            if (MaxSalarytxtbx.Text != "")
            { TheIdsList = MaxSalaryFilter(TheIdsList); }
            the_lists k = new the_lists(TheIdsList); k.Show();
        }

        private void button8_Click(object sender, EventArgs e) { the_lists k = new the_lists(true); k.Show(); }

        int[] LivingLocationFilter(int[] TheIdsList)
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); SqlCommand cmd;
            if (LivingLocationCmbbx.SelectedIndex == 0)
            {
                cmd = new SqlCommand("select * from attaysir1.dbo.faydalananaile where LivingLocation='داخل البلدة القديمة' ", con);
            }
            else { cmd = new SqlCommand("select * from attaysir1.dbo.faydalananaile where LivingLocation='خارج البلدة القديمة' ", con); }
            SqlDataReader read = cmd.ExecuteReader();
            int h = 0;
            while (read.Read()) { h++; }
            read.Close(); SqlDataReader read1 = cmd.ExecuteReader(); int[] n = new int[h]; int g = 0;
            while (read1.Read()) { n[g] = int.Parse(read1["id"].ToString()); g++; }

            int k = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int p = 0; p < TheIdsList.Length; p++)
                {
                    if (n[t] == TheIdsList[p]) { k++; }
                }
            }
            int[] son = new int[k]; int y = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int o = 0; o < TheIdsList.Length; o++)
                {
                    if (n[t] == TheIdsList[o]) { son[y] = n[t]; y++; }
                }
            }
            con.Close();
            return son;
        }

        int[] kindOfFamilyFilter(int[] TheIdsList)
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); SqlCommand cmd;
            if (KindOfFamilyCmbbx.SelectedIndex == 0)
            {
                cmd = new SqlCommand("select * from attaysir1.dbo.faydalananaile where KindOfFamily = 'عائلة متعففة' ", con);
            }
            else { cmd = new SqlCommand("select * from attaysir1.dbo.faydalananaile where KindOfFamily = 'عائلة ايتام' ", con); ; }
            SqlDataReader read = cmd.ExecuteReader(); int h = 0;
            while (read.Read()) { h++; }
            read.Close(); SqlDataReader read1 = cmd.ExecuteReader(); int[] n = new int[h]; int g = 0;
            while (read1.Read()) { n[g] = int.Parse(read1["id"].ToString()); g++; }
            int k = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int p = 0; p < TheIdsList.Length; p++)
                {
                    if (n[t] == TheIdsList[p]) { k++; }
                }
            }
            int[] son = new int[k]; int y = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int o = 0; o < TheIdsList.Length; o++)
                {
                    if (n[t] == TheIdsList[o]) { son[y] = n[t]; y++; }
                }
            }
            con.Close();
            return son;
        }

        int[] MinSalaryFilter(int[] TheIdsList)
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); SqlCommand cmd;
            string quary = string.Format("SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE MonthlyAverageSalaryOfPerson > {0}", MinSalarytxtbx.Text);
            cmd = new SqlCommand(quary, con);
            SqlDataReader read = cmd.ExecuteReader(); int h = 0;
            while (read.Read()) { h++; }
            read.Close(); SqlDataReader read1 = cmd.ExecuteReader(); int[] n = new int[h]; int g = 0;
            while (read1.Read()) { n[g] = int.Parse(read1["id"].ToString()); g++; }
            int k = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int p = 0; p < TheIdsList.Length; p++)
                {
                    if (n[t] == TheIdsList[p]) { k++; }
                }
            }
            int[] son = new int[k]; int y = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int o = 0; o < TheIdsList.Length; o++)
                {
                    if (n[t] == TheIdsList[o]) { son[y] = n[t]; y++; }
                }
            }
            con.Close();
            return son;
        }

        int[] MaxSalaryFilter(int[] TheIdsList)
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); SqlCommand cmd;
            string quary = string.Format("SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE MonthlyAverageSalaryOfPerson < {0}", MaxSalarytxtbx.Text);
            cmd = new SqlCommand(quary, con);
            SqlDataReader read = cmd.ExecuteReader(); int h = 0;
            while (read.Read()) { h++; }
            read.Close(); SqlDataReader read1 = cmd.ExecuteReader(); int[] n = new int[h]; int g = 0;
            while (read1.Read()) { n[g] = int.Parse(read1["id"].ToString()); g++; }
            int k = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int p = 0; p < TheIdsList.Length; p++)
                {
                    if (n[t] == TheIdsList[p]) { k++; }
                }
            }
            int[] son = new int[k]; int y = 0;
            for (int t = 0; t < n.Length; t++)
            {
                for (int o = 0; o < TheIdsList.Length; o++)
                {
                    if (n[t] == TheIdsList[o]) { son[y] = n[t]; y++; }
                }
            }
            con.Close();
            return son;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AddUnivStud k = new AddUnivStud(); k.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            if (message != "")
            {
                SelectReciever k = new SelectReciever(message, id, "employee"); k.Show();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string time = listView1.SelectedItems[0].SubItems[2].Text;
                string readedornot = ""; if (listView1.SelectedItems[0].SubItems[3].Text == "غير مقروئة") { readedornot = "false"; }
                if (listView1.SelectedItems[0].SubItems[3].Text == "مقروئة") { readedornot = "true"; }
                string idofsender = "";
                string firstname = "", lastname = ""; name.ToCharArray(); bool firstorlast = false;
                string senderadminoremloyee = "";
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i].ToString() != " " && firstorlast == false) { firstname += name[i].ToString(); }
                    if (name[i].ToString() != " " && firstorlast == true) { lastname += name[i].ToString(); }
                    if (name[i].ToString() == " ") { firstorlast = true; }
                }

                bool resultAdmin;
                DataTable dt = dataAccess.Executequery(string.Format("Select id from attaysir1.dbo.admin where adminfirstname = '{0}' and adminlastname = '{1}'", firstname, lastname));
                if (dt.Rows.Count > 0) { resultAdmin = true; } else { resultAdmin = false; }

                bool resultEmployee;
                DataTable dt1 = dataAccess.Executequery(string.Format("Select id from attaysir1.dbo.employee where firstname = '{0}' and lastname = '{1}'", firstname, lastname));
                if (dt1.Rows.Count > 0) { resultEmployee = true; } else { resultEmployee = false; }

                if (resultAdmin == true) { senderadminoremloyee = "admin"; idofsender = dataAccess.reader(string.Format("Select id from attaysir1.dbo.admin where adminfirstname = '{0}' and adminlastname = '{1}'", firstname, lastname), "id"); }
                if (resultEmployee == true) { senderadminoremloyee = "employee"; idofsender = dataAccess.reader(string.Format("Select id from attaysir1.dbo.employee where firstname = '{0}' and lastname = '{1}'", firstname, lastname), "id"); }
                if ((resultAdmin == true && resultEmployee == true) || idofsender == "") { MessageBox.Show("اسم المستخدم المدخل يتشابه مع اسم ادمن و اسم موظف في نفس الوقت او غير موجود"); }
                else
                {
                    string message = dataAccess.reader(string.Format("select message from attaysir1.dbo.messages where senderid = '{0}' and senderadminoremployee = '{1}' and recieverid ='{2}'" +
                        " and recieveradminoremployee = '{3}' and dateofsendding = '{4}' and seen = '{5}'", idofsender, senderadminoremloyee, this.id, "admin", time, readedornot), "message");

                    int messageid = int.Parse(dataAccess.reader(string.Format("select id from attaysir1.dbo.messages where senderid = '{0}' and senderadminoremployee = '{1}' and recieverid ='{2}'" +
                        " and recieveradminoremployee = '{3}' and dateofsendding = '{4}' and seen = '{5}'", idofsender, senderadminoremloyee, this.id, "admin", time, readedornot), "id"));

                    TheMessage k = new TheMessage(message, messageid, this); k.Show();
                }
            }
            catch { }
        }

        public void getMessages()
        {
            listView1.Items.Clear();
            getMessages1();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.messages where recieverid = '{0}' and recieveradminoremployee = '{1}' order by dateofsendding desc", id, "employee"), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read["seen"].ToString() == "true")
                {
                    ListViewItem item = new ListViewItem();
                    int id = int.Parse(read["senderid"].ToString());
                    if (read["recieveradminoremployee"].ToString() == "employee")
                    {
                        String nameQuery = "select * from dbo.employee where id = " + id;
                        string name = dataAccess.reader(nameQuery, "firstName") + " " + dataAccess.reader(nameQuery, "lastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("مقروئة");
                    }
                    else
                    {
                        String nameQuery = "select * from dbo.admin where id = " + id;
                        string name = dataAccess.reader(nameQuery, "adminfirstName") + " " + dataAccess.reader(nameQuery, "adminlastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("مقروئة");
                    }
                    listView1.Items.Add(item);
                }
            }
            con.Close();
        }

        public void getMessages1()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.messages where recieverid = '{0}' and recieveradminoremployee = '{1}' order by dateofsendding desc", id, "employee"), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read["seen"].ToString() == "false")
                {
                    ListViewItem item = new ListViewItem();
                    int id = int.Parse(read["senderid"].ToString());
                    if (read["recieveradminoremployee"].ToString() == "employee")
                    {
                        String nameQuery = "select * from dbo.employee where id = " + id;
                        string name = dataAccess.reader(nameQuery, "firstName") + " " + dataAccess.reader(nameQuery, "lastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("غير مقروئة");
                    }
                    else
                    {
                        String nameQuery = "select * from dbo.admin where id = " + id;
                        string name = dataAccess.reader(nameQuery, "adminfirstName") + " " + dataAccess.reader(nameQuery, "adminlastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("غير مقروئة");
                    }
                    listView1.Items.Add(item);
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProjects k = new AddProjects(this.id,"employee");k.Show();
        }
    }
}
