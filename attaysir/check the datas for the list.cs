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
            SqlCommand cmd = new SqlCommand(string.Format("select * from attaysir1.dbo.IdesOfTheList where IdOfList = '{0}'",this.idoflist), con);
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
            String finalCommand = "select " +command + "  from attaysir1.dbo.FaydalananAile where id =" + id;

            return finalCommand;
        }
        ArrayList sqlCommands = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList selectedColumns = new ArrayList();
            
           
            if (FamilyNumberChBox.Checked)
            {
                selectedColumns.Add(0);
            }
            if (HusbandFirstNameChBox.Checked)
            {
                selectedColumns.Add(1);
            }
            if (HusbandLastNameChBox.Checked)
            {
                selectedColumns.Add(2);
            }
            if (WifeFirstNameChBox.Checked)
            {
                selectedColumns.Add(3);
            }
            if (WifeLastNameChBox.Checked)
            {
                selectedColumns.Add(4);
            }
            if (LivingLocationChBox.Checked)
            {
                selectedColumns.Add(5);
            }
            if (AdressChBox.Checked)
            {
                selectedColumns.Add(6);
            }
            if (HusbandIdentificationNumberChBox.Checked)
            {
                selectedColumns.Add(7);
            }
            if (WifeIdentificationNumberChBox.Checked)
            {
                selectedColumns.Add(8);
            }
            if (HusbandPhoneNumberChBox.Checked)
            {
                selectedColumns.Add(9);
            }
            if (WifePhoneNumberChBox.Checked)
            {
                selectedColumns.Add(10);
            }
            if (NumberOfFamilyMembersChBox.Checked)
            {
                selectedColumns.Add(11);
            }
            if (HusbandSalaryChBox.Checked)
            {
                selectedColumns.Add(12);
            }
            if (WifeSalaryChBox.Checked)
            {
                selectedColumns.Add(13);
            }
            if (TotalChildrenInsuranceChBox.Checked)
            {
                selectedColumns.Add(14);
            }
            if (NumberOfChildrenTackingInsuranceChBox.Checked)
            {
                selectedColumns.Add(15);
            }
            if (RegisterEmployeesFirstNameChBox.Checked)
            {
                selectedColumns.Add(16);
            }
            if (RegisterEmployeesLastNameChBox.Checked)
            {
                selectedColumns.Add(17);
            }
            if (RegisteretionDateTimeChBox.Checked)
            {
                selectedColumns.Add(18);
            }
            if (MonthlyAverageSalaryOfPersonChBox.Checked)
            {
                selectedColumns.Add(19);
            }
            if (KindOfFamilyChBox.Checked)
            {
                selectedColumns.Add(20);
            }
            if (ExpiryDateOfFileChBox.Checked)
            {
                selectedColumns.Add(21);
            }
            if (HusbandOrWifeChBox.Checked)
            {
                selectedColumns.Add(22);
            }

            // MessageBox.Show(createSqlCommand(selectedColumns, "11"));

           for (int i=0; i<ids.Count; i++)
            {
                sqlCommands.Add(createSqlCommand(selectedColumns, (String) ids[i]));
            }


            sevdigim_yusufun_istedigi s = new sevdigim_yusufun_istedigi(sqlCommands,selectedColumns,uniList);
            s.Show();
            this.Close();

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
