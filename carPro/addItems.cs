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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File(*.jpg; *.jpeg;*.gif;*.bmp;*.png;)|*.jpg; *.jpeg;*.gif;*.bmp;*.png;";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = ofd.FileName;
            }
        }
    }
}
