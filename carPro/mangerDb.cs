using MySql.Data.MySqlClient;
using System.Data;

namespace carPro
{
    internal class MangerDb
    {
        readonly MySqlConnection connection;
        MySqlCommand MyCommand2;
        DataTable dataTable;
        public MangerDb() 
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        /// <param name="phone">Phone number of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="uName">Name of the user.</param>
        /// <param name="stat">Status of the user.</param>
        /// <param name="mail">Email of the user.</param>
        /// <returns>True if the insertion is successful, false otherwise.</returns>
        public bool InsertUser(string phone,string password,string uName,string stat,string mail)
        {
            lock(connection)
            {
                try
                {
                    string strFun;

                    strFun = "INSERT INTO `usertable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`,`mail`) VALUES " +
                                                    "(@phone,@password,@name,@status,@start_date,@last_date,@available,@mail)";
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phone", phone);
                    MyCommand2.Parameters.AddWithValue("@password", password);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@start_date", DateTime.Now);
                    MyCommand2.Parameters.AddWithValue("@last_date", "");
                    MyCommand2.Parameters.AddWithValue("@available", "פעיל");
                    MyCommand2.Parameters.AddWithValue("@mail", mail);
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("הוספת משתמשם הצליחה");
                    return true;
                }
                catch 
                {
                    MessageBox.Show("משתמש קיים");
                    connection.Close();
                    return false;
                }
            }
        }
        /// <summary>
        /// Retrieves data from the database based on the provided query and returns it as a DataTable.
        /// </summary>
        /// <param name="strFun">SQL query to retrieve data from the database.</param>
        /// <returns>The DataTable containing the query results or null if there's an error.</returns>
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// Updates user information in the database.
        /// </summary>
        /// <param name="userNa">New phone number of the user.</param>
        /// <param name="uName">New name of the user.</param>
        /// <param name="stat">New status of the user.</param>
        /// <param name="oldId">Old phone number of the user.</param>
        /// <param name="maill">New email of the user.</param>
        /// <returns>True if the update is successful, false otherwise.</returns>
        public bool UpdateUser(string userNa, string uName, string stat, string oldId,string maill)
        {
            lock(connection)
            {
                try
                {
                    string strFun ="UPDATE usertable SET phoneNumber = @phone, name = @name, status = @status,mail=@mail WHERE phoneNumber = @old; " +
                                 "UPDATE orders SET phoneNumber=@phone WHERE phoneNumber=@old;" +
                                 "UPDATE paytable SET phoneNumber=@phone WHERE phoneNumber=@old;";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MyCommand2.Parameters.AddWithValue("@phone", userNa);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@mail", maill);
                    MyCommand2.Parameters.AddWithValue("@old", oldId);
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
        /// <summary>
        /// Retrieves the count of active managers from the database.
        /// </summary>
        /// <param name="stat">Status of the managers to be counted.</param>
        /// <returns>The count of active managers or -1 if there's an error.</returns>
        public int MangerCount(string stat)
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return -1;
                }
            }

        }
        /// <summary>
        /// Deactivates or reactivates a user in the database based on the provided status and phone number.
        /// </summary>
        /// <param name="stat">Status to be set for the user (either "פעיל" or "לא פעיל").</param>
        /// <param name="userNa">Phone number of the user.</param>
        /// <returns>True if the deactivation/reactivation is successful, false otherwise.</returns>
        public bool DeletUser(string stat,string userNa)
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }

            }
        }
        /// <summary>
        /// Inserts a new item into the database.
        /// </summary>
        /// <param name="nameIt">Name of the item.</param>
        /// <param name="carType">Type of the car related to the item.</param>
        /// <param name="placeInSh">Location of the item in the shop.</param>
        /// <param name="parC">Product code of the item.</param>
        /// <param name="salePrice">Selling price of the item.</param>
        /// <param name="payPrice">Purchase price of the item.</param>
        /// <param name="img">Image of the item.</param>
        /// <param name="amou">Amount of the item.</param>
        /// <param name="comn">Comment or details about the item.</param>
        /// <returns>True if the insertion is successful, false otherwise.</returns>
        public bool InsertItem(string nameIt,string carType,string placeInSh,string parC, float salePrice,float payPrice, byte[] img,int amou ,string comn)
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        /// <summary>
        /// Updates item information in the database.
        /// </summary>
        /// <param name="flagImg">Flag indicating whether the item's image is updated.</param>
        /// <param name="nameIt">Name of the item.</param>
        /// <param name="carType">Type of the car related to the item.</param>
        /// <param name="placeInSh">Location of the item in the shop.</param>
        /// <param name="parC">Product code of the item.</param>
        /// <param name="salePrice">Selling price of the item.</param>
        /// <param name="payPrice">Purchase price of the item.</param>
        /// <param name="img">Image of the item.</param>
        /// <param name="amou">Amount of the item.</param>
        /// <param name="comn">Comment or details about the item.</param>
        /// <param name="oldPar">Old product code of the item.</param>
        /// <returns>True if the update is successful, false otherwise.</returns>
        public bool UpdateItem(bool flagImg,string nameIt, string carType, string placeInSh, string parC, float salePrice, float payPrice, byte[] img, int amou, string comn,string oldPar)
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
        /// <summary>
        /// Retrieves sales data from the database based on the provided query and returns it as a DataTable.
        /// </summary>
        /// <param name="strFun">SQL query to retrieve sales data from the database.</param>
        /// <returns>The DataTable containing the query results or null if there's an error.</returns>
        public DataTable ReturnSaleWithSta(string strFun)
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// Retrieves item sale details from the database based on the provided phone number and order ID.
        /// </summary>
        /// <param name="phoneNum">Phone number of the user.</param>
        /// <param name="orderId">Order ID of the sale.</param>
        /// <returns>The DataTable containing the item sale details or null if there's an error.</returns>
        public DataTable ReturnItemSale(string phoneNum, string orderId)
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
                catch 
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            } 
        }
        /// <summary>
        /// Deactivates or reactivates an item in the database based on the provided status and product code.
        /// </summary>
        /// <param name="stat">Status to be set for the item (either "פעיל" or "לא פעיל").</param>
        /// <param name="par">Product code of the item.</param>
        /// <returns>True if the deactivation/reactivation is successful, false otherwise.</returns>
        public bool DelItems(string stat,string par)
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
                catch 
                {
                    connection.Close();
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    return false;
                }
            }
        }
    }
}