using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
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
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace carPro
{
    public partial class Manger : Form
    {

        readonly MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");
        MySqlCommand MyCommand2;
        DataTable dataTable;
        bool flagImg;
        int index;
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
        private void searchItems()
        {
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = $"parCode = '{parCode.Text}'"; ;
            items.Refresh();
        }
        private void add_item_Click(object sender, EventArgs e)
        {
            searchItems();
            if (items.RowCount == 1)
                MessageBox.Show("מוצר קיים");
            else
            {
                bool priceFlag = false;
                string nameIt = nameItem.Text;
                string carType = typeCar.Text;
                string carM = carModel.Text;
                float pric;
                string parC = parCode.Text;
                string placeInSh = placeInShop.Text;
                int amou;
                MemoryStream ms = new();
                //all the if gona be here !!!
                if (float.TryParse(price.Text, out pric))
                {
                    if (pric <= 0 || price.Text == "")
                    {
                        priceFlag = true;
                    }
                    else
                    {
                        pric = float.Parse(price.Text);
                        priceFlag = false;
                    }
                }
                else
                {
                    priceFlag = true;
                }

                if (nameIt == "")
                {
                    MessageBox.Show("שם מוצר ריק");
                }
                else if (carType == "")
                {
                    MessageBox.Show("סוג רכב ריק");
                }
                else if (carM == "")
                {
                    MessageBox.Show("דגם רכב ריק");
                }
                else if (priceFlag)
                {
                    MessageBox.Show("מחיר ריק/שלילי");
                }
                else if (parC == "")
                {
                    MessageBox.Show("פ'ר קוד ריק");
                }
                else if (placeInSh == "")
                {
                    MessageBox.Show("מקום של מוצר ריק");
                }
                else if (Amount.Text == "")
                {
                    MessageBox.Show("כמות ריק");
                }
                else if (int.TryParse(Amount.Text,out amou)&& amou <= 0)
                {
                    MessageBox.Show("כמות שלילית");
                }
                else if(picPath.Image==null)
                {
                    MessageBox.Show("תמונה ריקה");
                }
                //all the if's end's here
                else
                {
                    try
                    {
                        picPath.Image.Save(ms, picPath.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        string strFun = "INSERT INTO items(nameItem,typeCar,modelC,parCode,placeInShop,amount,price,image)VALUES (@nameIt,@typeC,@modelC,@parCod,@placeSho,@amount,@price, @imageLocation)";
                        MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");
                        MySqlCommand MyCommand2 = new(strFun, con);
                        con.Open();
                        MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                        MyCommand2.Parameters.AddWithValue("@typeC", carType);
                        MyCommand2.Parameters.AddWithValue("@modelC", carM);
                        MyCommand2.Parameters.AddWithValue("@parCod", parC);
                        MyCommand2.Parameters.AddWithValue("@placeSho", placeInSh);
                        MyCommand2.Parameters.AddWithValue("@amount", amou);
                        MyCommand2.Parameters.AddWithValue("@price", pric);
                        MyCommand2.Parameters.AddWithValue("@imageLocation", img);
                        MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.
                        MessageBox.Show("הוספת מוצר הצליחה");
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
            }
        }

        private void picPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "Image File(*.jpg; *.jpeg;*.gif;*.bmp;*.png;)|*.jpg; *.jpeg;*.gif;*.bmp;*.png;"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picPath.Image = Image.FromFile(ofd.FileName);
                flagImg = true;
            }
        }

        private void searchItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < searchItem.Items.Count; i++)
            {
                if (searchItem.SelectedIndex != i)
                    searchItem.SetItemChecked(i, false);

            }
        }

        private void search_box_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (searchItem.Text != "")
            {
                if (searchItem.Text == "פ\"ר קוד")
                    dataView.RowFilter = $"parCode LIKE '%{search_box.Text}%'";
                else if (searchItem.Text == "סוג רכב")
                    dataView.RowFilter = $"typeCar LIKE '%{search_box.Text}%'";
                else
                    dataView.RowFilter = $"nameItem LIKE '%{search_box.Text}%'";
            }
            items.Refresh();
        }

        private void items_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = items.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = items.Rows[rowIndex].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    pictureBox1.Image = Image.FromStream(ms);

                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            flagImg = false;
            nameItem.Text = items.Rows[e.RowIndex].Cells[0].Value.ToString();
            typeCar.Text = items.Rows[e.RowIndex].Cells[1].Value.ToString();
            carModel.Text = items.Rows[e.RowIndex].Cells[2].Value.ToString();
            parCode.Text = items.Rows[e.RowIndex].Cells[3].Value.ToString();
            parCode.ReadOnly = true;
            placeInShop.Text = items.Rows[e.RowIndex].Cells[4].Value.ToString();
            Amount.Text = items.Rows[e.RowIndex].Cells[5].Value.ToString();
            price.Text = items.Rows[e.RowIndex].Cells[6].Value.ToString();
            DataGridViewCell selectedCell = items.Rows[e.RowIndex].Cells[7];
            if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
            {
                byte[] imageData = (byte[])selectedCell.Value;
                using MemoryStream ms = new(imageData);
                picPath.Image = Image.FromStream(ms);
            }
            add_item.Visible = false;
            updateItems.Visible = true;
            index=e.RowIndex;
        }
        private void clearItmesDetla()
        {

            nameItem.Text = "";
            typeCar.Text = "";
            carModel.Text = "";
            price.Text = "";
            parCode.Text = "";
            placeInShop.Text = "";
            Amount.Text = "";
            picPath.Image = null;
            add_item.Visible = true;
            updateItems.Visible = false;
        }

        private void updateItems_Click(object sender, EventArgs e)
        {
            bool priceFlag ;
            string nameIt = nameItem.Text;
            string carType = typeCar.Text;
            string carM = carModel.Text;
            float pric;
            string parC = parCode.Text;
            string placeInSh = placeInShop.Text;
            int amou;
            MemoryStream ms;
            byte[] img=null;
            if (flagImg)
            {
                ms = new();
                picPath.Image.Save(ms, picPath.Image.RawFormat);
                img = ms.ToArray();
            }
            else
            {
                DataGridViewCell selectedCell = items.Rows[index].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    ms = new(imageData);
                    picPath.Image = Image.FromStream(ms);
                }
            }
            //all the if gona be here !!!
            if (float.TryParse(price.Text, out pric))
            {
                if (pric <= 0 || price.Text == "")
                {
                    priceFlag = true;
                }
                else
                {
                    pric = float.Parse(price.Text);
                    priceFlag = false;
                }
            }
            else
            {
                priceFlag = true;
            }

            if (nameIt == "")
            {
                MessageBox.Show("שם מוצר ריק");
            }
            else if (carType == "")
            {
                MessageBox.Show("סוג רכב ריק");
            }
            else if (carM == "")
            {
                MessageBox.Show("דגם רכב ריק");
            }
            else if (priceFlag)
            {
                MessageBox.Show("מחיר ריק/שלילי");
            }
            else if (parC == "")
            {
                MessageBox.Show("פ'ר קוד ריק");
            }
            else if (placeInSh == "")
            {
                MessageBox.Show("מקום של מוצר ריק");
            }
            else if (Amount.Text == "")
            {
                MessageBox.Show("כמות ריק");
            }
            else if (int.TryParse(Amount.Text, out amou) && amou <= 0)
            {
                MessageBox.Show("כמות שלילית");
            }
            else if (picPath.Image == null)
            {
                MessageBox.Show("תמונה ריקה");
            }
            else
            {
                try
                {
                    string strFun;
                    if (flagImg)
                           strFun = "UPDATE `items` SET `nameItem`=@nameIt,`typeCar`= @typeC,`modelC`= @model,`placeInShop`= @placeInS,`amount`= @amounts,`price`= @prices,`image`= @images WHERE `parCode`= @parC ";
                    else 
                        strFun = "UPDATE `items` SET `nameItem`=@nameIt,`typeCar`= @typeC,`modelC`= @model,`placeInShop`= @placeInS,`amount`= @amounts,`price`= @prices WHERE `parCode`= @parC ";
                    con.Open();
                    MyCommand2 = new MySqlCommand(strFun, con);
                    MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                    MyCommand2.Parameters.AddWithValue("@typeC", carType);
                    MyCommand2.Parameters.AddWithValue("@model", carM);
                    MyCommand2.Parameters.AddWithValue("@placeInS", placeInSh);
                    MyCommand2.Parameters.AddWithValue("@amounts", amou);
                    MyCommand2.Parameters.AddWithValue("@prices", pric);
                    if(flagImg)
                    MyCommand2.Parameters.AddWithValue("@images",img);
                    MyCommand2.Parameters.AddWithValue("@parC", parC);
                    MyCommand2.ExecuteNonQuery();
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("hello");
                    con.Close();
                }
                TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
                clearItmesDetla();
            }
        }
    }
}
