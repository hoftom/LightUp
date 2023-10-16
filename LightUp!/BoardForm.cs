﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightUp_
{
    public partial class BoardForm : Form
    {
        public BoardForm()
        {
            InitializeComponent();
        }

        private void BoardForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Prevent the application from going into fullscreen mode
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}