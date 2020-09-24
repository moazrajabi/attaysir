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
            string query = string.Format("SELECT * FROM Attaysir1.dbo.Employee WHERE Email = '{0}' AND Password='{1}'", email, password);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static string NameById(int id)
        {
            string query1 = string.Format("SELECT FirstName FROM Attaysir1.dbo.Employee WHERE id = '{0}' ", id);
            string query2 = string.Format("SELECT LastName FROM Attaysir1.dbo.Employee WHERE id = '{0}' ", id);
            string FirstName = dataAccess.reader(query1, "FirstName");
            string LastName = FirstName + " " + dataAccess.reader(query2, "LastName");
            return LastName;
        }

        public static string NameByIdAdmin(int id)
        {
            string query1 = string.Format("SELECT AdminFirstName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            string query2 = string.Format("SELECT AdminLastName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            string FirstName = dataAccess.reader(query1, "AdminFirstName");
            string LastName = FirstName + " " + dataAccess.reader(query2, "AdminLastName");
            return LastName;
        }

        public static string idByEmailAndPassword(string email, string password)
        {
            string query = string.Format("SELECT id FROM Attaysir1.dbo.Employee WHERE email = '{0}' and password = '{1}'", email, password);
            return dataAccess.reader(query, "id");
        }

        public static string FirstNameById(int id)
        {
            string query = string.Format("SELECT firstName FROM Attaysir1.dbo.Employee WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "firstName");
        }

        public static string FirstNameByIdAdmin(int id)
        {
            string query = string.Format("SELECT AdminFirstName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "AdminFirstName");
        }

        public static string LastNameById(int id)
        {
            string query = string.Format("SELECT lastName FROM Attaysir1.dbo.Employee WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "lastName");
        }

        public static string LastNameByIdAdmin(int id)
        {
            string query = string.Format("SELECT AdminLastName FROM Attaysir1.dbo.Admin WHERE id = '{0}' ", id);
            return dataAccess.reader(query, "AdminLastName");
        }

        public static int AddFamily(string HusbandFirstName, string WifeFirstName,
            string husbandPhoneNUMber, string HusbandLastName, string WifeLastName,
            string WifePhoneNumber, string husbandIdentityNumber, string WifeIdentityNumber,
            int FamilyNumOfMember, string LivingLocation, string Adress, int husbandSalary,
            int WifeSalary, int TotalChildrenInsurance, string FamilyKind,
            int NumChiltackInsurance, string HusbandOrWife, int MonthlyAverageSalaryOfPerson,
            string firstnameofemploadmin,string lastnameofemploadmin,string thedatetime)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.FaydalananAile(LivingLocation, Adress," +
                " HusbandIdentificationNumber, WifeIdentificationNumber, HusbandPhoneNumber, WifePhoneNumber," +
                " HusbandFirstName, WifeFirstName, NumberOfFamilyMembers, HusbandSalary, WifeSalary," +
                " TotalChildrenInsurance, NumberOfChildrenTackingInsurance,  KindOfFamily," +
                "RegisterEmployeesFirstName, RegisterEmployeesLastName, HusbandOrWife, HusbandLastName," +
                " WifeLastName,MonthlyAverageSalaryOfPerson,RegisteretionDateTime) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'," +
                "'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')"
                , LivingLocation, Adress, husbandIdentityNumber, WifeIdentityNumber, husbandPhoneNUMber, WifePhoneNumber
                , HusbandFirstName, WifeFirstName, FamilyNumOfMember, husbandSalary, WifeSalary, TotalChildrenInsurance
                , NumChiltackInsurance, FamilyKind, firstnameofemploadmin, lastnameofemploadmin
                , HusbandOrWife, HusbandLastName, WifeLastName, MonthlyAverageSalaryOfPerson,thedatetime);
            return dataAccess.executenonquery(query);
        }
        
        public static int AddUnivStud(string HusbandIdNu,string WifeIdNu, string firstname, string FatherName, string MotherName,
            string lastname, string IdentityNu, string univname, string KolejName, string department,
            string whichyear,string YearlyFees, string PhoneNu, string SecondPhoneNu, string Email)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.UnivStud(Familyid,FirstName,Father"+
                "Name,MotherName,LastName,IdentityNu,UnivName,KolejName,DepartmentName,whichyear,Phone"+
                "Nu,SecondPhoneNu,Email,YearlyFees) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'," +
                "'{9}','{10}','{11}','{12}','{13}')", 
                int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdNu, WifeIdNu)),firstname,FatherName,MotherName,
                lastname,IdentityNu,univname,KolejName,department,whichyear,PhoneNu,SecondPhoneNu,Email, YearlyFees);
            return dataAccess.executenonquery(query);
        }

        public static int AddUnivStudWithOutFamily(string firstname, string FatherName, string MotherName,
            string lastname, string IdentityNu, string univname, string KolejName, string department,
            string whichyear, string YearlyFees, string PhoneNu, string SecondPhoneNu, string Email)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.UnivStud(FirstName,Father" +
                "Name,MotherName,LastName,IdentityNu,UnivName,KolejName,DepartmentName,whichyear,Phone" +
                "Nu,SecondPhoneNu,Email,YearlyFees) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'," +
                "'{9}','{10}','{11}','{12}')",
                firstname, FatherName, MotherName, lastname, IdentityNu, univname, KolejName, 
                department, whichyear, PhoneNu, SecondPhoneNu, Email, YearlyFees);
            return dataAccess.executenonquery(query);
        }

        public static int AddSchoolStud(string HusbandIdNu,string WifeIdNu, string FirstName,string FatherName,string MotherName,string IDNum,string SchoolName,string WhichClass)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.SchoolStud(Familyid,FirstName,FatherName,MotherName,IDNum,SchoolName,WhichClass) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdNu, WifeIdNu)), FirstName, FatherName, MotherName, IDNum, SchoolName, WhichClass);
            return dataAccess.executenonquery(query);
        }
        
        public static bool IfTheFamilyThere(string HusbandFirstName, string WifeFirstName)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.FaydalananAile WHERE HusbandFirstName = '{0}' AND WifeFirstName = '{1}'", HusbandFirstName, WifeFirstName);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static bool ifthefamilythereforPDFfiles(string familyid) {
            string query = string.Format("select * from Attaysir1.dbo.PDFFiles where Familyid = '{0}'", familyid);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static int AddExpenses(string HusbandIdentificationNumber, string WifeIdentificationNumber, string AmountOfMonthlyRent,
            string AmountOfMonthlyElectricBill, string AmountOfTwoMonthlyWaterBill, string AmountOfYearlyArnona)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.Expenses(AmountOfMonthlyRent," +
                " AmountOfMonthlyElectricBill, AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona,Familyid) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}')", AmountOfMonthlyRent, AmountOfMonthlyElectricBill,
                AmountOfTwoMonthlyWaterBill, AmountOfYearlyArnona, int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdentificationNumber, WifeIdentificationNumber)));
            return dataAccess.executenonquery(query);
        }
        
        public static int AddOtherExpenses(string HusbandIdentificationNumber, string WifeIdentificationNumber, string OtherExpenses,
            int AmountOfOtherExpenses, string CycleOfOtherExpenses)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.OtherExpenses(OtherExpenses," +
                    " AmountOfOtherExpenses, CycleOfOtherExpenses,Familyid) " +
                    "VALUES('{0}','{1}','{2}','{3}')", OtherExpenses, AmountOfOtherExpenses, CycleOfOtherExpenses
                    , int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdentificationNumber, WifeIdentificationNumber)));
            return dataAccess.executenonquery(query);
        }

        public static int AddOtherSalaries(string HusbandIdentificationNumber, string WifeIdentificationNumber, string OtherSalary, int AmountOfOtherSalary, string CycleOfOtherSalary)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.OtherSalaries(OtherSalary," +
                "AmountOfOtherSalary,CycleOfOtherSalary,Familyid) " +
                "VALUES('{0}','{1}','{2}','{3}')", OtherSalary, AmountOfOtherSalary, CycleOfOtherSalary
                , int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdentificationNumber, WifeIdentificationNumber)));
            return dataAccess.executenonquery(query);
        }

        public static string SelectIdByHusbandIdNumWifeIdNum(string HusbandIdentificationNumber, string WifeIdentificationNumber)
        {
            string query = string.Format("SELECT id FROM Attaysir1.dbo.FaydalananAile WHERE HusbandIdentificationNumber = " +
                "'{0}' and WifeIdentificationNumber ='{1}' ", HusbandIdentificationNumber, WifeIdentificationNumber);
            return dataAccess.reader(query, "id");
        }

        public static bool AreThereASalariesFile(int id)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.OtherSalaries WHERE Familyid = '{0}' ", id);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static bool AreThereAExpensesFile(int id)
        {
            string query = string.Format("SELECT * FROM Attaysir1.dbo.OtherExpenses WHERE Familyid = '{0}' ", id);
            DataTable dt = dataAccess.Executequery(query);
            if (dt.Rows.Count > 0) { return true; } else { return false; }
        }

        public static int SalariesById(int id)
        {
            if (AreThereASalariesFile(id) == true)
            {
                int othersalary = 0;
                for (int i = 1; i < 6; i++) {
                    string query = string.Format("SELECT AmountOfOtherSalary{0} FROM " +
                       "Attaysir1.dbo.OtherSalaries WHERE Familyid = '{1}' ", i, id); string colomn = string.Format("AmountOfOtherSalary{0}", i);
                    othersalary += int.Parse(dataAccess.reader(query, colomn));
                }
                return othersalary;
            }
            else { return 0; }
        }

        public static int ExpensesById(int id)
        {
            string query1 = string.Format("select SUM(OtherExpenses.AmountOfOtherExpenses) as AmountOfOtherExpenses " +
                "from Attaysir1.dbo.OtherExpenses where Familyid = '{0}' ", id);
            return int.Parse(dataAccess.reader(query1, "AmountOfOtherExpenses"));
        }

        public static void viewer(ListView listview)
        {
            int n = dataAccess.NumberOfItems("SELECT * FROM Attaysir1.dbo.FaydalananAile");
            int[] ids = new int[n];
            dataAccess.FillingIdsArrey(ids);

            string[] arr = new string[22];
            ListViewItem item;
            for (int i = 0; i < n; i++)
            {
                string query = string.Format("SELECT * FROM Attaysir1.dbo.FaydalananAile where id = '{0}' ", ids[i]);
                arr[i] = dataAccess.reader(query, "FamilyNumber");
                arr[i] = dataAccess.reader(query, "HusbandLastName");
                arr[i] = dataAccess.reader(query, "HusbandFirstName");
                arr[i] = dataAccess.reader(query, "WifeFirstName");
                arr[i] = dataAccess.reader(query, "WifeLastName");
                arr[i] = dataAccess.reader(query, "LivingLocation");
                arr[i] = dataAccess.reader(query, "Adress");
                arr[i] = dataAccess.reader(query, "HusbandIdentificationNumber");
                arr[i] = dataAccess.reader(query, "WifeIdentificationNumber");
                arr[i] = dataAccess.reader(query, "HusbandPhoneNumber");
                arr[i] = dataAccess.reader(query, "WifePhoneNumber");
                arr[i] = dataAccess.reader(query, "NumberOfFamilyNumber");
                arr[i] = dataAccess.reader(query, "HusbandSalary");
                arr[i] = dataAccess.reader(query, "WifeSalary");
                arr[i] = dataAccess.reader(query, "TotalChildrenInsurance");
                arr[i] = dataAccess.reader(query, "NumberOfChildrenTackingInsurance");
                arr[i] = dataAccess.reader(query, "RegisterEmployeesFirstName") +
                    dataAccess.reader(query, "RegisterEmployeesLastName");
                arr[i] = dataAccess.reader(query, "RegisteretionDateTime");
                arr[i] = dataAccess.reader(query, "MonthlyAverageSalaryOfPerson");
                arr[i] = dataAccess.reader(query, "KindOfFamily");
                arr[i] = dataAccess.reader(query, "ExpiryDateOfFile");
                arr[i] = dataAccess.reader(query, "HusbandOrWife");
                item = new ListViewItem(arr);
                listview.Items.Add(item);
            }
        }

        public static void justCharacters(Object o, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        public static void justNumbers(Object o, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46
                //e.KeyChar != char.Parse(Keys.S.ToString())
                //e.KeyChar == (char)Keys.Return
                ) { e.Handled = true; }
        }

        public static int AddEmployeesNote(string HusbandIdentificationNumber,
            string WifeIdentificationNumber,string EmployeesNote,
            string employyesfirstname,string employeeslastname,string TheDateTime)
        {
            string query = string.Format("INSERT INTO Attaysir1.dbo.EmployeesNote(" +
                "EmployeesNote,EmployeesFirstName,EmployeesLastName,RegisteringDat"+
                "eTime,FamilyId) VALUES('{0}','{1}','{2}','{3}','{4}')",
                EmployeesNote,employyesfirstname,employeeslastname,TheDateTime,int.Parse(SelectIdByHusbandIdNumWifeIdNum(HusbandIdentificationNumber, WifeIdentificationNumber)));
            return dataAccess.executenonquery(query);
        }

        public static int didntchecked(string HIdNu,string WIdNu)
        {
            string query = string.Format("UPDATE Attaysir1.dbo.FaydalananAile SET CheckedOrNot = 'false',ExpiryDateOfFile='12-12-2000' WHERE id = '{0}'", int.Parse(SelectIdByHusbandIdNumWifeIdNum(HIdNu, WIdNu)));
            return dataAccess.executenonquery(query);
        }

        public static int CreatGroup(string HusbandIdNu, string WifeIdNu)
        {
            string query = 
                string.Format("INSERT INTO Attaysir1.dbo.Groups(FamilyId) VALUES('{0}')",
                SelectIdByHusbandIdNumWifeIdNum(HusbandIdNu, WifeIdNu));
            return dataAccess.executenonquery(query);
        }

        public static int CreatGroup2(string HusbandIdNu, string WifeIdNu)
        {
            string query =
                string.Format("INSERT INTO Attaysir1.dbo.Groups2(FamilyId) VALUES('{0}')",
                SelectIdByHusbandIdNumWifeIdNum(HusbandIdNu, WifeIdNu));
            return dataAccess.executenonquery(query);
        }

        public static int addunivstudtogroup(string HIdNu,string WIdNu, string univstudidnu,string kacinci)
        {
            string query1 = string.Format("select GroupId from attaysir1.dbo.groups where familyid = '{0}'", SelectIdByHusbandIdNumWifeIdNum(HIdNu, WIdNu));
            string query2 = string.Format("select id from attaysir1.dbo.univstud where IdentityNu = '{0}'",univstudidnu);
            string query3 = string.Format("UPDATE Attaysir1.dbo.groups SET univstudid{0} = '{1}' WHERE GroupId = '{2}'",kacinci , dataAccess.reader(query2, "id"), dataAccess.reader(query1, "GroupId"));
            return dataAccess.executenonquery(query3);
        }

        public static int addschoolstudtogroup2(string groupid2, string schoolstudid, string kacinci)
        {
            //string query1 = string.Format("select GroupId from attaysir1.dbo.groups2 where familyid = '{0}'", SelectIdByHusbandIdNumWifeIdNum(HIdNu, WIdNu));
            //string query2 = string.Format("select id from attaysir1.dbo.univstud where IdentityNu = '{0}'", univstudidnu);
            string query3 = string.Format("UPDATE Attaysir1.dbo.groups2 SET SchoolStud{0} = '{1}' WHERE GroupId = '{2}'", kacinci, schoolstudid,groupid2);
            return dataAccess.executenonquery(query3);
        }
    }
}