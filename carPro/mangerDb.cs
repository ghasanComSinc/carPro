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
    }
}
