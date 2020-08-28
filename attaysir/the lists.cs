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
    public partial class the_lists : Form
    {
        public the_lists()
        {
            InitializeComponent();
        }

        public the_lists(int[] intarr)
        {
            InitializeComponent();
            this.intarr = intarr;
        }
        int[] intarr;

        private void the_lists_Load(object sender, EventArgs e)
        {
            listView1.Location = new Point(10,35);
            listView1.Size = new Size(this.Width-35,this.Height-105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2+90, 8);
            button1.Location = new Point(this.Width - 120, this.Height-65);
            small();
        }

        private void the_lists_Resize(object sender, EventArgs e)
        {
            listView1.Location = new Point(10, 35);
            listView1.Size = new Size(this.Width - 35, this.Height - 105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2 + 90, 8);
            button1.Location = new Point(this.Width - 120, this.Height - 65);
        }

        void viewr(int[] int1)
        {

        }

        public void small()
        {
            listView1.Columns.Clear();
            string[] k1 = { "رقم العائلة", "الاسم الاول للزوج", "الاسم الاخير للزوج",
                "الاسم الاول للزوجة", "الاسم الاخير للزوجة", "رقم هوية الزوج",
                "رقم هوية الزوجة", "رقم هاتف الزوج", "رقم هاتف الزوجة",
                "معدل الدخل الفردي للعائلة" };
            string[] k = { "FamilyNumber", "HusbandFirstName", "HusbandLastName",
                "WifeFirstName", "WifeLastName", "HusbandIdentificationNumber",
                "WifeIdentificationNumber", "HusbandPhoneNumber", "WifePhoneNumber",
                "MonthlyAverageSalaryOfPerson" };
            listView1.Columns.Add("");
            for (int i = 0; i < k1.LongLength; i++)
            {
                listView1.Columns.Add(k1[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewer(listView1, "faydalananaile where CheckedOrNot ='false'", k);
        }
    }
}
