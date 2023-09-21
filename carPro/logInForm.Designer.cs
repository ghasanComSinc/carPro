namespace carPro
{
    partial class logInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logInForm));
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
            label4 = new Label();
            nameCustumer = new TextBox();
            label3 = new Label();
            logInWorker = new Button();
            button2 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-1, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(807, 422);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(799, 384);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  ";
            tabPage1.UseVisualStyleBackColor = true;
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
            panel1.Location = new Point(194, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(441, 187);
            panel1.TabIndex = 8;
            // 
            // returnCustomer
            // 
            returnCustomer.Anchor = AnchorStyles.None;
            returnCustomer.Location = new Point(3, 144);
            returnCustomer.Name = "returnCustomer";
            returnCustomer.Size = new Size(159, 40);
            returnCustomer.TabIndex = 14;
            returnCustomer.Text = "החזרת לדף כניסה";
            returnCustomer.UseVisualStyleBackColor = true;
            returnCustomer.Click += ReturnCustomer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(71, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // password
            // 
            password.Anchor = AnchorStyles.None;
            password.Location = new Point(127, 74);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(150, 31);
            password.TabIndex = 11;
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.None;
            userName.Location = new Point(127, 19);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 10;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(314, 144);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 9;
            button1.Text = "כניסה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(347, 74);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 8;
            label2.Text = "סיסמה";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(304, 21);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 7;
            label1.Text = "שם משתמש";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(nameCustumer);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(logInWorker);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(799, 384);
            tabPage2.TabIndex = 1;
            tabPage2.Text = " ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(275, 44);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(258, 25);
            label4.TabIndex = 17;
            label4.Text = " ברוכים הבאים למערכת שלנו .";
            // 
            // nameCustumer
            // 
            nameCustumer.Anchor = AnchorStyles.None;
            nameCustumer.Location = new Point(275, 151);
            nameCustumer.Name = "nameCustumer";
            nameCustumer.Size = new Size(150, 31);
            nameCustumer.TabIndex = 16;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(452, 153);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 15;
            label3.Text = "שם לקוח";
            // 
            // logInWorker
            // 
            logInWorker.Anchor = AnchorStyles.None;
            logInWorker.Location = new Point(432, 224);
            logInWorker.Name = "logInWorker";
            logInWorker.Size = new Size(132, 40);
            logInWorker.TabIndex = 14;
            logInWorker.Text = "כניסה לעובד";
            logInWorker.UseVisualStyleBackColor = true;
            logInWorker.Click += LogInWorker_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(165, 224);
            button2.Name = "button2";
            button2.Size = new Size(132, 40);
            button2.TabIndex = 13;
            button2.Text = "כניסה לקוח";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // logInForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "logInForm";
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox password;
        private TextBox userName;
        private Button button1;
        private Label label2;
        private Label label1;
        private TabPage tabPage2;
        private Button logInWorker;
        private Button button2;
        private TextBox nameCustumer;
        private Label label3;
        private Button returnCustomer;
        private Label label4;
    }
}