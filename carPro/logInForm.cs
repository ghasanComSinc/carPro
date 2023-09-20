using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

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
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        private void button1_Click(object sender, EventArgs e)
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
                            
                            mangerform.Size = this.Size;
                            mangerform.Location=this.Location;
                            this.Hide();
                            mangerform.ShowDialog();
                        }
                        else
                        {
                            Employee emp = new Employee();
                            
                            emp.Size = this.Size;
                            emp.Location = this.Location;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (nameCustumer.Text != "")
            {
                customerSignIn customerForm = new customerSignIn();
                customerForm.nameCustumer = nameCustumer.Text;
                customerForm.Size = this.Size;
                customerForm.Location = this.Location;
                this.Hide();
                customerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("צריך להוסף שם בכדי לכנס למערכת");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }

        private void logInForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void logInForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
        }

        private void logInWorker_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void returnCustomer_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }
    }
}