﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace carPro
{
    public partial class addItems : Form
    {
        public addItems()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File(*.jpg; *.jpeg;*.gif;*.bmp;*.png;)|*.jpg; *.jpeg;*.gif;*.bmp;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image.Text = ofd.FileName;
            }
        }

        private void addItemBu_Click_1(object sender, EventArgs e)
        {
            string nameIt = nameItem.Text;
            string typeC = typeCar.Text;
            string parCod = parCode.Text;
            string placeSho = placeInShop.Text;
            string amount = Amount.Text;
            string imageLocation = image.Text;
            if (nameIt == "")
            {
                MessageBox.Show("שם מוצר ריק");
            }
            else if (typeC == "")
            {
                MessageBox.Show("סוג רכב ריק");
            }
            else if (parCod == "")
            {
                MessageBox.Show("פ'ר קוד ריק");
            }
            else if (placeSho == "")
            {
                MessageBox.Show("מקום של מוצר ריק");
            }
            else if (amount == "")
            {
                MessageBox.Show("כמות ריק");
            }
            else if (imageLocation == "")
            {
                MessageBox.Show("תמונה ריק");
            }
            else
            {
                try
                {
                    string strFun = "INSERT INTO items(nameItem,typeCar,parCode,placeInShop,amount,image)VALUES (@nameIt,@typeC,@parCod,@placeSho,@amount , @imageLocation)";
                    MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=pro1;password=");
                    MySqlCommand MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();

                    MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                    MyCommand2.Parameters.AddWithValue("@typeC", typeC);
                    MyCommand2.Parameters.AddWithValue("@parCod", parCod);
                    MyCommand2.Parameters.AddWithValue("@placeSho", placeSho);
                    MyCommand2.Parameters.AddWithValue("@amount", amount);
                    MyCommand2.Parameters.AddWithValue("@imageLocation", imageLocation);
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("הוספת מוצר הצליחה");

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            manger mange = new manger();
            this.Dispose();
            mange.ShowDialog();
        }
    }
}

