namespace HiCSFormTest
{
    partial class ProcessMaterial_DBClick
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
            this.processMaterial1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processMaterial1.Location = new System.Drawing.Point(23, 12);
            this.processMaterial1.Name = "processMaterial1";
            this.processMaterial1.Size = new System.Drawing.Size(468, 412);
            this.processMaterial1.TabIndex = 0;
            // 
            // ProcessMaterial_DBClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 446);
            this.Controls.Add(this.processMaterial1);
            this.Name = "ProcessMaterial_DBClick";
            this.Text = "ProcessMaterial_DBClick";
            this.Load += new System.EventHandler(this.ProcessMaterial_DBClick_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HiCSUserControl.ProcessMaterial processMaterial1;
    }
}