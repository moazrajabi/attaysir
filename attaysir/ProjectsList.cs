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
    public partial class ProjectsList : Form
    {
        public ProjectsList()
        {
            InitializeComponent();
        }

        private void ProjectsList_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            getProjects();
            listView1.FullRowSelect = true;
        }

        public void getProjects()
        {
            listView1.Items.Clear();
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.Projects order by id desc", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(read["ProjectName"].ToString());
                item.SubItems.Add(read["CreatingDate"].ToString());
                item.SubItems.Add(read["FaydalananSayisi"].ToString());
                item.SubItems.Add(read["Discription"].ToString());
                item.SubItems.Add(read["ExpiryDate"].ToString());
                item.SubItems.Add(dataAccess.reader(string.Format("select name from attaysir1.dbo.TheLists where id = '{0}'", read["ListId"].ToString()), "name"));
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string ProjectName = listView1.SelectedItems[0].SubItems[1].Text;
                string CreatingDate = listView1.SelectedItems[0].SubItems[2].Text;
                string FaydalananSayisi = listView1.SelectedItems[0].SubItems[3].Text;
                string Discription = listView1.SelectedItems[0].SubItems[4].Text;
                string ExpiryDate = listView1.SelectedItems[0].SubItems[5].Text;
                string listid = dataAccess.reader(string.Format("select listid from attaysir1.dbo.Projects where ProjectName = '{0}' and CreatingDate = '{1}' and FaydalananSayisi = '{2}' and Discription = '{3}' and ExpiryDate = '{4}'", ProjectName, CreatingDate, FaydalananSayisi, Discription, ExpiryDate), "ListId");
                string ProjectId = dataAccess.reader(string.Format("select id from attaysir1.dbo.Projects where ProjectName = '{0}' and CreatingDate = '{1}' and FaydalananSayisi = '{2}' and Discription = '{3}' and ExpiryDate = '{4}' and listid = '{5}'", ProjectName, CreatingDate, FaydalananSayisi, Discription, ExpiryDate, listid), "id");
                ProjectsDetails k = new ProjectsDetails(int.Parse(ProjectId)); k.ShowDialog();
            }
            catch { }
        }
    }
}
/*id,*/
