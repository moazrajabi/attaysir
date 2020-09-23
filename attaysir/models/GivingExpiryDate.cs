using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir.models
{
    public partial class GivingExpiryDate : Form
    {
        private didntcheckedtimefamily form = null;
        public GivingExpiryDate(Form form)
        {
            InitializeComponent();
            this.form = form as didntcheckedtimefamily;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = dateTimePicker2.Text;
            string query = string.Format("update attaysir1.dbo.faydalananaile set ExpiryDateOfFile='{0}' , UpdatedOrNot = '{1}', CheckedOrNot = 'false' where id='{2}'", dateTimePicker2.Text,"true", Employee2.SelectIdByHusbandIdNumWifeIdNum(this.form.IdentificetionNumber1, this.form.IdentificetionNumber2));
            dataAccess.executenonquery(query);
            if (form.ForUpDateing != "")
            {
                if (form.bigorsmall == false) { form.small1(); }
                else if (form.bigorsmall == true) { form.big1(); }
            }
            else
            { 
                if (form.bigorsmall == false) { form.small(); }
                else if (form.bigorsmall == true) { form.big(); }
            }
            this.Close();
        }
    }
}
