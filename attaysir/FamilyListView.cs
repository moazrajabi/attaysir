using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attaysir
{
    public partial class FamilyListView : Form
    {
        public FamilyListView(int[] n)
        {
            InitializeComponent();
            this.n = n;
        }
        int[] n;
        private void FamilyListView_Load(object sender, EventArgs e)
        {
            for(int i=0; i < n.Length; i++) { richTextBox1.Text +=(n[i]+"\n"); }
        }
    }
}
