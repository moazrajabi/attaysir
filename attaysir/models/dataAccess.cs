using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace attaysir.models
{
    public class dataAccess
    {
        public static string conString = "Data Source=10.0.0.21;User ID = attaysir; Password=7242";

        public static int executenonquery(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int x = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return x;
        }
        
        public static DataTable Executequery(string query)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        public static string reader(string query, string aranan)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader read = cmd.ExecuteReader();
            string astext = "";
            while (read.Read()) { astext = read[aranan].ToString(); }
            con.Close();
            return astext;
        }

        public static string reader1(string query, string aranan)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            string astext = "";
            while (read.Read()) { astext += read[aranan].ToString()+"\n"; }
            con.Close();
            return astext;
        }
        
        public static int NumberOfItems(string query)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            int n=0;
            while (read.Read()) { n++; }
            con.Close();
            return n;
        }
        
        public static void FillingIdsArrey(int[] f)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT id FROM Attaysir1.dbo.FaydalananAile", con);
            SqlDataReader read = cmd.ExecuteReader();
            int n = 0;
            while (read.Read()) { f[n] = int.Parse(read["id"].ToString());n++; }
            con.Close();
        }
        
        public static ArrayList viewer(string commend)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(commend, con);
            SqlDataReader read = cmd.ExecuteReader();
            ArrayList array = new ArrayList();
            while (read.Read()) {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(read["FamilyNumber"].ToString());
                item.SubItems.Add(read["HusbandLastName"].ToString());
                item.SubItems.Add(read["HusbandFirstName"].ToString());
                item.SubItems.Add(read["HusbandLastName"].ToString());
                item.SubItems.Add(read["WifeFirstName"].ToString());
                item.SubItems.Add(read["WifeLastName"].ToString());
                item.SubItems.Add(read["LivingLocation"].ToString());
                item.SubItems.Add(read["Adress"].ToString());
                item.SubItems.Add(read["HusbandIdentificationNumber"].ToString());
                item.SubItems.Add(read["WifeIdentificationNumber"].ToString());
                item.SubItems.Add(read["HusbandPhoneNumber"].ToString());
                item.SubItems.Add(read["WifePhoneNumber"].ToString());
                item.SubItems.Add(read["NumberOfFamilyMembers"].ToString());
                item.SubItems.Add(read["HusbandSalary"].ToString());
                item.SubItems.Add(read["WifeSalary"].ToString());
                item.SubItems.Add(read["TotalChildrenInsurance"].ToString());
                item.SubItems.Add(read["NumberOfChildrenTackingInsurance"].ToString());
                item.SubItems.Add(read["RegisterEmployeesFirstName"].ToString());
                item.SubItems.Add(read["RegisterEmployeesLastName"].ToString());
                item.SubItems.Add(read["RegisteretionDateTime"].ToString());
                item.SubItems.Add(read["MonthlyAverageSalaryOfPerson"].ToString());
                item.SubItems.Add(read["KindOfFamily"].ToString());
                item.SubItems.Add(read["ExpiryDateOfFile"].ToString());
                item.SubItems.Add(read["HusbandOrWife"].ToString());
                array.Add(item);
            }
            con.Close();
            return array;
        }

        public static ArrayList viewerEmployee(string commend)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(commend, con);
            SqlDataReader read = cmd.ExecuteReader();
            ArrayList array = new ArrayList();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(read["firstName"].ToString());
                item.SubItems.Add(read["lastName"].ToString());
                item.SubItems.Add(read["email"].ToString());
                item.SubItems.Add(read["birthday"].ToString());
                item.SubItems.Add(read["image"].ToString());
                item.SubItems.Add(read["identityNo"].ToString());
                item.SubItems.Add(read["MobileNum1"].ToString());
                item.SubItems.Add(read["MobileNum2"].ToString());
                array.Add(item);
            }
            con.Close();
            return array;
        }

        public static ArrayList viewerAdmin(string commend)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(commend, con);
            SqlDataReader read = cmd.ExecuteReader();
            ArrayList array = new ArrayList();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(read["AdminFirstName"].ToString());
                item.SubItems.Add(read["AdminLastName"].ToString());
                item.SubItems.Add(read["email"].ToString());
                item.SubItems.Add(read["birthday"].ToString());
                item.SubItems.Add(read["image"].ToString());
                item.SubItems.Add(read["identityNo"].ToString());
                item.SubItems.Add(read["MobileNum1"].ToString());
                item.SubItems.Add(read["MobileNum2"].ToString());
                array.Add(item);
            }
            con.Close();
            return array;
        }

        public static int SavePDFsAndimage(byte[] ByteArray, string TableName, string ColumnName,int id)
        {
            string query = "update attaysir1.dbo."+TableName+" set "+ColumnName+"=@img where id = "+id.ToString()+"";
            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@img", ByteArray));
            int x = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return x;
        }

        public static ArrayList viewer(string commend,string[] array1)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(commend, con);
            SqlDataReader read = cmd.ExecuteReader();
            ArrayList array = new ArrayList();
            while (read.Read())
            {
                ListViewItem item = new ListViewItem();
                for (int i=0; i < array1.LongLength; i++)
                {
                    item.SubItems.Add(read[array1[i]].ToString());
                }
                array.Add(item);
            }
            con.Close();
            return array;
        }

        public static void IsTheTimePassed()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlConnection con2 = new SqlConnection(conString);
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE CheckedOrNot= 'true'", con);
            SqlDataReader read = cmd.ExecuteReader();
            SqlCommand cmd2; string query;
            while (read.Read())
            {
                if (NeedsToUpdateOrNot(read["ExpiryDateOfFile"].ToString()))
                {
                    query = string.Format("update Attaysir1.dbo.FaydalananAile set UpdatedOrNot = 'false' where id='{0}'", read["id"].ToString());
                    cmd2 = new SqlCommand(query, con2); con2.Open(); cmd2.ExecuteNonQuery(); con2.Close();
                }
            }
            con.Close();
        }

        static bool NeedsToUpdateOrNot(string datetime)
        {
            string n = DateTime.ParseExact(DateTime.Now.ToString("dd-MM-yyyy"), "dd-MM-yyyy", null).ToString();n.ToCharArray();
            string k = datetime.ToString();k.ToCharArray();
            string datetimeint = "";string now = "";int l = 1;string  dd="", mm="", yyyy="";
            for (int i = 0; i < 12; i++)
            {
                if (k[i] != '0' && k[i] != '1' && k[i] != '2' && k[i] != '3' && k[i] != '4' && k[i] != '5' && k[i] != '6' && k[i] != '7' && k[i] != '8' && k[i] != '9') {
                    l++;
                }
                else
                {
                    if (l == 1) { dd += k[i]; }
                    if (l == 2) { mm += k[i]; }
                    if (l == 3) {
                        for (int j = i; j < (i+4); j++) { yyyy += k[j]; }
                        if (dd.Length == 1) { dd = "0" + dd; }
                        if (mm.Length == 1) { mm = "0" + mm; }
                        datetimeint = yyyy + mm + dd; yyyy = "";mm = "";dd = "";l = 1;
                        break;
                    }
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (n[i] != '0' && n[i] != '1' && n[i] != '2' && n[i] != '3' && n[i] != '4' && n[i] != '5' && n[i] != '6' && n[i] != '7' && n[i] != '8' && n[i] != '9')
                {
                    l++;
                }
                else
                {
                    if (l == 1) { dd += n[i]; }
                    if (l == 2) { mm += n[i]; }
                    if (l == 3)
                    {
                        for (int j = i; j < (i + 4); j++) { yyyy += n[j]; }
                        if (dd.Length == 1) { dd = "0" + dd; }
                        if (mm.Length == 1) { mm = "0" + mm; }
                        now = yyyy +dd+ mm ; yyyy = ""; mm = ""; dd = "";
                        break;
                    }
                }
            }
            if ((int.Parse(datetimeint) - int.Parse(now)) <= 100) { return true; } else { return false; }
        }

        public static void addAction(String action, String priority)
        {
            String query = String.Format("insert into EmployeesActions(action, date, priority) values('{0}','{1}', '{2}')", action, DateTime.Now.ToString(), priority);
            executenonquery(query);
        }
    }
}