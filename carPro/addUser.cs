using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class AddUser : Form
    {
        readonly MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manger mange = new()
            {
                Size = this.Size,
                Location = this.Location
            };
            this.Dispose();
            mange.ShowDialog();
        }

        
    }
}
