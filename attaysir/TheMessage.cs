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
    public partial class TheMessage : Form
    {
        private adminmain form = null;
        private officermain form1 = null;
        string adminoremployee;
        public TheMessage(string message, int id, Form form, string adminoremployee)
        {
            InitializeComponent();
            this.message = message;
            this.id = id;
            if (adminoremployee == "admin") { 
                this.form = form as adminmain; }
            if (adminoremployee == "employee")
            {
                this.form1 = form1 as officermain;
            }
        }
        string message ;
        int id;

        private void TheMessage_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = message;
        }

        private void TheMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataAccess.Executequery(string.Format("UPDATE Attaysir1.dbo.messages SET seen = 'true'WHERE id = '{0}'",id));

            if (adminoremployee == "admin")
            {
                form.getMessages();
            }
            if (adminoremployee == "employee")
            {
                form1.getMessages();
            }
        }
    }
}
