namespace HiCSUserControl
{
    partial class LoginModul
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
            this.gpLogin = new System.Windows.Forms.GroupBox();
            this.cbProcesses = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.dgvLoginUser = new System.Windows.Forms.DataGridView();
            this.gpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gpLogin
            // 
            this.gpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpLogin.Controls.Add(this.cbProcesses);
            this.gpLogin.Controls.Add(this.btnLogout);
            this.gpLogin.Controls.Add(this.btnLogin);
            this.gpLogin.Controls.Add(this.dgvLoginUser);
            this.gpLogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpLogin.Location = new System.Drawing.Point(15, 14);
            this.gpLogin.Margin = new System.Windows.Forms.Padding(4);
            this.gpLogin.Name = "gpLogin";
            this.gpLogin.Padding = new System.Windows.Forms.Padding(4);
            this.gpLogin.Size = new System.Drawing.Size(302, 323);
            this.gpLogin.TabIndex = 6;
            this.gpLogin.TabStop = false;
            this.gpLogin.Text = "登录信息";
            // 
            // cbProcesses
            // 
            this.cbProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcesses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbProcesses.FormattingEnabled = true;
            this.cbProcesses.Items.AddRange(new object[] {
            "管理员",
            "领班",
            "前处理",
            "质检",
            "包装"});
            this.cbProcesses.Location = new System.Drawing.Point(69, 26);
            this.cbProcesses.Name = "cbProcesses";
            this.cbProcesses.Size = new System.Drawing.Size(121, 20);
            this.cbProcesses.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogout.Location = new System.Drawing.Point(162, 277);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 34);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "全部注销";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(9, 277);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 34);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "手动登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // dgvLoginUser
            // 
            this.dgvLoginUser.AllowUserToAddRows = false;
            this.dgvLoginUser.AllowUserToDeleteRows = false;
            this.dgvLoginUser.AllowUserToResizeRows = false;
            this.dgvLoginUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoginUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoginUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginUser.ColumnHeadersVisible = false;
            this.dgvLoginUser.Location = new System.Drawing.Point(7, 56);
            this.dgvLoginUser.MultiSelect = false;
            this.dgvLoginUser.Name = "dgvLoginUser";
            this.dgvLoginUser.ReadOnly = true;
            this.dgvLoginUser.RowHeadersVisible = false;
            this.dgvLoginUser.RowTemplate.Height = 35;
            this.dgvLoginUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoginUser.Size = new System.Drawing.Size(281, 210);
            this.dgvLoginUser.TabIndex = 1;
            this.dgvLoginUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoginUser_CellDoubleClick);
            // 
            // LoginModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpLogin);
            this.Name = "LoginModul";
            this.Size = new System.Drawing.Size(325, 351);
            this.Load += new System.EventHandler(this.UserLoginModule_Load);
            this.gpLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpLogin;
        private System.Windows.Forms.ComboBox cbProcesses;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.DataGridView dgvLoginUser;
    }
}
