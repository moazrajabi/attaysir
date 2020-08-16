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
    public partial class TheEmployeeList2 : Form
    {
        public TheEmployeeList2()
        {
            InitializeComponent();
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            button1.Size = new Size(this.Width - 23, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
        }

        private void TheEmployeeList2_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewerAdmin(listView1, "select AdminFirstName"+
                ",AdminLastName,email,password,birthday,image,identityNo,Mobil"+
                "eNum1,MobileNum2 from Attaysir1.dbo.admin");
        }

        private void TheEmployeeList2_Resize(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width - 23, this.Height - 75);
            button1.Size = new Size(this.Width - 23, 25);
            button1.Location = new Point(4, (int.Parse(this.Height.ToString()) - 67));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ifthereadminornot = dataAccess.reader1("select * from attaysir1.dbo.admin", "id");
            if (ifthereadminornot != "")
            {
                if (ifthereadminornot != null)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show("هل انت متاكد انك تريد اخذ الصلاحيات من هذا الادمن و ارجاعه الى موظف", "صندوق التاكيد", buttons);
                    if (result == DialogResult.Yes)
                    {
                        String IdentificetionNumber = listView1.SelectedItems[0].SubItems[6].Text;
                        void TransferAdminToEmployee()
                        {
                            string query = string.Format("INSERT INTO Attaysir1.dbo.Employee(fi"+
                                "rstName, lastName, email, password, birthday, image, identityN"+
                                "o, MobileNum1, MobileNum2) SELECT AdminFirstName, AdminLastNam"+
                                "e, email, password, birthday, image, identityNo, MobileNum1, M"+
                                "obileNum2 FROM Attaysir1.dbo.Admin where identityNo = '{0}'", IdentificetionNumber);
                            dataAccess.executenonquery(query);
                        }
                        TransferAdminToEmployee();
                        admin.DeleteAdmin(IdentificetionNumber);
                        listviewfunctions.viewerAdmin(listView1, "select AdminFirstName" +
                            ",AdminLastName,email,password,birthday,image,identityNo,Mobil" +
                            "eNum1,MobileNum2 from Attaysir1.dbo.admin");
                    }
                }
            }
        }
    }
}
