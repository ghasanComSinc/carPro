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

namespace carPro
{
    public partial class Employee : Form
    {
        public string employName;
        readonly MySqlConnection connection = new("server=localhost;user=root;database=pro1;password=");
        MySqlCommand command;
        DataTable dataTable;
        public Employee()
        {
            InitializeComponent();
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            employeName.Text = "ברוך הבאה עובד יקר ,\r\n" + employName;
            tabControl1.TabPages.Remove(tabPage2);
            try
            {

                string strFun;

                strFun = "SELECT * FROM `paytable` WHERE `status`=\"process\"";
                connection.Open();
                command = new MySqlCommand(strFun, connection);

                MySqlDataAdapter adapter = new(command);
                dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                orders.DataSource = dataTable;
                orders.Columns[0].HeaderText = "שם של לקוח";
                orders.Columns[1].HeaderText = "מספר זיהוי";
                orders.Columns[2].HeaderText = "לתשלום";
                orders.Columns[3].Visible = false;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Employee_FormClosed(null, null);
            }
        }



        private void SearchOr_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (search.Text != "")
            {
                if (search.Text == "שם לקוח")
                    dataView.RowFilter = $"name LIKE '%{searchOr.Text}%'";
                else
                    dataView.RowFilter = $"id LIKE '%{searchOr.Text}%'";
            }
            orders.Refresh();
        }
        private void ToPay()
        {
            //7 10
            int sum = 0;
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (int.Parse(itemsInOrder.Rows[i].Cells[7].Value.ToString()) == 0)
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else if (int.Parse(itemsInOrder.Rows[i].Cells[7].Value.ToString()) >= int.Parse(itemsInOrder.Rows[i].Cells[10].Value.ToString()))
                {
                    sum += int.Parse(itemsInOrder.Rows[i].Cells[8].Value.ToString()) * int.Parse(itemsInOrder.Rows[i].Cells[10].Value.ToString());
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
                    strFun = "SELECT * FROM `sale` WHERE `id`=" + orders.Rows[e.RowIndex].Cells[1].Value.ToString();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void Label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            panel1.Visible = true;
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
                DataGridViewCell selectedCell = itemsInOrder.Rows[rowIndex].Cells[9];
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

        private void search_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < search.Items.Count; i++)
            {
                if (search.SelectedIndex != i)
                    search.SetItemChecked(i, false);

            }
        }

        private void orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Orders_CellContentClick(sender, e);
        }
    }
}

