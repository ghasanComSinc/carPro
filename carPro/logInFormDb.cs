using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace carPro
{
    internal class logInFormDb
    {
        readonly MySqlConnection connection ;
        MySqlCommand command;
        public logInFormDb() 
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        public MySqlDataReader logIn(string userName, string pass)
        {
            lock (connection)
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM userTable WHERE phoneNumber = '" + userName + "' AND password = '" + pass + "' AND available = '" + "פעיל" + "';";
                    command = new MySqlCommand(selectQuery, connection);
                    connection.Close();
                    return command.ExecuteReader();
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }


        }
        public bool signUp(string phone,string pass,string name)
        {
            lock (connection)
            {
                try
                {
                    string strFun;
                    strFun = "INSERT INTO `UserTable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`)" +
                                             "VALUES (@phoneN,@pass,@nameCust,@staut,@startD,@lastD,@avi)";
                    command = new MySqlCommand(strFun, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@phoneN", phone);
                    command.Parameters.AddWithValue("@pass",pass);
                    command.Parameters.AddWithValue("@nameCust", name);
                    command.Parameters.AddWithValue("@staut", "לקוח");
                    command.Parameters.AddWithValue("@startD", DateTime.Now);
                    command.Parameters.AddWithValue("@lastD", "");
                    command.Parameters.AddWithValue("@avi", "פעיל");
                    command.ExecuteNonQuery();
                    connection.Close();
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
    }
}
