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
            form.k();
            this.Close();
            form.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form.l();
            this.Close();
            form.Close();
        }

        void f()
        {
            richTextBox1.Text = form.j();
        }

        private void hal_turid_damj_alikhwacs_Load(object sender, EventArgs e)
        {
            f();
            form.Enabled = false;
            form.ControlBox = false;
        }
    }
}
