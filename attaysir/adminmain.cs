﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;
using System.Data.SqlClient;
using System.Collections;

namespace attaysir
{
    public partial class adminmain : Form
    {
        public adminmain(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        int id;

        private void adminmain_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FullRowSelect = true;
            string f = Employee2.NameByIdAdmin(id);
            richTextBox1.Text = f;
            timer1.Start();
            this.k();
            getMessages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adding n = new adding(id, true); n.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddingEmployee n = new AddingEmployee(); n.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TheEmployeesList n = new TheEmployeesList(); n.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TheEmployeeList2 n = new TheEmployeeList2(); n.ShowDialog();
        }

        bool bo1;//this bool for control the ligting of button13(the if there a files needs togiving time) 
                //if it false its mean no lighting and if it true means lighting
        public void k1()
        {
            if (admin.checkedornot1() == true) { this.bo1 = true; }
            else if (admin.checkedornot1() == false) { this.bo1 = false; }
        }

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

        private void button_Click(object sender, EventArgs e) { if (bo1 == true) { didntcheckedtimefamily n = new didntcheckedtimefamily(this,"schoolstud"); n.Show(); } }


        bool bo;//this bool for control the ligting of button13(the if there a files needs togiving time) 
                //if it false its mean no lighting and if it true means lighting
        public void k()
        {
            if (admin.checkedornot() == true) { this.bo = true; }
            else if (admin.checkedornot() == false) { this.bo = false; }
        }

        bool f = true;
        void sabit_mi_degisken_mi(bool bo)
        {
            if (bo == true)
            {
                if (f == true) { button13.ForeColor = Color.Red; panel2.BackColor = Color.Red; f = false; }
                else if (f == false) { button13.ForeColor = Color.Black; panel2.BackColor = this.BackColor; f = true; }
            }
            if (bo == false) { button13.ForeColor = Color.Black; panel2.BackColor = this.BackColor; }
        }

        private void button13_Click(object sender, EventArgs e){if (bo == true){didntcheckedtimefamily n = new didntcheckedtimefamily(this); n.ShowDialog();}}
        int n = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sabit_mi_degisken_mi(this.bo);
            k();
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
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where CheckedOrNot = 'true' ", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { h++; }
            read.Close();

            TheIdsList = new int[h]; int g = 0;
            SqlDataReader read1 = cmd.ExecuteReader();
            while (read1.Read()) { TheIdsList[g] = int.Parse(read1["id"].ToString()); g++; }
            con.Close();

            if (LivingLocationCmbbx.SelectedIndex == 0 || LivingLocationCmbbx.SelectedIndex == 1)
            { TheIdsList = LivingLocationFilter(TheIdsList); }
            if (KindOfFamilyCmbbx.SelectedIndex == 0 || KindOfFamilyCmbbx.SelectedIndex == 1)
            { TheIdsList = kindOfFamilyFilter(TheIdsList); }
            if (MinSalarytxtbx.Text != "")
            { TheIdsList = MinSalaryFilter(TheIdsList); }
            if (MaxSalarytxtbx.Text != "")
            { TheIdsList = MaxSalaryFilter(TheIdsList); }
            the_lists k = new the_lists(TheIdsList);k.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            the_lists k = new the_lists(true);k.ShowDialog();
        }

