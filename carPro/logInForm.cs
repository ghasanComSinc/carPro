using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Data;
using System.Windows.Forms;
using WhatsAppApi;
using WhatsAppApi.Parser;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;

namespace carPro
{
    public partial class LogInForm : System.Windows.Forms.Form
    {
        readonly MySqlConnection connection = new("server=localhost;user=root;database=sql12650296;password=");
        //readonly MySqlConnection connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");
        MySqlCommand command;
        MySqlDataReader mdr;
        public LogInForm()
        {
            InitializeComponent();
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT * FROM UserTable WHERE phoneNumber = '" + userName.Text + "' AND password = '" + password.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                    string statusAc = new(mdr[3].ToString());
                    string name = new(mdr[2].ToString());
                    if (statusAc.Equals("m"))
                    {
                        Manger mangerform = new();

                        this.Hide();
                        mangerform.ShowDialog();
                    }
                    else if (statusAc.Equals("e"))
                    {
                        Employee emp = new()
                        {
                            employName = name
                        };
                        this.Hide();
                        emp.ShowDialog();
                    }
                    else
                    {
                        CustomerSignIn customerS = new();
                        this.Hide();
                        customerS.ShowDialog();
                    }
                }
                else
                {

                    MessageBox.Show("משתמש לא קיים");   
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("אין רשת");
                connection.Close();
            }
        }
        private bool checkNumberPhone()
        {
            if (phoneCustomer.Text.Length != 8)
                return false;
            return phoneCustomer.Text.All(char.IsDigit);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (phoneCustomer.Text == "")
            {
                MessageBox.Show("צריך להוסיף מספר טלפון");
            }
            else if (nameCustomer.Text == "")
            {
                MessageBox.Show("צריך להוסיף שם");
            }
            else if (passSin.Text == "")
            {
                MessageBox.Show("צריך להוסיף סיסמה");
            }
            else
            {
                if (checkNumberPhone())
                {
                    try
                    {
                        string strFun;

                        strFun = "INSERT INTO `UserTable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`)" +
                                                 "VALUES (@phoneN,@pass,@nameCust,@staut,@startD,@lastD,@avi)";
                        command = new MySqlCommand(strFun, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("@phoneN", int.Parse(phoneCustomer.Text));
                        command.Parameters.AddWithValue("@pass", passSin.Text);
                        command.Parameters.AddWithValue("@nameCust", nameCustomer.Text);
                        command.Parameters.AddWithValue("@staut", "c");
                        command.Parameters.AddWithValue("@startD", DateTime.Now);
                        command.Parameters.AddWithValue("@lastD", "");
                        command.Parameters.AddWithValue("@avi", "available");
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("הרשמה הצליחה");
                        CustomerSignIn customerForm = new()
                        {
                            nameCustumer = phoneCustomer.Text,

                        };
                        this.Hide();
                        customerForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("משתמש קיים");
                        connection.Close();
                    }

                }
                else
                {
                    MessageBox.Show("מספר טלפון מכיל רק מספרים עם אורך של 9 ");
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }

        private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);

        }

        private void LogInWorker_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void ReturnCustomer_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (passSin.PasswordChar == '*')
                passSin.PasswordChar = '\0';
            else
                passSin.PasswordChar = '*';
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Button1_Click(sender, e);
        }
    }
}