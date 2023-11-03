using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carPro
{
    public partial class rePass : Form
    {
        int myRandomNo;
        public rePass()
        {
            InitializeComponent();
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
        }
        private void rePass_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount;)
                tabControl1.TabPages.RemoveAt(i);
            tabControl1.TabPages.Add(sendRandCode);
        }
        private void sendCode_Click(object sender, EventArgs e)
        {
            string number = userName.Text;
            string mail = email.Text;
            LogInFormDb sendCo = new();
            if (sendCo.sendCode(number, mail) == true)
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("porectAutoPart@hotmail.com", "porectAutoPart@hotmail.com"));
                email.To.Add(new MailboxAddress(mail, mail));

                email.Subject = "Testing out email sending";
                Random rnd = new Random();
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
        private void checkCode_Click(object sender, EventArgs e)
        {
            if (myRandomNo.ToString() == randPass.Text.ToString())
            {
                tabControl1.TabPages.Remove(sendRandCode);
                tabControl1.TabPages.Add(updatePass);
            }
            else
                MessageBox.Show("קוד שגוי");
        }
        private void changePass_Click(object sender, EventArgs e)
        {
            string phoneNum = userName.Text;
            string pass = newPass.Text;
            if (pass == reNewPass.Text)
            {
                LogInFormDb changepass = new();
                changepass.updatePass(phoneNum, pass);
            }
            else
                MessageBox.Show("קוד שגוי");

        }
    }
}
