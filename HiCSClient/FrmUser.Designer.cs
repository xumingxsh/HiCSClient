namespace HiCSClient
{
    partial class frmUser
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.rdbSexMan = new System.Windows.Forms.RadioButton();
            this.radSex2 = new System.Windows.Forms.RadioButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "邮箱：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "性别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "地址：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(217, 21);
            this.txtName.TabIndex = 4;
            this.txtName.Tag = "Name";
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(63, 35);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(268, 21);
            this.txtEMail.TabIndex = 5;
            this.txtEMail.Tag = "EMail";
            // 
            // rdbSexMan
            // 
            this.rdbSexMan.AutoSize = true;
            this.rdbSexMan.Location = new System.Drawing.Point(65, 77);
            this.rdbSexMan.Name = "rdbSexMan";
            this.rdbSexMan.Size = new System.Drawing.Size(35, 16);
            this.rdbSexMan.TabIndex = 6;
            this.rdbSexMan.TabStop = true;
            this.rdbSexMan.Text = "男";
            this.rdbSexMan.UseVisualStyleBackColor = true;
            // 
            // radSex2
            // 
            this.radSex2.AutoSize = true;
            this.radSex2.Location = new System.Drawing.Point(121, 78);
            this.radSex2.Name = "radSex2";
            this.radSex2.Size = new System.Drawing.Size(35, 16);
            this.radSex2.TabIndex = 7;
            this.radSex2.TabStop = true;
            this.radSex2.Text = "女";
            this.radSex2.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(61, 109);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(315, 21);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.Tag = "Address";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "年龄：";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(61, 144);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 21);
            this.txtAge.TabIndex = 11;
            this.txtAge.Tag = "Age";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 445);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.radSex2);
            this.Controls.Add(this.rdbSexMan);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUser";
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.RadioButton rdbSexMan;
        private System.Windows.Forms.RadioButton radSex2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAge;
    }
}

