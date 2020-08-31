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

        public the_lists(bool IfItUniv, int[] intarr)
        {
            InitializeComponent();
            this.intarr = intarr;
            this.IfItUniv = IfItUniv;
        }
        bool IfItUniv = false;
        int[] intarr;
        string first;
        private void the_lists_Load(object sender, EventArgs e)
        {
            textBox1.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            timer1.Start();
            first = textBox1.Text;
            listView1.Location = new Point(10,35);
            listView1.Size = new Size(this.Width-35,this.Height-105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2+90, 8);
            button1.Location = new Point(this.Width - 120, this.Height-65);
            small(f(intarr));
        }

        private void the_lists_Resize(object sender, EventArgs e)
        {
            listView1.Location = new Point(10, 35);
            listView1.Size = new Size(this.Width - 35, this.Height - 105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2 + 90, 8);
            button1.Location = new Point(this.Width - 120, this.Height - 65);
        }

        public void small(string query)
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
            listviewfunctions.viewer(listView1, query, k);
        }

        string f(int[] intarr)
        {
            string g = "faydalananaile";
            for (int i = 0; i < intarr.LongLength; i++)
            {
                if (i == 0) { g += string.Format(" where id = '{0}'", intarr[i].ToString()); }
                else { g += string.Format(" or id = '{0}'",intarr[i].ToString()); }
            }
            return g;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            string last = textBox1.Text;
            if (first != last)
            {
                first = last;
                whentimerclicked();
            }
        }

        void whentimerclicked()
        {
            if (IfItUniv == true)
            {

            }
        }
    }
}
