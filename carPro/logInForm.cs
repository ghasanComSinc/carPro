using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Cryptography;
using System.Text;
using ZstdSharp.Unsafe;

namespace carPro
{
    public partial class LogInForm : System.Windows.Forms.Form
    {

        readonly LogInFormDb logInDb;
        /// <summary>
        /// this function build class logInForm "constructor"
        /// </summary>
        public LogInForm()
        {
            InitializeComponent();
            logInDb = new LogInFormDb();
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        /// <summary>
        /// Handles the click event for the SignIn button.
        /// This method checks user credentials, opens the appropriate form based on the user role, and then displays the current form again.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SignIn_Click(object sender, EventArgs e)
        {
            string pass = EncPass.EncryptString(password.Text);
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
        /// <summary>
        /// Checks if the input in the phoneCustomer text box is a valid phone number. 
        /// A valid phone number is a 10-digit number consisting of only digits.
        /// </summary>
        /// <returns>True if the input is a valid phone number, false otherwise.</returns>
        private bool CheckNumberPhone()
        {
            if (phoneCustomer.Text.Length != 10)
                return false;
            return phoneCustomer.Text.All(char.IsDigit);
        }
        /// <summary>
        /// Handles the click event for the SignInCu button.
        /// This method registers a new user if all the required fields are filled in and the phone number is valid.
        /// </summary>
        ///<param name = "sender" > The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void SignInCu_Click(object sender, EventArgs e)
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
            else if (mail.Text == "")
            {
                MessageBox.Show("צריך להוסיף מייל");
            }
            else
            {
                if (CheckNumberPhone())
                {
                    string pass = EncPass.EncryptString(passSin.Text);
                    if (logInDb.SignUp(phoneCustomer.Text, pass, nameCustomer.Text, mail.Text) == false)
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
        /// <summary>
        /// Handles the click event for the PictureBox1 control. 
        /// This method toggles the masking of the password characters in the password TextBox.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
                password.PasswordChar = '\0';
            else
                password.PasswordChar = '*';
        }
        /// <summary>
        /// Hides the registration tab (tabPage2) from the tab control upon loading the login form.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void LogInForm_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
        }
        /// <summary>
        /// Handles the click event for the "Login as Worker" button.
        /// Removes the registration tab (tabPage2) and adds the worker login tab (tabPage1) to the tab control.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void LogInWorker_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }
        /// <summary>
        /// Handles the click event for the "Return to Customer Login" button.
        /// Removes the worker login tab (tabPage1) and adds the registration tab (tabPage2) to the tab control.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void ReturnCustomer_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }
        /// <summary>
        /// Handles the click event for the password visibility toggle button (PictureBox2).
        /// Toggles the masking of the password characters in the password TextBox (passSin).
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (passSin.PasswordChar == '*')
            {
                passSin.PasswordChar = '\0'; // Unmask password
            }
            else
            {
                passSin.PasswordChar = '*'; // Mask password
            }
        }
        /// <summary>
        /// Handles the KeyPress event for the password TextBox (password).
        /// Triggers the "Sign In" button's click event if the Enter key is pressed.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SignIn_Click(sender, e);
            }
        }
        /// <summary>
        /// Handles the KeyPress event for the worker password TextBox (passSin).
        /// Triggers the "Sign In" button's click event for worker login if the Enter key is pressed.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void PassSin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SignInCu_Click(sender, e);
            }
        }
        /// <summary>
        /// Handles the click event for the "Forgot Password" button.
        /// Temporarily hides the current form, opens a password recovery form (rePass), and then re-displays the current form.
        /// </summary>
        ///<param name="sender"> The object that raised the event.</param>
        ///<param name="e">The event arguments.</param>
        private void RePa_Click(object sender, EventArgs e)
        {
            this.Hide();
            rePass rePass = new();
            rePass.ShowDialog();
            this.Show();
        }
    }
}