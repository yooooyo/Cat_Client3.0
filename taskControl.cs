using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cat_Client
{
    public partial class taskControl : UserControl
    {
        public taskControl()
        {
            InitializeComponent();
        }
        public async void gd_taskRefresh()
        {
            dg_task.DataSource = await Task.Factory.StartNew(()=> CatData.getlocaltasksByDesc());
            dg_task.Refresh();
        }

        public void list_taskitemRefresh()
        {
            list_taskitem.Items.Clear();
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var script_path = config.AppSettings.Settings["catscripts"].Value;
            if (Directory.Exists(script_path))
            {
                var scripts = Directory.GetFiles(script_path);
                if (scripts.Count() > 0)
                {
                    foreach (var v in Directory.GetFiles(script_path))
                    {
                        list_taskitem.Items.Add((new FileInfo(v)).Name);
                    }
                }

            }
            list_taskitem.Refresh();
        }

        private void dg_task_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                string message = "Want to add"+Environment.NewLine;
                foreach(var v in fileList)
                {
                    message+= new FileInfo(v).Name + Environment.NewLine;
                }
                message += " in task ?";
                if (MessageBox.Show(message,"Add Task",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var v in fileList)
                    {
                        cat_local.task task = new cat_local.task();
                        task.task1 = new FileInfo(v).Name;
                        task.state = CatStatus.taskStatus.PENDING.ToString();
                        CatData.localtaskAdd(task);
                    }
                    gd_taskRefresh();
                }
            }
        }

        private void dg_task_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var taskid = (int)dg_task.Rows[e.RowIndex].Cells["local_id"].Value;
            CatData.taskDelete(taskid);
            gd_taskRefresh();
        }

        private void dg_task_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var result_loc = dg_task.Rows[e.RowIndex].Cells["result_loc"].Value;
            if(result_loc != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", (string)result_loc);
            }
        }

        public void taskControlInit()
        {
            list_taskitemRefresh();
            gd_taskRefresh();
        }

        private void btn_taskadd_Click(object sender, EventArgs e)
        {
            var selected_tasks = list_taskitem.SelectedItems;
            var selected_tasks_e = selected_tasks.GetEnumerator();
            string message = "Want to add" + Environment.NewLine;
            while(selected_tasks_e.MoveNext())
            {
                message += new FileInfo(selected_tasks_e.Current.ToString()).Name + Environment.NewLine;
            }
            message += " in task ?";
            var dialogret = MessageBox.Show(message, "Add Task", MessageBoxButtons.YesNo);
            Console.WriteLine($"Dialog ret {dialogret}");
            if (dialogret == DialogResult.Yes)
            {
                Console.WriteLine("Comfirm add task");
                selected_tasks_e = selected_tasks.GetEnumerator();
                while (selected_tasks_e.MoveNext())
                {
                    cat_local.task task = new cat_local.task();
                    task.task1 = new FileInfo(selected_tasks_e.Current.ToString()).Name;
                    task.state = CatStatus.taskStatus.PENDING.ToString();
                    CatData.localtaskAdd(task);
                }

            }
            gd_taskRefresh();
        }

        private void btn_taskremove_Click(object sender, EventArgs e)
        {

        }
    }
}
