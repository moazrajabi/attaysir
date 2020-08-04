using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class TheListView : Form
    {
        public TheListView()
        {
            InitializeComponent();
            listView1.Size = new Size(this.Width - 23, this.Height - 45);
        }

        private void TheListView_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listviewfunctions.viewer(listView1, "select * from Attaysir1.dbo.FaydalananAile");
        }

        private void TheListView_Resize(object sender, EventArgs e)
        {
            listView1.Size = new Size(this.Width - 23, this.Height - 45);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String husbandName = listView1.SelectedItems[0].SubItems[2].Text;
            MessageBox.Show(husbandName);
        }
    }
}
