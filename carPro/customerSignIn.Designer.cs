namespace carPro
{
    partial class CustomerSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSignIn));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            itemsCom = new Label();
            itemToCustomer = new DataGridView();
            picItems = new PictureBox();
            tabPage2 = new TabPage();
            priceToPay = new Label();
            saveSale = new Button();
            saleItmesIm = new PictureBox();
            forSale = new DataGridView();
            tabPage3 = new TabPage();
            dataGridView1 = new DataGridView();
            itmesDe = new TabPage();
            orderDe = new DataGridView();
            panel1 = new Panel();
            lableTime = new Label();
            saleItem = new Label();
            minus = new PictureBox();
            sale = new Button();
            plus = new PictureBox();
            amountSale = new TextBox();
            label3 = new Label();
            logoPic = new PictureBox();
            phoneNumber = new Label();
            customerName = new Label();
            searchItem = new TextBox();
            label1 = new Label();
            tab_PDF = new TabControl();
            tabPage4 = new TabPage();
            PDF_Button_order = new Button();
            tabPage5 = new TabPage();
            PDF_Button_all_orders = new Button();
            saveFileforCustumr = new SaveFileDialog();
            labelDate = new Label();
            updateU = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItems).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)forSale).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            itmesDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderDe).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPic).BeginInit();
            tab_PDF.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(itmesDe);
            tabControl1.Location = new Point(-9, 117);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1186, 459);
            tabControl1.TabIndex = 17;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            tabControl1.MouseClick += TabControl1_MouseClick;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(itemsCom);
            tabPage1.Controls.Add(itemToCustomer);
            tabPage1.Controls.Add(picItems);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1178, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "מוצרים בחנות";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // itemsCom
            // 
            itemsCom.AutoSize = true;
            itemsCom.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            itemsCom.Location = new Point(115, 289);
            itemsCom.Name = "itemsCom";
            itemsCom.RightToLeft = RightToLeft.No;
            itemsCom.Size = new Size(20, 25);
            itemsCom.TabIndex = 20;
            itemsCom.Text = "s";
            itemsCom.Visible = false;
            // 
            // itemToCustomer
            // 
            itemToCustomer.AllowUserToAddRows = false;
            itemToCustomer.AllowUserToDeleteRows = false;
            itemToCustomer.AllowUserToOrderColumns = true;
            itemToCustomer.AllowUserToResizeColumns = false;
            itemToCustomer.AllowUserToResizeRows = false;
            itemToCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            itemToCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            itemToCustomer.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            itemToCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            itemToCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemToCustomer.Location = new Point(272, 6);
            itemToCustomer.Name = "itemToCustomer";
            itemToCustomer.ReadOnly = true;
            itemToCustomer.RightToLeft = RightToLeft.Yes;
            itemToCustomer.RowHeadersWidth = 62;
            itemToCustomer.RowTemplate.Height = 33;
            itemToCustomer.Size = new Size(900, 409);
            itemToCustomer.TabIndex = 0;
            itemToCustomer.CellClick += ItemToCustomer_CellClick;
            itemToCustomer.CellContentClick += ItemToCustomer_CellContentClick;
            itemToCustomer.MouseMove += ItemToCustomer_MouseMove;
            // 
            // picItems
            // 
            picItems.Location = new Point(7, 6);
            picItems.Name = "picItems";
            picItems.Size = new Size(259, 266);
            picItems.SizeMode = PictureBoxSizeMode.StretchImage;
            picItems.TabIndex = 15;
            picItems.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(priceToPay);
            tabPage2.Controls.Add(saveSale);
            tabPage2.Controls.Add(saleItmesIm);
            tabPage2.Controls.Add(forSale);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1178, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "הזמנה";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // priceToPay
            // 
            priceToPay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            priceToPay.AutoSize = true;
            priceToPay.Location = new Point(76, 202);
            priceToPay.Name = "priceToPay";
            priceToPay.RightToLeft = RightToLeft.Yes;
            priceToPay.Size = new Size(124, 50);
            priceToPay.TabIndex = 26;
            priceToPay.Text = "מחיר לתשלום:\r\n0";
            // 
            // saveSale
            // 
            saveSale.Location = new Point(45, 284);
            saveSale.Name = "saveSale";
            saveSale.Size = new Size(137, 32);
            saveSale.TabIndex = 17;
            saveSale.Text = "שמרת הזמנה";
            saveSale.UseVisualStyleBackColor = true;
            saveSale.Click += SaveSale_Click;
            // 
            // saleItmesIm
            // 
            saleItmesIm.Location = new Point(9, 21);
            saleItmesIm.Name = "saleItmesIm";
            saleItmesIm.Size = new Size(268, 163);
            saleItmesIm.SizeMode = PictureBoxSizeMode.Zoom;
            saleItmesIm.TabIndex = 16;
            saleItmesIm.TabStop = false;
            // 
            // forSale
            // 
            forSale.AllowUserToAddRows = false;
            forSale.AllowUserToDeleteRows = false;
            forSale.AllowUserToOrderColumns = true;
            forSale.AllowUserToResizeColumns = false;
            forSale.AllowUserToResizeRows = false;
            forSale.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            forSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            forSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            forSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            forSale.Location = new Point(283, 6);
            forSale.Name = "forSale";
            forSale.ReadOnly = true;
            forSale.RightToLeft = RightToLeft.Yes;
            forSale.RowHeadersWidth = 62;
            forSale.RowTemplate.Height = 33;
            forSale.Size = new Size(887, 409);
            forSale.TabIndex = 1;
            forSale.CellClick += ForSale_CellClick;
            forSale.CellContentClick += ForSale_CellContentClick;
            forSale.MouseMove += ForSale_MouseMove;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1178, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "דף הזמנות";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1163, 409);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            // 
            // itmesDe
            // 
            itmesDe.Controls.Add(orderDe);
            itmesDe.Location = new Point(4, 34);
            itmesDe.Name = "itmesDe";
            itmesDe.Padding = new Padding(3);
            itmesDe.Size = new Size(1178, 421);
            itmesDe.TabIndex = 3;
            itmesDe.Text = "פרוט הזמנה";
            itmesDe.UseVisualStyleBackColor = true;
            // 
            // orderDe
            // 
            orderDe.AllowUserToAddRows = false;
            orderDe.AllowUserToDeleteRows = false;
            orderDe.AllowUserToOrderColumns = true;
            orderDe.AllowUserToResizeColumns = false;
            orderDe.AllowUserToResizeRows = false;
            orderDe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orderDe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            orderDe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            orderDe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDe.Location = new Point(6, 6);
            orderDe.Name = "orderDe";
            orderDe.ReadOnly = true;
            orderDe.RightToLeft = RightToLeft.Yes;
            orderDe.RowHeadersWidth = 62;
            orderDe.RowTemplate.Height = 33;
            orderDe.Size = new Size(1164, 409);
            orderDe.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(lableTime);
            panel1.Controls.Add(saleItem);
            panel1.Controls.Add(minus);
            panel1.Controls.Add(sale);
            panel1.Controls.Add(plus);
            panel1.Controls.Add(amountSale);
            panel1.Location = new Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(421, 61);
            panel1.TabIndex = 16;
            // 
            // lableTime
            // 
            lableTime.AutoSize = true;
            lableTime.Location = new Point(86, 27);
            lableTime.Name = "lableTime";
            lableTime.Size = new Size(0, 25);
            lableTime.TabIndex = 52;
            lableTime.TextAlign = ContentAlignment.TopCenter;
            // 
            // saleItem
            // 
            saleItem.AutoSize = true;
            saleItem.Location = new Point(281, 18);
            saleItem.Name = "saleItem";
            saleItem.Size = new Size(59, 25);
            saleItem.TabIndex = 50;
            saleItem.Text = "label1";
            saleItem.Visible = false;
            // 
            // minus
            // 
            minus.Anchor = AnchorStyles.None;
            minus.Image = (Image)resources.GetObject("minus.Image");
            minus.Location = new Point(151, 18);
            minus.Name = "minus";
            minus.Size = new Size(27, 26);
            minus.SizeMode = PictureBoxSizeMode.Zoom;
            minus.TabIndex = 24;
            minus.TabStop = false;
            minus.Visible = false;
            minus.Click += Minus_Click;
            // 
            // sale
            // 
            sale.Anchor = AnchorStyles.None;
            sale.Location = new Point(18, 13);
            sale.Name = "sale";
            sale.Size = new Size(94, 40);
            sale.TabIndex = 23;
            sale.Text = "הזמנה";
            sale.UseVisualStyleBackColor = true;
            sale.Visible = false;
            sale.Click += Sale_Click;
            // 
            // plus
            // 
            plus.Anchor = AnchorStyles.None;
            plus.Image = (Image)resources.GetObject("plus.Image");
            plus.Location = new Point(118, 18);
            plus.Name = "plus";
            plus.Size = new Size(27, 26);
            plus.SizeMode = PictureBoxSizeMode.Zoom;
            plus.TabIndex = 21;
            plus.TabStop = false;
            plus.Visible = false;
            plus.Click += Plus_Click;
            // 
            // amountSale
            // 
            amountSale.Anchor = AnchorStyles.None;
            amountSale.Location = new Point(184, 13);
            amountSale.Name = "amountSale";
            amountSale.Size = new Size(91, 31);
            amountSale.TabIndex = 22;
            amountSale.Visible = false;
            amountSale.TextChanged += AmountSale_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(942, 4);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(217, 25);
            label3.TabIndex = 18;
            label3.Text = "ברוכים הבאים לחנות שלנו\r\n";
            // 
            // logoPic
            // 
            logoPic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logoPic.ErrorImage = null;
            logoPic.Image = (Image)resources.GetObject("logoPic.Image");
            logoPic.InitialImage = null;
            logoPic.Location = new Point(431, -5);
            logoPic.Name = "logoPic";
            logoPic.Size = new Size(360, 82);
            logoPic.SizeMode = PictureBoxSizeMode.Zoom;
            logoPic.TabIndex = 19;
            logoPic.TabStop = false;
            // 
            // phoneNumber
            // 
            phoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            phoneNumber.AutoSize = true;
            phoneNumber.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            phoneNumber.Location = new Point(1041, 34);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.RightToLeft = RightToLeft.Yes;
            phoneNumber.Size = new Size(118, 25);
            phoneNumber.TabIndex = 21;
            phoneNumber.Text = "מספר טלפון :";
            // 
            // customerName
            // 
            customerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customerName.AutoSize = true;
            customerName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            customerName.Location = new Point(1072, 59);
            customerName.Name = "customerName";
            customerName.RightToLeft = RightToLeft.Yes;
            customerName.Size = new Size(87, 25);
            customerName.TabIndex = 22;
            customerName.Text = "שם לקוח:";
            // 
            // searchItem
            // 
            searchItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchItem.Location = new Point(795, 31);
            searchItem.Name = "searchItem";
            searchItem.RightToLeft = RightToLeft.Yes;
            searchItem.Size = new Size(141, 31);
            searchItem.TabIndex = 26;
            searchItem.TextChanged += SearchItem_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(830, 4);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 27;
            label1.Text = "חיפוש מוצר";
            // 
            // tab_PDF
            // 
            tab_PDF.Controls.Add(tabPage4);
            tab_PDF.Controls.Add(tabPage5);
            tab_PDF.Location = new Point(431, 4);
            tab_PDF.Name = "tab_PDF";
            tab_PDF.RightToLeft = RightToLeft.Yes;
            tab_PDF.RightToLeftLayout = true;
            tab_PDF.SelectedIndex = 0;
            tab_PDF.Size = new Size(169, 107);
            tab_PDF.TabIndex = 28;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(PDF_Button_order);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(161, 69);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // PDF_Button_order
            // 
            PDF_Button_order.Location = new Point(23, 16);
            PDF_Button_order.Name = "PDF_Button_order";
            PDF_Button_order.Size = new Size(117, 34);
            PDF_Button_order.TabIndex = 0;
            PDF_Button_order.Text = "דוח הזמנות";
            PDF_Button_order.UseVisualStyleBackColor = true;
            PDF_Button_order.Click += PDF_Button_order_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(PDF_Button_all_orders);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(161, 69);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // PDF_Button_all_orders
            // 
            PDF_Button_all_orders.Location = new Point(26, 17);
            PDF_Button_all_orders.Name = "PDF_Button_all_orders";
            PDF_Button_all_orders.Size = new Size(117, 32);
            PDF_Button_all_orders.TabIndex = 0;
            PDF_Button_all_orders.Text = "פרוט הזמנה";
            PDF_Button_all_orders.UseVisualStyleBackColor = true;
            PDF_Button_all_orders.Click += PDF_Button_all_orders_Click;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(81, 56);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(0, 25);
            labelDate.TabIndex = 51;
            labelDate.TextAlign = ContentAlignment.TopCenter;
            // 
            // updateU
            // 
            updateU.Location = new Point(278, 71);
            updateU.Name = "updateU";
            updateU.Size = new Size(151, 40);
            updateU.TabIndex = 53;
            updateU.Text = "עדכון משתמש";
            updateU.UseVisualStyleBackColor = true;
            updateU.Click += UpdateU_Click;
            // 
            // CustomerSignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 578);
            Controls.Add(updateU);
            Controls.Add(labelDate);
            Controls.Add(tab_PDF);
            Controls.Add(label1);
            Controls.Add(searchItem);
            Controls.Add(customerName);
            Controls.Add(phoneNumber);
            Controls.Add(logoPic);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Name = "CustomerSignIn";
            RightToLeftLayout = true;
            Text = "ממשק לקוח";
            Load += CustomerSignIn_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItems).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).EndInit();
            ((System.ComponentModel.ISupportInitialize)forSale).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            itmesDe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderDe).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)minus).EndInit();
            ((System.ComponentModel.ISupportInitialize)plus).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPic).EndInit();
            tab_PDF.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView itemToCustomer;
        private PictureBox picItems;
        private TabPage tabPage2;
        private PictureBox saleItmesIm;
        private DataGridView forSale;
        private Button saveSale;
        private Panel panel1;
        private Label saleItem;
        private PictureBox minus;
        private Button sale;
        private PictureBox plus;
        private TextBox amountSale;
        private Label label3;
        private Label priceToPay;
        private TabPage tabPage3;
        private PictureBox logoPic;
        private DataGridView dataGridView1;
        private TabPage itmesDe;
        private DataGridView orderDe;
        private Label itemsCom;
        private Label phoneNumber;
        private Label customerName;
        private TextBox searchItem;
        private Label label1;
        private TabControl tab_PDF;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button PDF_Button_order;
        private Button PDF_Button_all_orders;
        private SaveFileDialog saveFileforCustumr;
        private Label labelDate;
        private Label lableTime;
        private Button updateU;
    }
}