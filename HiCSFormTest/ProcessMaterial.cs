﻿using System;
using System.Windows.Forms;

namespace HiCSFormTest
{
    public partial class ProcessMaterial : Form
    {
        public ProcessMaterial()
        {
            InitializeComponent();
        }

        private void ProcessMaterial_Load(object sender, EventArgs e)
        {
            processMaterial1.SetProcess("P1", "1");
        }
    }
}