        int[] LivingLocationFilter(int[] TheIdsList)
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); SqlCommand cmd;
            if (LivingLocationCmbbx.SelectedIndex == 0)
            {
                cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where LivingLocation='داخل البلدة القديمة' ", con);
            }
            else { cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where LivingLocation='خارج البلدة القديمة' ", con); }
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
            } int[] son = new int[k]; int y = 0;
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
                cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where KindOfFamily = 'عائلة متعففة' ", con);
            }
            else { cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where KindOfFamily = 'عائلة ايتام' ", con); ; }
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
            string quary = string.Format("SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE MonthlyAverageSalaryOfPerson > {0}",MinSalarytxtbx.Text);
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
            read.Close(); SqlDataReader read1 = cmd.ExecuteReader();int[] n = new int[h]; int g = 0;
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
            AddUnivStud k = new AddUnivStud();k.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message = richTextBox2.Text;
            if (message!="") {
                SelectReciever k = new SelectReciever(message, id, "admin"); k.Show();
            }
        }

        public void getMessages()
        {
            listView1.Items.Clear();
            getMessages1();
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.messages where recieverid = '{0}' and recieveradminoremployee = '{1}' order by dateofsendding desc", id, "admin"), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read["seen"].ToString() == "true")
                {
                    ListViewItem item = new ListViewItem();
                    int id = int.Parse(read["senderid"].ToString());
                    if (read["senderadminoremployee"].ToString() == "employee")
                    {
                        String nameQuery = "select * from Attaysir1.dbo.Employee where id = " + id;
                        string name = dataAccess.reader(nameQuery, "firstName") + " " + dataAccess.reader(nameQuery, "lastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("مقروءة");
                    }
                    else
                    {
                        String nameQuery = "select * from Attaysir1.dbo.Admin where id = " + id;
                        string name = dataAccess.reader(nameQuery, "AdminFirstName") + " " + dataAccess.reader(nameQuery, "AdminLastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("مقروءة");
                    }
                    listView1.Items.Add(item);
                }
            }
            con.Close();
        }

        public void getMessages1()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.messages where recieverid = '{0}' and recieveradminoremployee = '{1}' order by dateofsendding desc", id, "admin"), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read["seen"].ToString() == "false")
                {
                    ListViewItem item = new ListViewItem();
                    int id = int.Parse(read["senderid"].ToString());
                    if (read["senderadminoremployee"].ToString() == "employee")
                    {
                        String nameQuery = "select * from Attaysir1.dbo.Employee where id = " + id;
                        string name = dataAccess.reader(nameQuery, "firstName") + " " + dataAccess.reader(nameQuery, "lastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("غير مقروءة");
                    }
                    else
                    {
                        String nameQuery = "select * from Attaysir1.dbo.Admin where id = " + id;
                        string name = dataAccess.reader(nameQuery, "AdminFirstName") + " " + dataAccess.reader(nameQuery, "AdminLastName");
                        item.SubItems.Add(name);
                        item.SubItems.Add(read["dateofsendding"].ToString());
                        item.SubItems.Add("غير مقروءة");
                    }
                    listView1.Items.Add(item);
                }
            }
            con.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string time = listView1.SelectedItems[0].SubItems[2].Text;
                string readedornot = ""; if (listView1.SelectedItems[0].SubItems[3].Text == "غير مقروءة") { readedornot = "false"; }
                if (listView1.SelectedItems[0].SubItems[3].Text == "مقروءة") { readedornot = "true"; }
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
                DataTable dt = dataAccess.Executequery(string.Format("Select id from Attaysir1.dbo.Admin where AdminFirstName = '{0}' and AdminLastName = '{1}'", firstname, lastname));
                if (dt.Rows.Count > 0) { resultAdmin = true; } else { resultAdmin = false; }

                bool resultEmployee;
                DataTable dt1 = dataAccess.Executequery(string.Format("Select id from Attaysir1.dbo.Employee where firstName = '{0}' and lastName = '{1}'", firstname, lastname));
                if (dt1.Rows.Count > 0) { resultEmployee = true; } else { resultEmployee = false; }

                if (resultAdmin == true) { senderadminoremloyee = "admin"; idofsender = dataAccess.reader(string.Format("Select id from Attaysir1.dbo.Admin where AdminFirstName = '{0}' and AdminLastName = '{1}'", firstname, lastname), "id"); }
                if (resultEmployee == true) { senderadminoremloyee = "employee"; idofsender = dataAccess.reader(string.Format("Select id from Attaysir1.dbo.Employee where firstName = '{0}' and lastName = '{1}'", firstname, lastname), "id"); }
                if ((resultAdmin == true && resultEmployee == true) || idofsender == "") { MessageBox.Show("اسم المستخدم المدخل يتشابه مع اسم ادمن و اسم موظف في نفس الوقت او غير موجود"); }
                else
                {
                    string message = dataAccess.reader(string.Format("select message from Attaysir1.dbo.messages where senderid = '{0}' and senderadminoremployee = '{1}' and recieverid ='{2}'" +
                        " and recieveradminoremployee = '{3}' and dateofsendding = '{4}' and seen = '{5}'", idofsender, senderadminoremloyee, this.id, "admin", time, readedornot), "message");

                    int messageid = int.Parse(dataAccess.reader(string.Format("select id from Attaysir1.dbo.messages where senderid = '{0}' and senderadminoremployee = '{1}' and recieverid ='{2}'" +
                        " and recieveradminoremployee = '{3}' and dateofsendding = '{4}' and seen = '{5}'", idofsender, senderadminoremloyee, this.id, "admin", time, readedornot), "id"));

                    TheMessage k = new TheMessage(message, messageid, this,"admin"); k.Show();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddProjects k = new AddProjects(this.id, "admin"); k.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProjectsList k = new ProjectsList();k.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            the_lists_viewer k = new the_lists_viewer();k.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            int[] TheIdsList; int h = 0;
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.FaydalananAile where CheckedOrNot = 'true' and OneMoreColumn = 'true' ", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { h++; }
            read.Close();

            TheIdsList = new int[h]; int g = 0;
            SqlDataReader read1 = cmd.ExecuteReader();
            while (read1.Read()) { TheIdsList[g] = int.Parse(read1["id"].ToString()); g++; }
            con.Close();

            if (LivingLocationCmbbx.SelectedIndex == 0 || LivingLocationCmbbx.SelectedIndex == 1)
            { TheIdsList = LivingLocationFilter(TheIdsList); }
            if (KindOfFamilyCmbbx.SelectedIndex == 0 || KindOfFamilyCmbbx.SelectedIndex == 1)
            { TheIdsList = kindOfFamilyFilter(TheIdsList); }
            if (MinSalarytxtbx.Text != "")
            { TheIdsList = MinSalaryFilter(TheIdsList); }
            if (MaxSalarytxtbx.Text != "")
            { TheIdsList = MaxSalaryFilter(TheIdsList); }
            the_lists k = new the_lists(TheIdsList,"schoolstud"); k.ShowDialog();
        }

        ArrayList searchedPersonFamily = new ArrayList();
        ArrayList searchedPersonUniv = new ArrayList();
        ArrayList searchedPersonStudent = new ArrayList();
        ArrayList searchedPersonFamilyId = new ArrayList();
        ArrayList searchedPersonUnivId = new ArrayList();
        ArrayList searchedPersonStudentId = new ArrayList();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                searchedPersonFamily.Clear();
                searchedPersonFamilyId.Clear();
                searchedPersonStudent.Clear();
                searchedPersonStudentId.Clear();
                searchedPersonUniv.Clear();
                searchedPersonUnivId.Clear();
                String person = textBox1.Text;
                if (person != "")
                {

                    String queryFamily = "select * from FaydalananAile where HusbandFirstName like '" + person + "%' or HusbandLastName like '" + person + "%' or HusbandIdentificationNumber like '" + person + "%'";
                    String queryUniv = "select * from UnivStud where FirstName like '" + person + "%' or LastName like '" + person + "%' or IdentityNu like '" + person + "%'";
                    String queryStudent = "select * from SchoolStud where FirstName like '" + person + "%' or FatherName like '" + person + "%' or IDNum like '" + person + "%'";
                    SqlConnection con = new SqlConnection(dataAccess.conString);
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand(queryFamily, con);
                    SqlDataReader read = cmd1.ExecuteReader();
                    while (read.Read())
                    {
                        searchedPersonFamily.Add(read["HusbandFirstName"].ToString() + " " + read["HusbandLastName"].ToString());
                        searchedPersonFamilyId.Add(read["id"].ToString());
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand(queryUniv, con);
                    SqlDataReader read2 = cmd2.ExecuteReader();
                    while (read2.Read())
                    {
                        searchedPersonUniv.Add(read2["FirstName"].ToString() + " " + read2["LastName"].ToString());
                        searchedPersonUnivId.Add(read2["id"].ToString());
                    }
                    con.Close();
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand(queryStudent, con);
                    SqlDataReader read3 = cmd3.ExecuteReader();
                    while (read3.Read())
                    {
                        searchedPersonStudent.Add(read3["FirstName"].ToString() + " " + read3["FatherName"].ToString());
                        searchedPersonStudentId.Add(read3["id"].ToString());
                    }
                    con.Close();

                    if (searchedPersonFamily.Count != 0)
                    {
                        comboBox1.Items.Add("عائلات");
                        for (int i = 0; i < searchedPersonFamily.Count; i++)
                        {
                            comboBox1.Items.Add((String)searchedPersonFamily[i]);
                        }
                    }
                    if (searchedPersonUniv.Count != 0)
                    {
                        comboBox1.Items.Add("طلاب جامعات");
                        for (int i = 0; i < searchedPersonFamily.Count; i++)
                        {
                            comboBox1.Items.Add((String)searchedPersonUniv[i]);
                        }
                    }
                    if (searchedPersonStudent.Count != 0)
                    {
                        comboBox1.Items.Add("طلاب مدارس");
                        for (int i = 0; i < searchedPersonFamily.Count; i++)
                        {
                            comboBox1.Items.Add((String)searchedPersonStudent[i]);
                        }
                    }
                    comboBox1.DroppedDown = true;
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    if (comboBox1.SelectedItem.ToString() != "عائلات" && comboBox1.SelectedItem.ToString() != "طلاب جامعات" && comboBox1.SelectedItem.ToString() != "طلاب مدارس" && comboBox1.Items.ToString() != "")
                    {
                        if (comboBox1.Items.Contains("عائلات") && comboBox1.Items.Contains("طلاب جامعات"))
                            if (comboBox1.SelectedIndex > comboBox1.Items.IndexOf("عائلات") &&
                                comboBox1.SelectedIndex < comboBox1.Items.IndexOf("طلاب جامعات"))
                            {
                                //family
                                String familyId = (String)searchedPersonFamilyId[comboBox1.SelectedIndex - 1];
                                CheckingForm c = new CheckingForm(familyId);
                                c.ShowDialog();
                            }

                        if (comboBox1.Items.Contains("عائلات") && comboBox1.Items.Contains("طلاب مدارس")
                            && !comboBox1.Items.Contains("طلاب جامعات"))
                            if (comboBox1.SelectedIndex < comboBox1.Items.IndexOf("طلاب مدارس"))
                            {
                                //family
                                String familyId = (String)searchedPersonFamilyId[comboBox1.SelectedIndex - 1];
                                CheckingForm c = new CheckingForm(familyId);
                                c.ShowDialog();
                            }

                        if (comboBox1.Items.Contains("طلاب مدارس") && comboBox1.Items.Contains("طلاب جامعات"))
                            if (comboBox1.SelectedIndex < comboBox1.Items.IndexOf("طلاب مدارس") &&
                            comboBox1.SelectedIndex > comboBox1.Items.IndexOf("طلاب جامعات"))
                            {
                                //University
                                String studentId = (String)searchedPersonUnivId[comboBox1.SelectedIndex - comboBox1.Items.IndexOf("طلاب جامعات") - 1];
                                CheckingformUniv k = new CheckingformUniv(int.Parse(studentId)); k.ShowDialog();
                            }

                        if (comboBox1.Items.Contains("طلاب مدارس"))
                            if (comboBox1.SelectedIndex > comboBox1.Items.IndexOf("طلاب مدارس"))
                            {
                                //Student
                                String studentId = (String)searchedPersonStudentId[comboBox1.SelectedIndex - comboBox1.Items.IndexOf("طلاب مدارس") - 1];
                                Checkingformschool k = new Checkingformschool(int.Parse(studentId)); k.ShowDialog();
                            }

                        if (comboBox1.Items.Contains("طلاب جامعات") && !comboBox1.Items.Contains("طلاب مدارس"))
                            if (comboBox1.SelectedIndex > comboBox1.Items.IndexOf("طلاب جامعات"))
                            {
                                //University
                                String studentId = (String)searchedPersonUnivId[comboBox1.SelectedIndex - comboBox1.Items.IndexOf("طلاب جامعات") - 1];
                                CheckingformUniv k = new CheckingformUniv(int.Parse(studentId)); k.ShowDialog();
                            }
                    }
                }
            }
            catch { }
        }
    }
}