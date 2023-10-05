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
            returnCustomer = new Button();
            pictureBox1 = new PictureBox();
            password = new TextBox();
            userName = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            nameCustomer = new TextBox();
            passSin = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            phoneCustomer = new TextBox();
            label3 = new Label();
            logInWorker = new Button();
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
            tabPage1.BackgroundImage = Properties.Resources.logo_autopart;
            tabPage1.BackgroundImageLayout = ImageLayout.Zoom;
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
            panel1.Controls.Add(returnCustomer);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(password);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(166, 113);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 198);
            panel1.TabIndex = 8;
            // 
            // returnCustomer
            // 
            returnCustomer.Anchor = AnchorStyles.None;
            returnCustomer.Location = new Point(14, 126);
            returnCustomer.Name = "returnCustomer";
            returnCustomer.Size = new Size(159, 40);
            returnCustomer.TabIndex = 4;
            returnCustomer.Text = "הרשמה ";
            returnCustomer.UseVisualStyleBackColor = true;
            returnCustomer.Click += ReturnCustomer_Click;
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
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(325, 126);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 3;
            button1.Text = "כניסה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(382, 68);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
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
            label1.Size = new Size(91, 20);
            label1.TabIndex = 15;
            label1.Text = "שם משתמש";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(nameCustomer);
            tabPage2.Controls.Add(passSin);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(phoneCustomer);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(logInWorker);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(799, 411);
            tabPage2.TabIndex = 1;
            tabPage2.Text = " ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(193, 289);
            button2.Name = "button2";
            button2.Size = new Size(132, 40);
            button2.TabIndex = 4;
            button2.Text = "הרשמה";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
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
            label5.Size = new Size(70, 20);
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
            label6.Size = new Size(56, 20);
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
            label4.Size = new Size(216, 20);
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
            label3.Size = new Size(93, 20);
            label3.TabIndex = 15;
            label3.Text = "מספר טלפון";
            // 
            // logInWorker
            // 
            logInWorker.Anchor = AnchorStyles.None;
            logInWorker.Location = new Point(442, 289);
            logInWorker.Name = "logInWorker";
            logInWorker.Size = new Size(149, 40);
            logInWorker.TabIndex = 5;
            logInWorker.Text = "חזרה לדף קודם";
            logInWorker.UseVisualStyleBackColor = true;
            logInWorker.Click += LogInWorker_Click;
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
            FormClosed += LogInForm_FormClosed;
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
        private Button logInWorker;
        private TextBox phoneCustomer;
        private Label label3;
        private Label label4;
        private TextBox nameCustomer;
        private Label label5;
        private PictureBox pictureBox2;
        private TextBox passSin;
        private Label label6;
        private Button returnCustomer;
        private PictureBox pictureBox1;
        private TextBox password;
        private TextBox userName;
        private Button button1;
        private Label label2;
        private Label label1;
        private Button button2;
    }
}