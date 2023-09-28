namespace carPro
{
    partial class Employee
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
            tabControl1 = new TabControl();
            allOrder = new TabPage();
            orders = new DataGridView();
            tabPage2 = new TabPage();
            button2 = new Button();
            payBu = new Button();
            pay = new Label();
            picItems = new PictureBox();
            itemsInOrder = new DataGridView();
            employeName = new Label();
            panel1 = new Panel();
            search = new ListBox();
            searchOr = new TextBox();
            label1 = new Label();
            label7 = new Label();
            button1 = new Button();
            label6 = new Label();
            addItemBu = new Button();
            label2 = new Label();
            tabControl1.SuspendLayout();
            allOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orders).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemsInOrder).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(allOrder);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(8, 89);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(875, 442);
            tabControl1.TabIndex = 18;
            // 
            // allOrder
            // 
            allOrder.Controls.Add(orders);
            allOrder.Location = new Point(4, 34);
            allOrder.Name = "allOrder";
            allOrder.Padding = new Padding(3);
            allOrder.Size = new Size(867, 404);
            allOrder.TabIndex = 0;
            allOrder.Text = "הזמנות";
            allOrder.UseVisualStyleBackColor = true;
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
            orders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orders.Location = new Point(13, 6);
            orders.Name = "orders";
            orders.ReadOnly = true;
            orders.RightToLeft = RightToLeft.Yes;
            orders.RowHeadersWidth = 62;
            orders.RowTemplate.Height = 33;
            orders.Size = new Size(851, 395);
            orders.TabIndex = 1;
            orders.CellContentClick += Orders_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(payBu);
            tabPage2.Controls.Add(pay);
            tabPage2.Controls.Add(picItems);
            tabPage2.Controls.Add(itemsInOrder);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(867, 404);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "פרות של הזמנות";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(173, 340);
            button2.Name = "button2";
            button2.Size = new Size(133, 64);
            button2.TabIndex = 32;
            button2.Text = "עדכון כמות של מוצרים ";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += Button2_Click;
            // 
            // payBu
            // 
            payBu.Location = new Point(13, 334);
            payBu.Name = "payBu";
            payBu.Size = new Size(124, 40);
            payBu.TabIndex = 31;
            payBu.Text = "לתשלום";
            payBu.UseVisualStyleBackColor = true;
            payBu.Click += PayBu_Click;
            // 
            // pay
            // 
            pay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pay.AutoSize = true;
            pay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            pay.Location = new Point(218, 285);
            pay.Name = "pay";
            pay.Size = new Size(74, 20);
            pay.TabIndex = 30;
            pay.Text = "לתשלום :\r\n";
            // 
            // picItems
            // 
            picItems.Location = new Point(5, 6);
            picItems.Name = "picItems";
            picItems.Size = new Size(301, 266);
            picItems.SizeMode = PictureBoxSizeMode.StretchImage;
            picItems.TabIndex = 16;
            picItems.TabStop = false;
            // 
            // itemsInOrder
            // 
            itemsInOrder.AllowUserToAddRows = false;
            itemsInOrder.AllowUserToDeleteRows = false;
            itemsInOrder.AllowUserToOrderColumns = true;
            itemsInOrder.AllowUserToResizeColumns = false;
            itemsInOrder.AllowUserToResizeRows = false;
            itemsInOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemsInOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            itemsInOrder.BackgroundColor = SystemColors.ButtonHighlight;
            itemsInOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemsInOrder.Location = new Point(309, 6);
            itemsInOrder.Name = "itemsInOrder";
            itemsInOrder.ReadOnly = true;
            itemsInOrder.RightToLeft = RightToLeft.Yes;
            itemsInOrder.RowHeadersWidth = 62;
            itemsInOrder.RowTemplate.Height = 33;
            itemsInOrder.Size = new Size(552, 393);
            itemsInOrder.TabIndex = 2;
            itemsInOrder.MouseMove += ItemsInOrder_MouseMove;
            // 
            // employeName
            // 
            employeName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            employeName.AutoSize = true;
            employeName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            employeName.Location = new Point(695, 24);
            employeName.Name = "employeName";
            employeName.RightToLeft = RightToLeft.Yes;
            employeName.Size = new Size(156, 40);
            employeName.TabIndex = 19;
            employeName.Text = "ברוך הבאה עובד יקר ,\r\n ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(search);
            panel1.Controls.Add(searchOr);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(addItemBu);
            panel1.Location = new Point(159, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 69);
            panel1.TabIndex = 23;
            // 
            // search
            // 
            search.FormattingEnabled = true;
            search.ItemHeight = 25;
            search.Items.AddRange(new object[] { "", "שם לקוח", "מספר זיהוי" });
            search.Location = new Point(165, 22);
            search.Name = "search";
            search.RightToLeft = RightToLeft.Yes;
            search.Size = new Size(159, 29);
            search.TabIndex = 28;
            // 
            // searchOr
            // 
            searchOr.Anchor = AnchorStyles.None;
            searchOr.Location = new Point(39, 22);
            searchOr.Name = "searchOr";
            searchOr.Size = new Size(120, 31);
            searchOr.TabIndex = 27;
            searchOr.TextChanged += SearchOr_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(325, 21);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 26;
            label1.Text = "חיפוש הזמנה לפי";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(828, 297);
            label7.Name = "label7";
            label7.Size = new Size(51, 25);
            label7.TabIndex = 16;
            label7.Text = "מחיר";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(306, 386);
            button1.Name = "button1";
            button1.Size = new Size(130, 30);
            button1.TabIndex = 8;
            button1.Text = "הוספה תמונה";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(665, 403);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 13;
            label6.Text = "תמונה";
            // 
            // addItemBu
            // 
            addItemBu.Anchor = AnchorStyles.None;
            addItemBu.Location = new Point(179, 458);
            addItemBu.Name = "addItemBu";
            addItemBu.Size = new Size(112, 34);
            addItemBu.TabIndex = 8;
            addItemBu.Text = "הוספה";
            addItemBu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(25, 77);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 29;
            label2.Text = "חזרה לדף הזמנות";
            label2.Visible = false;
            label2.Click += Label2_Click;
            // 
            // Employee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 534);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(employeName);
            Controls.Add(tabControl1);
            Name = "Employee";
            Text = "ממשק עובד";
            FormClosed += Employee_FormClosed;
            Load += Employee_Load;
            tabControl1.ResumeLayout(false);
            allOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orders).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemsInOrder).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage allOrder;
        private TabPage tabPage2;
        private Label employeName;
        private DataGridView orders;
        private Panel panel1;
        private Label label7;
        private Button button1;
        private Label label6;
        private Button addItemBu;
        private ListBox search;
        private TextBox searchOr;
        private Label label1;
        private DataGridView itemsInOrder;
        private Label label2;
        private PictureBox picItems;
        private Label pay;
        private Button payBu;
        private Button button2;
    }
}