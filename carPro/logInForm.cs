using System.Security.Cryptography;
using System.Text;

namespace carPro
{
    public partial class LogInForm : System.Windows.Forms.Form
    {

        readonly LogInFormDb logInDb;
        public LogInForm()
        {
            InitializeComponent();
            logInDb = new LogInFormDb();
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string pass = encPass.EncryptString(password.Text);
            string statusAc = logInDb.LogIn(userName.Text, pass);
            if (statusAc == null)
                return;
            if (statusAc.Equals("מנהל"))
            {
                Manger mangerform = new()
                {
                    phone_number = userName.Text
                };
                this.Hide();
                mangerform.ShowDialog();
            }
            else if (statusAc.Equals("עובד"))
            {
                Employee emp = new()
                {
                    employName = userName.Text
                };
                this.Hide();
                emp.ShowDialog();
            }
            else if (statusAc.Equals(""))
            {
                return;
            }
            else
            {
                CustomerSignIn customerS = new()
                {
                    PhoneNum = userName.Text
                };
                this.Hide();
                customerS.ShowDialog();
            }


            this.Show();
        }
        private bool CheckNumberPhone()
        {
            if (phoneCustomer.Text.Length != 10)
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
                if (CheckNumberPhone())
                {
                    string pass = encPass.EncryptString(passSin.Text);
                    if (logInDb.SignUp(phoneCustomer.Text, pass, nameCustomer.Text) == false)
                    {
                        LogInWorker_Click(sender, e);
                        return;
                    }
                    MessageBox.Show("הרשמה הצליחה");
                    CustomerSignIn customerForm = new()
                    {
                        PhoneNum = phoneCustomer.Text,

                    };
                    this.Hide();
                    customerForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("מספר טלפון מכיל רק מספרים עם אורך של 10 ");
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
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (passSin.PasswordChar == '*')
                passSin.PasswordChar = '\0';
            else
                passSin.PasswordChar = '*';
        }
        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Button1_Click(sender, e);
        }
        private void PassSin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Button2_Click(sender, e);
        }
    }
}