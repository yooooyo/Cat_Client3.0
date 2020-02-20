namespace Cat_Client
{
    partial class F1_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F1_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pl_select_page = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_info = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.btn_task = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_main_mininum = new System.Windows.Forms.Button();
            this.btn_main_close = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_sn = new System.Windows.Forms.Label();
            this.lb_pvt = new System.Windows.Forms.Label();
            this.lb_pws = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_task_index = new System.Windows.Forms.Label();
            this.lb_task_name = new System.Windows.Forms.Label();
            this.lb_task_status = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_app_version = new System.Windows.Forms.Label();
            this.sqlCeProviderServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskControl1 = new Cat_Client.taskControl();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlCeProviderServicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 496);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.41129F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.58871F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 496);
            this.tableLayoutPanel4.TabIndex = 0;
            this.tableLayoutPanel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel4_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pl_select_page);
            this.panel2.Controls.Add(this.btn_info);
            this.panel2.Controls.Add(this.btn_log);
            this.panel2.Controls.Add(this.btn_task);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 360);
            this.panel2.TabIndex = 1;
            // 
            // pl_select_page
            // 
            this.pl_select_page.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pl_select_page.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(214)))));
            this.pl_select_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pl_select_page.Location = new System.Drawing.Point(0, 0);
            this.pl_select_page.Name = "pl_select_page";
            this.pl_select_page.Size = new System.Drawing.Size(5, 40);
            this.pl_select_page.TabIndex = 4;
            // 
            // btn_info
            // 
            this.btn_info.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_info.FlatAppearance.BorderSize = 0;
            this.btn_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_info.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_info.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_info.Image = ((System.Drawing.Image)(resources.GetObject("btn_info.Image")));
            this.btn_info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_info.Location = new System.Drawing.Point(0, 80);
            this.btn_info.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(194, 40);
            this.btn_info.TabIndex = 2;
            this.btn_info.Text = "Info";
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // btn_log
            // 
            this.btn_log.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_log.FlatAppearance.BorderSize = 0;
            this.btn_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_log.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_log.Location = new System.Drawing.Point(0, 40);
            this.btn_log.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(194, 40);
            this.btn_log.TabIndex = 1;
            this.btn_log.Text = "Log";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_task
            // 
            this.btn_task.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_task.FlatAppearance.BorderSize = 0;
            this.btn_task.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_task.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_task.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_task.Image = ((System.Drawing.Image)(resources.GetObject("btn_task.Image")));
            this.btn_task.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_task.Location = new System.Drawing.Point(0, 0);
            this.btn_task.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btn_task.Name = "btn_task";
            this.btn_task.Size = new System.Drawing.Size(194, 40);
            this.btn_task.TabIndex = 0;
            this.btn_task.Text = "Task";
            this.btn_task.UseVisualStyleBackColor = true;
            this.btn_task.Click += new System.EventHandler(this.btn_task_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(200, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_main_mininum, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_main_close, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(655, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(38, 94);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_main_mininum
            // 
            this.btn_main_mininum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_main_mininum.FlatAppearance.BorderSize = 0;
            this.btn_main_mininum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_main_mininum.Image = ((System.Drawing.Image)(resources.GetObject("btn_main_mininum.Image")));
            this.btn_main_mininum.Location = new System.Drawing.Point(3, 50);
            this.btn_main_mininum.Name = "btn_main_mininum";
            this.btn_main_mininum.Size = new System.Drawing.Size(32, 41);
            this.btn_main_mininum.TabIndex = 1;
            this.btn_main_mininum.UseVisualStyleBackColor = true;
            this.btn_main_mininum.Click += new System.EventHandler(this.btn_main_mininum_Click);
            // 
            // btn_main_close
            // 
            this.btn_main_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_main_close.FlatAppearance.BorderSize = 0;
            this.btn_main_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_main_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_main_close.Image")));
            this.btn_main_close.Location = new System.Drawing.Point(3, 3);
            this.btn_main_close.Name = "btn_main_close";
            this.btn_main_close.Size = new System.Drawing.Size(32, 41);
            this.btn_main_close.TabIndex = 0;
            this.btn_main_close.UseVisualStyleBackColor = true;
            this.btn_main_close.Click += new System.EventHandler(this.btn_main_close_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64463F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35537F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 379F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.lb_sn, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lb_pvt, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lb_pws, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.lb_task_index, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.lb_task_name, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.lb_task_status, 3, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.125F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(646, 94);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "SN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "PVT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "PWS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label3_MouseDown);
            // 
            // lb_sn
            // 
            this.lb_sn.AutoSize = true;
            this.lb_sn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_sn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_sn.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sn.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_sn.Location = new System.Drawing.Point(73, 0);
            this.lb_sn.Name = "lb_sn";
            this.lb_sn.Size = new System.Drawing.Size(88, 30);
            this.lb_sn.TabIndex = 0;
            this.lb_sn.Text = "SN";
            this.lb_sn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_sn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_sn_MouseDown);
            // 
            // lb_pvt
            // 
            this.lb_pvt.AutoSize = true;
            this.lb_pvt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pvt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_pvt.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_pvt.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_pvt.Location = new System.Drawing.Point(73, 30);
            this.lb_pvt.Name = "lb_pvt";
            this.lb_pvt.Size = new System.Drawing.Size(88, 34);
            this.lb_pvt.TabIndex = 0;
            this.lb_pvt.Text = "SN";
            this.lb_pvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_pvt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_pvt_MouseDown);
            // 
            // lb_pws
            // 
            this.lb_pws.AutoSize = true;
            this.lb_pws.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pws.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_pws.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_pws.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_pws.Location = new System.Drawing.Point(73, 64);
            this.lb_pws.Name = "lb_pws";
            this.lb_pws.Size = new System.Drawing.Size(88, 30);
            this.lb_pws.TabIndex = 0;
            this.lb_pws.Text = "SN";
            this.lb_pws.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_pws.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_pws_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(167, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Task Index";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label7_MouseDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(167, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 34);
            this.label8.TabIndex = 0;
            this.label8.Text = "Task Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label8_MouseDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(167, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "Task Status";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label9_MouseDown);
            // 
            // lb_task_index
            // 
            this.lb_task_index.AutoSize = true;
            this.lb_task_index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_task_index.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_task_index.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_task_index.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_task_index.Location = new System.Drawing.Point(269, 0);
            this.lb_task_index.Name = "lb_task_index";
            this.lb_task_index.Size = new System.Drawing.Size(374, 30);
            this.lb_task_index.TabIndex = 0;
            this.lb_task_index.Text = "SN";
            this.lb_task_index.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_task_index.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_task_index_MouseDown);
            // 
            // lb_task_name
            // 
            this.lb_task_name.AutoSize = true;
            this.lb_task_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_task_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_task_name.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_task_name.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_task_name.Location = new System.Drawing.Point(269, 30);
            this.lb_task_name.Name = "lb_task_name";
            this.lb_task_name.Size = new System.Drawing.Size(374, 34);
            this.lb_task_name.TabIndex = 0;
            this.lb_task_name.Text = "SN";
            this.lb_task_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_task_name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_task_name_MouseDown);
            // 
            // lb_task_status
            // 
            this.lb_task_status.AutoSize = true;
            this.lb_task_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_task_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_task_status.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_task_status.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_task_status.Location = new System.Drawing.Point(269, 64);
            this.lb_task_status.Name = "lb_task_status";
            this.lb_task_status.Size = new System.Drawing.Size(374, 30);
            this.lb_task_status.TabIndex = 0;
            this.lb_task_status.Text = "SN";
            this.lb_task_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_task_status.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_task_status_MouseDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(200, 100);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(696, 396);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.taskControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(690, 356);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.65218F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.34783F));
            this.tableLayoutPanel6.Controls.Add(this.lb_app_version, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 365);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(690, 28);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // lb_app_version
            // 
            this.lb_app_version.AutoSize = true;
            this.lb_app_version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_app_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_app_version.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_app_version.ForeColor = System.Drawing.Color.Gainsboro;
            this.lb_app_version.Location = new System.Drawing.Point(593, 0);
            this.lb_app_version.Name = "lb_app_version";
            this.lb_app_version.Size = new System.Drawing.Size(94, 28);
            this.lb_app_version.TabIndex = 1;
            this.lb_app_version.Text = "PWS";
            this.lb_app_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlCeProviderServicesBindingSource
            // 
            this.sqlCeProviderServicesBindingSource.DataSource = typeof(System.Data.Entity.SqlServerCompact.SqlCeProviderServices);
            // 
            // taskControl1
            // 
            this.taskControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.taskControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskControl1.Location = new System.Drawing.Point(0, 0);
            this.taskControl1.Name = "taskControl1";
            this.taskControl1.Size = new System.Drawing.Size(690, 356);
            this.taskControl1.TabIndex = 0;
            // 
            // F1_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(896, 496);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F1_Main";
            this.Text = "Cat Client";
            this.Shown += new System.EventHandler(this.F1_Main_Shown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlCeProviderServicesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_sn;
        private System.Windows.Forms.Label lb_pvt;
        private System.Windows.Forms.Label lb_pws;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_task_index;
        private System.Windows.Forms.Label lb_task_name;
        private System.Windows.Forms.Label lb_task_status;
        private System.Windows.Forms.Button btn_main_close;
        private System.Windows.Forms.Button btn_main_mininum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btn_task;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lb_app_version;
        private System.Windows.Forms.FlowLayoutPanel pl_select_page;
        private System.Windows.Forms.BindingSource sqlCeProviderServicesBindingSource;
        private taskControl taskControl1;
    }
}

