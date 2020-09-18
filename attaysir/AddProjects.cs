using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir
{
    public partial class AddProjects : Form
    {
        Object[] sortedIds;
        public AddProjects(int id, string adminoremployee)
        {
            InitializeComponent();
            this.id = id;
            this.adminoremployee = adminoremployee;
        }
        int id;
        string adminoremployee="";

        private void AddProjects_Load(object sender, EventArgs e)
        {
            getids();
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.MinDate = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime time = DateTime.Now;
            string date = time.ToString();
            

            if (textBox1.Text == "")
            { MessageBox.Show("ادخل اسم للمشروع اولا"); }
            else if (textBox3.Text == "")
            { MessageBox.Show("ادخل عدد المستفيدين اولا"); }
            else if (textBox4.Text == "")
            { MessageBox.Show("ادخل رابط المشروع اولا"); }
            else if (richTextBox1.Text == "")
            { MessageBox.Show("ادخل وصف للمشروع اولا"); }
            else if (comboBox1.Text == "")
            { MessageBox.Show("اختر قائمة مستفيدين اولا"); }
            else if(dateTimePicker1.Value >= dateTimePicker2.Value)
            { MessageBox.Show("هناك تعارض في تواريخ اإنشاء والإنتهاء"); }
            else
            {
                dataAccess.Executequery(string.Format("INSERT INTO Attaysir1.dbo.Projects(ProjectName,CreatingDate,FaydalananSayisi,Discription,ExpiryDate,listid) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", textBox1.Text,dateTimePicker1.Text, textBox3.Text, richTextBox1.Text,dateTimePicker2.Text, one[comboBox1.SelectedIndex].ToString()));
                //Array.Reverse(sortedIds);
                //int id = int.Parse((string) sortedIds.GetValue(comboBox1.SelectedIndex));
                
                //int g = int.Parse(sortedIds[comboBox1.SelectedIndex].ToString());
                //MessageBox.Show(sortedIds.GetValue(comboBox1.SelectedIndex).ToString());
                //one[comboBox1.SelectedIndex].ToString()
            }
        }
        int[] one;
        void getids()
        {
            ArrayList array = new ArrayList();
            
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9J5CO0P;Initial Catalog=Attaysir1;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select id from Attaysir1.dbo.thelists", con1);
            SqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read()) { array.Add(read1["id"].ToString());  }
            con1.Close();
            Object[] anArray = array.ToArray();
            Array.Sort(anArray);
            sortedIds = anArray;
            int[] two = new int[anArray.Length];
            for (int i=(anArray.Length-1); i>=0; i--)
            {
                int o =  int.Parse((string) anArray[i]);
                string h = dataAccess.reader( string.Format("select name from attaysir1.dbo.thelists where id='{0}'", o.ToString()),"name");
                comboBox1.Items.Add(h);
                two[i] = o;
            }
            one = two;Array.Reverse(one);
        }
        
        ///////////////////////////////////
        /////////////////////////////////////////////////////
        ///////////////////////////////////////////////مهم جدا amk
        void rabit(string url)
        {
            if (MessageBox.Show("هل تريد أن تفتح الرابط ؟", " فتح الرابط", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(url);
            }
        }
    }
}
