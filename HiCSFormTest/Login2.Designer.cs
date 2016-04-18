namespace HiCSFormTest
{
    partial class Login2
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
            this.loginModul1 = new HiCSUserControl.LoginModul();
            this.SuspendLayout();
            // 
            // loginModul1
            // 
            this.loginModul1.Location = new System.Drawing.Point(12, 12);
            this.loginModul1.Name = "loginModul1";
            this.loginModul1.Size = new System.Drawing.Size(325, 351);
            this.loginModul1.TabIndex = 0;
            // 
            // Login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 389);
            this.Controls.Add(this.loginModul1);
            this.Name = "Login2";
            this.Text = "Login2";
            this.Load += new System.EventHandler(this.Login2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HiCSUserControl.LoginModul loginModul1;
    }
}