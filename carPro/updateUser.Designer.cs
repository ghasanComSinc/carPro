namespace carPro
{
    partial class UpdateUser
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
            pass = new TextBox();
            label3 = new Label();
            userName = new TextBox();
            label2 = new Label();
            name = new TextBox();
            label1 = new Label();
            updateU = new Button();
            mail = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // pass
            // 
            pass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pass.Location = new Point(494, 163);
            pass.Name = "pass";
            pass.Size = new Size(150, 31);
            pass.TabIndex = 9;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(690, 166);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 11;
            label3.Text = "סיסמה";
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            userName.Location = new Point(494, 112);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 8;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(650, 115);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 10;
            label2.Text = "מספר טלפון";
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            name.Location = new Point(494, 62);
            name.Name = "name";
            name.RightToLeft = RightToLeft.Yes;
            name.Size = new Size(150, 31);
            name.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(677, 65);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 7;
            label1.Text = "שם עובד";
            // 
            // updateU
            // 
            updateU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateU.Location = new Point(338, 277);
            updateU.Name = "updateU";
            updateU.Size = new Size(133, 35);
            updateU.TabIndex = 12;
            updateU.Text = "עדכון משתמש";
            updateU.UseVisualStyleBackColor = true;
            updateU.Click += UpdateU_Click;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Location = new Point(494, 223);
            mail.Name = "mail";
            mail.Size = new Size(211, 31);
            mail.TabIndex = 13;
            mail.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(711, 229);
            label4.Name = "label4";
            label4.Size = new Size(44, 25);
            label4.TabIndex = 14;
            label4.Text = "מייל";
            // 
            // updateUser
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mail);
            Controls.Add(label4);
            Controls.Add(updateU);
            Controls.Add(pass);
            Controls.Add(label3);
            Controls.Add(userName);
            Controls.Add(label2);
            Controls.Add(name);
            Controls.Add(label1);
            Name = "updateUser";
            Text = "עדכון משתמש";
            Load += UpdateUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pass;
        private Label label3;
        private TextBox userName;
        private Label label2;
        private TextBox name;
        private Label label1;
        private Button updateU;
        private TextBox mail;
        private Label label4;
    }
}