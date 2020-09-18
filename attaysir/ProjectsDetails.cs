using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class ProjectsDetails : Form
    {
        int id;
        string thelink = "";
        int theListId;
        public ProjectsDetails(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ProjectsDetails_Load(object sender, EventArgs e)
        {
            GetDitails();
        }

        void GetDitails()
        {
            string projectname =  dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "projectname");
            string CreatingDate = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "creatingdate");
            string faydalanansayisi = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "faydalanansayisi");
            string discription = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "discription");
            string expirydate = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "expirydate");
            string listid = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "listid");
            string TheLink = dataAccess.reader(string.Format("select * from attaysir1.dbo.Projects where id = '{0}'", this.id), "TheLink");

            this.theListId = int.Parse(listid);
            this.thelink = TheLink;

            textBox1.Text = projectname;
            textBox2.Text = CreatingDate;
            textBox3.Text = faydalanansayisi;
            textBox4.Text = expirydate;
            richTextBox1.Text = discription;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
/* ProjectName,CreatingDate,FaydalananSayisi,Discription,ExpiryDate,ListId,TheLink */
