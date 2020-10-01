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
            string projectname =  dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "ProjectName");
            string CreatingDate = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "CreatingDate");
            string faydalanansayisi = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "FaydalananSayisi");
            string discription = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "Discription");
            string expirydate = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "ExpiryDate");
            string listid = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "ListId");
            string TheLink = dataAccess.reader(string.Format("select * from Attaysir1.dbo.Projects where id = '{0}'", this.id), "TheLink");

            this.theListId = int.Parse(listid);
            this.thelink = TheLink;

            textBox1.Text = projectname;
            textBox2.Text = CreatingDate;
            textBox3.Text = faydalanansayisi;
            textBox4.Text = expirydate;
            richTextBox1.Text = discription;
        }

        private void OpenTheLinkBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد أن تفتح الرابط ؟", " فتح الرابط", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(this.thelink);
            }
        }

        private void ViewTheListBtn_Click(object sender, EventArgs e)
        {
            ViewTheListOfProject k = new ViewTheListOfProject(this.theListId); k.ShowDialog();
        }
    }
} 
/* ProjectName,CreatingDate,FaydalananSayisi,Discription,ExpiryDate,ListId,TheLink */
