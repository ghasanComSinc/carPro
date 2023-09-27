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
            tab = new TabControl();
            addItem = new TabPage();
            items = new DataGridView();
            panel2 = new Panel();
            label11 = new Label();
            price = new TextBox();
            picPath = new PictureBox();
            button2 = new Button();
            label12 = new Label();
            label7 = new Label();
            Amount = new TextBox();
            label9 = new Label();
            placeInShop = new TextBox();
            label10 = new Label();
            parCode = new TextBox();
            label8 = new Label();
            carModel = new TextBox();
            label5 = new Label();
            label6 = new Label();
            nameItem = new TextBox();
            typeCar = new TextBox();
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
            tab.SuspendLayout();
            addItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)items).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPath).BeginInit();
            addUser.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)users).BeginInit();
            SuspendLayout();
            // 
            // tab
            // 
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.Controls.Add(addItem);
            tab.Controls.Add(addUser);
            tab.Location = new Point(0, 0);
            tab.Name = "tab";
            tab.RightToLeft = RightToLeft.Yes;
            tab.RightToLeftLayout = true;
            tab.SelectedIndex = 0;
            tab.Size = new Size(887, 532);
            tab.TabIndex = 9;
            tab.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // addItem
            // 
            addItem.Controls.Add(items);
            addItem.Controls.Add(panel2);
            addItem.Location = new Point(4, 34);
            addItem.Name = "addItem";
            addItem.Padding = new Padding(3);
            addItem.Size = new Size(879, 494);
            addItem.TabIndex = 0;
            addItem.Text = "הוספת  מוצר";
            addItem.UseVisualStyleBackColor = true;
            // 
            // items
            // 
            items.AllowUserToAddRows = false;
            items.AllowUserToDeleteRows = false;
            items.AllowUserToOrderColumns = true;
            items.AllowUserToResizeColumns = false;
            items.AllowUserToResizeRows = false;
            items.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            items.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            items.BackgroundColor = SystemColors.ButtonHighlight;
            items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            items.Location = new Point(6, 2);
            items.Name = "items";
            items.ReadOnly = true;
            items.RightToLeft = RightToLeft.Yes;
            items.RowHeadersWidth = 62;
            items.RowTemplate.Height = 33;
            items.Size = new Size(870, 214);
            items.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(label11);
            panel2.Controls.Add(price);
            panel2.Controls.Add(picPath);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(Amount);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(placeInShop);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(parCode);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(carModel);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(nameItem);
            panel2.Controls.Add(typeCar);
            panel2.Location = new Point(3, 222);
            panel2.Name = "panel2";
            panel2.Size = new Size(871, 262);
            panel2.TabIndex = 5;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(811, 147);
            label11.Name = "label11";
            label11.Size = new Size(51, 25);
            label11.TabIndex = 188;
            label11.Text = "מחיר";
            // 
            // price
            // 
            price.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            price.Location = new Point(294, 68);
            price.Name = "price";
            price.RightToLeft = RightToLeft.Yes;
            price.Size = new Size(150, 31);
            price.TabIndex = 184;
            // 
            // picPath
            // 
            picPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picPath.Location = new Point(296, 147);
            picPath.Name = "picPath";
            picPath.Size = new Size(145, 94);
            picPath.SizeMode = PictureBoxSizeMode.Zoom;
            picPath.TabIndex = 187;
            picPath.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(142, 211);
            button2.Name = "button2";
            button2.Size = new Size(130, 30);
            button2.TabIndex = 185;
            button2.Text = "הוספה תמונה";
            button2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(492, 147);
            label12.Name = "label12";
            label12.Size = new Size(61, 25);
            label12.TabIndex = 186;
            label12.Text = "תמונה";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(501, 99);
            label7.Name = "label7";
            label7.Size = new Size(52, 25);
            label7.TabIndex = 183;
            label7.Text = "כמות";
            // 
            // Amount
            // 
            Amount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Amount.Location = new Point(294, 105);
            Amount.Name = "Amount";
            Amount.RightToLeft = RightToLeft.Yes;
            Amount.Size = new Size(150, 31);
            Amount.TabIndex = 180;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(448, 64);
            label9.Name = "label9";
            label9.Size = new Size(105, 25);
            label9.TabIndex = 182;
            label9.Text = "מקום בחנות";
            // 
            // placeInShop
            // 
            placeInShop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            placeInShop.Location = new Point(608, 147);
            placeInShop.Name = "placeInShop";
            placeInShop.RightToLeft = RightToLeft.Yes;
            placeInShop.Size = new Size(150, 31);
            placeInShop.TabIndex = 179;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(482, 22);
            label10.Name = "label10";
            label10.Size = new Size(71, 25);
            label10.TabIndex = 181;
            label10.Text = "פ\"ר קוד";
            // 
            // parCode
            // 
            parCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            parCode.Location = new Point(294, 24);
            parCode.Name = "parCode";
            parCode.RightToLeft = RightToLeft.Yes;
            parCode.Size = new Size(150, 31);
            parCode.TabIndex = 178;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(789, 90);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 177;
            label8.Text = "דגם רכב";
            // 
            // carModel
            // 
            carModel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            carModel.Location = new Point(606, 95);
            carModel.Name = "carModel";
            carModel.RightToLeft = RightToLeft.Yes;
            carModel.Size = new Size(150, 31);
            carModel.TabIndex = 174;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(790, 55);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 176;
            label5.Text = "סוג רכב";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(784, 11);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 175;
            label6.Text = "שם מוצר";
            // 
            // nameItem
            // 
            nameItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameItem.Location = new Point(606, 14);
            nameItem.Name = "nameItem";
            nameItem.RightToLeft = RightToLeft.Yes;
            nameItem.Size = new Size(150, 31);
            nameItem.TabIndex = 172;
            // 
            // typeCar
            // 
            typeCar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            typeCar.Location = new Point(606, 58);
            typeCar.Name = "typeCar";
            typeCar.RightToLeft = RightToLeft.Yes;
            typeCar.Size = new Size(150, 31);
            typeCar.TabIndex = 173;
            // 
            // addUser
            // 
            addUser.Controls.Add(panel1);
            addUser.Controls.Add(users);
            addUser.Location = new Point(4, 34);
            addUser.Name = "addUser";
            addUser.Padding = new Padding(3);
            addUser.Size = new Size(879, 494);
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
            panel1.Location = new Point(3, 316);
            panel1.Name = "panel1";
            panel1.Size = new Size(867, 175);
            panel1.TabIndex = 5;
            // 
            // deletU
            // 
            deletU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deletU.Location = new Point(237, 124);
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
            button1.Location = new Point(535, 83);
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
            status.Location = new Point(652, 93);
            status.Name = "status";
            status.Size = new Size(141, 60);
            status.TabIndex = 9;
            status.SelectedIndexChanged += status_SelectedIndexChanged;
            // 
            // updateU
            // 
            updateU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateU.Location = new Point(244, 83);
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
            label4.Location = new Point(799, 93);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 7;
            label4.Text = "תפקיד";
            // 
            // pass
            // 
            pass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pass.Location = new Point(161, 30);
            pass.Name = "pass";
            pass.Size = new Size(119, 31);
            pass.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(286, 30);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 5;
            label3.Text = "סיסמה";
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            userName.Location = new Point(357, 24);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(513, 27);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 3;
            label2.Text = "שם משתמש";
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            name.Location = new Point(627, 18);
            name.Name = "name";
            name.Size = new Size(150, 31);
            name.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(783, 20);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 1;
            label1.Text = "שם עובד";
            // 
            // addU
            // 
            addU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addU.Location = new Point(383, 83);
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
            users.Size = new Size(870, 307);
            users.TabIndex = 4;
            users.CellClick += Users_CellClick;
            users.CellContentClick += Users_CellContentClick;
            // 
            // Manger
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 534);
            Controls.Add(tab);
            Name = "Manger";
            Text = "ממשק מנהל";
            FormClosing += Manger_FormClosing;
            Load += Manger_Load;
            tab.ResumeLayout(false);
            addItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)items).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPath).EndInit();
            addUser.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)users).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tab;
        private TabPage addItem;
        private TabPage addUser;
        private DataGridView users;
        private Panel panel1;
        private Label label4;
        private TextBox userName;
        private Label label2;
        private TextBox name;
        private Label label1;
        private Button addU;
        private Button updateU;
        private CheckedListBox status;
        private Button button1;
        private Button deletU;
        private Panel panel2;
        private Label label11;
        private TextBox price;
        private PictureBox picPath;
        private Button button2;
        private Label label12;
        private Label label7;
        private TextBox Amount;
        private Label label9;
        private TextBox placeInShop;
        private Label label10;
        private TextBox parCode;
        private Label label8;
        private TextBox carModel;
        private Label label5;
        private Label label6;
        private TextBox nameItem;
        private TextBox typeCar;
        private TextBox pass;
        private Label label3;
        private DataGridView items;
    }
}