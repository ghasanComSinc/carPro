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
    public partial class addItems : Form
    {
        public addItems()
        {
            InitializeComponent();
        }

        private void addItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            manger mangerForm = new manger();
            this.Dispose();
            mangerForm.ShowDialog();
        }
    }
}
