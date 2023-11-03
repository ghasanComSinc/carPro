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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            tab = new TabControl();
            addItem = new TabPage();
            items = new DataGridView();
            updateIt = new Panel();
            deleteItems = new Button();
            searchItem = new DomainUpDown();
            comnet = new TextBox();
            label13 = new Label();
            updateItems = new Button();
            label8 = new Label();
            paySale = new TextBox();
            price = new TextBox();
            pictureBox1 = new PictureBox();
            label11 = new Label();
            search_box = new TextBox();
            search_label = new Label();
            add_item = new Button();
            picPath = new PictureBox();
            label12 = new Label();
            label7 = new Label();
            Amount = new TextBox();
            label9 = new Label();
            placeInShop = new TextBox();
            label10 = new Label();
            parCode = new TextBox();
            label5 = new Label();
            label6 = new Label();
            nameItem = new TextBox();
            typeCar = new TextBox();
            addUser = new TabPage();
            panel1 = new Panel();
            status = new DomainUpDown();
            deletU = new Button();
            button1 = new Button();
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
            ordersM = new TabPage();
            orders = new DataGridView();
            ordersD = new TabPage();
            orderD = new DataGridView();
            sinC = new Button();
            sinEm = new Button();
            statusOrder = new DomainUpDown();
            pdfItems = new Button();
            saveFileFromManger = new SaveFileDialog();
            ExPDF = new TabControl();
            ordersPDF = new TabPage();
            ExPDFOr = new Button();
            ItmesPDF = new TabPage();
            ExpUserPDF = new TabPage();
            PDFUser = new Button();
            ordersDe = new TabPage();
            ExPDFDeOr = new Button();
            mail = new TextBox();
            label14 = new Label();
            tab.SuspendLayout();
            addItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)items).BeginInit();
            updateIt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPath).BeginInit();
            addUser.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)users).BeginInit();
            ordersM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orders).BeginInit();
            ordersD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderD).BeginInit();
            ExPDF.SuspendLayout();
            ordersPDF.SuspendLayout();
            ItmesPDF.SuspendLayout();
            ExpUserPDF.SuspendLayout();
            ordersDe.SuspendLayout();
            SuspendLayout();
            // 
            // tab
            // 
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.Controls.Add(addItem);
            tab.Controls.Add(addUser);
            tab.Controls.Add(ordersM);
            tab.Controls.Add(ordersD);
            tab.Location = new Point(1, 166);
            tab.Name = "tab";
            tab.RightToLeft = RightToLeft.Yes;
            tab.RightToLeftLayout = true;
            tab.SelectedIndex = 0;
            tab.Size = new Size(1382, 602);
            tab.TabIndex = 9;
            tab.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // addItem
            // 
            addItem.Controls.Add(items);
            addItem.Controls.Add(updateIt);
            addItem.Location = new Point(4, 34);
            addItem.Name = "addItem";
            addItem.Padding = new Padding(3);
            addItem.Size = new Size(1374, 564);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            items.Location = new Point(6, 6);
            items.Name = "items";
            items.ReadOnly = true;
            items.RightToLeft = RightToLeft.Yes;
            items.RowHeadersWidth = 62;
            items.RowTemplate.Height = 33;
            items.Size = new Size(1365, 283);
            items.TabIndex = 7;
            items.CellClick += Items_CellClick;
            items.CellContentClick += Items_CellContentClick;
            items.MouseMove += Items_MouseMove;
            // 
            // updateIt
            // 
            updateIt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            updateIt.Controls.Add(deleteItems);
            updateIt.Controls.Add(searchItem);
            updateIt.Controls.Add(comnet);
            updateIt.Controls.Add(label13);
            updateIt.Controls.Add(updateItems);
            updateIt.Controls.Add(label8);
            updateIt.Controls.Add(paySale);
            updateIt.Controls.Add(price);
            updateIt.Controls.Add(pictureBox1);
            updateIt.Controls.Add(label11);
            updateIt.Controls.Add(search_box);
            updateIt.Controls.Add(search_label);
            updateIt.Controls.Add(add_item);
            updateIt.Controls.Add(picPath);
            updateIt.Controls.Add(label12);
            updateIt.Controls.Add(label7);
            updateIt.Controls.Add(Amount);
            updateIt.Controls.Add(label9);
            updateIt.Controls.Add(placeInShop);
            updateIt.Controls.Add(label10);
            updateIt.Controls.Add(parCode);
            updateIt.Controls.Add(label5);
            updateIt.Controls.Add(label6);
            updateIt.Controls.Add(nameItem);
            updateIt.Controls.Add(typeCar);
            updateIt.Location = new Point(7, 295);
            updateIt.Name = "updateIt";
            updateIt.Size = new Size(1361, 266);
            updateIt.TabIndex = 5;
            // 
            // deleteItems
            // 
            deleteItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteItems.Location = new Point(349, 170);
            deleteItems.Name = "deleteItems";
            deleteItems.Size = new Size(133, 64);
            deleteItems.TabIndex = 201;
            deleteItems.Text = "מחיקה\\החזרה מוצר";
            deleteItems.UseVisualStyleBackColor = true;
            deleteItems.Visible = false;
            deleteItems.Click += DeleteItems_Click;
            // 
            // searchItem
            // 
            searchItem.Items.Add("פ\"ר קוד");
            searchItem.Items.Add("שם מוצר");
            searchItem.Items.Add("סוג רכב");
            searchItem.Location = new Point(450, 77);
            searchItem.Name = "searchItem";
            searchItem.ReadOnly = true;
            searchItem.RightToLeft = RightToLeft.Yes;
            searchItem.Size = new Size(133, 31);
            searchItem.TabIndex = 200;
            // 
            // comnet
            // 
            comnet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comnet.Location = new Point(637, 50);
            comnet.Multiline = true;
            comnet.Name = "comnet";
            comnet.RightToLeft = RightToLeft.Yes;
            comnet.Size = new Size(155, 192);
            comnet.TabIndex = 8;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(669, 16);
            label13.Name = "label13";
            label13.Size = new Size(134, 25);
            label13.TabIndex = 196;
            label13.Text = "פרטים של מוצר";
            // 
            // updateItems
            // 
            updateItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateItems.Location = new Point(488, 212);
            updateItems.Name = "updateItems";
            updateItems.Size = new Size(126, 36);
            updateItems.TabIndex = 195;
            updateItems.Text = "עדכון מוצר";
            updateItems.UseVisualStyleBackColor = true;
            updateItems.Visible = false;
            updateItems.Click += UpdateItems_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(986, 56);
            label8.Name = "label8";
            label8.Size = new Size(92, 25);
            label8.TabIndex = 177;
            label8.Text = "מחיר קניה";
            // 
            // paySale
            // 
            paySale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            paySale.Location = new Point(819, 61);
            paySale.Name = "paySale";
            paySale.RightToLeft = RightToLeft.Yes;
            paySale.Size = new Size(150, 31);
            paySale.TabIndex = 6;
            // 
            // price
            // 
            price.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            price.Location = new Point(819, 16);
            price.Name = "price";
            price.RightToLeft = RightToLeft.Yes;
            price.Size = new Size(155, 31);
            price.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(14, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 248);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 193;
            pictureBox1.TabStop = false;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(980, 18);
            label11.Name = "label11";
            label11.Size = new Size(105, 25);
            label11.TabIndex = 188;
            label11.Text = "מחיר מכירה";
            // 
            // search_box
            // 
            search_box.Location = new Point(323, 76);
            search_box.Name = "search_box";
            search_box.Size = new Size(128, 31);
            search_box.TabIndex = 192;
            search_box.TextChanged += Search_box_TextChanged;
            // 
            // search_label
            // 
            search_label.AutoSize = true;
            search_label.Location = new Point(450, 32);
            search_label.Name = "search_label";
            search_label.Size = new Size(133, 25);
            search_label.TabIndex = 190;
            search_label.Text = "חיפוש מוצר לפי";
            // 
            // add_item
            // 
            add_item.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            add_item.Location = new Point(488, 170);
            add_item.Name = "add_item";
            add_item.Size = new Size(126, 36);
            add_item.TabIndex = 189;
            add_item.Text = "הוספת מוצר";
            add_item.UseVisualStyleBackColor = true;
            add_item.Click += Add_item_Click;
            // 
            // picPath
            // 
            picPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picPath.BackColor = Color.Black;
            picPath.Location = new Point(821, 148);
            picPath.Name = "picPath";
            picPath.Size = new Size(145, 94);
            picPath.SizeMode = PictureBoxSizeMode.Zoom;
            picPath.TabIndex = 187;
            picPath.TabStop = false;
            picPath.Click += PicPath_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(1017, 148);
            label12.Name = "label12";
            label12.Size = new Size(61, 25);
            label12.TabIndex = 186;
            label12.Text = "תמונה";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(1026, 100);
            label7.Name = "label7";
            label7.Size = new Size(52, 25);
            label7.TabIndex = 183;
            label7.Text = "כמות";
            // 
            // Amount
            // 
            Amount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Amount.Location = new Point(819, 106);
            Amount.Name = "Amount";
            Amount.RightToLeft = RightToLeft.Yes;
            Amount.Size = new Size(150, 31);
            Amount.TabIndex = 7;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(1253, 105);
            label9.Name = "label9";
            label9.Size = new Size(105, 25);
            label9.TabIndex = 182;
            label9.Text = "מקום בחנות";
            // 
            // placeInShop
            // 
            placeInShop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            placeInShop.Location = new Point(1096, 105);
            placeInShop.Name = "placeInShop";
            placeInShop.RightToLeft = RightToLeft.Yes;
            placeInShop.Size = new Size(150, 31);
            placeInShop.TabIndex = 3;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(1285, 157);
            label10.Name = "label10";
            label10.Size = new Size(71, 25);
            label10.TabIndex = 181;
            label10.Text = "פ\"ר קוד";
            // 
            // parCode
            // 
            parCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            parCode.Location = new Point(1097, 159);
            parCode.Name = "parCode";
            parCode.RightToLeft = RightToLeft.Yes;
            parCode.Size = new Size(150, 31);
            parCode.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(1280, 55);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 176;
            label5.Text = "סוג רכב";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(1274, 11);
            label6.Name = "label6";
            label6.Size = new Size(81, 25);
            label6.TabIndex = 175;
            label6.Text = "שם מוצר";
            // 
            // nameItem
            // 
            nameItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameItem.Location = new Point(1096, 14);
            nameItem.Name = "nameItem";
            nameItem.RightToLeft = RightToLeft.Yes;
            nameItem.Size = new Size(150, 31);
            nameItem.TabIndex = 1;
            // 
            // typeCar
            // 
            typeCar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            typeCar.Location = new Point(1096, 58);
            typeCar.Name = "typeCar";
            typeCar.RightToLeft = RightToLeft.Yes;
            typeCar.Size = new Size(150, 31);
            typeCar.TabIndex = 2;
            // 
            // addUser
            // 
            addUser.Controls.Add(panel1);
            addUser.Controls.Add(users);
            addUser.Location = new Point(4, 34);
            addUser.Name = "addUser";
            addUser.Padding = new Padding(3);
            addUser.Size = new Size(1374, 564);
            addUser.TabIndex = 1;
            addUser.Text = " הוספת משתמש";
            addUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(mail);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(status);
            panel1.Controls.Add(deletU);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(updateU);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(userName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(name);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(addU);
            panel1.Location = new Point(7, 383);
            panel1.Name = "panel1";
            panel1.Size = new Size(1361, 175);
            panel1.TabIndex = 5;
            // 
            // status
            // 
            status.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            status.Items.Add("מנהל");
            status.Items.Add("עובד");
            status.Items.Add("לקוח");
            status.Location = new Point(1121, 70);
            status.Name = "status";
            status.ReadOnly = true;
            status.RightToLeft = RightToLeft.Yes;
            status.Size = new Size(150, 31);
            status.TabIndex = 200;
            // 
            // deletU
            // 
            deletU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deletU.Location = new Point(738, 108);
            deletU.Name = "deletU";
            deletU.Size = new Size(133, 64);
            deletU.TabIndex = 11;
            deletU.Text = "מחיקה\\החזרה משתמש";
            deletU.UseVisualStyleBackColor = true;
            deletU.Visible = false;
            deletU.Click += DeletU_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(912, 123);
            button1.Name = "button1";
            button1.Size = new Size(111, 35);
            button1.TabIndex = 10;
            button1.Text = "ריקון נתונים";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click_1;
            // 
            // updateU
            // 
            updateU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateU.Location = new Point(738, 67);
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
            label4.Location = new Point(1293, 64);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 7;
            label4.Text = "תפקיד";
            // 
            // pass
            // 
            pass.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pass.Location = new Point(655, 30);
            pass.Name = "pass";
            pass.Size = new Size(119, 31);
            pass.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(780, 30);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 5;
            label3.Text = "סיסמה";
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            userName.Location = new Point(851, 24);
            userName.Name = "userName";
            userName.Size = new Size(150, 31);
            userName.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1007, 27);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 3;
            label2.Text = "מספר טלפון";
            // 
            // name
            // 
            name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            name.Location = new Point(1121, 18);
            name.Name = "name";
            name.Size = new Size(150, 31);
            name.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1277, 20);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 1;
            label1.Text = "שם עובד";
            // 
            // addU
            // 
            addU.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addU.Location = new Point(877, 83);
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            users.Location = new Point(6, 3);
            users.Name = "users";
            users.ReadOnly = true;
            users.RightToLeft = RightToLeft.Yes;
            users.RowHeadersWidth = 62;
            users.RowTemplate.Height = 33;
            users.Size = new Size(1362, 375);
            users.TabIndex = 4;
            users.CellClick += Users_CellClick;
            users.CellContentClick += Users_CellContentClick;
            // 
            // ordersM
            // 
            ordersM.Controls.Add(orders);
            ordersM.Location = new Point(4, 34);
            ordersM.Name = "ordersM";
            ordersM.Padding = new Padding(3);
            ordersM.Size = new Size(1374, 564);
            ordersM.TabIndex = 2;
            ordersM.Text = "הזמנות";
            ordersM.UseVisualStyleBackColor = true;
            // 
            // orders
            // 
            orders.AllowUserToAddRows = false;
            orders.AllowUserToDeleteRows = false;
            orders.AllowUserToOrderColumns = true;
            orders.AllowUserToResizeColumns = false;
            orders.AllowUserToResizeRows = false;
            orders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orders.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            orders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orders.Location = new Point(6, 6);
            orders.Name = "orders";
            orders.ReadOnly = true;
            orders.RightToLeft = RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            orders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            orders.RowHeadersWidth = 62;
            orders.RowTemplate.Height = 33;
            orders.Size = new Size(1362, 553);
            orders.TabIndex = 5;
            orders.CellContentClick += Orders_CellContentClick;
            // 
            // ordersD
            // 
            ordersD.Controls.Add(orderD);
            ordersD.Location = new Point(4, 34);
            ordersD.Name = "ordersD";
            ordersD.Padding = new Padding(3);
            ordersD.Size = new Size(1374, 564);
            ordersD.TabIndex = 3;
            ordersD.Text = "פירוט הזמנות";
            ordersD.UseVisualStyleBackColor = true;
            // 
            // orderD
            // 
            orderD.AllowUserToAddRows = false;
            orderD.AllowUserToDeleteRows = false;
            orderD.AllowUserToOrderColumns = true;
            orderD.AllowUserToResizeColumns = false;
            orderD.AllowUserToResizeRows = false;
            orderD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orderD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderD.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            orderD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            orderD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderD.Location = new Point(7, 3);
            orderD.Name = "orderD";
            orderD.ReadOnly = true;
            orderD.RightToLeft = RightToLeft.Yes;
            orderD.RowHeadersWidth = 62;
            orderD.RowTemplate.Height = 33;
            orderD.Size = new Size(1364, 553);
            orderD.TabIndex = 6;
            // 
            // sinC
            // 
            sinC.Location = new Point(21, 12);
            sinC.Name = "sinC";
            sinC.Size = new Size(124, 40);
            sinC.TabIndex = 197;
            sinC.Text = "כניסה לקוח";
            sinC.UseVisualStyleBackColor = true;
            sinC.Click += SinC_Click;
            // 
            // sinEm
            // 
            sinEm.Location = new Point(173, 8);
            sinEm.Name = "sinEm";
            sinEm.Size = new Size(124, 40);
            sinEm.TabIndex = 198;
            sinEm.Text = "כניסה עובד";
            sinEm.UseVisualStyleBackColor = true;
            sinEm.Click += SinEm_Click;
            // 
            // statusOrder
            // 
            statusOrder.Items.Add("כול הזמנות");
            statusOrder.Items.Add("בוצעה בהצלחה");
            statusOrder.Items.Add("בטיפול");
            statusOrder.Items.Add("בוטלה");
            statusOrder.Location = new Point(61, 6);
            statusOrder.Name = "statusOrder";
            statusOrder.ReadOnly = true;
            statusOrder.RightToLeft = RightToLeft.Yes;
            statusOrder.Size = new Size(180, 31);
            statusOrder.TabIndex = 199;
            statusOrder.Visible = false;
            statusOrder.SelectedItemChanged += StatusOrder_SelectedItemChanged;
            // 
            // pdfItems
            // 
            pdfItems.Location = new Point(76, 19);
            pdfItems.Name = "pdfItems";
            pdfItems.Size = new Size(156, 61);
            pdfItems.TabIndex = 200;
            pdfItems.Text = "הוצאת דוח של ספרת מלי";
            pdfItems.UseVisualStyleBackColor = true;
            pdfItems.Click += Button3_Click;
            // 
            // ExPDF
            // 
            ExPDF.Controls.Add(ordersPDF);
            ExPDF.Controls.Add(ItmesPDF);
            ExPDF.Controls.Add(ExpUserPDF);
            ExPDF.Controls.Add(ordersDe);
            ExPDF.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ExPDF.ImeMode = ImeMode.NoControl;
            ExPDF.Location = new Point(326, 22);
            ExPDF.Name = "ExPDF";
            ExPDF.RightToLeft = RightToLeft.Yes;
            ExPDF.RightToLeftLayout = true;
            ExPDF.SelectedIndex = 0;
            ExPDF.Size = new Size(256, 150);
            ExPDF.TabIndex = 6;
            // 
            // ordersPDF
            // 
            ordersPDF.BackColor = SystemColors.ButtonFace;
            ordersPDF.Controls.Add(ExPDFOr);
            ordersPDF.Controls.Add(statusOrder);
            ordersPDF.Location = new Point(4, 34);
            ordersPDF.Name = "ordersPDF";
            ordersPDF.Padding = new Padding(3);
            ordersPDF.Size = new Size(248, 112);
            ordersPDF.TabIndex = 0;
            ordersPDF.Text = "דוח הזמנות";
            // 
            // ExPDFOr
            // 
            ExPDFOr.Location = new Point(90, 43);
            ExPDFOr.Name = "ExPDFOr";
            ExPDFOr.Size = new Size(113, 61);
            ExPDFOr.TabIndex = 201;
            ExPDFOr.Text = "הוצאת דוח הזמנות";
            ExPDFOr.UseVisualStyleBackColor = true;
            ExPDFOr.Click += ExPDFOr_Click;
            // 
            // ItmesPDF
            // 
            ItmesPDF.BackColor = SystemColors.ButtonFace;
            ItmesPDF.CausesValidation = false;
            ItmesPDF.Controls.Add(pdfItems);
            ItmesPDF.ForeColor = SystemColors.ControlText;
            ItmesPDF.Location = new Point(4, 34);
            ItmesPDF.Name = "ItmesPDF";
            ItmesPDF.Padding = new Padding(3);
            ItmesPDF.Size = new Size(248, 112);
            ItmesPDF.TabIndex = 1;
            ItmesPDF.Text = "ספרת מלי";
            // 
            // ExpUserPDF
            // 
            ExpUserPDF.BackColor = SystemColors.ButtonFace;
            ExpUserPDF.Controls.Add(PDFUser);
            ExpUserPDF.Location = new Point(4, 34);
            ExpUserPDF.Name = "ExpUserPDF";
            ExpUserPDF.Padding = new Padding(3);
            ExpUserPDF.Size = new Size(248, 112);
            ExpUserPDF.TabIndex = 2;
            ExpUserPDF.Text = "דוח משתמש";
            // 
            // PDFUser
            // 
            PDFUser.Location = new Point(54, 29);
            PDFUser.Name = "PDFUser";
            PDFUser.Size = new Size(156, 61);
            PDFUser.TabIndex = 201;
            PDFUser.Text = "הוצאת דוח של משתמשים";
            PDFUser.UseVisualStyleBackColor = true;
            PDFUser.Click += PDFUser_Click;
            // 
            // ordersDe
            // 
            ordersDe.BackColor = SystemColors.ButtonFace;
            ordersDe.Controls.Add(ExPDFDeOr);
            ordersDe.Location = new Point(4, 34);
            ordersDe.Name = "ordersDe";
            ordersDe.Padding = new Padding(3);
            ordersDe.Size = new Size(248, 112);
            ordersDe.TabIndex = 3;
            ordersDe.Text = "פירוט הזמנה";
            // 
            // ExPDFDeOr
            // 
            ExPDFDeOr.Location = new Point(68, 26);
            ExPDFDeOr.Name = "ExPDFDeOr";
            ExPDFDeOr.Size = new Size(156, 61);
            ExPDFDeOr.TabIndex = 202;
            ExPDFDeOr.Text = "הוצאת דוח של פרוט הזמנה";
            ExPDFDeOr.UseVisualStyleBackColor = true;
            ExPDFDeOr.Click += ExPDFDeOr_Click;
            // 
            // mail
            // 
            mail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mail.Location = new Point(1029, 131);
            mail.Name = "mail";
            mail.Size = new Size(242, 31);
            mail.TabIndex = 201;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(1311, 134);
            label14.Name = "label14";
            label14.Size = new Size(44, 25);
            label14.TabIndex = 202;
            label14.Text = "מייל";
            // 
            // Manger
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1381, 770);
            Controls.Add(ExPDF);
            Controls.Add(sinEm);
            Controls.Add(sinC);
            Controls.Add(tab);
            Name = "Manger";
            Text = "ממשק מנהל";
            WindowState = FormWindowState.Maximized;
            Load += Manger_Load;
            tab.ResumeLayout(false);
            addItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)items).EndInit();
            updateIt.ResumeLayout(false);
            updateIt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPath).EndInit();
            addUser.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)users).EndInit();
            ordersM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orders).EndInit();
            ordersD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderD).EndInit();
            ExPDF.ResumeLayout(false);
            ordersPDF.ResumeLayout(false);
            ItmesPDF.ResumeLayout(false);
            ExpUserPDF.ResumeLayout(false);
            ordersDe.ResumeLayout(false);
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
        private Button button1;
        private Button deletU;
        private Panel updateIt;
        private Label label11;
        private TextBox price;
        private PictureBox picPath;
        private Button ExPDFDeOr;
        private Label label12;
        private Label label7;
        private TextBox Amount;
        private Label label9;
        private TextBox placeInShop;
        private Label label10;
        private TextBox parCode;
        private Label label8;
        private TextBox paySale;
        private Label label5;
        private Label label6;
        private TextBox nameItem;
        private TextBox typeCar;
        private TextBox pass;
        private Label label3;
        private Button add_item;
        private Label search_label;
        private TextBox search_box;
        private PictureBox pictureBox1;
        private Button updateItems;
        private Button sinC;
        private Button sinEm;
        private DataGridView items;
        private TextBox comnet;
        private Label label13;
        private TabPage ordersM;
        private DataGridView orders;
        private DomainUpDown statusOrder;
        private DomainUpDown searchItem;
        private DomainUpDown status;
        private TabPage ordersD;
        private DataGridView orderD;
        private Button pdfItems;
        private SaveFileDialog saveFileFromManger;
        private TabControl ExPDF;
        private TabPage ordersPDF;
        private TabPage ItmesPDF;
        private Button ExPDFOr;
        private TabPage ExpUserPDF;
        private Button PDFUser;
        private TabPage ordersDe;
        private Button deleteItems;
        private TextBox mail;
        private Label label14;
    }
}