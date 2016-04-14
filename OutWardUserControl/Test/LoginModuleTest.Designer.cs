namespace OutWardUserControl.Test
{
    partial class LoginModuleTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userLoginModule1 = new OutWardUserControl.UserLoginModule();
            this.SuspendLayout();
            // 
            // userLoginModule1
            // 
            this.userLoginModule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userLoginModule1.Location = new System.Drawing.Point(0, 0);
            this.userLoginModule1.Name = "userLoginModule1";
            this.userLoginModule1.Size = new System.Drawing.Size(341, 267);
            this.userLoginModule1.TabIndex = 0;
            // 
            // LoginModuleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 267);
            this.Controls.Add(this.userLoginModule1);
            this.Name = "LoginModuleTest";
            this.Text = "LoginModuleTest";
            this.ResumeLayout(false);

        }

        #endregion

        private UserLoginModule userLoginModule1;
    }
}