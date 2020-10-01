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
using attaysir.models;

namespace attaysir
{
    public partial class ViewTheListOfProject : Form
    {
        int id;
        public ViewTheListOfProject(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ViewTheListOfProject_Load(object sender, EventArgs e)
        {
            string kindoflist = dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id = '{0}'", this.id.ToString()), "TypeOfList");
            
            if (kindoflist == "family")
            { fillthelist(); }
            if (kindoflist == "univ")
            {
                fillthelistuniv();
            }
            if (kindoflist == "schoolstud")
            {//school
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        string[] columns ={"رقم العائلة","اسم الزوج","اسم عائلة الزوج","اسم الزوجة","اسم عائلة الزوجة","مكان السكن","العنوان","رقم هوية الزوج",
            "رقم هوية الزوجة","رقم هاتف الزوج","رقم هاتف الزوجة","عدد افراد العائلة","مرتب الزوج","مرتب الزوجة","مخصصات الاولاد",
            "عدد الاولاد الحاصلين على مخصصات","اسم الموظف المسجل","تاريخ و وقت التسجيل","معدل الدخل الشهري للفرد","نوع العائلة",
            "تاريخ انتهاء صلاحية الملف","التواصل مع الزوج او الزوجة" };

        void fillthelist()
        {
            label1.Text = "عنوان القائمة:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "Name");
            label2.Text = "تاريخ انشاء القائمة:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "CreatingDate");
            label3.Text = "نوع القائمة:- "
            + "عائلات";
            label4.Text = "عدد المستفيدين:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "faydalananlarsayisi");

            for (int i=0;i<columns.Length;i++)
            {
                listView1.Columns.Add(columns[i]);
            }

            int count =  int.Parse(dataAccess.reader(string.Format("select faydalananlarsayisi from Attaysir1.dbo.TheLists where id = '{0}'",this.id.ToString()), "faydalananlarsayisi"));
            int[] ids = new int[count];
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();int count1 = 0;
            SqlCommand cmd = new SqlCommand(string.Format("select Faydalananlae_id from attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", this.id.ToString()), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ids[count1] = int.Parse(read["Faydalananlae_id"].ToString());count1++;
            }
            con.Close();

            string query = "select * from Attaysir1.dbo.FaydalananAile";
            for(int i = 0;i<count;i++)
            {
                if (i==0) { query += string.Format(" where id ='{0}'",ids[i].ToString()); } else { query += string.Format(" or id ='{0}'", ids[i].ToString()); }
            }
            
            SqlConnection con1 = new SqlConnection(dataAccess.conString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read())
            {
                ListViewItem item = new ListViewItem(read1["FamilyNumber"].ToString());

                item.SubItems.Add(read1["HusbandFirstName"].ToString());
                item.SubItems.Add(read1["HusbandLastName"].ToString());
                item.SubItems.Add(read1["WifeFirstName"].ToString());
                item.SubItems.Add(read1["WifeLastName"].ToString());
                item.SubItems.Add(read1["LivingLocation"].ToString());
                item.SubItems.Add(read1["Adress"].ToString());
                item.SubItems.Add(read1["HusbandIdentificationNumber"].ToString());
                item.SubItems.Add(read1["WifeIdentificationNumber"].ToString());
                item.SubItems.Add(read1["HusbandPhoneNumber"].ToString());
                item.SubItems.Add(read1["WifePhoneNumber"].ToString());
                item.SubItems.Add(read1["NumberOfFamilyMembers"].ToString());
                item.SubItems.Add(read1["HusbandSalary"].ToString());
                item.SubItems.Add(read1["WifeSalary"].ToString());
                item.SubItems.Add(read1["TotalChildrenInsurance"].ToString());
                item.SubItems.Add(read1["NumberOfChildrenTackingInsurance"].ToString());
                item.SubItems.Add((read1["RegisterEmployeesFirstName"].ToString()+" "+read1["RegisterEmployeesLastName"].ToString()));
                item.SubItems.Add(read1["RegisteretionDateTime"].ToString());
                item.SubItems.Add(read1["MonthlyAverageSalaryOfPerson"].ToString());
                item.SubItems.Add(read1["KindOfFamily"].ToString());
                item.SubItems.Add(read1["ExpiryDateOfFile"].ToString());
                item.SubItems.Add(read1["HusbandOrWife"].ToString());

                listView1.Items.Add(item);
            }
            con1.Close();
        }

        string[] columnsuniv = { "الاسم الاول", "اسم الاب", "اسم الام", "اسم العائلة", "رقم الهوية", "اسم الجامعة", "اسم الكلية", "اسم التخصص", "القسط السنوي", "السنة الدراسية", "رقم الهاتف", "رقم الهاتف الاحتياطي", "البريد الالكتروني", "هل مدرج مع عائلة!" };
        void fillthelistuniv()
        {
            label1.Text = "عنوان القائمة:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "Name");
            label2.Text = "تاريخ انشاء القائمة:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "CreatingDate");
            label3.Text = "نوع القائمة:- "
            + "طلاب جامعة";
            label4.Text = "عدد المستفيدين:- "
            + dataAccess.reader(string.Format("select * from Attaysir1.dbo.TheLists where id ='{0}'", this.id.ToString()), "faydalananlarsayisi");

            for (int i = 0; i < columnsuniv.Length; i++)
            {
                listView1.Columns.Add(columnsuniv[i]);
            }

            int count = int.Parse(dataAccess.reader(string.Format("select faydalananlarsayisi from Attaysir1.dbo.TheLists where id = '{0}'", this.id.ToString()), "faydalananlarsayisi"));
            int[] ids = new int[count];
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open(); int count1 = 0;
            SqlCommand cmd = new SqlCommand(string.Format("select Faydalananlae_id from attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", this.id.ToString()), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ids[count1] = int.Parse(read["Faydalananlae_id"].ToString()); count1++;
            }
            con.Close();

            string query = "select * from Attaysir1.dbo.UnivStud";
            for (int i = 0; i < count; i++)
            {
                if (i == 0) { query += string.Format(" where id ='{0}'", ids[i].ToString()); } else { query += string.Format(" or id ='{0}'", ids[i].ToString()); }
            }

            SqlConnection con1 = new SqlConnection(dataAccess.conString);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(query, con1);
            SqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read())
            {
                ListViewItem item = new ListViewItem(read1["FirstName"].ToString());

                item.SubItems.Add(read1["FatherName"].ToString());
                item.SubItems.Add(read1["MotherName"].ToString());
                item.SubItems.Add(read1["LastName"].ToString());
                item.SubItems.Add(read1["IdentityNu"].ToString());
                item.SubItems.Add(read1["UnivName"].ToString());
                item.SubItems.Add(read1["KolejName"].ToString());
                item.SubItems.Add(read1["DepartmentName"].ToString());
                item.SubItems.Add(read1["YearlyFees"].ToString());
                item.SubItems.Add(read1["whichyear"].ToString());
                item.SubItems.Add(read1["PhoneNu"].ToString());
                item.SubItems.Add(read1["SecondPhoneNu"].ToString());
                item.SubItems.Add(read1["Email"].ToString());
                if (read1["Familyid"].ToString()=="") { item.SubItems.Add("لا"); }
                else { item.SubItems.Add("نعم"); }
                
                listView1.Items.Add(item);
            }
            con1.Close();
        }
    }
}

