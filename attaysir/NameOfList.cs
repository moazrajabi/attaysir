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

namespace attaysir
{
    public partial class NameOfList : Form
    {
        string listType;
        ListView.CheckedListViewItemCollection checkedItems;
    
        
        public NameOfList(String listType, ListView.CheckedListViewItemCollection checkedItems)
        {
            InitializeComponent();

            this.listType = listType;
            this.checkedItems = checkedItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                DateTime time = DateTime.Now;
                string date = time.ToString();
                dataAccess.Executequery(string.Format("insert into TheLists(Name,CreatingDate,TypeOfList,faydalananlarsayisi) values('{0}','{1}','{2}','{3}')", richTextBox1.Text , date, listType, checkedItems.Count.ToString()));
                addList();
            }  
        }

        private void addList()
        {
            int listId;
            listId = int.Parse(dataAccess.reader("SELECT max(id) as \"id\" from attaysir1.dbo.TheLists", "id"));

            foreach (ListViewItem item in checkedItems)
            {
                if (listType == "univ")
                {
                    string id = dataAccess.reader(string.Format("select id from attaysir1.dbo.univstud where IdentityNu='{0}'", item.SubItems[5].Text), "id");
                    dataAccess.Executequery(string.Format("insert into attaysir1.dbo.IdesOfTheList(IdOfList,Faydalananlae_id) values('{0}','{1}')", listId, id));
                }
                else
                {
                    dataAccess.Executequery(string.Format("insert into attaysir1.dbo.IdesOfTheList(IdOfList,Faydalananlae_id) values('{0}','{1}')", listId, item.SubItems[1].Text));
                }
            }
            MessageBox.Show("تمت اضافة القائمة بنجاح");
            this.Close();
        }
    }
}
