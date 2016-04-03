namespace HiCSClient.Test
{
    partial class DataGridViewTestFrm
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
            this.dataGridViewTest1 = new HiCSClient.Test.DataGridViewTest();
            this.SuspendLayout();
            // 
            // dataGridViewTest1
            // 
            this.dataGridViewTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTest1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTest1.Name = "dataGridViewTest1";
            this.dataGridViewTest1.Size = new System.Drawing.Size(746, 416);
            this.dataGridViewTest1.TabIndex = 0;
            // 
            // DataGridViewTestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 416);
            this.Controls.Add(this.dataGridViewTest1);
            this.Name = "DataGridViewTestFrm";
            this.Text = "DataGridViewTestFrm";
            this.ResizeEnd += new System.EventHandler(this.DataGridViewTestFrm_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTest dataGridViewTest1;
    }
}