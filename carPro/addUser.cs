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
    public partial class addUser : Form
    {
        MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");
        MySqlCommand MyCommand2;
        public addUser()
        {
            InitializeComponent();
        }

        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            manger mange = new()
            {
                Size = this.Size,
                Location = this.Location
            };
            this.Dispose();
            mange.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string uName = name.Text;
            string userNa=userName.Text;
            string password = pass.Text;
            string stat = status.Text;
            if (uName == "")
            {
                MessageBox.Show("שם עובד ריק");
            }
            else if (userNa == "")
            {
                MessageBox.Show("שם משתמש ריק");
            }
            else if (password == "")
            {
                MessageBox.Show("סיסמה ריק");
            }
            else if (stat == "")
            {
                MessageBox.Show("תפקיד ריק");
            }
            else { 
                try
                {
                    string strFun;
                
                    strFun = "INSERT INTO test2(user_name,password,status,name) VALUES (@userNa,@password,@status,@name)";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MyCommand2.Parameters.AddWithValue("@userNa", userNa);
                    MyCommand2.Parameters.AddWithValue("@password", password);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.ExecuteNonQuery();     
                    con.Close();
                    MessageBox.Show("הוספת משמשם הצליחה");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
