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
        int TheIdOfList;
        ArrayList sqlCommands, selectedColumns, columnsNames;
        public sevdigim_yusufun_istedigi(ArrayList sqlCommands, ArrayList selectedColumns, ArrayList columnsNames,int TheIdOfList)
        {
            InitializeComponent();
            this.sqlCommands = sqlCommands;
            this.selectedColumns = selectedColumns;
            this.columnsNames = columnsNames;
            fillLitView();
            this.TheIdOfList = TheIdOfList;
        }

        ListViewItem[] listViewItems;string[] columns; string itsschool = "";
        public sevdigim_yusufun_istedigi(ListViewItem[] listViewItems,string[] columns,int TheIdOfList)
        {
            InitializeComponent();
            this.listViewItems = listViewItems;
            this.columns = columns;
            this.itsschool = "itsschool";
            this.TheIdOfList = TheIdOfList;
        }

        private void sevdigim_yusufun_istedigi_Load(object sender, EventArgs e)
        {
            if (itsschool!="") {
                fillthelistviewfromschool(listViewItems, columns);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        void fillthelistviewfromschool(ListViewItem[] listViewItems,string[] columns)
        {
            for (int i=0;i<columns.Length;i++)
            {
                listView1.Columns.Add(columns[i]);
            }
            for (int i=0;i< listViewItems.Length;i++)
            {
                //MessageBox.Show(listViewItems[i].ToString());
                //MessageBox.Show(listViewItems.Length.ToString());
                listView1.Items.Add(listViewItems[i].Text);
            }
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
