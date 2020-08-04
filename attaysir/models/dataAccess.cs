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
        static String conString = "Data Source=DESKTOP-9J5CO0P;Initial Catalog=attaysir;Integrated Security=True";
        
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
    }
}

/*string f = string.Format("insert into dbo.Employee(firstName,lastName,email,password," +
    "identityNo) values('{0}','{1}','{2}','{3}','{4}')", a, b, c, d, e);*/
