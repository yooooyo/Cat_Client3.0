using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cat_Client
{
    public partial class F1_Main : Form
    {
        


        public F1_Main()
        {
            CatCore core = new CatCore();
            InitializeComponent();
            core.CatInit();
            
        }

        private void btn_main_close_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void btn_main_mininum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #region mouse move window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void mouse_move_window(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void tableLayoutPanel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_sn_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_task_index_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_pvt_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_task_name_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_pws_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void lb_task_status_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move_window(e);
        }

        #endregion

        private void F1_Main_Shown(object sender, EventArgs e)
        {
            CatCore core = new CatCore();
            Task mainRun = new Task(() => core.Execute());
            lb_pvt.Text = CatReg.winpvt_version;
            if(CatCore.device != null) lb_sn.Text = CatCore.device.sn;
            lb_task_index.Text = CatReg.task_id;
            lb_task_name.Text   = CatReg.task_name;
            lb_task_status.Text = CatReg.task_status;
            lb_pvt.Text = CatReg.winpvt_version;
            lb_pws.Text = CatReg.pws_version;
            if (CatCore.device != null) mainRun.Start();

        }

        private void btn_task_Click(object sender, EventArgs e)
        {
            pl_select_page.Location = new Point(pl_select_page.Location.X, btn_task.Location.Y);
            taskControl1.BringToFront();
            taskControl1.taskControlInit();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            pl_select_page.Location = new Point(pl_select_page.Location.X, btn_log.Location.Y);
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            pl_select_page.Location = new Point(pl_select_page.Location.X, btn_info.Location.Y);
        }

    }
}
