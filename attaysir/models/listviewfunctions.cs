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
        }

        public static void viewerEmployee(ListView listView1, string commend)
        {
            ArrayList array = dataAccess.viewerEmployee(commend);
            listView1.Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                ListViewItem item = (ListViewItem)array[i];
                listView1.Items.Add(item);
            }
            listView1.FullRowSelect = true;
            listView1.Items[0].Focused = true;
            listView1.Items[0].Selected = true;
        }
    }
}
