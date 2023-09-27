namespace carPro
{
    partial class Manger
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
            button2 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            addUser = new TabPage();
            panel1 = new Panel();
            deletU = new Button();
            button1 = new Button();
            status = new CheckedListBox();
            updateU = new Button();
            label4 = new Label();
            pass = new TextBox();
            label3 = new Label();
            userName = new TextBox();
            label2 = new Label();
            name = new TextBox();
            label1 = new Label();
            addU = new Button();
            users = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            addUser.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)users).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(8, 349);
            button2.Name = "button2";
            button2.Size = new Size(123, 34);
            button2.TabIndex = 4;
            button2.Text = "הוספה מוצר";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(addUser);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 427);
            tabControl1.TabIndex = 9;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(780, 389);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // addUser
            // 
            addUser.Controls.Add(panel1);
            addUser.Controls.Add(users);
            addUser.Location = new Point(4, 34);
            addUser.Name = "addUser";
            addUser.Padding = new Padding(3);
            addUser.Size = new Size(780, 389);
            addUser.TabIndex = 1;
            addUser.Text = " הוספת משתמש";
            addUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(deletU);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(status);
            panel1.Controls.Add(updateU);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(name);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(addU);
            panel1.Location = new Point(6, 217);
            panel1.Name = "panel1";
            panel1.Size = new Size(769, 166);
            panel1.TabIndex = 5;
            // 
            // deletU
            // 
            deletU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deletU.Location = new Point(139, 124);
            deletU.Name = "deletU";
            deletU.Size = new Size(144, 35);
            deletU.TabIndex = 11;
            deletU.Text = "מחיקה משתמש";
            deletU.UseVisualStyleBackColor = true;
            deletU.Visible = false;
            deletU.Click += DeletU_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(437, 83);
            button1.Name = "button1";
            button1.Size = new Size(111, 35);
            button1.TabIndex = 10;
            button1.Text = "ריקון נתונים";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click_1;
            // 
            // status
            // 
            status.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            status.Items.AddRange(new object[] { "manger", "employe" });
            status.Location = new Point(554, 93);
            status.Name = "status";
            status.Size = new Size(141, 60);
            status.TabIndex = 9;
            status.SelectedIndexChanged += CheckedListBox1_SelectedIndexChanged;
            // 
            // updateU
            // 
            updateU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateU.Location = new Point(146, 83);
            updateU.Name = "updateU";
            updateU.Size = new Size(133, 35);
            updateU.TabIndex = 8;
            updateU.Text = "עדכון משתמש";
            updateU.UseVisualStyleBackColor = true;
            updateU.Visible = false;
            updateU.Click += UpdateU_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(701, 93);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 7;
            label4.Text = "תפקיד";
            // 
            // pass
            // 
            pass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pass.Location = new Point(11, 24);
            pass.Name = "pass";
            pass.Size = new Size(122, 31);
            pass.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(139, 24);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 5;
            label3.Text = "סיסמה";
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            userName.Location = new Point(210, 24);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(366, 27);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 3;
            label2.Text = "שם משתמש";
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            name.Location = new Point(499, 21);
            name.Name = "name";
            name.Size = new Size(150, 31);
            name.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(685, 20);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 1;
            label1.Text = "שם עובד";
            // 
            // addU
            // 
            addU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addU.Location = new Point(285, 83);
            addU.Name = "addU";
            addU.Size = new Size(146, 35);
            addU.TabIndex = 0;
            addU.Text = "הוספה משתמש";
            addU.UseVisualStyleBackColor = true;
            addU.Click += AddU_Click;
            // 
            // users
            // 
            users.AllowUserToAddRows = false;
            users.AllowUserToDeleteRows = false;
            users.AllowUserToOrderColumns = true;
            users.AllowUserToResizeColumns = false;
            users.AllowUserToResizeRows = false;
            users.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            users.BackgroundColor = SystemColors.ButtonHighlight;
            users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            users.Location = new Point(3, 3);
            users.Name = "users";
            users.ReadOnly = true;
            users.RightToLeft = RightToLeft.Yes;
            users.RowHeadersWidth = 62;
            users.RowTemplate.Height = 33;
            users.Size = new Size(772, 208);
            users.TabIndex = 4;
            users.CellClick += Users_CellClick;
            users.CellContentClick += Users_CellContentClick;
            // 
            // manger
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 439);
            Controls.Add(tabControl1);
            Name = "manger";
            Text = "ממשק מנהל";
            FormClosing += Manger_FormClosing;
            Load += Manger_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            addUser.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)users).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage addUser;
        private DataGridView users;
        private Panel panel1;
        private Label label4;
        private TextBox pass;
        private Label label3;
        private TextBox userName;
        private Label label2;
        private TextBox name;
        private Label label1;
        private Button addU;
        private Button updateU;
        private CheckedListBox status;
        private Button button1;
        private Button deletU;
    }
}