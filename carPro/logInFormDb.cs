using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace carPro
{
    internal class LogInFormDb 
    {
        readonly MySqlConnection connection ;
        MySqlCommand command;
        public LogInFormDb() 
        {
            connection = new("server=localhost;user=root;database=carshop;password=");
            // connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        }
        public string LogIn(string userName, string pass)
        {
            lock (connection)
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM userTable WHERE phoneNumber = '" + userName + "' AND password = '" + pass + "' AND available = '" + "פעיל" + "';";
                    command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader ms = command.ExecuteReader();
                    if (ms.Read() == false)
                    {
                        MessageBox.Show("משתמש לא קיים");
                        return"";
                    }
                    string status = ms[3].ToString();
                    connection.Close();
                    return status;
                }
                catch
                {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return null;
                }
            }


        }
        public bool SignUp(string phone, string pass, string name,string mail)
        {
            lock (connection)
            {
                try
                {
                    string strFun;
                    strFun = "INSERT INTO `UserTable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`,`mail`)" +
                                             "VALUES (@phoneN,@pass,@nameCust,@staut,@startD,@lastD,@avi,@mail)";
                    command = new MySqlCommand(strFun, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@phoneN", phone);
                    command.Parameters.AddWithValue("@pass",pass);
                    command.Parameters.AddWithValue("@nameCust", name);
                    command.Parameters.AddWithValue("@staut", "לקוח");
                    command.Parameters.AddWithValue("@startD", DateTime.Now);
                    command.Parameters.AddWithValue("@lastD", "");
                    command.Parameters.AddWithValue("@avi", "פעיל");
                    command.Parameters.AddWithValue("@mail", mail);
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
        public bool SendCode(string phone ,string mail)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "SELECT COUNT(*) FROM `usertable` WHERE `phoneNumber`=@phone AND `mail`=@mail";
                    connection.Open();
                    command = new MySqlCommand(strFun, connection);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@mail",mail);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return count!=0;
                }
                catch {
                    MessageBox.Show("נסה שוב בעיה בתקשורת");
                    connection.Close();
                    return false;
                }

            }
        }
        public bool UpdatePass(string phone, string pass)
        {
            lock (connection)
            {
                try
                {
                    string strFun = "UPDATE usertable SET phoneNumber = @phone ,password=@pass WHERE phoneNumber = @phone; ";
                    connection.Open();
                    command = new MySqlCommand(strFun, connection);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@pass", encPass.EncryptString(pass));
                    command.ExecuteNonQuery();
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
