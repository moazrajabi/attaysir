﻿using System;
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
    public partial class officermain : Form
    {
        public officermain(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        int id;

        private void button1_Click(object sender, EventArgs e)
        {
            adding n = new adding(id); n.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string f = textBox5.Text;
            if (f != "") {
                
                //
                /*
                comboBox2.Items.Add( "string" );
                */
                //
            }
        }
    }
}
