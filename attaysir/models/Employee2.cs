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
    class Employee2
    {
        public static bool login(string email, string password)
        {
            string query = string.Format("SELECT * FROM dbo.Employee WHERE Email = '{0}' AND Password='{1}'", email, password);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static string nameById(int id)
        {
            string query = string.Format("SELECT EmployeeFirstName FROM dbo.Employee WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "EmployeeFirstName");
        }

        public static string idByEmailAndPassword(string email, string password)
        {
            string query = string.Format("SELECT id FROM dbo.Employee WHERE email = '{0}' and password = '{1}'", email, password);
            return dataAccess.reader(query, "id");
        }

        public static string FirstNameById(int id)
        {
            string query = string.Format("SELECT firstName FROM attaysir.dbo.Employee WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "firstName");
        }

        public static string LastNameById(int id)
        {
            string query = string.Format("SELECT lastName FROM attaysir.dbo.Employee WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "lastName");
        }

        public static int AddFamily(int EmployeeOrAdminId, string HusbandFirstName, string WifeFirstName, 
            string husbandPhoneNUMber,string HusbandLastName, string WifeLastName,
            string WifePhoneNumber,string husbandIdentityNumber, string WifeIdentityNumber,
            int    FamilyNumOfMember, string LivingLocation,string Adress, int husbandSalary,
            int    WifeSalary, int TotalChildrenInsurance,string FamilyKind,
            int NumChiltackInsurance,string HusbandOrWife
            /*, string TotalUniversitiesFees, string StudentMonthlyTranportaion, string TotalSchoolsFees
             * ,string EmployeesNote,string AmountOfMonthlyElectricBill, string AmountOfMonthlyRent
             * , string AmountOfTwoMonthlyWaterBill,string AmountOfYearlyArnona*/)
        {
            string query = string.Format("INSERT INTO attaysir.dbo.FaydalananAile(LivingLocation, Adress," +
                " HusbandIdentificationNumber, WifeIdentificationNumber, HusbandPhoneNumber, WifePhoneNumber,"+
                " HusbandFirstName, WifeFirstName, NumberOfFamilyMembers,"+
                " HusbandSalary, WifeSalary, TotalChildrenInsurance, NumberOfChildrenTackingInsurance, "+
                //", RegisteretionDateTime, "+
                /*"MonthlyAverageSalaryOfPerson,"+*/" KindOfFamily,RegisterEmployeesFirstName, RegisterEmployeesLastName" +
                /*" ExpiryDateOfFile,"+*/", HusbandOrWife, HusbandLastName, WifeLastName) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',"+
                "'{12}','{13}','{14}','{15}','{16}','{17}','{18}')"
                , LivingLocation, Adress, husbandIdentityNumber, WifeIdentityNumber, husbandPhoneNUMber, WifePhoneNumber
                , HusbandFirstName, WifeFirstName, FamilyNumOfMember, husbandSalary, WifeSalary, TotalChildrenInsurance
                , NumChiltackInsurance, FamilyKind,FirstNameById(EmployeeOrAdminId),LastNameById(EmployeeOrAdminId)
                ,HusbandOrWife,HusbandLastName,WifeLastName
                /*, AmountOfMonthlyRent, AmountOfMonthlyElectricBill
                , AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona, EmployeesNote
                , TotalSchoolsFees, TotalUniversitiesFees, StudentMonthlyTranportaion*/);
            return dataAccess.executenonquery(query);
        }

        public static bool IfTheFamilyThere(string HusbandFirstName, string WifeFirstName)
        {
            string query = string.Format("SELECT * FROM attaysir.dbo.FaydalananAile WHERE HusbandFirstName = '{0}' AND WifeFirstName = '{1}'", HusbandFirstName, WifeFirstName);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static int AddExpenses(string HusbandIdentificationNumber,string WifeIdentificationNumber, string AmountOfMonthlyRent,
            string AmountOfMonthlyElectricBill,string AmountOfTwoMonthlyWaterBill,string AmountOfYearlyArnona)
        {
            string query = string.Format("INSERT INTO attaysir.dbo.Expenses(AmountOfMonthlyRent,"+
                " AmountOfMonthlyElectricBill, AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona,Familyid) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}')", AmountOfMonthlyRent, AmountOfMonthlyElectricBill,
                AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona,int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdentificationNumber, WifeIdentificationNumber)));
            return dataAccess.executenonquery(query);
        }

        public static string SelectIdByHusbandIdNumWifeIdNum(string HusbandIdentificationNumber, string WifeIdentificationNumber)
        {
            string query = string.Format("SELECT id FROM attaysir.dbo.FaydalananAile WHERE HusbandIdentificationNumber = " +
                "'{0}' and WifeIdentificationNumber ='{1}' ", HusbandIdentificationNumber, WifeIdentificationNumber);
            return dataAccess.reader(query, "id");
        }

        public static bool AreThereASalariesFile(int id)
        {
            string query = string.Format("SELECT * FROM attaysir.dbo.OtherSalaries WHERE Familyid = '{0}' ",id);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static bool AreThereAExpensesFile(int id)
        {
            string query = string.Format("SELECT * FROM attaysir.dbo.OtherExpenses WHERE Familyid = '{0}' ", id);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static int SalariesById(int id)
        {
            if (AreThereASalariesFile(id) == true)
            {
                int othersalary = 0;
                for (int i=1;i<6 ;i++ ) {
                     string query = string.Format("SELECT AmountOfOtherSalary{0} FROM "+
                        "attaysir.dbo.OtherSalaries WHERE Familyid = '{1}' ",i, id);string colomn = string.Format("AmountOfOtherSalary{0}", i); 
                    othersalary += int.Parse(dataAccess.reader(query, colomn));
                }
                return othersalary;
            }
            else { return 0; }
        }
        
        public static int ExpensesById(int id)
        {
            string query1 = string.Format("select SUM(OtherExpenses.AmountOfOtherExpenses) as AmountOfOtherExpenses "+
                "from attaysir.dbo.OtherExpenses where Familyid = '{0}' ", id);
            return int.Parse(dataAccess.reader(query1, "AmountOfOtherExpenses"));
        }
    }
}