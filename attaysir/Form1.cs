using attaysir.models;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            String firstName = firstNameTxtBx.Text;
            String lastName = lastNameTxtBx.Text;
            String email = emailTxtBx.Text;
            String password = passwordTxtBx.Text;
            String identityNo = identityTxtBx.Text;
            
            int x = admin.addEmployee(firstName, lastName, email, password, identityNo);
            if (x > 0)
            {
                MessageBox.Show("Employee added successfully", "success");
            }
            else
            {
                MessageBox.Show("failed", "failed");
            }
        }
    }
}
