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
        public the_lists(int[] intarr)
        {
            InitializeComponent();
            this.intarr = intarr;
        }

        string schoolstud;
        int[] SchoolIntArr;
        public the_lists(int[] SchoolIntArr, string schoolstud)
        {
            InitializeComponent();
            this.SchoolIntArr = SchoolIntArr;
            this.schoolstud = schoolstud;
        }

        public the_lists(bool IfItUniv)
        {
            InitializeComponent();
            this.IfItUniv = IfItUniv;
        }
        bool IfItUniv = false;
        int[] intarr;
        string TheDateTime;
        private void the_lists_Load(object sender, EventArgs e)
        {
            if (schoolstud != "schoolstud") {
                if (IfItUniv == false) { intarr = sort(intarr); }
                if (IfItUniv == true) { SortUniv(); } }
            textBox1.KeyPress += new KeyPressEventHandler(Employee2.justNumbers);
            timer1.Start();
            listView1.Location = new Point(10, 35);
            listView1.Size = new Size(this.Width - 35, this.Height - 105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2 + 90, 8);
            button1.Location = new Point(this.Width - 120, this.Height - 65);
            label2.Location = new Point(this.Width / 2+180, 11);
            if (schoolstud == "schoolstud") { bigstud(schoolstudsort());  } else {
                if (IfItUniv == false) { big(intarr); }
                if (IfItUniv == true) { biguniv(SortUniv()); } }
            listView1.CheckBoxes = true;
            label2.Text = "max = " + listView1.Items.Count.ToString();

        }

        private void the_lists_Resize(object sender, EventArgs e)
        {
            listView1.Location = new Point(10, 35);
            listView1.Size = new Size(this.Width - 35, this.Height - 105);
            label1.Location = new Point(this.Width / 2, 11);
            textBox1.Location = new Point(this.Width / 2 + 90, 8);
            button1.Location = new Point(this.Width - 120, this.Height - 65);
            label2.Location = new Point(this.Width / 2 + 180, 11);
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
            for (int i = 0; i < intarr.LongLength; i++)
            {
                string g = "FaydalananAile";
                g += string.Format(" where id = '{0}'", intarr[i].ToString());
                ViewerForTheLists(listView1, g, k);
            }
        }

        public void big(int[] intarr)
        {
            listView1.Columns.Clear();
            string[] k1 = { "رقم العائلة", "الاسم الاول للزوج", "الاسم الاخير للزوج",
                "الاسم الاول للزوجة", "الاسم الاخير للزوجة", "مكان السكن", "العنوان المفصل",
                "رقم هوية الزوج", "رقم هوية الزوجة", "رقم هاتف الزوج", "رقم هاتف الزوجة",
                "عدد افراد الاسرة", "معاش الزوج", "معاش الزوجة", "مقدار مخصصات الاولاد",
                "عدد الاولاد الحاصلين على مخصصات", "الاسم الاول للموظف المسجل",
                "الاسم الاخير للموظف المسجل", "تاريخ و وقت التسجيل", "معدل الدخل الفردي للعائلة",
                "نوع العائلة", "تاريخ انتهاء فعالية الملف", "التواصل مع الزوج ام الزوجة",
                "تمت معاينة الملف ام لا" };
            string[] k = { "FamilyNumber", "HusbandFirstName", "HusbandLastName", "WifeFirstName",
                "WifeLastName", "LivingLocation", "Adress", "HusbandIdentificationNumber",
                "WifeIdentificationNumber", "HusbandPhoneNumber", "WifePhoneNumber",
                "NumberOfFamilyMembers", "HusbandSalary", "WifeSalary", "TotalChildrenInsurance",
                "NumberOfChildrenTackingInsurance", "RegisterEmployeesFirstName", "RegisterEmployeesLastName",
                "RegisteretionDateTime", "MonthlyAverageSalaryOfPerson", "KindOfFamily", "ExpiryDateOfFile",
                "HusbandOrWife", "CheckedOrNot" };
            listView1.Columns.Add("");
            for (int i = 0; i < k1.LongLength; i++)
            {
                listView1.Columns.Add(k1[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (int i = 0; i < intarr.LongLength; i++)
            {
                string g = "FaydalananAile";
                g += string.Format(" where id = '{0}'", intarr[i].ToString());
                ViewerForTheLists(listView1, g, k);
            }
        }
        
        public void biguniv(int[] intarr)
        {
            listView1.Columns.Clear();
            string[] k1 = {"الاسم الاول","اسم الاب", "اسم الام", "اسم العائلة", "رقم الهوية",
                "اسم الجامعة", "اسم الكلية", "اسم التخصص", "الاقساط السنوية", "السنة الدراسية",
                "رقم الهاتف", "رقم الهاتف الاحتياطي", "الايميل" };
            string[] k = { "FirstName", "FatherName", "MotherName", "LastName", "IdentityNu",
                "UnivName", "KolejName", "DepartmentName", "YearlyFees", "whichyear", "PhoneNu",
                "SecondPhoneNu", "Email" };
            listView1.Columns.Add("");
            for (int i = 0; i < k1.LongLength; i++)
            {
                listView1.Columns.Add(k1[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            for (int i = 0; i < intarr.LongLength; i++)
            {
                string g = "UnivStud";
                g += string.Format(" where id = '{0}'", intarr[i].ToString());
                ViewerForTheLists(listView1, g, k);
            }
        }

        public void bigstud(int[] intarr)
        {
            listView1.Columns.Clear();
            listView1.Columns.Add("رقم العائلة");
            listView1.Columns.Add("اسم الطالب");
            listView1.Columns.Add("اسم الاب");
            listView1.Columns.Add("اسم الام");
            listView1.Columns.Add("رقم هوية الطالب");
            listView1.Columns.Add("اسم المدرسة");
            listView1.Columns.Add("السنة الدراسية");
            listView1.Columns.Add("القسط السنوي");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            for (int i = 0; i < intarr.LongLength; i++)
            {
                SqlConnection con = new SqlConnection(dataAccess.conString);
                con.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.SchoolStud where id ='{0}'", intarr[i].ToString()), con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read["Familyid"].ToString());
                    item.SubItems.Add(read["FirstName"].ToString());
                    item.SubItems.Add(read["FatherName"].ToString());
                    item.SubItems.Add(read["MotherName"].ToString());
                    item.SubItems.Add(read["IDNum"].ToString());
                    item.SubItems.Add(read["SchoolName"].ToString());
                    item.SubItems.Add(read["WhichClass"].ToString());
                    item.SubItems.Add(read["YearlyFees"].ToString());
                    listView1.Items.Add(item);
                }
                con.Close();
            }
        }

        public static void ViewerForTheLists(ListView listView1, string TableName, string[] array1)
        {
            string g = string.Format("select * from Attaysir1.dbo.{0}", TableName);
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

        int[] sort(int[] one)
        {
            int k;
            for (int i = 0; i < one.LongLength; i++)
            {
                for (int j = 0; j < ((one.LongLength - 1) - i); j++)
                {
                    if (int.Parse(dataAccess.reader(string.Format(
                        "select MonthlyAverageSalaryOfPerson from Attaysir1.dbo.FaydalananAile where id = '{0}'",
                        one[j]), "MonthlyAverageSalaryOfPerson")) >
                        int.Parse(dataAccess.reader(string.Format(
                            "select MonthlyAverageSalaryOfPerson from Attaysir1.dbo.FaydalananAile where id = '{0}'",
                            one[j + 1]), "MonthlyAverageSalaryOfPerson")))
                    { k = one[j]; one[j] = one[j + 1]; one[j + 1] = k; }
                }
            }
            return one;
        }

        int[] SortUniv()
        {
            int count = 0;
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.UnivStud", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { count++; }

            int[] univides = new int[count];
            int UnivIdesCounter = 0;

            for (int i = 1; i <= 8; i++)
            {
                for (int l = 8; l >= i; l--)
                {
                    SqlConnection con1 = new SqlConnection(dataAccess.conString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from Attaysir1.dbo.Groups", con1);
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        if (l == 8 && read1[string.Format("UnivStudId{0}", l)].ToString() != "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 7 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == "")
                        { univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 6 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 5 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 3))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 4 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 4))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 3 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 5))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 2 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 6))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                        if (l == 1 && read1[string.Format("UnivStudId{0}", l)].ToString() != ""
                            && read1[string.Format("UnivStudId{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 6))].ToString() == ""
                            && read1[string.Format("UnivStudId{0}", (l + 7))].ToString() == "")
                        {
                            univides[UnivIdesCounter] = int.Parse(read1[string.Format("UnivStudId{0}", i)].ToString());
                            UnivIdesCounter++;
                        }
                    }
                }
            }
            return univides;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {/*
            double price = 0.0;
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                price += Double.Parse(item.SubItems[1].Text);
            }
            if (e.CurrentValue == CheckState.Unchecked)
            {
                price += Double.Parse(this.listView1.Items[e.Index].SubItems[1].Text);
            }
            else if ((e.CurrentValue == CheckState.Checked))
            {
                price -= Double.Parse(this.listView1.Items[e.Index].SubItems[1].Text);
            }
            // Output the price to TextBox1.
            textBox1.Text = price.ToString();
        */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && long.Parse(textBox1.Text)< 2147483646.0) {

                ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;

                foreach (ListViewItem item in checkedItems)
                {
                    item.Checked = false;
                }

                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    if (i == listView1.Items.Count)
                        break;

                    listView1.Items[i].Checked = true;
                }
            }
            else
            {
                ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;

                foreach (ListViewItem item in checkedItems)
                {
                    item.Checked = false;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TheDateTime = time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count >= 2)
            {
                if (schoolstud != "schoolstud")
                {
                    String listType = "univ";
                    if (IfItUniv == false)
                    {
                        listType = "family";
                    }

                    ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
                    NameOfList nameOfList = new NameOfList(listType, checkedItems);
                    if (checkedItems.Count > 0)
                        nameOfList.ShowDialog();
                }
                else
                {
                    ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
                    NameOfList nameOfList = new NameOfList("schoolstud", checkedItems);
                    if (checkedItems.Count > 0)
                        nameOfList.ShowDialog();
                }

            }
            else { MessageBox.Show("يجب عليك اختيار مستفيدين اثنين على الاقل"); }    
        }
        
        int[] schoolstudsort()
        {
            int count = 0;
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Attaysir1.dbo.SchoolStud", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read()) { count++; }

            int[] schoolides = new int[count];
            int schoolIdesCounter = 0;
            
            string query = "select * from Attaysir1.dbo.Groups2";
            for (int i=0;i< SchoolIntArr.Length;i++)
            {
                if (i == 0) { query += string.Format(" where FamilyId = '{0}'", SchoolIntArr[i].ToString()); }
                else { query += string.Format(" or FamilyId = '{0}'", SchoolIntArr[i].ToString()); }
            }
            
            for (int i = 1; i <= 10; i++)
            {
                for (int l = 10; l >= i; l--)
                {
                    SqlConnection con1 = new SqlConnection(dataAccess.conString);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(query, con1);
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        if (l == 10 && read1[string.Format("SchoolStud{0}", l)].ToString() != "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }

                        if (l == 9 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }

                        if (l == 8 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 7 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 6 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 5 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 5))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 4 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 6))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 3 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 6))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 7))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 2 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 6))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 7))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 8))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                        if (l == 1 && read1[string.Format("SchoolStud{0}", l)].ToString() != ""
                            && read1[string.Format("SchoolStud{0}", (l + 1))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 2))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 3))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 4))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 5))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 6))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 7))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 8))].ToString() == ""
                            && read1[string.Format("SchoolStud{0}", (l + 9))].ToString() == "")
                        {
                            schoolides[schoolIdesCounter] = int.Parse(read1[string.Format("SchoolStud{0}", i)].ToString());
                            schoolIdesCounter++;
                        }
                    }
                }
            }
            return schoolides;
        }
    }
}

