using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Collections;
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
using WhatsAppApi.Parser;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace carPro
{
    public partial class CustomerSignIn : Form
    {
        readonly MySqlConnection connection = new("server=localhost;user=root;database=carshop;password=");
        //readonly MySqlConnection connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");

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
            forSale.Columns.Add("ברקוד", "ברקוד");//2->3
            forSale.Columns.Add("כמות", "כמות");//3->7
            forSale.Columns.Add("מחיר ליחידה", "מחיר ליחידה");//4->4
            forSale.Columns.Add("סה\"כ מחיר", "סה\"כ מחיר");//5
            forSale.Columns.Add("pic", "");//6
            forSale.Columns[6].Visible = false;
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
        DataTable dataTable = new();
        private void CustomerSignIn_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            try
            {
                string strFun;
                strFun= "SELECT `name` FROM `usertable` WHERE `phoneNumber`="+ nameCustumer;
                connection.Open();
                MyCommand2 = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(MyCommand2);
                adapter = new(MyCommand2);
                DataTable dataTable1 = new();
                adapter.Fill(dataTable1);
                phoneNumber.Text += nameCustumer;
                DataRow row = dataTable1.Rows[0];
                customerName.Text += row["name"];
                connection.Close();
                strFun = "SELECT * FROM `items` ORDER BY BINARY `typeCar` ASC;";
                connection.Open();
                MyCommand2 = new MySqlCommand(strFun, connection);
                adapter = new(MyCommand2);
                //DataTable dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                // Bind the DataTable to the DataGridView
                itemToCustomer.DataSource = dataTable;
                itemToCustomer.Columns[0].HeaderText = "שם מוצר";
                itemToCustomer.Columns[1].HeaderText = "סוג רכב";
                itemToCustomer.Columns[2].Visible = false;
                itemToCustomer.Columns[3].HeaderText = "ברקוד";
                itemToCustomer.Columns[4].HeaderText = "מחיר ליחידה";
                itemToCustomer.Columns[5].Visible = false;
                itemToCustomer.Columns[6].Visible = false;
                itemToCustomer.Columns[7].HeaderText = "כמות";
                itemToCustomer.Columns[8].Visible = false;// "הערה";
                EmtpyItems();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CustomerSignIn_FormClosed(null, null);
                connection.Close();

            }
            /* the load of the data orders*/

        }
        private void HideItem()
        {
            saleItem.Visible = false;
            sale.Visible = false;
            amountSale.Visible = false;
            plus.Visible = false;
            minus.Visible = false;
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    string strFun;

                    strFun = "SELECT * FROM `payTable` WHERE `phoneNumber` = " + nameCustumer;
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);

                    MySqlDataAdapter adapter1 = new(MyCommand2);
                    DataTable dataTable = new();

                    // Fill the DataTable with the query results
                    adapter1.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "מספר הזמנה";
                    dataGridView1.Columns[2].HeaderText = "מחיר תשלום";
                    dataGridView1.Columns[3].HeaderText = "מצב הזמנה";
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
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
                    itmesDe.AutoScroll = true;
                    itemsCom.MaximumSize = new System.Drawing.Size(100, 100);
                    itemsCom.Text = itemToCustomer.Rows[rowIndex].Cells[8].Value.ToString();

                    itemsCom.Visible = true;
                }
            }
            else
            {
                picItems.Image = null;
                itemsCom.Visible = false;
            }
        }
        private void ItemToCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = itemToCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[7].Value.ToString(), out amount);
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
                HideItem();
            }
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && amount >= int.Parse(amountSale.Text))
                amountSale.Text = (int.Parse(amountSale.Text) + 1) + "";
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > 0)
                amountSale.Text = (int.Parse(amountSale.Text) - 1) + "";
        }
        private void AmountSale_TextChanged(object sender, EventArgs e)
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
        private int ChechDoplicatItems()
        {
            for (int i = 0; i < forSale.Rows.Count; i++)
            {
                if (forSale.Rows[i].Cells[2].Value.ToString() == parcod)
                {
                    return i;
                }
            }
            return -1;
        }
        private void Sale_Click(object sender, EventArgs e)
        {
            int rowOld = ChechDoplicatItems();
            if (rowOld == -1)
            {
                if (amountSale.Text != "0")
                {
                    int rowIndexNew = forSale.Rows.Add();
                    // Copy data from selected row in DataGridView1 to the new row in DataGridView2
                    for (int i = 0; i < forSale.Rows[rowIndexNew].Cells.Count; i++)
                    {
                        if (i >= 0 && i < 2 || i == 4 || i == 6)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = itemToCustomer.Rows[rowIndex].Cells[i].Value;
                        }
                        else if (i == 2)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = itemToCustomer.Rows[rowIndex].Cells[3].Value;
                        }
                        else if (i == 3)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = amountSale.Text;
                        }
                        else if (i == 5)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = int.Parse(forSale.Rows[rowIndexNew].Cells[3].Value.ToString()) * int.Parse(forSale.Rows[rowIndexNew].Cells[4].Value.ToString());
                        }
                    }
                    tabPage2.Text = "הזמנה" + "(" + forSale.Rows.Count + ")";
                    sum += int.Parse(forSale.Rows[rowIndexNew].Cells[5].Value.ToString());
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                }
            }
            else
            {
                if (amountSale.Text != "0")
                {
                    //forSale.Rows[rowOld].Cells[5].Value = int.Parse(forSale.Rows[rowOld].Cells[3].Value.ToString()) * int.Parse(forSale.Rows[rowOld].Cells[4].Value.ToString());
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out int num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out int num2);
                    sum -= num1 * num2;
                    forSale.Rows[rowOld].Cells[3].Value = amountSale.Text;
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out num2);
                    sum += num1 * num2;
                    forSale.Rows[rowOld].Cells[5].Value = num1 * num2;
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
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out int num1);
                    _ = int.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out int num2);
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
                DataGridViewCell selectedCell = forSale.Rows[rowIndex].Cells[6];
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
                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[4].Value.ToString(), out amount);
                parcod = forSale.Rows[e.RowIndex].Cells[2].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = forSale.Rows[e.RowIndex].Cells[3].Value.ToString();
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
                    string strFun = "SELECT COUNT(*) FROM `paytable`;";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    _ = int.TryParse(MyCommand2.ExecuteScalar().ToString(), out int count);
                    count += 1;
                    connection.Close();
                    strFun = "INSERT INTO paytable(`phoneNumber`, `orderId`, `price`, `status`) VALUES" +
                        "(@phoneNumber,@orderId,@price,@status)";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                    MyCommand2.Parameters.AddWithValue("@orderId", count);
                    MyCommand2.Parameters.AddWithValue("@price", sum);
                    MyCommand2.Parameters.AddWithValue("@status", "proce");
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    connection.Close();
                    for (int i = 0; i < forSale.Rows.Count; i++)
                    {
                        strFun = "INSERT `orders`(`phoneNumber`, `parCode`, `orderId`, `amount`, `stauts`, `timeOrder`, `dateOrder`) VALUES" +
                                        "(@phoneNumber,@parCode,@orderId,@amount,@stauts,@timeOrder,@dateOrder)";
                        MyCommand2 = new(strFun, connection);
                        connection.Open();
                        MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                        MyCommand2.Parameters.AddWithValue("@parCode", forSale.Rows[i].Cells[2].Value);
                        MyCommand2.Parameters.AddWithValue("@orderId", count);
                        MyCommand2.Parameters.AddWithValue("@amount", forSale.Rows[i].Cells[3].Value);
                        MyCommand2.Parameters.AddWithValue("@stauts", "pro");
                        MyCommand2.Parameters.AddWithValue("@timeOrder", DateTime.Now.TimeOfDay.ToString());
                        MyCommand2.Parameters.AddWithValue("@dateOrder", DateTime.Now.Date.ToString());
                        MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                        connection.Close();
                    }

                    MessageBox.Show("שמרת הזמנה התבצעה בהצלחה ,מספר הזמנה שלכה הוא " + count);
                    //CustomerSignIn_FormClosed(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellContentClick(sender, e);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl1.SelectedIndex = 3;
                try
                {
                    string strFun;
                    strFun = "SELECT * FROM `orders` " +
                        $"WHERE `phoneNumber`={nameCustumer} AND `orderId`={dataGridView1.Rows[e.RowIndex].Cells[1].Value}";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    DataTable dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
                    orderDe.DataSource = dataTable;
                    //the number off the custmer to be used in the logo style
                    string phoneNumber = orderDe.Columns[0].ToString();
                    orderDe.Columns[0].Visible = false; //the number of customer  
                    // we can add the name of the prodact insted of the phone number in this taple?
                    orderDe.Columns[1].HeaderText = "ברקוד";
                    orderDe.Columns[2].HeaderText = "מספר הזמנה";
                    orderDe.Columns[3].HeaderText = "כמות";
                    orderDe.Columns[4].HeaderText = "סטטוס הזמנה";
                    orderDe.Columns[5].Visible = false;//the time 
                    orderDe.Columns[6].HeaderText = " צאריך ושעת הזמנה";


                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }
    }
}
