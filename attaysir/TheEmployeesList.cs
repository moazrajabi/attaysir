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
            butto.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width - 15) / 2) - 13, 25);
            butto.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width / 2), (int.Parse(this.Height.ToString()) - 67));
        }

        private void TheEmployeesList_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewerEmployee(listView1, "select firstName,lastName," +
                "email,birthday,image,identityNo,MobileNum1,MobileNum2 from Attaysi" +
                "r1.dbo.Employee");
        }

        private void TheEmployeesList_Resize(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            butto.Size = new Size(((this.Width - 15) / 2), 25);
            button2.Size = new Size(((this.Width - 15) / 2) - 13, 25);
            butto.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
            button2.Location = new Point((this.Width / 2), (int.Parse(this.Height.ToString()) - 67));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ifthereemployeeornot = dataAccess.reader1("select * from Attaysir1.dbo.Employee", "id");
            if (ifthereemployeeornot != ""){
                if (ifthereemployeeornot != null)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("هل انت متاكد انك تريد حذف هذا الموظف", "صندوق التاكيد", buttons);
                    if (result == DialogResult.Yes)
                    {
                        String IdentificetionNumber = listView1.SelectedItems[0].SubItems[6].Text;
                        admin.DeleteEmployee(IdentificetionNumber);
                        listviewfunctions.viewerEmployee(listView1, "select firstName,lastName," +
                            "email,birthday,image,identityNo,MobileNum1,MobileNum2 from Attaysi" +
                            "r1.dbo.Employee");                
                    }
                }
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ifthereemployeeornot = dataAccess.reader1("select * from Attaysir1.dbo.Employee", "id");
            if (ifthereemployeeornot != "")
            {
                if (ifthereemployeeornot != null)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("هل انت متاكد انك تريد ترقية هذا الموظف الى ادمن", "صندوق التاكيد", buttons);
                    if (result == DialogResult.Yes)
                    {
                        String IdentificetionNumber = listView1.SelectedItems[0].SubItems[6].Text;
                        void TransferEmployeeToAdmin()
                        {
                            string query = string.Format("INSERT INTO Attaysir1.dbo.Admin(Admin"+
                                "FirstName,AdminLastName,email,password,birthday,image,identity"+
                                "No,MobileNum1,MobileNum2) SELECT firstName, lastName, email, p"+
                                "assword, birthday, image, identityNo, MobileNum1, MobileNum2 F"+
                                "ROM Attaysir1.dbo.Employee where identityNo = '{0}'", IdentificetionNumber);
                            dataAccess.executenonquery(query);
                        }TransferEmployeeToAdmin();
                        admin.DeleteEmployee(IdentificetionNumber);
                        listviewfunctions.viewerEmployee(listView1, "select firstName,lastName," +
                            "email,birthday,image,identityNo,MobileNum1,MobileNum2 from Attaysi" +
                            "r1.dbo.Employee");
                    }
                }
            }
        }
    }
}
