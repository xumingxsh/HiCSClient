namespace HiCSFormTest
{
    partial class ProcessMaterial
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
            this.processMaterial1 = new HiCSUserControl.ProcessMaterial();
            this.SuspendLayout();
            // 
            // processMaterial1
            // 
            this.processMaterial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processMaterial1.Location = new System.Drawing.Point(0, 0);
            this.processMaterial1.Name = "processMaterial1";
            this.processMaterial1.Size = new System.Drawing.Size(683, 417);
            this.processMaterial1.TabIndex = 0;
            // 
            // ProcessMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 417);
            this.Controls.Add(this.processMaterial1);
            this.Name = "ProcessMaterial";
            this.Text = "ProcessMaterial";
            this.Load += new System.EventHandler(this.ProcessMaterial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HiCSUserControl.ProcessMaterial processMaterial1;
    }
}