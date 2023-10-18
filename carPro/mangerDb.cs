using iText.Layout.Borders;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace carPro
{
    internal class MangerDb
    {
         MySqlConnection connection;
        MySqlCommand MyCommand2;
        DataTable dataTable;
        public MangerDb() 
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        public bool InsertUser(string phone,string password,string uName,string stat)
        {
            lock(connection)
            {
                try
                {
                    string strFun;

                    strFun = "INSERT INTO `usertable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`) VALUES " +
                                                    "(@phone,@password,@name,@status,@start_date,@last_date,@available)";
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phone", phone);
                    MyCommand2.Parameters.AddWithValue("@password", password);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@start_date", DateTime.Now);
                    MyCommand2.Parameters.AddWithValue("@last_date", "");
                    MyCommand2.Parameters.AddWithValue("@available", "פעיל");
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("הוספת משתמשם הצליחה");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return false;
                }
            }
        }
        public DataTable ReturnAllTable(string strFun)
        {
            lock (connection)
            {
                try
                {
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }
        public bool UpdateUser(string userNa, string password, string uName, string stat, string oldId)
        {
            lock(connection)
            {
                try
                {
                    string strFun ="UPDATE usertable SET phoneNumber = @phone, password = @pass, name = @name, status = @status WHERE phoneNumber = @old; " +
                                 "UPDATE orders SET phoneNumber=@phone WHERE phoneNumber=@old;" +
                                 "UPDATE paytable SET phoneNumber=@phone WHERE phoneNumber=@old;";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MyCommand2.Parameters.AddWithValue("@phone", userNa);
                    MyCommand2.Parameters.AddWithValue("@pass", password);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@old", oldId);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return false;
                }
            }
        }
        public int mangerCount(string stat)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "SELECT COUNT(*) FROM `usertable` WHERE `status`=@manger AND `available`=@act";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MyCommand2.Parameters.AddWithValue("@manger", stat);
                    MyCommand2.Parameters.AddWithValue("@act", "פעיל");
                    int count = Convert.ToInt32(MyCommand2.ExecuteScalar());
                    connection.Close();
                    return count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return -1;
                }
            }

        }
        public bool deletUser(string stat,string userNa)
        {
            lock(connection)
            {
                try
                {
                    string strFun = "UPDATE `usertable` SET `last_date`= @last,`available`= @av WHERE `phoneNumber`= @phone";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    if (stat == "פעיל")
                    {
                        MyCommand2.Parameters.AddWithValue("@last", DateTime.Now);
                        MyCommand2.Parameters.AddWithValue("@av", "לא פעיל");
                    }
                    else
                    {
                        MyCommand2.Parameters.AddWithValue("@last", "");
                        MyCommand2.Parameters.AddWithValue("@av", "פעיל");
                    }
                    MyCommand2.Parameters.AddWithValue("@phone", userNa);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return false;
                }

            }
        }
        public bool insertItem(string nameIt,string carType,string placeInSh,string parC, float salePrice,float payPrice, byte[] img,int amou ,string comn)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "INSERT INTO `items`(`nameItmes`, `typeCar`, `placeInShop`, `parCode`, `salePrice`, `payPrice`, `image`, `amount`, `comment`,`available`) VALUES " +
                                           "(@nameIt,@typeC,@placeSho,@parCod,@salePri,@payPrice,@image,@amount,@com,@avai)";
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                    MyCommand2.Parameters.AddWithValue("@typeC", carType);
                    MyCommand2.Parameters.AddWithValue("@placeSho", placeInSh);
                    MyCommand2.Parameters.AddWithValue("@parCod", parC);
                    MyCommand2.Parameters.AddWithValue("@salePri", salePrice);
                    MyCommand2.Parameters.AddWithValue("@payPrice", payPrice);
                    MyCommand2.Parameters.AddWithValue("@image", img);
                    MyCommand2.Parameters.AddWithValue("@amount", amou);
                    MyCommand2.Parameters.AddWithValue("@com", comn);
                    MyCommand2.Parameters.AddWithValue("@avai", "פעיל");
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.
                    MessageBox.Show("הוספת מוצר הצליחה");
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return false;
                }
            }
        }
        public bool updateItem(bool flagImg,string nameIt, string carType, string placeInSh, string parC, float salePrice, float payPrice, byte[] img, int amou, string comn,string oldPar)
        {
            lock (connection)
            {
                try
                {
                    string strFun;
                    if (flagImg)
                        strFun = "UPDATE `items`,`orders` SET `orders`.`parCode`=@parCod,`nameItmes`=@nameIt,`typeCar`= @typeC,`placeInShop`= @placeSho,`items`.`parCode`= @parCod,`salePrice`=@salePri,`payPrice`=@payPrice,`image`= @images,`items`.`amount`= @amounts,`comment`= @com WHERE `orders`.`parCode`= @oldPa AND `items`.`parCode`= @oldPa";
                    else
                        strFun = "UPDATE `items`,`orders` SET `orders`.`parCode`=@parCod,`nameItmes`=@nameIt,`typeCar`= @typeC,`placeInShop`= @placeSho,`items`.`parCode`= @parCod,`salePrice`=@salePri,`payPrice`=@payPrice,`items`.`amount`= @amounts,`comment`= @com WHERE `orders`.`parCode`= @oldPa AND  `items`.`parCode`= @oldPa";
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                    MyCommand2.Parameters.AddWithValue("@typeC", carType);
                    MyCommand2.Parameters.AddWithValue("@placeSho", placeInSh);
                    MyCommand2.Parameters.AddWithValue("@parCod", parC);
                    MyCommand2.Parameters.AddWithValue("@salePri", salePrice);
                    MyCommand2.Parameters.AddWithValue("@payPrice", payPrice);
                    if (flagImg)
                        MyCommand2.Parameters.AddWithValue("@images", img);
                    MyCommand2.Parameters.AddWithValue("@amounts", amou);
                    MyCommand2.Parameters.AddWithValue("@com", comn);
                    MyCommand2.Parameters.AddWithValue("@oldPa", oldPar);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch
                {
                    MessageBox.Show("מוצר קיים");
                    connection.Close();
                    return false;
                }
            }
        }
        public DataTable returnSaleWithSta(string strFun)
        {
            lock (connection)
            {
                try
                {
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }
        public DataTable returnItemSale(string phoneNum, string orderId)
        {
            lock (connection) {
                string strFun = "SELECT * FROM `orders` join `items` ON `orders`.`parCode` = `items`.`parCode`" +
                            $"WHERE `phoneNumber`={phoneNum} AND `orderId`='{orderId}'";
                try
                {
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                    return null;
                }
            } 
        }
        public bool delItems(string stat,string par)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "UPDATE  `items` SET `available`= @av WHERE `parCode`= @parCod";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    if (stat == "פעיל")
                    {
                        MyCommand2.Parameters.AddWithValue("@av", "לא פעיל");
                    }
                    else
                    {
                        MyCommand2.Parameters.AddWithValue("@av", "פעיל");
                    }
                    MyCommand2.Parameters.AddWithValue("@parCod", par);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}