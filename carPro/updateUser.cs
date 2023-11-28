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
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }
        public string phoneNumber;
        private readonly MangerDb mangerD = new();
        private string stat;
        private void UpdateU_Click(object sender, EventArgs e)
        {
            CustomerClassDb db = new();
            if (db.UpdateUser(userName.Text.ToString(), EncPass.EncryptString(pass.Text), name.Text.ToString(), stat, phoneNumber, mail.Text) == true)
                phoneNumber = userName.Text;
        }
        private void UpdateUser_Load(object sender, EventArgs e)
        {

            DataTable row = mangerD.ReturnAllTable("SELECT * FROM `usertable` WHERE `phoneNumber`=" + phoneNumber);
            if (row == null)
            {
                this.Close();
                return;
            }
            name.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][2].ToString();
            userName.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][0].ToString();
            pass.Text = EncPass.DecryptString(row.Rows[0].Table.Rows[0].Table.Rows[0][1].ToString());
            stat = row.Rows[0].Table.Rows[0].Table.Rows[0][3].ToString();
            mail.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][7].ToString();
        }
    }
}
