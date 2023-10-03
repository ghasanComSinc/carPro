using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static WhatsAppApi.Parser.FMessage;
using WhatsAppApi.Parser;

namespace carPro
{
    public partial class Employee : Form
    {
        public string employName;//phone
        public bool man = false;
        //readonly MySqlConnection connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        readonly MySqlConnection connection = new("server=localhost;user=root;database=carshop;password=");
        MySqlCommand command;
        DataTable dataTable;
        public Employee()
        {
            InitializeComponent();
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            employeName.Text = "ברוך הבאה עובד יקר ";
            tabControl1.TabPages.Remove(tabPage2);
            try
            {

                string strFun;
                strFun = "SELECT * FROM `paytable` WHERE `status`=\"pro\"";
                connection.Open();
                command = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(command);
                dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                orders.DataSource = dataTable;
                orders.Columns[0].HeaderText = "מספר טלפון";
                orders.Columns[1].HeaderText = "מזה הזמנה";
                orders.Columns[2].HeaderText = "לתשלום";
                orders.Columns[3].Visible = false;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Employee_FormClosed(null, null);
                connection.Close();
            }
        }
        private void SearchOr_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (search.Text != "" && searchOr.Text != "")
            {
                if (search.Text == "מספר טלפון")
                    dataView.RowFilter = $"Convert(phoneNumber, 'System.String') LIKE '%{searchOr.Text}%'";
                else
                {
                    dataView.RowFilter = $"Convert(orderId, 'System.String') LIKE '%{searchOr.Text}%'";
                }
            }
            orders.Refresh();
        }
        private void ToPay()
        {
            //7 10
            int sum = 0;
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (int.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) == 0)
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else if (int.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) >= int.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString()))
                {
                    sum += int.Parse(itemsInOrder.Rows[i].Cells[12].Value.ToString()) * int.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString());
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    button2.Visible = true;
                }

            }
            pay.Text = "לתשלום :\r\n" + sum;
        }
        private void Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl1.TabPages.Remove(allOrder);
                tabControl1.TabPages.Add(tabPage2);
                label2.Visible = true;
                panel1.Visible = false;
                try
                {
                    string strFun;
                    strFun = "SELECT * FROM `orders` join `items` ON `orders`.`parCode` = `items`.`parCode`" +
                        $"WHERE `phoneNumber`={orders.Rows[e.RowIndex].Cells[0].Value} AND `orderId`='{orders.Rows[e.RowIndex].Cells[1].Value}'";
                    connection.Open();
                    command = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(command);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    connection.Close();
                    itemsInOrder.DataSource = dataTable;
                    itemsInOrder.Columns[0].Visible = false;// "מספר טלפון";
                    itemsInOrder.Columns[1].HeaderText = "פר";
                    itemsInOrder.Columns[2].Visible = false;// "מזה הזמנה";
                    itemsInOrder.Columns[3].HeaderText = "כמות רצויה";
                    itemsInOrder.Columns[4].Visible = false;//status
                    itemsInOrder.Columns[5].HeaderText = "שעת קניה";
                    itemsInOrder.Columns[6].HeaderText = "תאריך קניה";
                    itemsInOrder.Columns[7].HeaderText = "שם מוצר";
                    itemsInOrder.Columns[8].HeaderText = "סוג רכב";
                    itemsInOrder.Columns[9].HeaderText = "מיקום בחנות";
                    itemsInOrder.Columns[10].Visible = false;//parcode
                    itemsInOrder.Columns[11].HeaderText = "מחיר";
                    itemsInOrder.Columns[12].Visible = false;//paypri
                    itemsInOrder.Columns[13].Visible = false;//pic
                    itemsInOrder.Columns[14].Visible = false;// "קמות בחנות";
                    itemsInOrder.Columns[15].HeaderText = "הערה על מוצר";
                    ToPay();
                    phoneNum.Visible = true;
                    orderI.Visible = true;
                    phoneNum.Text = "מספר טלפון של לקוח " + " " + itemsInOrder.Rows[0].Cells[0].Value.ToString();
                    orderI.Text = "מזה הזמנה" + " " + itemsInOrder.Rows[0].Cells[2].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            panel1.Visible = true;
            phoneNum.Visible = false;
            orderI.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(allOrder);
            Employee_Load(sender, e);
        }
        private void ItemsInOrder_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = itemsInOrder.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = itemsInOrder.Rows[rowIndex].Cells[13];
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
        private void UpdateItems()
        {
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {

                if (int.Parse(itemsInOrder.Rows[i].Cells[7].Value.ToString()) >= int.Parse(itemsInOrder.Rows[i].Cells[10].Value.ToString()))
                {
                    try
                    {
                        string strFun = "UPDATE `items` SET   `amount`=@amountIt WHERE `parCode`=@id";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        MySqlDataAdapter adapter = new(command);
                        int amount = int.Parse(itemsInOrder.Rows[i].Cells[7].Value.ToString()) - int.Parse(itemsInOrder.Rows[i].Cells[10].Value.ToString());
                        command.Parameters.AddWithValue("@amountIt", amount.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[5].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                        strFun = "UPDATE `sale` SET `amount`= @amountIt, `status`=@statusIt WHERE id=@idCustm AND parCode=@id";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        adapter = new(command);
                        command.Parameters.AddWithValue("@amountIt", amount.ToString());
                        command.Parameters.AddWithValue("@statusIt", "successful");
                        command.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[5].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                        strFun = "UPDATE `sale` SET `amount`= @amountIt WHERE id!=@idCustm AND parCode=@id";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        adapter = new(command);
                        command.Parameters.AddWithValue("@amountIt", amount.ToString());
                        command.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[5].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    try
                    {
                        String strFun = "UPDATE `sale` SET  `status`=@statusIt WHERE id=@idCustm AND parCode=@id";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        MySqlDataAdapter adapter = new(command);
                        command.Parameters.AddWithValue("@statusIt", "cancel");
                        command.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[5].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void PayBu_Click(object sender, EventArgs e)
        {
            try
            {
                string strFun = "UPDATE `paytable` SET `status`= 'successful' WHERE `id`=@id";
                connection.Open();
                command = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(command);
                command.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[1].Value.ToString());
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("הזמנה בוצעתה בהצלחה");
                Employee_Load(sender, e);
                Label2_Click(sender, e);
                UpdateItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (itemsInOrder.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {
                    string strFun = "UPDATE `sale` SET `amountSale`=@amountS WHERE `id`=@id";
                    connection.Open();
                    command = new MySqlCommand(strFun, connection);
                    command.Parameters.AddWithValue("@amountS", itemsInOrder.Rows[i].Cells[7].Value.ToString());
                    command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("עדכון מוצר התבציע בהצלחה");
                    ///////////////////////////////////////////////////////////////////
                    ///string strFun;
                    strFun = "SELECT * FROM `sale` WHERE `id`=" + itemsInOrder.Rows[i].Cells[1].Value.ToString();
                    connection.Open();
                    command = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(command);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    itemsInOrder.DataSource = dataTable;
                    itemsInOrder.Columns[9].Visible = false;
                    itemsInOrder.Columns[11].Visible = false;
                    itemsInOrder.Columns[0].HeaderText = "שם לקוח";
                    itemsInOrder.Columns[1].HeaderText = "מספר זיהוי";
                    itemsInOrder.Columns[2].HeaderText = "שם מוצר";
                    itemsInOrder.Columns[3].HeaderText = "סוג רכב";
                    itemsInOrder.Columns[4].HeaderText = "מודל";
                    itemsInOrder.Columns[5].HeaderText = "זיהוי מוצר";
                    itemsInOrder.Columns[6].HeaderText = "מקום בחנות";
                    itemsInOrder.Columns[7].HeaderText = "קמות בחנות";
                    itemsInOrder.Columns[8].HeaderText = "מחיר";
                    itemsInOrder.Columns[9].HeaderText = "תמונה";
                    itemsInOrder.Columns[10].HeaderText = "קמות רצויה";
                    itemsInOrder.Columns[11].HeaderText = "מצב של הזמנה";
                    connection.Close();
                    ToPay();
                    /// //////////////////////////////////////////////////////////////
                }
            }
            string strFun1 = "UPDATE `paytable` SET `priceToPay`=@price WHERE `id`=@id";

            connection.Open();
            command = new MySqlCommand(strFun1, connection);
            //MySqlDataAdapter adapter1 = new(command);
            ///Regex.Match(subjectString, @"\d+").Value;
            command.Parameters.AddWithValue("@price", Regex.Match(pay.Text.ToString(), @"\d+").Value);
            command.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[1].Value.ToString());

            command.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
            connection.Close();


        }
        private void Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < search.Items.Count; i++)
            {
                if (search.SelectedIndex != i)
                    search.SetItemChecked(i, false);

            }
        }
        private void Orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Orders_CellContentClick(sender, e);
        }
        private void SinC_Click(object sender, EventArgs e)
        {
            CustomerSignIn cust = new()
            {
                nameCustumer = employName
            };
            this.Hide();

            cust.ShowDialog();

            this.Show();
        }
    }
}

