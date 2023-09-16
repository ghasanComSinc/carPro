namespace carPro
{
    partial class customerSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerSignIn));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            itemToCustomer = new DataGridView();
            picItems = new PictureBox();
            tabPage2 = new TabPage();
            button1 = new Button();
            saleItmesIm = new PictureBox();
            forSale = new DataGridView();
            amountSale = new TextBox();
            sale = new Button();
            plus = new PictureBox();
            minus = new PictureBox();
            saleItem = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItems).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)forSale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minus).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(953, 392);
            tabControl1.TabIndex = 17;
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
            itemToCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemToCustomer.Location = new Point(212, 6);
            itemToCustomer.Name = "itemToCustomer";
            itemToCustomer.ReadOnly = true;
            itemToCustomer.RightToLeft = RightToLeft.Yes;
            itemToCustomer.RowHeadersWidth = 62;
            itemToCustomer.RowTemplate.Height = 33;
            itemToCustomer.Size = new Size(730, 342);
            itemToCustomer.TabIndex = 0;
            itemToCustomer.CellContentClick += itemToCustomer_CellContentClick;
            itemToCustomer.MouseMove += itemToCustomer_MouseMove;
            // 
            // picItems
            // 
            picItems.Location = new Point(9, 23);
            picItems.Name = "picItems";
            picItems.Size = new Size(173, 153);
            picItems.SizeMode = PictureBoxSizeMode.Zoom;
            picItems.TabIndex = 15;
            picItems.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button1);
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
            // button1
            // 
            button1.Location = new Point(804, 349);
            button1.Name = "button1";
            button1.Size = new Size(137, 32);
            button1.TabIndex = 17;
            button1.Text = "שמרת הזמנה";
            button1.UseVisualStyleBackColor = true;
            // 
            // saleItmesIm
            // 
            saleItmesIm.Location = new Point(9, 21);
            saleItmesIm.Name = "saleItmesIm";
            saleItmesIm.Size = new Size(173, 153);
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
            forSale.Location = new Point(200, 6);
            forSale.Name = "forSale";
            forSale.ReadOnly = true;
            forSale.RightToLeft = RightToLeft.Yes;
            forSale.RowHeadersWidth = 62;
            forSale.RowTemplate.Height = 33;
            forSale.Size = new Size(741, 337);
            forSale.TabIndex = 1;
            // 
            // amountSale
            // 
            amountSale.Anchor = AnchorStyles.None;
            amountSale.Location = new Point(284, 7);
            amountSale.Name = "amountSale";
            amountSale.Size = new Size(150, 31);
            amountSale.TabIndex = 16;
            amountSale.Visible = false;
            amountSale.TextChanged += amountSale_TextChanged;
            // 
            // sale
            // 
            sale.Anchor = AnchorStyles.None;
            sale.Location = new Point(118, 7);
            sale.Name = "sale";
            sale.Size = new Size(94, 40);
            sale.TabIndex = 18;
            sale.Text = "הזמנה";
            sale.UseVisualStyleBackColor = true;
            sale.Visible = false;
         
            // 
            // plus
            // 
            plus.Image = (Image)resources.GetObject("plus.Image");
            plus.Location = new Point(218, 12);
            plus.Name = "plus";
            plus.Size = new Size(27, 26);
            plus.SizeMode = PictureBoxSizeMode.Zoom;
            plus.TabIndex = 16;
            plus.TabStop = false;
            plus.Visible = false;
            plus.Click += plus_Click;
            // 
            // minus
            // 
            minus.Image = (Image)resources.GetObject("minus.Image");
            minus.Location = new Point(251, 12);
            minus.Name = "minus";
            minus.Size = new Size(27, 26);
            minus.SizeMode = PictureBoxSizeMode.Zoom;
            minus.TabIndex = 19;
            minus.TabStop = false;
            minus.Visible = false;
            minus.Click += minus_Click;
            // 
            // saleItem
            // 
            saleItem.AutoSize = true;
            saleItem.Location = new Point(453, 9);
            saleItem.Name = "saleItem";
            saleItem.Size = new Size(59, 25);
            saleItem.TabIndex = 20;
            saleItem.Text = "label1";
            saleItem.Visible = false;
            // 
            // customerSignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 443);
            Controls.Add(saleItem);
            Controls.Add(minus);
            Controls.Add(sale);
            Controls.Add(plus);
            Controls.Add(amountSale);
            Controls.Add(tabControl1);
            Name = "customerSignIn";
            RightToLeftLayout = true;
            Text = "ממשק לקוח";
            FormClosed += customerSignIn_FormClosed;
            Load += customerSignIn_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItems).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)saleItmesIm).EndInit();
            ((System.ComponentModel.ISupportInitialize)forSale).EndInit();
            ((System.ComponentModel.ISupportInitialize)plus).EndInit();
            ((System.ComponentModel.ISupportInitialize)minus).EndInit();
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
        private Button button1;
        private TextBox amountSale;
        private Button sale;
        private PictureBox plus;
        private PictureBox minus;
        private Label saleItem;
    }
}