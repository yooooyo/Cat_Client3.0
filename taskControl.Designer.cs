namespace Cat_Client
{
    partial class taskControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dg_task = new System.Windows.Forms.DataGridView();
            this.tmr_Refresh_grid = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dg_task)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_task
            // 
            this.dg_task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_task.Location = new System.Drawing.Point(0, 0);
            this.dg_task.Name = "dg_task";
            this.dg_task.Size = new System.Drawing.Size(690, 356);
            this.dg_task.TabIndex = 0;
            // 
            // tmr_Refresh_grid
            // 
            this.tmr_Refresh_grid.Tick += new System.EventHandler(this.tmr_Refresh_grid_Tick);
            // 
            // taskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.dg_task);
            this.Name = "taskControl";
            this.Size = new System.Drawing.Size(690, 356);
            ((System.ComponentModel.ISupportInitialize)(this.dg_task)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_task;
        private System.Windows.Forms.Timer tmr_Refresh_grid;
    }
}
