﻿using System;
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
        }
        public async void gd_taskrefresh()
        {
            dg_task.DataSource = await Task.Factory.StartNew(()=> CatData.getlocaltasks());
            dg_task.Refresh();
        }

    }
}
