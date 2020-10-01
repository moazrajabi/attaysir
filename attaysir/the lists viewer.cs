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
    public partial class the_lists_viewer : Form
    {
        public the_lists_viewer()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.FullRowSelect = true;
        }

        private void the_lists_viewer_Load(object sender, EventArgs e)
        {
            getlists();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        void getlists()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.TheLists order by CreatingDate desc", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(read["Name"].ToString());
                item.SubItems.Add(read["TypeOfList"].ToString());
                item.SubItems.Add(getfaydalananlarsayisi(int.Parse(read["id"].ToString())).ToString());
                item.SubItems.Add(read["CreatingDate"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        int getfaydalananlarsayisi(int id)
        {
            int i = 0;
            SqlConnection con1 = new SqlConnection(dataAccess.conString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(string.Format("select * from Attaysir1.dbo.IdesOfTheList where IdOfList='{0}'", id.ToString()), con1);
            SqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read())
            {
                i++;
            }
            con1.Close();
            return i;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {/*
            string name = listView1.SelectedItems[0].SubItems[1].Text;
            string typeoflist = listView1.SelectedItems[0].SubItems[2].Text;
            string faydalananlarsayisi = listView1.SelectedItems[0].SubItems[3].Text;
            string creatingdate = listView1.SelectedItems[0].SubItems[4].Text;
            string idoflist = dataAccess.reader(string.Format("select id from attaysir1.dbo.TheLists where Name = '{0}' and CreatingDate = '{1}' and TypeOfList = '{2}' and faydalananlarsayisi = '{3}'", name, creatingdate, typeoflist, faydalananlarsayisi),"id");
        */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string typeoflist = listView1.SelectedItems[0].SubItems[2].Text;
                string name = listView1.SelectedItems[0].SubItems[1].Text;
                string faydalananlarsayisi = listView1.SelectedItems[0].SubItems[3].Text;
                string creatingdate = listView1.SelectedItems[0].SubItems[4].Text;
                if (typeoflist == "family")
                {
                    string idoflist = dataAccess.reader(string.Format("select id from Attaysir1.dbo.TheLists where Name = '{0}' and CreatingDate = '{1}' and TypeOfList = '{2}' and faydalananlarsayisi = '{3}'", name, creatingdate, typeoflist, faydalananlarsayisi), "id");
                    check_the_datas_for_the_list k = new check_the_datas_for_the_list(int.Parse(idoflist));// k.Show();
                    k.ShowDialog();
                }else if (typeoflist == "univ")
                {
                    string idoflist = dataAccess.reader(string.Format("select id from Attaysir1.dbo.TheLists where Name = '{0}' and CreatingDate = '{1}' and TypeOfList = '{2}' and faydalananlarsayisi = '{3}'", name, creatingdate, typeoflist, faydalananlarsayisi), "id");
                    CheckTheDatasForTheListUNIV c = new CheckTheDatasForTheListUNIV(int.Parse(idoflist));c.ShowDialog();
                }
                else
                {
                    string idoflist = dataAccess.reader(string.Format("select id from Attaysir1.dbo.TheLists where Name = '{0}' and CreatingDate = '{1}' and TypeOfList = '{2}' and faydalananlarsayisi = '{3}'", name, creatingdate, typeoflist, faydalananlarsayisi), "id");
                    CheckTheDatasForTheListSCHOOL c = new CheckTheDatasForTheListSCHOOL(int.Parse(idoflist)); c.ShowDialog();
                }
            }
            catch { MessageBox.Show("اختر احد القوائم اولا"); }
        }
    }
}
/* id,Name,CreatingDate,TypeOfList,faydalananlarsayisi   --   TheLists */


