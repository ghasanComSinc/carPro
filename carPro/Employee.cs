﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carPro
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm logIn = new()
            {
                Location = this.Location,
                Size = this.Size
            };
            this.Dispose();
            logIn.ShowDialog();
        }
    }
}
