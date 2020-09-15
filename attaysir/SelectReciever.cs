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
using attaysir.models;

namespace attaysir
{
    public partial class SelectReciever : Form
    {
        public SelectReciever(string message, int id, string accType)
        {
            InitializeComponent();
            this.message = message;
            this.accType = accType;
            this.id = id;
        }
        string message,accType;
        int id;

        private void SelectReciever_Load(object sender, EventArgs e)
        {
            getEmployeesLists();
            getManagersLists();
         //   MessageBox.Show(Environment.MachineName.ToString());
        }

        
        private void getEmployeesLists()
        {
            comboBox1.Items.Add("");
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.employee", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) {
                string employeename = "";
                employeename = read["firstName"].ToString();
            employeename += " " + read["lastName"].ToString();
                comboBox1.Items.Add(employeename);
            }
            con.Close();
        }

        private void getManagersLists()
        {
            comboBox2.Items.Add("");
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.admin", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                string adminname = "";
                adminname = read["adminfirstName"].ToString();
                adminname += " " + read["adminlastName"].ToString();
                comboBox2.Items.Add(adminname);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reciever = comboBox1.Text;
            if (reciever != "" && comboBox2.Text == "")
            {
                string recieverAccType = "employee";
                DateTime date = DateTime.Now;
                string recieverId = dataAccess.reader(string.Format("select id as id from dbo.Employee where firstname = '{0}' and lastname = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ")+1, reciever.Length - (reciever.IndexOf(" ")+1))),"id");
                string sendQuery = string.Format("insert into dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message,id,accType,recieverId,recieverAccType,date.ToString(),"false");
                dataAccess.executenonquery(sendQuery);
                MessageBox.Show("تم الإرسال بنجاح");
                this.Close();


            }else if (comboBox2.Text != "" && comboBox1.Text == "")
            {
                reciever = comboBox2.Text;
                string recieverAccType = "admin";
                string recieverId = dataAccess.reader(string.Format("select id as id from dbo.Admin where adminfirstname = '{0}' and adminlastname = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ")+1, reciever.Length - (reciever.IndexOf(" ")+1))), "id");
                string sendQuery = string.Format("insert into dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",message, id, accType, recieverId, recieverAccType, DateTime.Now.ToString(), "false");
                dataAccess.executenonquery(sendQuery);
                MessageBox.Show("تم الإرسال بنجاح");
                this.Close();

            }else if (comboBox2.Text != "" && comboBox1.Text != "")
            {
                string recieverAccType = "employee";
                string recieverId = dataAccess.reader(string.Format("select id as id from dbo.Employee where firstname = '{0}' and lastname = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ") + 1, reciever.Length - (reciever.IndexOf(" ") + 1))), "id");
                string sendQuery = string.Format("insert into dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message, id, accType, recieverId, recieverAccType, DateTime.Now.ToString(), "false");
                dataAccess.executenonquery(sendQuery);

                reciever = comboBox2.Text;
                string recieverAccType2 = "admin";
                string recieverId2 = dataAccess.reader(string.Format("select id as id from dbo.Admin where adminfirstname = '{0}' and adminlastname = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ") + 1, reciever.Length - (reciever.IndexOf(" ") + 1))), "id");
                string sendQuery2 = string.Format("insert into dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message, id, accType, recieverId2, recieverAccType2, DateTime.Now.ToString(), "false");
                dataAccess.executenonquery(sendQuery2);
                MessageBox.Show("تم الإرسال بنجاح");
                this.Close();

            }
            else
            {
                MessageBox.Show("الرجاء اختبار مستقبل");
            }
        }
    }
}
