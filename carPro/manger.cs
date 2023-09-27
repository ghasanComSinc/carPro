using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace carPro
{
    public partial class Manger : Form
    {

        readonly MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");
        MySqlCommand MyCommand2;
        DataTable dataTable;
        public Manger()
        {
            InitializeComponent();
        }
        private void Manger_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
        }
        private void CheckUser()
        {
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = $"user_name = '{userName.Text}'"; ;
            users.Refresh();
        }
        private void AddU_Click(object sender, EventArgs e)
        {
            CheckUser();
            if (users.Rows.Count == 1)
            {
                MessageBox.Show("משתמש קיים");
            }
            else
            {
                string uName = name.Text;
                string userNa = userName.Text;
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
                else
                {
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
                        con.Close();
                    }
                    TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
                }
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab.SelectedIndex == 0)
            {
                try
                {
                    string strFun;
                    strFun = "SELECT * FROM `items`";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    items.DataSource = dataTable;

                    items.Columns[0].HeaderText = "שם מוצר";
                    items.Columns[1].HeaderText = "סוג רכב";
                    items.Columns[2].HeaderText = "תת- רכב";
                    items.Columns[3].HeaderText = "פר";
                    items.Columns[4].HeaderText = "מקום בחנות";
                    items.Columns[5].HeaderText = "כמות";
                    items.Columns[6].HeaderText = "מחיר";
                    items.Columns[7].HeaderText = "תמונה";
                    items.Columns[7].Visible = false;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            else if (tab.SelectedIndex == 1)
            {
                try
                {
                    string strFun;

                    strFun = "SELECT * FROM `test2`";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();

                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    users.DataSource = dataTable;

                    users.Columns[0].HeaderText = "שם משתמש";
                    users.Columns[1].HeaderText = "סיסמה";
                    users.Columns[2].HeaderText = "תפקיד";
                    users.Columns[3].HeaderText = "שם";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }
        private void Manger_Load(object sender, EventArgs e)
        {
            TabControl1_SelectedIndexChanged(sender, e);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        private void Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateU.Visible = true;
            deletU.Visible = true;
            addU.Visible = false;
            name.Text = users.Rows[e.RowIndex].Cells[3].Value.ToString();
            pass.Text = users.Rows[e.RowIndex].Cells[1].Value.ToString();
            userName.Text = users.Rows[e.RowIndex].Cells[0].Value.ToString();
            userName.ReadOnly = true;
            status.Text = users.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (status.Text == "manger")
                status.SetItemChecked(0, true);
            else
                status.SetItemChecked(1, true);

        }
        private void Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Users_CellContentClick(sender, e);
        }
        private void UpdateU_Click(object sender, EventArgs e)
        {
            try
            {
                string uName = name.Text;
                string userNa = userName.Text;
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
                else
                {
                    string strFun = "UPDATE `test2` SET `user_name`=@userN,`password`=@pass,`status`=@status,`name`=@nameU WHERE user_name=@userN";
                    con.Open();
                    MyCommand2 = new MySqlCommand(strFun, con);
                    MyCommand2.Parameters.AddWithValue("@userN", userName.Text);
                    MyCommand2.Parameters.AddWithValue("@pass", pass.Text);
                    MyCommand2.Parameters.AddWithValue("@status", status.Text);
                    MyCommand2.Parameters.AddWithValue("@nameU", name.Text);
                    MyCommand2.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            TabControl1_SelectedIndexChanged(sender, e);
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            updateU.Visible = false;
            deletU.Visible = false;
            addU.Visible = true;
            name.Text = "";
            pass.Text = "";
            userName.Text = "";
            userName.ReadOnly = false;
            TabControl1_SelectedIndexChanged(sender, e);
        }
        private void DeletU_Click(object sender, EventArgs e)
        {
            try
            {
                string userNa = userName.Text;
                string stat = status.Text;

                string strFun;
                if (stat == "manger")
                {
                    strFun = "SELECT COUNT(*) FROM `test2` WHERE `status`=@manger";
                    con.Open();
                    MyCommand2 = new MySqlCommand(strFun, con);
                    MyCommand2.Parameters.AddWithValue("@manger", stat);
                    int count = Convert.ToInt32(MyCommand2.ExecuteScalar());
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("קיים רק מנהיל יחד אי אפשר למחוק"); return;
                    }
                }
                strFun = "DELETE FROM `test2` WHERE user_name=@userN";
                con.Open();
                MyCommand2 = new MySqlCommand(strFun, con);
                MyCommand2.Parameters.AddWithValue("@userN", userNa);
                MyCommand2.ExecuteNonQuery();
                con.Close();
                TabControl1_SelectedIndexChanged(sender, e);
                Button1_Click_1(sender, e);
            }
            catch
            { }
        }
        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < status.Items.Count; i++)
            {
                if (status.SelectedIndex != i)
                    status.SetItemChecked(i, false);

            }
        }


    }
}
