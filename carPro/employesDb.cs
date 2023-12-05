using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace carPro
{
    internal class EmployesDb
    {
        readonly MySqlConnection connection;
        MySqlCommand MyCommand2;
        
        public EmployesDb() 
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        /// <summary>
        /// Updates the amount of items in the 'items' table based on the provided DataGridView and index.
        /// </summary>
        /// <param name="itemsInOrder">The DataGridView containing the items details.</param>
        /// <param name="i">The index of the item in the DataGridView.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool UpdateItmes(DataGridView itemsInOrder, int i)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "UPDATE `items` SET  `amount`=@amountIt WHERE `parCode`=@id";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    float amount = float.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) - float.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@amountIt", amount.ToString());
                    MyCommand2.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[1].Value.ToString());
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
        /// Updates the status of an order in the 'orders' table based on the provided DataGridView, index, and status.
        /// </summary>
        /// <param name="itemsInOrder">The DataGridView containing the order details.</param>
        /// <param name="i">The index of the order in the DataGridView.</param>
        /// <param name="status">The new status for the order.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool UpdateOrder(DataGridView itemsInOrder, int i,string status)
        {
            lock(connection)
            {
                try
                {
                    string strFun = "UPDATE `orders` SET `stauts`=@statusIt WHERE `phoneNumber`=@idCustm AND `orderId`=@id AND `parCode`=@par";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    MyCommand2.Parameters.AddWithValue("@statusIt", status);
                    MyCommand2.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[0].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[2].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@par", itemsInOrder.Rows[i].Cells[10].Value.ToString());
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        /// <summary>
        /// Updates the 'status' column in the 'paytable' table based on the provided query and DataGridView.
        /// </summary>
        /// <param name="strFun">The SQL query to update the 'status' column in the 'paytable' table.</param>
        /// <param name="itemsInOrder">The DataGridView containing the details for updating the 'paytable' table.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool UpdatePayTable(string strFun, DataGridView itemsInOrder)
        {
            lock (connection)
            {
                try
                {
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    MyCommand2.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[0].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@orderId", itemsInOrder.Rows[0].Cells[2].Value.ToString());
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("הזמנה בוצעתה בהצלחה");
                    return true;
                }
                catch {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        /// <summary>
        /// Updates the 'amount' column in the 'orders' table based on the provided DataGridView and index.
        /// </summary>
        /// <param name="itemsInOrder">The DataGridView containing the details for updating the 'orders' table.</param>
        /// <param name="i">The index of the item in the DataGridView.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool UpdateItemsAmountInOr(DataGridView itemsInOrder,int i)
        {
            lock (connection) 
            {
                try
                {
                    string strFun = "UPDATE `orders` SET `amount`=@amountS WHERE `phoneNumber`=@id AND `parCode`=@par AND `orderId`=@idOr";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MyCommand2.Parameters.AddWithValue("@amountS", itemsInOrder.Rows[i].Cells[14].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[0].Value);
                    MyCommand2.Parameters.AddWithValue("@par", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                    MyCommand2.Parameters.AddWithValue("@idOr", itemsInOrder.Rows[i].Cells[2].Value.ToString());
                    MyCommand2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("עדכון מוצר התבציע בהצלחה");
                    return true;
                }
                catch {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }
            }
        }
        /// <summary>
        /// Updates the 'price' column in the 'paytable' table based on the provided DataGridView and pay value.
        /// </summary>
        /// <param name="itemsInOrder">The DataGridView containing the details for updating the 'paytable' table.</param>
        /// <param name="pay">The total payment value.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        public bool UpdatePaytablePrice(DataGridView itemsInOrder,string pay)
        {
            try
            {
                string strFun1 = "UPDATE `paytable` SET `price`=@price WHERE `phoneNumber`=@id AND `orderId`=@orderId";
                connection.Open();
                MyCommand2 = new MySqlCommand(strFun1, connection);
                MyCommand2.Parameters.AddWithValue("@price", Regex.Match(pay, @"\d+").Value);
                MyCommand2.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[0].Value);
                MyCommand2.Parameters.AddWithValue("@orderId", itemsInOrder.Rows[0].Cells[2].Value.ToString());
                MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                connection.Close();
                return true;
            }
            catch {
                MessageBox.Show("נסה שוב בעיה בתקשורת");
                connection.Close();
                return false;
            }
        }
    }
}
