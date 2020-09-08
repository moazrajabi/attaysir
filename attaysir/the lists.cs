using attaysir.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            intarr = sort(intarr);
            textBox1.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            timer1.Start();
            first = textBox1.Text;
            listView1.Location = new Point(10,35);
            listView1.Size = new Size(this.Width-35,this.Height-105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2+90, 8);
            button1.Location = new Point(this.Width - 120, this.Height-65);
            small(f(intarr));
            listView1.CheckBoxes = true;
            //listView1.CheckedItems
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
                /*
                for (int i = 8; i > 0; i--)
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.groups", con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        if (dataAccess.reader(string.Format("select UnivStudId{0} from attaysir1.dbo.groups", i), string.Format("univstudid{0}", i)) != "")
                        {

                        }
                    }
                    con.Close();
                }*/
            }
            if (IfItUniv == false)
            {
                int number = int.Parse(textBox1.Text);
                for (int i = 0; i < number; i++)
                {

                }
            }
        }

        int[] sort(int[] one)
        {
            int k ;
            for (int i=0;i<one.LongLength;i++)
            {
                for (int j = 0; j < ((one.LongLength - 1) - i); j++)
                {
                    if (int.Parse(dataAccess.reader(string.Format("select MonthlyAverageSalaryOfPerson from attaysir1.dbo.faydalananaile where id = '{0}'", one[j]), "MonthlyAverageSalaryOfPerson")) >
                        int.Parse(dataAccess.reader(string.Format("select MonthlyAverageSalaryOfPerson from attaysir1.dbo.faydalananaile where id = '{0}'", one[j+1]), "MonthlyAverageSalaryOfPerson")))
                    { k = one[j];one[j] = one[j + 1];one[j + 1] = k; }
                }
            }
            return one;
        }

        /*
            // Handles the ItemChecked event.  The method loops through all the 
            // checked items and tallies a new price each time an item is 
            // checked or unchecked. It outputs the price to TextBox1.
            private void ListView1_ItemCheck2(object sender, 
            System.Windows.Forms.ItemCheckEventArgs e)
            {
                double price = 0.0;
                ListView.CheckedListViewItemCollection checkedItems = 
                ListView1.CheckedItems;
        
                foreach ( ListViewItem item in checkedItems )
                {
                    price += Double.Parse(item.SubItems[1].Text);
                }
                if (e.CurrentValue==CheckState.Unchecked)
                {
                    price += Double.Parse(
                    this.ListView1.Items[e.Index].SubItems[1].Text);
                }
                else if((e.CurrentValue==CheckState.Checked))
                {
                    price -= Double.Parse(
                    this.ListView1.Items[e.Index].SubItems[1].Text);
                }
                // Output the price to TextBox1.
                TextBox1.Text = price.ToString();
            }
        }*/
    }
}
