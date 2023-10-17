using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carPro
{
    internal class customerClassDb
    {
        readonly MySqlConnection connection;
        MySqlCommand MyCommand2;
        DataTable dataTable;
        public customerClassDb()
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        public string nameCust(string PhoneCustumer)
        {
            lock (connection)
            {
                DataRow row = null;
                try
                {
                    string strFun;
                    strFun = "SELECT `name` FROM `usertable` WHERE `phoneNumber`=" + PhoneCustumer;
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    adapter = new(MyCommand2);
                    DataTable dataTable1 = new();
                    adapter.Fill(dataTable1);
                    row = dataTable1.Rows[0];
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return ""; ;
                }
                return row["name"].ToString();
            }
        }
        public int returnCountCus()
        {
            lock (connection)
            {
                try
                {
                    string strFun = "SELECT COUNT(*) FROM `paytable`;";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    _ = int.TryParse(MyCommand2.ExecuteScalar().ToString(), out int count);
                    connection.Close();
                    return count + 1;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return -1;
                }
            }
        }
        public bool insertSaleCus(string nameCustumer, int count, float sum)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "INSERT INTO paytable(`phoneNumber`, `orderId`, `price`, `status`) VALUES" +
                           "(@phoneNumber,@orderId,@price,@status)";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                    MyCommand2.Parameters.AddWithValue("@orderId", count);
                    MyCommand2.Parameters.AddWithValue("@price", sum);
                    MyCommand2.Parameters.AddWithValue("@status", "בטיפול");
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    connection.Close();
                    return true;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        public bool insertItemInSale(string nameCustumer, DataGridView data, int i, int count)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "INSERT `orders`(`phoneNumber`, `parCode`, `orderId`, `amount`, `stauts`, `timeOrder`, `dateOrder`) VALUES" +
                                           "(@phoneNumber,@parCode,@orderId,@amount,@stauts,@timeOrder,@dateOrder)";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                    MyCommand2.Parameters.AddWithValue("@parCode", data.Rows[i].Cells[2].Value);
                    MyCommand2.Parameters.AddWithValue("@orderId", count);
                    MyCommand2.Parameters.AddWithValue("@amount", data.Rows[i].Cells[3].Value);
                    MyCommand2.Parameters.AddWithValue("@stauts", "בטיפול");
                    MyCommand2.Parameters.AddWithValue("@timeOrder", DateTime.Now.ToLongTimeString());
                    MyCommand2.Parameters.AddWithValue("@dateOrder", DateTime.Now.ToShortDateString());
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    connection.Close();
                    return true;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        public DataTable returnSale(string nameCustumer, string orderId)
        {
            lock (connection)
            {
                try
                {

                    string strFun = "SELECT * FROM `orders` " +
                        $"WHERE `phoneNumber`={nameCustumer} AND `orderId`={orderId}";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    DataTable dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    connection.Close();
                    return dataTable;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }
        }
        public DataTable returnItem()
        {
            lock (connection)
            {
                try
                {
                    string strFun = "SELECT * FROM `items` WHERE `available`=\"פעיל\"   ORDER BY BINARY `typeCar` ASC";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    DataTable dataTable1 = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable1);
                    connection.Close();
                    return dataTable1;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }
        }
        public DataTable returnAllSaleForCus(string nameCustumer) {
            lock (connection)
            {
                try
                {
                    string   strFun = "SELECT * FROM `payTable` WHERE `phoneNumber` = " + nameCustumer;
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter1 = new(MyCommand2);
                    DataTable dataTable = new();
                    // Fill the DataTable with the query results
                    adapter1.Fill(dataTable);
                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }
        }
    }
}