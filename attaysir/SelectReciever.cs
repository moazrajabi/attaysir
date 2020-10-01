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
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.Employee", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (gg(read["id"].ToString(),"employee"))
                {
                    string employeename = "";
                    employeename = read["firstName"].ToString();
                    employeename += " " + read["lastName"].ToString();
                    comboBox1.Items.Add(employeename);
                }
            }
            con.Close();
        }
        bool gg(string id, string EmployeeOrAdmin)
        {
            bool kk = false;

            if (accType == "admin")
            {
                if (EmployeeOrAdmin == "employee") { kk = true; }
                if (EmployeeOrAdmin == "admin" && id != this.id.ToString()) { kk = true; }
            }
            else if (accType == "employee")
            {
                if (EmployeeOrAdmin == "employee" && id != this.id.ToString()) { kk = true; }
                if (EmployeeOrAdmin == "admin") { kk = true; }
            }

            return kk;
        }

        private void getManagersLists()
        {
            comboBox2.Items.Add("");
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.Admin", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (gg(read["id"].ToString(),"admin"))
                {
                    string adminname = "";
                    adminname = read["AdminFirstName"].ToString();
                    adminname += " " + read["AdminLastName"].ToString();
                    comboBox2.Items.Add(adminname);
                }
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
                string recieverId = dataAccess.reader(string.Format("select id as id from Attaysir1.dbo.Employee where firstName = '{0}' and lastName = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ")+1, reciever.Length - (reciever.IndexOf(" ")+1))),"id");
                string sendQuery = string.Format("insert into Attaysir1.dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message,id,accType,recieverId,recieverAccType,date.ToString(),"false");
                dataAccess.executenonquery(sendQuery);
                MessageBox.Show("تم الإرسال بنجاح");
                this.Close();


            }else if (comboBox2.Text != "" && comboBox1.Text == "")
            {
                reciever = comboBox2.Text;
                string recieverAccType = "admin";
                string recieverId = dataAccess.reader(string.Format("select id as id from Attaysir1.dbo.Admin where AdminFirstName = '{0}' and AdminLastName = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ")+1, reciever.Length - (reciever.IndexOf(" ")+1))), "id");
                string sendQuery = string.Format("insert into Attaysir1.dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message, id, accType, recieverId, recieverAccType, DateTime.Now.ToString(), "false");
                dataAccess.executenonquery(sendQuery);
                MessageBox.Show("تم الإرسال بنجاح");
                this.Close();

            }else if (comboBox2.Text != "" && comboBox1.Text != "")
            {
                string recieverAccType = "employee";
                string recieverId = dataAccess.reader(string.Format("select id as id from Attaysir1.dbo.Employee where firstName = '{0}' and lastName = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ") + 1, reciever.Length - (reciever.IndexOf(" ") + 1))), "id");
                string sendQuery = string.Format("insert into Attaysir1.dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message, id, accType, recieverId, recieverAccType, DateTime.Now.ToString(), "false");
                dataAccess.executenonquery(sendQuery);

                reciever = comboBox2.Text;
                string recieverAccType2 = "admin";
                string recieverId2 = dataAccess.reader(string.Format("select id as id from Attaysir1.dbo.Admin where AdminFirstName = '{0}' and AdminLastName = '{1}'", reciever.Substring(0, reciever.IndexOf(" ")), reciever.Substring(reciever.IndexOf(" ") + 1, reciever.Length - (reciever.IndexOf(" ") + 1))), "id");
                string sendQuery2 = string.Format("insert into Attaysir1.dbo.messages(message,senderid,senderadminoremployee,recieverid,recieveradminoremployee,dateofsendding,seen) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", message, id, accType, recieverId2, recieverAccType2, DateTime.Now.ToString(), "false");
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
