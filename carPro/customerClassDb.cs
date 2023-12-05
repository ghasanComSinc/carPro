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
        /// <summary>
        /// Retrieves the name of a customer based on their phone number from the 'usertable' in the database.
        /// </summary>
        /// <param name="PhoneCustumer">The phone number of the customer to look up.</param>
        /// <returns>
        /// The name of the customer if found in the database; otherwise, an empty string is returned.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and an empty string is returned.
        /// </returns>
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
        /// <summary>
        /// Retrieves the count of records in the 'paytable' and returns the count plus one.
        /// </summary>
        /// <returns>
        /// The count of records in the 'paytable' plus one.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and -1 is returned to indicate failure.
        /// </returns>
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
        /// <summary>
        /// Inserts a new sale record into the 'paytable' with the provided customer name, order ID, price, and default status.
        /// </summary>
        /// <param name="nameCustumer">The name of the customer associated with the sale.</param>
        /// <param name="count">The order ID or count associated with the sale.</param>
        /// <param name="sum">The total price of the sale.</param>
        /// <returns>
        /// True if the sale record is successfully inserted into the 'paytable'; otherwise, false.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and false is returned to indicate failure.
        /// </returns>
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
        /// <summary>
        /// Inserts an item into the 'orders' table for a specific sale identified by customer name and order ID.
        /// </summary>
        /// <param name="nameCustumer">The name of the customer associated with the sale.</param>
        /// <param name="data">DataGridView containing information about the item to be inserted.</param>
        /// <param name="i">The row index in the DataGridView representing the item to be inserted.</param>
        /// <param name="count">The order ID associated with the sale.</param>
        /// <returns>
        /// True if the item is successfully inserted into the 'orders' table; otherwise, false.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and false is returned to indicate failure.
        /// </returns>
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
        /// <summary>
        /// Executes a SQL query and returns the results as a DataTable.
        /// </summary>
        /// <param name="strFun">The SQL query to be executed.</param>
        /// <returns>
        /// A DataTable containing the results of the SQL query.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and null is returned to indicate failure.
        /// </returns>
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
        /// <summary>
        /// Updates user information across multiple tables in the database.
        /// </summary>
        /// <param name="userNa">The new phone number for the user.</param>
        /// <param name="pass">The new password for the user.</param>
        /// <param name="name">The new name for the user.</param>
        /// <param name="stat">The new status for the user.</param>
        /// <param name="phoneNumber">The current phone number of the user to be updated.</param>
        /// <param name="mail">The new email address for the user.</param>
        /// <returns>
        /// True if the user information is successfully updated across tables; otherwise, false.
        /// If any communication issues or exceptions occur during the database operation, an error message is displayed,
        /// and false is returned to indicate failure.
        /// </returns>
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