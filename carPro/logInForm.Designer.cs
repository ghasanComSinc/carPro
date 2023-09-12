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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            password = new TextBox();
            userName = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(password);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(181, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(447, 205);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(77, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(12, 141);
            button2.Name = "button2";
            button2.Size = new Size(132, 40);
            button2.TabIndex = 12;
            button2.Text = "כניסה לקוח";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // password
            // 
            password.Anchor = AnchorStyles.None;
            password.Location = new Point(133, 79);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(150, 31);
            password.TabIndex = 11;
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.None;
            userName.Location = new Point(133, 24);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 10;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(310, 128);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 9;
            button1.Text = "כניסה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(353, 79);
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
            label1.Location = new Point(310, 26);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 7;
            label1.Text = "שם משתמש";
            // 
            // logInForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "logInForm";
            Text = "כניסה למערכת";
            FormClosed += logInForm_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button2;
        private TextBox password;
        private TextBox userName;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}