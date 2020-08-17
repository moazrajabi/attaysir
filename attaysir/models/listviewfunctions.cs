using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using attaysir.models;

namespace attaysir.models
{
    class listviewfunctions
    {
        /*
        public static void viewer(ListView listView1,string commend)
        {
            ArrayList array = dataAccess.viewer(commend);
            listView1.Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            listView1.FullRowSelect = true;
            listView1.Items[0].Focused = true;
            listView1.Items[0].Selected = true;
        }*/
        
        public static void viewerEmployee(ListView listView1, string commend)
        {
            ArrayList array = dataAccess.viewerEmployee(commend);
            listView1.Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            string ifthereemployeesornot =dataAccess.reader1("select * from attaysir1.dbo.employee","id");
            if (ifthereemployeesornot != "")
            {
                listView1.FullRowSelect = true;
                listView1.Items[0].Focused = true;
                listView1.Items[0].Selected = true;
            }
        }

        public static void viewerAdmin(ListView listView1, string commend)
        {
            ArrayList array = dataAccess.viewerAdmin(commend);
            listView1.Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            string ifthereadminsornot = dataAccess.reader1("select * from attaysir1.dbo.admin", "id");
            if (ifthereadminsornot != "")
            {
                listView1.FullRowSelect = true;
                listView1.Items[0].Focused = true;
                listView1.Items[0].Selected = true;
            }
        }

        public static void viewer(ListView listView1, string TableName,string[] array1)
        {
            string g = string.Format("select * from attaysir1.dbo.{0}",TableName);
            ArrayList array = dataAccess.viewer(g,array1);
            listView1.Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            string IfThereItemsOrNot = dataAccess.reader1(g, "id");
            if (IfThereItemsOrNot != "")
            {
                listView1.FullRowSelect = true;
                listView1.Items[0].Focused = true;
                listView1.Items[0].Selected = true;
            }
        }
    }
}
