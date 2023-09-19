using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carPro
{
    public partial class customerSignIn : Form
    {
        int amount = 0;
        string parcod;
        int rowIndex;
        int amountToSale = 0;
        int countSale = 0;
        public customerSignIn()
        {
            InitializeComponent();
            forSale.Columns.Add("שם מוצר", "שם מוצר");
            forSale.Columns.Add("סוג רכב", "סוג רכב");
            forSale.Columns.Add("תת- רכב", "תת- רכב");
            forSale.Columns.Add("פר", "פר");
            forSale.Columns.Add("מקום בחנות", "מקום בחנות");
            forSale.Columns.Add("כמות", "כמות");
            forSale.Columns.Add("מחיר", "מחיר");
            forSale.Columns.Add("תמונה", "תמונה");     
            forSale.Columns.Add("הזמנה", "הזמנה");
           
            forSale.Columns[7].Visible = false;
            
        }

        private void customerSignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            logInForm logIn = new logInForm();
            this.Dispose();
            logIn.ShowDialog();
        }

        private void customerSignIn_Load(object sender, EventArgs e)
        {
            try
            {
                string strFun;
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=pro1;password=");
                MySqlCommand MyCommand2;
                strFun = "SELECT * FROM `items` ORDER BY BINARY `typeCar` ASC;";
                con.Open();
                MyCommand2 = new MySqlCommand(strFun, con);

                MySqlDataAdapter adapter = new MySqlDataAdapter(MyCommand2);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query results
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                itemToCustomer.DataSource = dataTable;

                itemToCustomer.Columns[0].HeaderText = "שם מוצר";
                itemToCustomer.Columns[1].HeaderText = "סוג רכב";
                itemToCustomer.Columns[2].HeaderText = "תת- רכב";
                itemToCustomer.Columns[3].HeaderText = "פר";
                itemToCustomer.Columns[4].HeaderText = "מקום בחנות";
                //itemToCustomer.Columns[4].Visible = false;
                itemToCustomer.Columns[5].HeaderText = "כמות";
                itemToCustomer.Columns[6].HeaderText = "מחיר";
                itemToCustomer.Columns[7].Visible = false;
                itemToCustomer.Columns[7].HeaderText = "תמונה";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void itemToCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = itemToCustomer.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = itemToCustomer.Rows[rowIndex].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picItems.Image = Image.FromStream(ms);
                    }

                }
            }
            else
            {
                picItems.Image = null;
            }
        }

        private void itemToCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = itemToCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                amount = int.Parse(itemToCustomer.Rows[e.RowIndex].Cells[5].Value.ToString());
                parcod = itemToCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = "0";
            }
            else
            {
                saleItem.Visible = false;
                sale.Visible = false;
                amountSale.Visible = false;
                plus.Visible = false;
                minus.Visible = false;
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && amount > int.Parse(amountSale.Text) + 1)
                amountSale.Text = (int.Parse(amountSale.Text) + 1) + "";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > 0)
                amountSale.Text = (int.Parse(amountSale.Text) - 1) + "";
        }

        private void amountSale_TextChanged(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > amount)
            {
                MessageBox.Show("אין במלי הכמות הדרושה");
                amountSale.Text = "0";
            }
            else if (!Regex.IsMatch(amountSale.Text, @"^\d+$"))
            {
                amountSale.Text = "0";
            }
        }
        private int chechDoplicatItems()
        {
            for (int i = 0; i < forSale.Rows.Count; i++)
            {
                if (forSale.Rows[i].Cells[3].Value.ToString() == parcod)
                {
                    return i;
                }
            }
            return -1;
        }
        private void sale_Click(object sender, EventArgs e)
        {

            // Create a new row in DataGridView2

            int rowOld = chechDoplicatItems();
            if (rowOld == -1)
            {
                if (amountSale.Text != "0")
                {
                    int rowIndexNew = forSale.Rows.Add();
                    // Copy data from selected row in DataGridView1 to the new row in DataGridView2
                    for (int i = 0; i < itemToCustomer.Rows[rowIndex].Cells.Count; i++)
                    {
                        forSale.Rows[rowIndexNew].Cells[i].Value = itemToCustomer.Rows[rowIndex].Cells[i].Value;
                    }
                    forSale.Rows[rowIndexNew].Cells[8].Value = amountSale.Text;
                }
            }
            else
            {
                if (amountSale.Text != "0")
                    forSale.Rows[rowOld].Cells[7].Value = amountSale.Text;
                else
                {
                    forSale.Rows.RemoveAt(rowOld);
                    hideItem();
                    saleItmesIm.Image = null;
                }
            }

        }
        private void hideItem()
        {
            saleItem.Visible = false;
            sale.Visible = false;
            amountSale.Visible = false;
            plus.Visible = false;
            minus.Visible = false;
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            hideItem();
        }

        private void forSale_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = forSale.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = forSale.Rows[rowIndex].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        saleItmesIm.Image = Image.FromStream(ms);
                    }

                }
            }
            else
            {
                saleItmesIm.Image = null;
            }
        }

        private void forSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = forSale.Rows[e.RowIndex].Cells[0].Value.ToString();
                amount = int.Parse(itemToCustomer.Rows[e.RowIndex].Cells[4].Value.ToString());
                parcod = forSale.Rows[e.RowIndex].Cells[3].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = "0";
            }
            else
            {
                saleItem.Visible = false;
                sale.Visible = false;
                amountSale.Visible = false;
                plus.Visible = false;
                minus.Visible = false;
            }
        }

        private void saveSale_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < forSale.Rows.Count; i++)
                {
                    string strFun = "INSERT INTO sale(name, idSale, nameItem, typeCar, modelC,parCode,placeInShop, amount,price, image,amountSale)" +
                                              " VALUES (@nameSa,@id,@nameIt,@typeC,@modelCar,@parC,@placeInSh,@amountItem,@priceItem,@imageItem,@amountSale)";
                    MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=pro1;password=");
                    MySqlCommand MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MyCommand2.Parameters.AddWithValue("@nameSa", "");
                    MyCommand2.Parameters.AddWithValue("@id", amountToSale.ToString());
                    MyCommand2.Parameters.AddWithValue("@nameIt", forSale.Rows[i].Cells[0].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@typeC", forSale.Rows[i].Cells[1].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@modelCar", forSale.Rows[i].Cells[2].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@parC", forSale.Rows[i].Cells[3].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@placeInSh", forSale.Rows[i].Cells[4].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@amountItem", forSale.Rows[i].Cells[5].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@priceItem", forSale.Rows[i].Cells[6].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@imageItem", forSale.Rows[i].Cells[7].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@amountSale", forSale.Rows[i].Cells[8].Value.ToString());
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    con.Close();
                }
                amountToSale++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
