using MailKit.Net.Smtp;
using MimeKit;

namespace carPro
{
    public partial class rePass : Form
    {
        int myRandomNo;
        /// <summary>
        /// Initializes the 'rePass' form, configuring the appearance of the tab control.
        /// </summary>
        public rePass()
        {
            InitializeComponent();
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        /// <summary>
        /// Handles the 'Load' event of the 'rePass' form, preparing the form by removing all tabs except 'sendRandCode'.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void RePass_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount;)
                tabControl1.TabPages.RemoveAt(i);
            tabControl1.TabPages.Add(sendRandCode);
        }
        /// <summary>
        /// Handles the 'Click' event of the 'SendCode' button, sending a verification code to the specified user's email.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SendCode_Click(object sender, EventArgs e)
        {
            string number = userName.Text;
            string mail = email.Text;
            LogInFormDb sendCo = new();
            if (sendCo.SendCode(number, mail) == true)
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("porectAutoPart@hotmail.com", "porectAutoPart@hotmail.com"));
                email.To.Add(new MailboxAddress(mail, mail));
                email.Subject = "Testing out email sending";
                Random rnd = new();
                myRandomNo = rnd.Next(10000000, 99999999);
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = "הקוד לשחזור סיסמה הוא :" + myRandomNo
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp-mail.outlook.com", 587, false);
                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate("porectAutoPart@hotmail.com", "autoPart123*");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                MessageBox.Show("בדוק את המייל");
                checkCode.Visible = true;
                randPass.Visible = true;
                label4.Visible = true;
            }
            else
                MessageBox.Show("משתמש לא קיים");
        }
        /// <summary>
        /// Handles the 'Click' event of the 'CheckCode' button, 
        /// verifying the entered code and updating the form accordingly.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckCode_Click(object sender, EventArgs e)
        {
            if (myRandomNo.ToString() == randPass.Text.ToString())
            {
                tabControl1.TabPages.Remove(sendRandCode);
                tabControl1.TabPages.Add(updatePass);
            }
            else
                MessageBox.Show("קוד שגוי");
        }
        /// <summary>
        /// Handles the 'Click' event of the 'ChangePass' button, updating the user's password if the new passwords match.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ChangePass_Click(object sender, EventArgs e)
        {
            string phoneNum = userName.Text;
            string pass = newPass.Text;
            if (pass == reNewPass.Text)
            {
                LogInFormDb changepass = new();
                changepass.UpdatePass(phoneNum, pass);
            }
            else
                MessageBox.Show("קוד שגוי");

        }
    }
}
