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
        public TheMessage(string message,int id,Form form)
        {
            InitializeComponent();
            this.message = message;
            this.id = id;
            this.form = form as adminmain;
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
            form.getMessages();
        }
    }
}
