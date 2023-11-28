using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System.Data;

namespace carPro
{
    internal class CustomerClassDb 
    {
        readonly MySqlConnection connection;
        MySqlCommand MyCommand2;
        public CustomerClassDb()
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        public string NameCust(string PhoneCustumer)
        {
            lock (connection)
            {
                DataRow? row = null;
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
                    return ""; 
                }
                return row["name"].ToString();
            }
        }
        public int ReturnCountCus()
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
        public bool InsertSaleCus(string nameCustumer, int count, float sum)
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
        public bool InsertItemInSale(string nameCustumer, DataGridView data, int i, int count)
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
        public DataTable ReturnSale(string strFun)
        {
            lock (connection)
            {
                try
                {
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
        public DataTable ReturnItem()
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
        public DataTable ReturnAllSaleForCus(string strFun)
        {
            lock (connection)
            {
                try
                {
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter1 = new(MyCommand2);
                    DataTable dataTable = new();
                    // Fill the DataTable with the query results
                    adapter1.Fill(dataTable);
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
        public bool UpdateUser(string userNa, string pass, string name, string stat, string phoneNumber, string mail)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "UPDATE usertable SET phoneNumber = @phone, name = @name, status = @status,mail=@mail,`password`=@pass WHERE phoneNumber = @old; " +
                                 "UPDATE orders SET phoneNumber=@phone WHERE phoneNumber=@old;" +
                                 "UPDATE paytable SET phoneNumber=@phone WHERE phoneNumber=@old;";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MyCommand2.Parameters.AddWithValue("@phone", userNa);
                    MyCommand2.Parameters.AddWithValue("@name", name);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@mail", mail);
                    MyCommand2.Parameters.AddWithValue("@pass", pass);
                    MyCommand2.Parameters.AddWithValue("@old", phoneNumber);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("עדכון משתמש הצליח");
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
    }
}