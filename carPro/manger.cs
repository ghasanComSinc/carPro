using System;
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
    public partial class manger : Form
    {
        public manger()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addItems addItem = new addItems();
            this.Dispose();
            addItem.ShowDialog();
        }

        private void manger_FormClosing(object sender, FormClosingEventArgs e)
        {
            logInForm logIn = new logInForm();
            this.Dispose();
            logIn.ShowDialog();
        }
    }
}
