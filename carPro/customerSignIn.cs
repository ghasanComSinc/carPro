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
    public partial class customerSignIn : Form
    {
        public customerSignIn()
        {
            InitializeComponent();
        }

        private void customerSignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm logIn = new logInForm();
            this.Dispose();
            logIn.ShowDialog();
        }
    }
}