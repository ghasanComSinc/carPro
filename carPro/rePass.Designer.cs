namespace carPro
{
    partial class rePass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rePass));
            tabControl1 = new TabControl();
            sendRandCode = new TabPage();
            panel1 = new Panel();
            checkCode = new Button();
            randPass = new TextBox();
            label4 = new Label();
            sendCode = new Button();
            email = new TextBox();
            userName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            updatePass = new TabPage();
            hideNewPass = new PictureBox();
            newPass = new TextBox();
            label3 = new Label();
            changePass = new Button();
            hideReNewPass = new PictureBox();
            reNewPass = new TextBox();
            label6 = new Label();
            tabControl1.SuspendLayout();
            sendRandCode.SuspendLayout();
            panel1.SuspendLayout();
            updatePass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hideNewPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hideReNewPass).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(sendRandCode);
            tabControl1.Controls.Add(updatePass);
            tabControl1.Location = new Point(-3, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(807, 449);
            tabControl1.TabIndex = 9;
            // 
            // sendRandCode
            // 
            sendRandCode.BackColor = Color.Transparent;
            sendRandCode.BackgroundImageLayout = ImageLayout.Stretch;
            sendRandCode.Controls.Add(panel1);
            sendRandCode.Location = new Point(4, 34);
            sendRandCode.Name = "sendRandCode";
            sendRandCode.Padding = new Padding(3);
            sendRandCode.Size = new Size(799, 411);
            sendRandCode.TabIndex = 0;
            sendRandCode.Text = "  ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(checkCode);
            panel1.Controls.Add(randPass);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(sendCode);
            panel1.Controls.Add(email);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(86, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 301);
            panel1.TabIndex = 8;
            // 
            // checkCode
            // 
            checkCode.Anchor = AnchorStyles.None;
            checkCode.Location = new Point(403, 239);
            checkCode.Name = "checkCode";
            checkCode.Size = new Size(159, 41);
            checkCode.TabIndex = 19;
            checkCode.Text = "בדיקת קוד אימות";
            checkCode.UseVisualStyleBackColor = true;
            checkCode.Visible = false;
            checkCode.Click += CheckCode_Click;
            // 
            // randPass
            // 
            randPass.Anchor = AnchorStyles.None;
            randPass.Location = new Point(295, 184);
            randPass.Name = "randPass";
            randPass.Size = new Size(150, 31);
            randPass.TabIndex = 17;
            randPass.Visible = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(481, 190);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 18;
            label4.Text = "קוד אימות";
            label4.Visible = false;
            // 
            // sendCode
            // 
            sendCode.Anchor = AnchorStyles.None;
            sendCode.Location = new Point(403, 124);
            sendCode.Name = "sendCode";
            sendCode.Size = new Size(159, 40);
            sendCode.TabIndex = 4;
            sendCode.Text = "שלחת קוד אימות";
            sendCode.UseVisualStyleBackColor = true;
            sendCode.Click += SendCode_Click;
            // 
            // email
            // 
            email.Anchor = AnchorStyles.None;
            email.Location = new Point(284, 68);
            email.Name = "email";
            email.Size = new Size(150, 31);
            email.TabIndex = 2;
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.None;
            userName.Location = new Point(284, 22);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(518, 74);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 16;
            label2.Text = "מייל";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(461, 24);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 15;
            label1.Text = "שם משתמש";
            // 
            // updatePass
            // 
            updatePass.Controls.Add(hideNewPass);
            updatePass.Controls.Add(newPass);
            updatePass.Controls.Add(label3);
            updatePass.Controls.Add(changePass);
            updatePass.Controls.Add(hideReNewPass);
            updatePass.Controls.Add(reNewPass);
            updatePass.Controls.Add(label6);
            updatePass.Location = new Point(4, 34);
            updatePass.Name = "updatePass";
            updatePass.Padding = new Padding(3);
            updatePass.Size = new Size(799, 411);
            updatePass.TabIndex = 1;
            updatePass.Text = " ";
            updatePass.UseVisualStyleBackColor = true;
            // 
            // hideNewPass
            // 
            hideNewPass.Anchor = AnchorStyles.None;
            hideNewPass.Image = (Image)resources.GetObject("hideNewPass.Image");
            hideNewPass.Location = new Point(274, 139);
            hideNewPass.Name = "hideNewPass";
            hideNewPass.Size = new Size(40, 31);
            hideNewPass.SizeMode = PictureBoxSizeMode.Zoom;
            hideNewPass.TabIndex = 19;
            hideNewPass.TabStop = false;
            // 
            // newPass
            // 
            newPass.Anchor = AnchorStyles.None;
            newPass.Location = new Point(330, 139);
            newPass.Name = "newPass";
            newPass.PasswordChar = '*';
            newPass.Size = new Size(150, 31);
            newPass.TabIndex = 17;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(564, 139);
            label3.Name = "label3";
            label3.Size = new Size(121, 25);
            label3.TabIndex = 18;
            label3.Text = "סיסמה חדשה";
            // 
            // changePass
            // 
            changePass.Anchor = AnchorStyles.None;
            changePass.Location = new Point(348, 239);
            changePass.Name = "changePass";
            changePass.Size = new Size(132, 43);
            changePass.TabIndex = 4;
            changePass.Text = "עדכון סיסמה";
            changePass.UseVisualStyleBackColor = true;
            changePass.Click += ChangePass_Click;
            // 
            // hideReNewPass
            // 
            hideReNewPass.Anchor = AnchorStyles.None;
            hideReNewPass.Image = (Image)resources.GetObject("hideReNewPass.Image");
            hideReNewPass.Location = new Point(274, 187);
            hideReNewPass.Name = "hideReNewPass";
            hideReNewPass.Size = new Size(40, 31);
            hideReNewPass.SizeMode = PictureBoxSizeMode.Zoom;
            hideReNewPass.TabIndex = 16;
            hideReNewPass.TabStop = false;
            // 
            // reNewPass
            // 
            reNewPass.Anchor = AnchorStyles.None;
            reNewPass.Location = new Point(330, 187);
            reNewPass.Name = "reNewPass";
            reNewPass.PasswordChar = '*';
            reNewPass.Size = new Size(150, 31);
            reNewPass.TabIndex = 3;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(488, 187);
            label6.Name = "label6";
            label6.Size = new Size(197, 25);
            label6.TabIndex = 14;
            label6.Text = "עותק של סיסמה חדשה";
            // 
            // rePass
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "rePass";
            Text = "שכחתי סיסמה";
            Load += RePass_Load;
            tabControl1.ResumeLayout(false);
            sendRandCode.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            updatePass.ResumeLayout(false);
            updatePass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hideNewPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)hideReNewPass).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage sendRandCode;
        private Panel panel1;
        private TabPage updatePass;
        private PictureBox hideNewPass;
        private TextBox newPass;
        private Label label3;
        private Button changePass;
        private PictureBox hideReNewPass;
        private TextBox reNewPass;
        private Label label6;
        private Button checkCode;
        private TextBox randPass;
        private Label label4;
        private Button sendCode;
        private TextBox email;
        private TextBox userName;
        private Label label2;
        private Label label1;
    }
}