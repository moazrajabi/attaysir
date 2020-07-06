using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

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
        // textboxes functions
        // **************************************

        public static void sadeceint(TextBox txtbx)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtbx.Text, "[^0-9]"))
            {
                txtbx.Text = txtbx.Text.Remove(txtbx.Text.Length - 1);
            }
        }

        public static string whtws = "";
        public static int crsesws;

        public static void sadecechar1(TextBox txtbx)
        {
            whtws = txtbx.Text;
        }

        public static void sadecechar2(TextBox txtbx)
        {
            if (Regex.IsMatch(txtbx.Text, "^[a-zA-Z ]*$"))
            {
                whtws = txtbx.Text;
            }
            else
            {
                crsesws = txtbx.SelectionStart == 0 ? 0 : txtbx.SelectionStart - 1;
                txtbx.Text = whtws;
                txtbx.SelectionStart = crsesws;
            }
        }
    }
}

/*string f = string.Format("insert into dbo.Employee(firstName,lastName,email,password," +
    "identityNo) values('{0}','{1}','{2}','{3}','{4}')", a, b, c, d, e);*/
