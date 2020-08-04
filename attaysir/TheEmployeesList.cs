using attaysir.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attaysir
{
    public partial class TheEmployeesList : Form
    {
        public TheEmployeesList()
        {
            InitializeComponent();
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            button1.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width - 15) / 2) - 13, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width / 2), (int.Parse(this.Height.ToString()) - 67));
        }

        private void TheEmployeesList_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewerEmployee(listView1, "select firstName,lastName,"+
                "email,birthday,image,identityNo,MobileNum1,MobileNum2 from Attaysi"+
                "r1.dbo.Employee");
        }

        private void TheEmployeesList_Resize(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            button1.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width -15) / 2)-13, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width/2), (int.Parse(this.Height.ToString()) - 67));
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String husbandName = listView1.SelectedItems[0].SubItems[2].Text;
            MessageBox.Show(husbandName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String IdentificetionNumber = listView1.SelectedItems[0].SubItems[6].Text;
            admin.DeleteEmployee(IdentificetionNumber);
            listviewfunctions.viewerEmployee(listView1, "select firstName,lastName," +
                "email,birthday,image,identityNo,MobileNum1,MobileNum2 from Attaysi" +
                "r1.dbo.Employee");
        }
    }
}
