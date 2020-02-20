using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cat_Client
{
    public partial class taskControl : UserControl
    {
        public taskControl()
        {
            InitializeComponent();
            tmr_Refresh_grid.Start();
        }


        private void gd_taskrefresh()
        {
            dg_task.DataSource = CatData.getlocaltasks();
        }

        private void tmr_Refresh_grid_Tick(object sender, EventArgs e)
        {
            gd_taskrefresh();
        }
    }
}
