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
    public partial class updateUser : Form
    {
        public updateUser()
        {
            InitializeComponent();
        }
        public string phoneNumber;
        private MangerDb mangerD = new();
        private string stat;
        private void updateU_Click(object sender, EventArgs e)
        {
           if(mangerD.UpdateUser(userName.Text.ToString(), encPass.EncryptString(pass.Text.ToString()), name.Text.ToString(),stat, phoneNumber)==true)
            phoneNumber= userName.Text;
            
        }

        private void updateUser_Load(object sender, EventArgs e)
        {
            
            DataTable row = mangerD.ReturnAllTable("SELECT * FROM `usertable` WHERE `phoneNumber`=" + phoneNumber);
            if (row == null)
            {
                this.Close();
                return;
            }
            name.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][2].ToString();
            userName.Text = row.Rows[0].Table.Rows[0].Table.Rows[0][0].ToString();        
            pass.Text = encPass.DecryptString(row.Rows[0].Table.Rows[0].Table.Rows[0][1].ToString());
            stat = row.Rows[0].Table.Rows[0].Table.Rows[0][3].ToString();
        }
    }
}
