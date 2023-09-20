namespace carPro
{
    partial class AddItems
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
            addItemBu = new Button();
            panel1 = new Panel();
            label8 = new Label();
            carModel = new TextBox();
            label7 = new Label();
            price = new TextBox();
            picPath = new PictureBox();
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            Amount = new TextBox();
            label4 = new Label();
            placeInShop = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            parCode = new TextBox();
            nameItem = new TextBox();
            typeCar = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPath).BeginInit();
            SuspendLayout();
            // 
            // addItemBu
            // 
            addItemBu.Anchor = AnchorStyles.None;
            addItemBu.Location = new Point(23, 474);
            addItemBu.Name = "addItemBu";
            addItemBu.Size = new Size(112, 34);
            addItemBu.TabIndex = 8;
            addItemBu.Text = "הוספה";
            addItemBu.UseVisualStyleBackColor = true;
            addItemBu.Click += AddItemBu_Click_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(carModel);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(price);
            panel1.Controls.Add(picPath);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(addItemBu);
            panel1.Controls.Add(Amount);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(placeInShop);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(parCode);
            panel1.Controls.Add(nameItem);
            panel1.Controls.Add(typeCar);
            panel1.Location = new Point(162, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(647, 544);
            panel1.TabIndex = 1;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(489, 100);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 18;
            label8.Text = "דגם רכב";
            // 
            // carModel
            // 
            carModel.Anchor = AnchorStyles.None;
            carModel.Location = new Point(310, 94);
            carModel.Name = "carModel";
            carModel.RightToLeft = RightToLeft.Yes;
            carModel.Size = new Size(150, 31);
            carModel.TabIndex = 3;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(516, 313);
            label7.Name = "label7";
            label7.Size = new Size(51, 25);
            label7.TabIndex = 16;
            label7.Text = "מחיר";
            // 
            // price
            // 
            price.Anchor = AnchorStyles.Right;
            price.Location = new Point(309, 307);
            price.Name = "price";
            price.RightToLeft = RightToLeft.Yes;
            price.Size = new Size(150, 31);
            price.TabIndex = 7;
            // 
            // picPath
            // 
            picPath.Location = new Point(310, 344);
            picPath.Name = "picPath";
            picPath.Size = new Size(173, 153);
            picPath.SizeMode = PictureBoxSizeMode.Zoom;
            picPath.TabIndex = 14;
            picPath.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(150, 402);
            button1.Name = "button1";
            button1.Size = new Size(130, 30);
            button1.TabIndex = 8;
            button1.Text = "הוספה תמונה";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += Button1_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(509, 419);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 13;
            label6.Text = "תמונה";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(516, 261);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 11;
            label5.Text = "כמות";
            // 
            // Amount
            // 
            Amount.Anchor = AnchorStyles.None;
            Amount.Location = new Point(309, 255);
            Amount.Name = "Amount";
            Amount.RightToLeft = RightToLeft.Yes;
            Amount.Size = new Size(150, 31);
            Amount.TabIndex = 6;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(465, 206);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 10;
            label4.Text = "מקום בחנות";
            // 
            // placeInShop
            // 
            placeInShop.Anchor = AnchorStyles.None;
            placeInShop.Location = new Point(309, 200);
            placeInShop.Name = "placeInShop";
            placeInShop.RightToLeft = RightToLeft.Yes;
            placeInShop.Size = new Size(150, 31);
            placeInShop.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(499, 150);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 9;
            label3.Text = "פ\"ר קוד";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(495, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 8;
            label2.Text = "סוג רכב";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(489, 11);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 7;
            label1.Text = "שם מוצר";
            // 
            // parCode
            // 
            parCode.Anchor = AnchorStyles.None;
            parCode.Location = new Point(309, 138);
            parCode.Name = "parCode";
            parCode.RightToLeft = RightToLeft.Yes;
            parCode.Size = new Size(150, 31);
            parCode.TabIndex = 4;
            // 
            // nameItem
            // 
            nameItem.Anchor = AnchorStyles.None;
            nameItem.Location = new Point(309, 2);
            nameItem.Name = "nameItem";
            nameItem.RightToLeft = RightToLeft.Yes;
            nameItem.Size = new Size(150, 31);
            nameItem.TabIndex = 1;
            // 
            // typeCar
            // 
            typeCar.Anchor = AnchorStyles.None;
            typeCar.Location = new Point(310, 50);
            typeCar.Name = "typeCar";
            typeCar.RightToLeft = RightToLeft.Yes;
            typeCar.Size = new Size(150, 31);
            typeCar.TabIndex = 2;
            // 
            // addItems
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 604);
            Controls.Add(panel1);
            Name = "addItems";
            Text = "הוספת מוצר";
            FormClosing += AddItems_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPath).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button addItemBu;
        private Panel panel1;
        private Label label4;
        private TextBox placeInShop;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox parCode;
        private TextBox nameItem;
        private TextBox typeCar;
        private TextBox Amount;
        private Label label5;
        private Button button1;
        private Label label6;
        private PictureBox picPath;
        private Label label8;
        private TextBox carModel;
        private Label label7;
        private TextBox price;
    }
}