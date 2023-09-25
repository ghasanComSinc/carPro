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
        readonly MySqlConnection connection = new("server=localhost;user=root;database=pro1;password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public logInForm()
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
                string selectQuery = "SELECT * FROM test2 WHERE user_name = '" + userName.Text + "' AND password = '" + password.Text + "';";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();

                if (mdr.Read())
                {
                        string statusAc = new(mdr[2].ToString());
                        string name = new(mdr[3].ToString());
                    if (statusAc.Equals("manger"))
                    {
                        manger mangerform = new()
                        {
                            Size = this.Size,
                            Location = this.Location
                        };
                        this.Hide();
                        mangerform.ShowDialog();
                    }
                    else
                    {
                        Employee emp = new()
                        {
                            employName = name
                        };
                        
                        this.Hide();
                        emp.ShowDialog();


                    }
                    connection.Close();

                }
                else
                {

                    MessageBox.Show("Incorrect Login Information! Try again.");
                    connection.Close();
                }


            }
            catch
            {
                MessageBox.Show("no service connection");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (nameCustumer.Text != "")
            {
                customerSignIn customerForm = new()
                {
                    nameCustumer = nameCustumer.Text,
                    
                };
                this.Hide();
                customerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("צריך להוסף שם בכדי לכנס למערכת");
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
            tabControl1.TabPages.Remove(tabPage1);
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
    }
}