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
            FamilyListView k = new FamilyListView(TheIdsList); k.Show();
        }

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
    }
}
