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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSignIn));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            itemToCustomer = new DataGridView();
            picItems = new PictureBox();
            tabPage2 = new TabPage();
            priceToPay = new Label();
            saveSale = new Button();
            saleItmesIm = new PictureBox();
            forSale = new DataGridView();
            tabPage3 = new TabPage();
            panel1 = new Panel();
            saleItem = new Label();
            minus = new PictureBox();
            sale = new Button();
            plus = new PictureBox();
            amountSale = new TextBox();
            label3 = new Label();
            logoPic = new PictureBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItems).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)forSale).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPic).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(953, 392);
            tabControl1.TabIndex = 17;
            tabControl1.MouseClick += TabControl1_MouseClick;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(itemToCustomer);
            tabPage1.Controls.Add(picItems);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(945, 354);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "מוצרים בחנות";
            tabPage1.UseVisualStyleBackColor = true;
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
            itemToCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemToCustomer.Location = new Point(272, 6);
            itemToCustomer.Name = "itemToCustomer";
            itemToCustomer.ReadOnly = true;
            itemToCustomer.RightToLeft = RightToLeft.Yes;
            itemToCustomer.RowHeadersWidth = 62;
            itemToCustomer.RowTemplate.Height = 33;
            itemToCustomer.Size = new Size(670, 342);
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
            tabPage2.Size = new Size(945, 354);
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
            forSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            forSale.Location = new Point(283, 6);
            forSale.Name = "forSale";
            forSale.ReadOnly = true;
            forSale.RightToLeft = RightToLeft.Yes;
            forSale.RowHeadersWidth = 62;
            forSale.RowTemplate.Height = 33;
            forSale.Size = new Size(656, 345);
            forSale.TabIndex = 1;
            forSale.CellClick += ForSale_CellClick;
            forSale.CellContentClick += ForSale_CellContentClick;
            forSale.MouseMove += ForSale_MouseMove;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(945, 354);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "דף הזמנות";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(saleItem);
            panel1.Controls.Add(minus);
            panel1.Controls.Add(sale);
            panel1.Controls.Add(plus);
            panel1.Controls.Add(amountSale);
            panel1.Location = new Point(27, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(406, 65);
            panel1.TabIndex = 16;
            // 
            // saleItem
            // 
            saleItem.Anchor = AnchorStyles.None;
            saleItem.AutoSize = true;
            saleItem.Location = new Point(346, 17);
            saleItem.Name = "saleItem";
            saleItem.Size = new Size(59, 25);
            saleItem.TabIndex = 25;
            saleItem.Text = "label1";
            saleItem.Visible = false;
            // 
            // minus
            // 
            minus.Anchor = AnchorStyles.None;
            minus.Image = (Image)resources.GetObject("minus.Image");
            minus.Location = new Point(144, 20);
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
            sale.Location = new Point(11, 15);
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
            plus.Location = new Point(111, 20);
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
            amountSale.Location = new Point(177, 15);
            amountSale.Name = "amountSale";
            amountSale.Size = new Size(150, 31);
            amountSale.TabIndex = 22;
            amountSale.Visible = false;
            amountSale.TextChanged += AmountSale_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(731, 4);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(179, 40);
            label3.TabIndex = 18;
            label3.Text = "ברוכים הבאים לחנות שלנו\r\nלקוח יקר, ";
            // 
            // logoPic
            // 
            logoPic.ErrorImage = null;
            logoPic.Image = (Image)resources.GetObject("logoPic.Image");
            logoPic.InitialImage = null;
            logoPic.Location = new Point(438, 4);
            logoPic.Name = "logoPic";
            logoPic.Size = new Size(387, 79);
            logoPic.TabIndex = 19;
            logoPic.TabStop = false;
            // 
            // CustomerSignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 443);
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
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItems).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).EndInit();
            ((System.ComponentModel.ISupportInitialize)forSale).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)minus).EndInit();
            ((System.ComponentModel.ISupportInitialize)plus).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPic).EndInit();
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
    }
}