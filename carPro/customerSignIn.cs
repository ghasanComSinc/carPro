﻿using MySql.Data.MySqlClient;
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
        int amount=0;
        int rowIndex;
        int amountToSale=0;
        public customerSignIn()
        {
            InitializeComponent();
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
                strFun = "SELECT `nameItem`,`typeCar`,`modelC`,`parCode`,`amount`,`price`,`image` FROM `items` ORDER BY BINARY `typeCar` ASC;";
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
                itemToCustomer.Columns[4].HeaderText = "כמות";
                itemToCustomer.Columns[5].HeaderText = "מחיר";
                itemToCustomer.Columns[6].Visible = false;
                itemToCustomer.Columns[6].HeaderText = "תמונה";

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
                DataGridViewCell selectedCell = itemToCustomer.Rows[rowIndex].Cells[6];
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
                amount = int.Parse(itemToCustomer.Rows[e.RowIndex].Cells[4].Value.ToString());
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = "0";
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

       
    }
}
