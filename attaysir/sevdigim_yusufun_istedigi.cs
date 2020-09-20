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
       
        ArrayList sqlCommands, selectedColumns, columnsNames;
        public sevdigim_yusufun_istedigi(ArrayList sqlCommands, ArrayList selectedColumns, ArrayList columnsNames)
        {
            InitializeComponent();
            this.sqlCommands = sqlCommands;
            this.selectedColumns = selectedColumns;
            this.columnsNames = columnsNames;
            fillLitView();
        }

        private void sevdigim_yusufun_istedigi_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dttbl = new DataTable();
            //file:///C:/Users/Moaz/Desktop/New%20Microsoft%20Word%20Document.pdf
            //@"E:\test.pdf"
            FromListView(dttbl,listView1);
            ExportDataTableToPdf(dttbl, @"C:/Users/Moaz/Desktop/New%20Microsoft%20Word%20Document.pdf","khara");

            /*
            //     private StreamReader streamToPrint;
            StreamReader streamToPrint;

            streamToPrint = new StreamReader
               ("C:\\My Documents\\MyFile.pdf");
            PrintDocument PrintDocument = new PrintDocument();
            PrintDocument.PrintPage += (object ssender, PrintPageEventArgs ee) =>
            {
                Font font = new Font("Arial", 12);
                float offset = ee.MarginBounds.Top;
                foreach (ListViewItem Item in listView1.Items)
                {
                    // The 5.0f is to add a small space between lines
                    offset += (font.GetHeight() + 5.0f);
                    PointF location = new System.Drawing.PointF(ee.MarginBounds.Left, offset);
                    ee.Graphics.DrawString(Item.Text, font, Brushes.Black, location);
                }
            };

            PrintDocument.Print();
            streamToPrint.Close();*/
        }

        private void fillLitView()
        {
            listView1.Columns.Add("");
            int cs = 0;
            for (int i=0; i<sqlCommands.Count; i++)
            {
                SqlConnection con = new SqlConnection(dataAccess.conString);
                con.Open();
                SqlCommand cmd = new SqlCommand((String) sqlCommands[i], con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem();
                    for (int x=0; x<selectedColumns.Count; x++)
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

        void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
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
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, iTextSharp.text.Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
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
