using attaysir.models;
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
            small(intarr);
            listView1.CheckBoxes = true;
            //listView1.CheckedItems
            tecrube(SortUniv());
        }

        private void the_lists_Resize(object sender, EventArgs e)
        {
            listView1.Location = new Point(10, 35);
            listView1.Size = new Size(this.Width - 35, this.Height - 105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2 + 90, 8);
            button1.Location = new Point(this.Width - 120, this.Height - 65);
        }
        

        public void small(int[] intarr)
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
            for (int i=0;i<intarr.LongLength;i++)
            {
                string g = "faydalananaile";
                g += string.Format(" where id = '{0}'", intarr[i].ToString());
                ViewerForTheLists(listView1, g, k);
            }
        }
        
        public static void ViewerForTheLists(ListView listView1, string TableName, string[] array1)
        {
            string g = string.Format("select * from attaysir1.dbo.{0}", TableName);
            ArrayList array = dataAccess.viewer(g, array1);
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            string IfThereItemsOrNot = dataAccess.reader1(g, "id");
            if (IfThereItemsOrNot != "")
            {
                listView1.FullRowSelect = true;
                listView1.Items[0].Focused = true;
                listView1.Items[0].Selected = true;
            }
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
                    SqlConnection con = new SqlConnection(
                    "Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.groups", con);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        if (dataAccess.reader(string.Format(
                        "select UnivStudId{0} from attaysir1.dbo.groups", i), string.Format("univstudid{0}", i)) != "")
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
                    if (int.Parse(dataAccess.reader(string.Format(
                        "select MonthlyAverageSalaryOfPerson from attaysir1.dbo.faydalananaile where id = '{0}'",
                        one[j]), "MonthlyAverageSalaryOfPerson")) >
                        int.Parse(dataAccess.reader(string.Format(
                            "select MonthlyAverageSalaryOfPerson from attaysir1.dbo.faydalananaile where id = '{0}'",
                            one[j+1]), "MonthlyAverageSalaryOfPerson")))
                    { k = one[j];one[j] = one[j + 1];one[j + 1] = k; }
                }
            }
            return one;
        }

        int[] SortUniv()
        {
            int count = 0;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from attaysir1.dbo.UnivStud", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { count++; }

            int[] univides = new int[count];
            int UnivIdesCounter = 0;
            
            for (int i = 1; i <= 8; i++)
            {
                for (int l = 8; l >= i; l--)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from attaysir1.dbo.Groups", con1);
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        if (l==8 && read1[string.Format("univstudid{0}", l)].ToString() != "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 7 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l+1))].ToString() == "")
                        {univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 6 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 5 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 3))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 4 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 3))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 4))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 3 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 3))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 4))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 5))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 2 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 3))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 4))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 5))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 6))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 1 && read1[string.Format("univstudid{0}", l)].ToString() != "" 
                            && read1[string.Format("univstudid{0}", (l + 1))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 2))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 3))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 4))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 5))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 6))].ToString() == "" 
                            && read1[string.Format("univstudid{0}", (l + 7))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("univstudid{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                    }
                }
            }
            return univides;
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

        void tecrube(int[] sortuniv)
        {
            string l = "";
            for (int i=0;i<sortuniv.LongLength;i++) { l += sortuniv[i].ToString();l += " "; }
            MessageBox.Show(l);
        }
    }
}
