namespace HiCSClient.Test
{
    partial class DataGridViewTest
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTest1 = new System.Windows.Forms.DataGridView();
            this.clColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTest1
            // 
            this.dgvTest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clColumnID});
            this.dgvTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTest1.Location = new System.Drawing.Point(0, 0);
            this.dgvTest1.Name = "dgvTest1";
            this.dgvTest1.RowTemplate.Height = 23;
            this.dgvTest1.Size = new System.Drawing.Size(395, 381);
            this.dgvTest1.TabIndex = 0;
            this.dgvTest1.Tag = "ColumnID";
            // 
            // clColumnID
            // 
            this.clColumnID.DataPropertyName = "ColumnID";
            this.clColumnID.HeaderText = "Column ID";
            this.clColumnID.Name = "clColumnID";
            // 
            // DataGridViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTest1);
            this.Name = "DataGridViewTest";
            this.Size = new System.Drawing.Size(395, 381);
            this.Load += new System.EventHandler(this.DataGridViewTest_Load);
            this.SizeChanged += new System.EventHandler(this.DataGridViewTest_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTest1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clColumnID;
    }
}
