using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace attaysir.models
{
    class admin
    {
        public static bool login(string email, string password)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.Admin WHERE Email = '{0}' AND Password='{1}'", email, password);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static int addAdmin(string AdminFirstName, string AdminLastName, string email, string password)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.Admin(AdminFirstName,AdminLastName,email,password) " +
                "VALUES('{0}','{1}','{2}','{3}')", AdminFirstName, AdminLastName, email, password);
            return dataAccess.executenonquery(query);
        }

        public static int addEmployee(string firstName, string lastName, string email, string password, string identityNo)
        {
            string query = string.Format("insert into Attaysir1.dbo.Employee(firstName,lastName,email,password,identityNo)" +
                " values('{0}','{1}','{2}','{3}','{4}')", firstName, lastName, email, password, identityNo);
            return dataAccess.executenonquery(query);
        }

        public static int addFaydalanan(string FaydalananFirstName, string FaydalananLastName, string email, string password)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.Faydalanan(FaydalananFirstName,FaydalananLastName,email,password) " +
                "VALUES('{0}','{1}','{2}','{3}')", FaydalananFirstName, FaydalananLastName, email, password);
            return dataAccess.executenonquery(query);
        }

        public static string LastNameById(int id)
        {
            string query = string.Format("SELECT AdminLastName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "AdminLastName");
        }

        public static string FirstNameById(int id)
        {
            string query = string.Format("SELECT AdminFirstName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "AdminFirstName");
        }

        public static string idByEmailAndPassword(string email, string password)
        {
            string query = string.Format("SELECT id FROM Attaysir1.dbo.Admin WHERE email = '{0}' and password = '{1}'", email, password);
            return dataAccess.reader(query, "id");
        }

        public static void DeleteEmployee(string id)
        {
            string query = string.Format("delete from attaysir1.dbo.employee where identityno = '{0}'",id);
            dataAccess.executenonquery(query);
        }

        public static void DeleteAdmin(string id)
        {
            string query = string.Format("delete from attaysir1.dbo.Admin where identityno = '{0}'", id);
            dataAccess.executenonquery(query);
        }
        
        public static bool checkedornot()
        {
            string query = "SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE CheckedOrNot = 'false'";
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }
    }
}
