using attaysir.models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace attaysir
{
    public partial class sevdigim_yusufun_istedigi : Form
    {
        int TheIdOfList,count;
        ArrayList sqlCommands, selectedColumns, columnsNames;
        bool checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8;
        public sevdigim_yusufun_istedigi(ArrayList sqlCommands, ArrayList selectedColumns, ArrayList columnsNames,int TheIdOfList)
        {
            InitializeComponent();
            this.sqlCommands = sqlCommands;
            this.selectedColumns = selectedColumns;
            this.columnsNames = columnsNames;
            fillLitView();
            this.TheIdOfList = TheIdOfList;
        }

        int[] listViewItems;string[] columns; string itsschool = "";int[] secelencolumns;
        public sevdigim_yusufun_istedigi(int[] listViewItems,string[] columns,int[] secelencolumns,int TheIdOfList)
        {
            InitializeComponent();
            this.listViewItems = listViewItems;
            this.columns = columns;
            this.itsschool = "itsschool";
            this.TheIdOfList = TheIdOfList;
            this.secelencolumns = secelencolumns;
            count = int.Parse(dataAccess.reader(string.Format("select * from attaysir1.dbo.TheLists where id='{0}'", TheIdOfList), "faydalananlarsayisi"));
        }

        private void sevdigim_yusufun_istedigi_Load(object sender, EventArgs e)
        {
            if (itsschool!="")
            {
                checkedboxes();
                fillthelistviewfromschool(listViewItems, columns);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void checkedboxes()
        {
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 1) { checkBox1 = true; break; } else { checkBox1 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 2) { checkBox2 = true; break; } else { checkBox2 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 3) { checkBox3 = true; break; } else { checkBox3 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 4) { checkBox4 = true; break; } else { checkBox4 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 5) { checkBox5 = true; break; } else { checkBox5 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 6) { checkBox6 = true; break; } else { checkBox6 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 7) { checkBox7 = true; break; } else { checkBox7 = false; } }
            for (int i = 0; i < secelencolumns.Length; i++) { if (secelencolumns[i] == 8) { checkBox8 = true; break; } else { checkBox8 = false; } }
        }

        //creating the PDF
        private void button1_Click(object sender, EventArgs e)
        {
            String path="";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "إختر موقع للملف";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string NameOfList = dataAccess.reader(string.Format("select Name from Attaysir1.dbo.TheLists where id ='{0}'",this.TheIdOfList), "Name");
                path = fbd.SelectedPath + "\\"+ NameOfList + ".pdf";
                DataTable dttbl = new DataTable();
                FromListView(dttbl, listView1);
                ExportDataTableToPdf(dttbl, path, NameOfList);
                System.Diagnostics.Process.Start(path);
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            
            
        
        }

        void fillthelistviewfromschool(int[] listViewItems,string[] columns)
        {
            for (int i=0;i<columns.Length;i++)
            {
                listView1.Columns.Add(columns[i]);
            }
            getcolumns();
        }
        void getcolumns()
        {
            int[] ides = listViewItems;
            int attartib = 0;
            string query = "select";
            if (checkBox1) { query += " FirstName"; attartib++; }
            if (checkBox2) { if (attartib > 0) { query += " ,FatherName"; } else { query += " FatherName"; attartib++; } }
            if (checkBox3) { if (attartib > 0) { query += " ,MotherName"; } else { query += " MotherName"; attartib++; } }
            if (checkBox4) { if (attartib > 0) { query += " ,IDNum"; } else { query += " IDNum"; attartib++; } }
            if (checkBox5) { if (attartib > 0) { query += " ,SchoolName"; } else { query += " SchoolName"; attartib++; } }
            if (checkBox6) { if (attartib > 0) { query += " ,WhichClass"; } else { query += " WhichClass"; attartib++; } }
            if (checkBox7) { if (attartib > 0) { query += " ,YearlyFees"; } else { query += " YearlyFees"; attartib++; } }
            if (checkBox8) { if (attartib > 0) { query += " ,Familyid"; } else { query += " Familyid"; attartib++; } }
            query += string.Format(" from Attaysir1.dbo.SchoolStud where ");
            for (int i = 0; i < count; i++)
            {
                if (i == 0) { query += string.Format(" id = '{0}'", ides[i]); } else { query += string.Format(" or id = '{0}'", ides[i]); }
            }
            SqlConnection con = new SqlConnection(dataAccess.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                int attartib1 = 0;
                ListViewItem item = null;
                if (checkBox1) { if (attartib1 > 0) { item.SubItems.Add(read["FirstName"].ToString()); } else { item = new ListViewItem(read["FirstName"].ToString()); attartib1++; } }
                if (checkBox2) { if (attartib1 > 0) { item.SubItems.Add(read["FatherName"].ToString()); } else { item = new ListViewItem(read["FatherName"].ToString()); attartib1++; } }
                if (checkBox3) { if (attartib1 > 0) { item.SubItems.Add(read["MotherName"].ToString()); } else { item = new ListViewItem(read["MotherName"].ToString()); attartib1++; } }
                if (checkBox4) { if (attartib1 > 0) { item.SubItems.Add(read["IDNum"].ToString()); } else { item = new ListViewItem(read["IDNum"].ToString()); attartib1++; } }
                if (checkBox5) { if (attartib1 > 0) { item.SubItems.Add(read["SchoolName"].ToString()); } else { item = new ListViewItem(read["SchoolName"].ToString()); attartib1++; } }
                if (checkBox6) { if (attartib1 > 0) { item.SubItems.Add(read["WhichClass"].ToString()); } else { item = new ListViewItem(read["WhichClass"].ToString()); attartib1++; } }
                if (checkBox7) { if (attartib1 > 0) { item.SubItems.Add(read["YearlyFees"].ToString()); } else { item = new ListViewItem(read["YearlyFees"].ToString()); attartib1++; } }
                if (checkBox8) { if (attartib1 > 0) { item.SubItems.Add(read["Familyid"].ToString()); } else { item = new ListViewItem(read["Familyid"].ToString()); attartib1++; } }
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void fillLitView()
        {
            int cs = 0;
            for (int i=0; i<sqlCommands.Count; i++)
            {
                SqlConnection con = new SqlConnection(dataAccess.conString);
                con.Open();
                SqlCommand cmd = new SqlCommand((String) sqlCommands[i], con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem(read[(String)columnsNames[(int)selectedColumns[0]]].ToString());
                    for (int x=1; x<selectedColumns.Count; x++)
                    {
                        if (cs == 0)
                        {
                            cs++;

                            // Set to details view.
                            listView1.View = View.Details;
                            // Add a column with width 20 and left alignment.
                            for (int n=0; n<selectedColumns.Count; n++)
                            listView1.Columns.Add((String)columnsNames[(int)selectedColumns[n]], 20, HorizontalAlignment.Left);
                        }
                        item.SubItems.Add(read[(String)columnsNames[(int)selectedColumns[x]]].ToString());
                    }
                    listView1.Items.Add(item);
                }
                con.Close();
            }
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                this.BringToFront();
                i++;
            }
        }

        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////
        /////////////////

        void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            //StreamWriter(@"C:\\AllValidateReturn.xls", true, System.Text.Encoding.GetEncoding("Arabic"));
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/arabtype.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.Color.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Author : Dotnet Mob", fntAuthor));
            prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 20);
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, iTextSharp.text.Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.Color.GRAY;
                cell.AddElement(new Phrase(dtblTable.Columns[i].ColumnName.ToUpper(), font));
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Phrase(dtblTable.Rows[i][j].ToString(), font));
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        public static void FromListView(DataTable table, System.Windows.Forms.ListView lvw)
        {
            table.Clear();
            var columns = lvw.Columns.Count;

            foreach (ColumnHeader column in lvw.Columns)
                table.Columns.Add(column.Text);

            foreach (ListViewItem item in lvw.Items)
            {
                var cells = new object[columns];
                for (var i = 0; i < columns; i++)
                    cells[i] = item.SubItems[i].Text;
                table.Rows.Add(cells);
            }
        }
    }
}
