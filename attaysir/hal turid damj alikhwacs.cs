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
    public partial class hal_turid_damj_alikhwacs : Form
    {
        private AddUnivStud form = null;
        public hal_turid_damj_alikhwacs(Form form)
        {
            InitializeComponent();
            this.form = form as AddUnivStud;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form.k();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form.l();
        }
    }
}
