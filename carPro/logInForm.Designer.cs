namespace carPro
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            rePa = new Label();
            signOut = new Button();
            pictureBox1 = new PictureBox();
            password = new TextBox();
            userName = new TextBox();
            signIn = new Button();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            mail = new TextBox();
            label7 = new Label();
            signInCu = new Button();
            pictureBox2 = new PictureBox();
            nameCustomer = new TextBox();
            passSin = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            phoneCustomer = new TextBox();
            label3 = new Label();
            backToLogIn = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(807, 449);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(799, 411);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(rePa);
            panel1.Controls.Add(signOut);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(password);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(signIn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(166, 113);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 198);
            panel1.TabIndex = 8;
            // 
            // rePa
            // 
            rePa.Anchor = AnchorStyles.None;
            rePa.AutoSize = true;
            rePa.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            rePa.Location = new Point(294, 98);
            rePa.Name = "rePa";
            rePa.Size = new Size(128, 25);
            rePa.TabIndex = 21;
            rePa.Text = "שכחתי סיסמה";
            rePa.Click += label7_Click;
            // 
            // signOut
            // 
            signOut.Anchor = AnchorStyles.None;
            signOut.Location = new Point(14, 126);
            signOut.Name = "signOut";
            signOut.Size = new Size(159, 40);
            signOut.TabIndex = 4;
            signOut.Text = "הרשמה ";
            signOut.UseVisualStyleBackColor = true;
            signOut.Click += ReturnCustomer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(106, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // password
            // 
            password.Anchor = AnchorStyles.None;
            password.Location = new Point(162, 59);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(150, 31);
            password.TabIndex = 2;
            password.KeyPress += Password_KeyPress;
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.None;
            userName.Location = new Point(162, 13);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 1;
            // 
            // signIn
            // 
            signIn.Anchor = AnchorStyles.None;
            signIn.Location = new Point(325, 126);
            signIn.Name = "signIn";
            signIn.Size = new Size(124, 40);
            signIn.TabIndex = 3;
            signIn.Text = "כניסה";
            signIn.UseVisualStyleBackColor = true;
            signIn.Click += Button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(382, 68);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 16;
            label2.Text = "סיסמה";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(339, 15);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 15;
            label1.Text = "שם משתמש";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(mail);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(signInCu);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(nameCustomer);
            tabPage2.Controls.Add(passSin);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(phoneCustomer);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(backToLogIn);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(799, 411);
            tabPage2.TabIndex = 1;
            tabPage2.Text = " ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.None;
            mail.Location = new Point(303, 281);
            mail.Name = "mail";
            mail.RightToLeft = RightToLeft.No;
            mail.Size = new Size(215, 31);
            mail.TabIndex = 19;
            mail.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(547, 287);
            label7.Name = "label7";
            label7.Size = new Size(44, 25);
            label7.TabIndex = 20;
            label7.Text = "מייל";
            // 
            // signInCu
            // 
            signInCu.Anchor = AnchorStyles.None;
            signInCu.Location = new Point(193, 337);
            signInCu.Name = "signInCu";
            signInCu.Size = new Size(132, 40);
            signInCu.TabIndex = 4;
            signInCu.Text = "הרשמה";
            signInCu.UseVisualStyleBackColor = true;
            signInCu.Click += Button2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(248, 221);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            pictureBox2.Click += PictureBox2_Click;
            // 
            // nameCustomer
            // 
            nameCustomer.Anchor = AnchorStyles.None;
            nameCustomer.Location = new Point(303, 156);
            nameCustomer.Name = "nameCustomer";
            nameCustomer.Size = new Size(150, 31);
            nameCustomer.TabIndex = 2;
            // 
            // passSin
            // 
            passSin.Anchor = AnchorStyles.None;
            passSin.Location = new Point(304, 221);
            passSin.Name = "passSin";
            passSin.PasswordChar = '*';
            passSin.Size = new Size(150, 31);
            passSin.TabIndex = 3;
            passSin.KeyPress += PassSin_KeyPress;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(507, 162);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 18;
            label5.Text = "שם לקוח";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(524, 221);
            label6.Name = "label6";
            label6.Size = new Size(67, 25);
            label6.TabIndex = 14;
            label6.Text = "סיסמה";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(275, 57);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(258, 25);
            label4.TabIndex = 17;
            label4.Text = " ברוכים הבאים למערכת שלנו .";
            // 
            // phoneCustomer
            // 
            phoneCustomer.Anchor = AnchorStyles.None;
            phoneCustomer.Location = new Point(303, 105);
            phoneCustomer.Name = "phoneCustomer";
            phoneCustomer.Size = new Size(150, 31);
            phoneCustomer.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(480, 107);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 15;
            label3.Text = "מספר טלפון";
            // 
            // backToLogIn
            // 
            backToLogIn.Anchor = AnchorStyles.None;
            backToLogIn.Location = new Point(442, 337);
            backToLogIn.Name = "backToLogIn";
            backToLogIn.Size = new Size(149, 40);
            backToLogIn.TabIndex = 5;
            backToLogIn.Text = "חזרה לדף קודם";
            backToLogIn.UseVisualStyleBackColor = true;
            backToLogIn.Click += LogInWorker_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.logo_autopart;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "LogInForm";
            Text = "כניסה למערכת";
            Load += LogInForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private TabPage tabPage2;
        private Button backToLogIn;
        private TextBox phoneCustomer;
        private Label label3;
        private Label label4;
        private TextBox nameCustomer;
        private Label label5;
        private PictureBox pictureBox2;
        private TextBox passSin;
        private Label label6;
        private Button signOut;
        private PictureBox pictureBox1;
        private TextBox password;
        private TextBox userName;
        private Button signIn;
        private Label label2;
        private Label label1;
        private Button signInCu;
        private Label rePa;
        private TextBox mail;
        private Label label7;
    }
}