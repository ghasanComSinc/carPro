using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace carPro
{
    public partial class CustomerSignIn : Form
    {
        readonly MySqlConnection connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        MySqlCommand MyCommand2;
        int sum = 0;
        public string nameCustumer;
        int amount = 0;
        string parcod;
        int rowIndex;
        public CustomerSignIn()
        {
            InitializeComponent();
            forSale.Columns.Add("שם מוצר", "שם מוצר");//0
            forSale.Columns.Add("סוג רכב", "סוג רכב");//1
            forSale.Columns.Add("פר", "פר");//2
            forSale.Columns.Add("כמות", "כמות");//3
            forSale.Columns.Add("מחיר ליחידה", "מחיר ליחידה");//4
            forSale.Columns.Add("סה\"כ מחיר", "סה\"כ מחיר");//5

        }
        private void CustomerSignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
        }
        private void EmtpyItems()
        {
            for (int i = 0; i < itemToCustomer.Rows.Count; i++)
            {
                if (itemToCustomer.Rows[i].Cells[5].Value.ToString() == "0")
                {
                    itemToCustomer.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void CustomerSignIn_Load(object sender, EventArgs e)
        {
            label3.Text += nameCustumer;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            try
            {
                string strFun;

                strFun = "SELECT * FROM `items` ORDER BY BINARY `typeCar` ASC;";
                connection.Open();
                MyCommand2 = new MySqlCommand(strFun, connection);

                MySqlDataAdapter adapter = new(MyCommand2);
                DataTable dataTable = new();

                // Fill the DataTable with the query results
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                itemToCustomer.DataSource = dataTable;

                itemToCustomer.Columns[0].HeaderText = "שם מוצר";
                itemToCustomer.Columns[1].HeaderText = "סוג רכב";
                itemToCustomer.Columns[2].HeaderText = "פר";
                itemToCustomer.Columns[3].HeaderText = "כמות";
                itemToCustomer.Columns[4].HeaderText = "מחיר ליחידה";
                itemToCustomer.Columns[5].Visible = false;
                itemToCustomer.Columns[6].Visible = false;
                itemToCustomer.Columns[7].Visible = false;
                itemToCustomer.Columns[8].Visible = false;
                EmtpyItems();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CustomerSignIn_FormClosed(null, null);

            }
        }
        private void HideItem()
        {
            saleItem.Visible = false;
            sale.Visible = false;
            amountSale.Visible = false;
            plus.Visible = false;
            minus.Visible = false;
        }
        private void ItemToCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = itemToCustomer.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = itemToCustomer.Rows[rowIndex].Cells[6];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    picItems.Image = Image.FromStream(ms);

                }
            }
            else
            {
                picItems.Image = null;
            }
        }
        private void ItemToCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = itemToCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[3].Value.ToString(), out amount);
                parcod = itemToCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = "0";
            }
            else
            {
                HideItem();
            }
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && amount >= int.Parse(amountSale.Text) + 1)
                amountSale.Text = (int.Parse(amountSale.Text) + 1) + "";
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > 0)
                amountSale.Text = (int.Parse(amountSale.Text) - 1) + "";
        }
        private void AmountSale_TextChanged(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) >= amount)
            {
                MessageBox.Show("אין במלי הכמות הדרושה");
                amountSale.Text = "0";
            }
            else if (!Regex.IsMatch(amountSale.Text, @"^\d+$"))
            {
                amountSale.Text = "0";
            }
        }
        // it coulde be done will !!
        private int ChechDoplicatItems()
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
        private void Sale_Click(object sender, EventArgs e)
        {

            // Create a new row in DataGridView2
            int rowOld = ChechDoplicatItems();
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
                    tabPage2.Text = "הזמנה" + "(" + forSale.Rows.Count + ")";
                    _ = int.TryParse(forSale.Rows[rowIndexNew].Cells[6].Value.ToString(), out int num1);
                    _ = int.TryParse(forSale.Rows[rowIndexNew].Cells[8].Value.ToString(), out int num2);
                    sum += num1 * num2;
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                }
            }
            else
            {
                if (amountSale.Text != "0")
                {
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[6].Value.ToString(), out int num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[8].Value.ToString(), out int num2);
                    sum -= num1 * num2;
                    forSale.Rows[rowOld].Cells[8].Value = amountSale.Text;
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[6].Value.ToString(), out num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[8].Value.ToString(), out num2);
                    sum += num1 * num2;
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                }
                else if (amountSale.Text == "0" && tabControl1.SelectedIndex == 1)
                {
                    if ((forSale.Rows.Count - 1) == 0)
                        tabPage2.Text = "הזמנה";
                    else
                        tabPage2.Text = "הזמנה" + "(" + (forSale.Rows.Count - 1) + ")";
                    HideItem();
                    saleItmesIm.Image = null;
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[6].Value.ToString(), out int num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[8].Value.ToString(), out int num2);
                    sum -= num1 * num2;
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                    forSale.Rows.RemoveAt(rowOld);
                }
            }

        }
        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            HideItem();
        }
        private void ForSale_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = forSale.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = forSale.Rows[rowIndex].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    saleItmesIm.Image = Image.FromStream(ms);

                }
            }
            else
            {
                saleItmesIm.Image = null;
            }
        }
        private void ForSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = forSale.Rows[e.RowIndex].Cells[0].Value.ToString();

                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[5].Value.ToString(), out amount);

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
                HideItem();
            }
        }
        private void SaveSale_Click(object sender, EventArgs e)
        {
            if (forSale.Rows.Count > 0)
            {
                try
                {
                    string strFun = "SELECT COUNT(*) FROM paytable";
                    MySqlConnection con = new("server=localhost;user=root;database=pro1;password=");
                    MySqlCommand MyCommand2 = new(strFun, connection);
                    connection.Open();
                    _ = int.TryParse(MyCommand2.ExecuteScalar().ToString(), out int count);
                    connection.Close();
                    strFun = "INSERT INTO paytable(name, id, priceToPay,status) VALUES (@name,@idSale,@price,@status)";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@name", nameCustumer);
                    MyCommand2.Parameters.AddWithValue("@idSale", count);
                    MyCommand2.Parameters.AddWithValue("@price", sum);
                    MyCommand2.Parameters.AddWithValue("@status", "process");
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    connection.Close();
                    for (int i = 0; i < forSale.Rows.Count; i++)
                    {

                        strFun = "INSERT INTO sale(name, id, nameItem, typeCar, modelC,parCode,placeInShop, amount,price, image,amountSale,status)" +
                                                 " VALUES (@nameSa,@idSale,@nameIt,@typeC,@modelCar,@parC,@placeInSh,@amountItem,@priceItem,@imageItem,@amountSale,@statusOrder)";
                        MyCommand2 = new(strFun, connection);
                        connection.Open();
                        MyCommand2.Parameters.AddWithValue("@nameSa", nameCustumer);
                        MyCommand2.Parameters.AddWithValue("@idSale", count);
                        MyCommand2.Parameters.AddWithValue("@nameIt", forSale.Rows[i].Cells[0].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@typeC", forSale.Rows[i].Cells[1].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@modelCar", forSale.Rows[i].Cells[2].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@parC", forSale.Rows[i].Cells[3].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@placeInSh", forSale.Rows[i].Cells[4].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@amountItem", forSale.Rows[i].Cells[5].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@priceItem", forSale.Rows[i].Cells[6].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@imageItem", forSale.Rows[i].Cells[7].Value);
                        MyCommand2.Parameters.AddWithValue("@amountSale", forSale.Rows[i].Cells[8].Value.ToString());
                        MyCommand2.Parameters.AddWithValue("@statusOrder", "process");
                        MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                        connection.Close();
                    }

                    MessageBox.Show("שמרת הזמנה התבצעה בהצלחה ,מספר זיהוי שלכה הוא " + count);
                    CustomerSignIn_FormClosed(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("הזמנה ריקה");
            }
        }
        private void ItemToCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemToCustomer_CellContentClick(sender, e);
        }
        private void ForSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ForSale_CellContentClick(sender, e);
        }
    }
}
