namespace FormTest
{
    partial class KeyBoardForm
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
            this.txtOutPut = new System.Windows.Forms.TextBox();
            this.keyBoardControl1 = new HiCSUIHelper.KeyBoardControl();
            this.SuspendLayout();
            // 
            // txtOutPut
            // 
            this.txtOutPut.Location = new System.Drawing.Point(31, 300);
            this.txtOutPut.Multiline = true;
            this.txtOutPut.Name = "txtOutPut";
            this.txtOutPut.Size = new System.Drawing.Size(552, 103);
            this.txtOutPut.TabIndex = 1;
            this.txtOutPut.MouseEnter += new System.EventHandler(this.txtOutPut_MouseEnter);
            this.txtOutPut.MouseLeave += new System.EventHandler(this.txtOutPut_MouseLeave);
            // 
            // keyBoardControl1
            // 
            this.keyBoardControl1.Location = new System.Drawing.Point(126, 47);
            this.keyBoardControl1.Name = "keyBoardControl1";
            this.keyBoardControl1.Size = new System.Drawing.Size(481, 207);
            this.keyBoardControl1.TabIndex = 2;
            this.keyBoardControl1.UserParent = this;
            // 
            // KeyBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 703);
            this.Controls.Add(this.keyBoardControl1);
            this.Controls.Add(this.txtOutPut);
            this.Name = "KeyBoardForm";
            this.Text = "KeyBoardForm";
            this.Load += new System.EventHandler(this.KeyBoardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutPut;
        private HiCSUIHelper.KeyBoardControl keyBoardControl1;
    }
}