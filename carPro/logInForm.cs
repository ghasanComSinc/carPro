using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace carPro
{
    public partial class logInForm : System.Windows.Forms.Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=pro1;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public logInForm()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT * FROM testfirst WHERE user_name = '" + userName.Text + "' AND password = '" + password.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    connection.Close();
                    connection.Open();
                    string status = "SELECT *  FROM  test2 WHERE user_name = '" + userName.Text + "' AND password = '" + password.Text + "';";
                    command = new MySqlCommand(status, connection);
                    MySqlDataReader mdr1 = command.ExecuteReader();
                    if (mdr1.Read())
                    {
                        string statusAc = new string(mdr1[2].ToString());
                        string name = new string(mdr1[3].ToString());
                        if (statusAc.Equals("manger"))
                        {
                            manger mangerform = new manger();
                            this.Hide();
                            mangerform.ShowDialog();
                        }
                        else
                        {
                            Employee emp = new Employee();
                            this.Hide();
                            emp.ShowDialog();
                        }
                    }
                    connection.Close();

                }
                else
                {

                    MessageBox.Show("Incorrect Login Information! Try again.");
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("no service connection");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            customerSignIn customerForm = new customerSignIn();
            this.Hide();
            customerForm.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }

        private void logInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}