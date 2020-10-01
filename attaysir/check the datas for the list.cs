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
using attaysir.models;

namespace attaysir
{
    public partial class check_the_datas_for_the_list : Form
    {
        int idoflist;
        public check_the_datas_for_the_list(int idoflist)
        {
            InitializeComponent();
            this.idoflist = idoflist;
            GetFaydalananIdes();
            uniList.Add("FamilyNumber");uniList.Add("HusbandFirstName");
            uniList.Add("HusbandLastName");uniList.Add("WifeFirstName");
            uniList.Add("WifeLastName");uniList.Add("LivingLocation");
            uniList.Add("Adress");uniList.Add("HusbandIdentificationNumber");
            uniList.Add("WifeIdentificationNumber");uniList.Add("HusbandPhoneNumber");
            uniList.Add("WifePhoneNumber");uniList.Add("NumberOfFamilyMembers");
            uniList.Add("HusbandSalary");uniList.Add("WifeSalary");
            uniList.Add("TotalChildrenInsurance");uniList.Add("NumberOfChildrenTackingInsurance");
            uniList.Add("RegisterEmployeesFirstName");uniList.Add("RegisterEmployeesLastName");
            uniList.Add("RegisteretionDateTime");uniList.Add("MonthlyAverageSalaryOfPerson");
            uniList.Add("KindOfFamily");uniList.Add("ExpiryDateOfFile");
            uniList.Add("HusbandOrWife");

           

            
        }

        private void check_the_datas_for_the_list_Load(object sender, EventArgs e)
        {

        }
        ArrayList ids = new ArrayList();
        void GetFaydalananIdes()
        {
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from Attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'", this.idoflist), con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ids.Add(read["Faydalananlae_id"].ToString());
            }
            con.Close();
        }

        ArrayList uniList = new ArrayList();
        private String createSqlCommand(ArrayList selectedList, String id)
        {

            String command ="";
            for(int i = 0; i < selectedList.Count; i++)
            {
                if (i < selectedList.Count - 1)
                {
                    command += uniList[(int)selectedList[i]]/* + " as " + uniList[(int)selectedList[i]]*/ + ", ";
                }
                else
                {
                    command += uniList[(int)selectedList[i]] /* " as "+ uniList[(int)selectedList[i]]*/;
                }

            }
            String finalCommand = "select " +command + "  from Attaysir1.dbo.FaydalananAile where id =" + id;

            return finalCommand;
        }
        ArrayList sqlCommands = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList selectedColumns = new ArrayList();
            int o = 0;
            if (FamilyNumberChBox.Checked) { selectedColumns.Add(0);o++; }
            if (HusbandFirstNameChBox.Checked) { selectedColumns.Add(1); o++; }
            if (HusbandLastNameChBox.Checked) { selectedColumns.Add(2); o++; }
            if (WifeFirstNameChBox.Checked) { selectedColumns.Add(3); o++; }
            if (WifeLastNameChBox.Checked) { selectedColumns.Add(4); o++; }
            if (LivingLocationChBox.Checked) { selectedColumns.Add(5); o++; }
            if (AdressChBox.Checked) { selectedColumns.Add(6); o++; }
            if (HusbandIdentificationNumberChBox.Checked) { selectedColumns.Add(7); o++; }
            if (WifeIdentificationNumberChBox.Checked) { selectedColumns.Add(8); o++; }
            if (HusbandPhoneNumberChBox.Checked) { selectedColumns.Add(9); o++; }
            if (WifePhoneNumberChBox.Checked) { selectedColumns.Add(10); o++; }
            if (NumberOfFamilyMembersChBox.Checked) { selectedColumns.Add(11); o++; }
            if (HusbandSalaryChBox.Checked) { selectedColumns.Add(12); o++; }
            if (WifeSalaryChBox.Checked) { selectedColumns.Add(13); o++; }
            if (TotalChildrenInsuranceChBox.Checked) { selectedColumns.Add(14); o++; }
            if (NumberOfChildrenTackingInsuranceChBox.Checked) { selectedColumns.Add(15); o++; }
            if (RegisterEmployeesFirstNameChBox.Checked) { selectedColumns.Add(16); o++; }
            if (RegisterEmployeesLastNameChBox.Checked) { selectedColumns.Add(17); o++; }
            if (RegisteretionDateTimeChBox.Checked) { selectedColumns.Add(18); o++; }
            if (MonthlyAverageSalaryOfPersonChBox.Checked) { selectedColumns.Add(19); o++; }
            if (KindOfFamilyChBox.Checked) { selectedColumns.Add(20); o++; }
            if (ExpiryDateOfFileChBox.Checked) { selectedColumns.Add(21); o++; }
            if (HusbandOrWifeChBox.Checked) { selectedColumns.Add(22); o++; }
            if (o<2) { MessageBox.Show("يجب عليك اختيار مربعين على الاقل"); } else {
                for (int i = 0; i < ids.Count; i++)
                {
                    sqlCommands.Add(createSqlCommand(selectedColumns, (String)ids[i]));
                }

                sevdigim_yusufun_istedigi s = new sevdigim_yusufun_istedigi(sqlCommands, selectedColumns, uniList,this.idoflist);
                s.Show();
                this.Close();
                s.BringToFront();
            }

        }
    }
}
/*
 /Creating iTextSharp Table from the DataTable data
PdfPTable pdfTable = new PdfPTable(listView1.Columns.Count);
pdfTable.DefaultCell.Padding = 3;
pdfTable.WidthPercentage = 30;
pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
pdfTable.DefaultCell.BorderWidth = 1;

//Adding Header row
foreach (ColumnHeader column in listView1.Columns)
{
    PdfPCell cell = new PdfPCell(new Phrase(column.Text));
    pdfTable.AddCell(cell);
}

//Adding DataRow
foreach (ListViewItem itemRow in listView1.Items)
{
    int i = 0;
    for (i = 0; i < itemRow.SubItems.Count - 1; i++)
    {
        pdfTable.AddCell(itemRow.SubItems[i].Text);
    }
}

//Exporting to PDF
string folderPath = @"D:/Temp/";
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}
using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
{
    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
    PdfWriter.GetInstance(pdfDoc, stream);
    pdfDoc.Open();
    pdfDoc.Add(pdfTable);
    pdfDoc.Close();
    stream.Close();
}
     
     
     */
/*
SELECT TOP (1000) [Familyid]
 ,[GroupId]
 ,[id]
 ,[FirstName]
 ,[FatherName]
 ,[MotherName]
 ,[LastName]
 ,[IdentityNu]
 ,[UnivName]
 ,[KolejName]
 ,[DepartmentName]
 ,[YearlyFees]
 ,[whichyear]
 ,[PhoneNu]
 ,[SecondPhoneNu]
 ,[Email]
FROM [Attaysir1].[dbo].[UnivStud] 

*/
/*
SELECT TOP(1000) [id]
      ,[GroupId]
      ,[Familyid]
      ,[FirstName]
      ,[FatherName]
      ,[MotherName]
      ,[IDNum]
      ,[SchoolName]
      ,[WhichClass]
      ,[YearlyFees]
FROM[Attaysir1].[dbo].[SchoolStud]

*  */
