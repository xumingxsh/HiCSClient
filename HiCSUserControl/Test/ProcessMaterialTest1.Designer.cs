namespace HiCSUserControl.Test
{
    partial class ProcessMaterialTest1
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
            this.uiProcessMaterial = new HiCSUserControl.ProcessMaterial();
            this.SuspendLayout();
            // 
            // uiProcessMaterial
            // 
            this.uiProcessMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiProcessMaterial.Location = new System.Drawing.Point(0, 0);
            this.uiProcessMaterial.Name = "uiProcessMaterial";
            this.uiProcessMaterial.Size = new System.Drawing.Size(968, 770);
            this.uiProcessMaterial.TabIndex = 0;
            // 
            // ProcessMaterialTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 770);
            this.Controls.Add(this.uiProcessMaterial);
            this.Name = "ProcessMaterialTest1";
            this.Text = "ProcessMaterialTest1";
            this.Load += new System.EventHandler(this.ProcessMaterialTest1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProcessMaterial uiProcessMaterial;
    }
}