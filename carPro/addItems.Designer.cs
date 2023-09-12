namespace carPro
{
    partial class addItems
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
            addItemBu.Location = new Point(31, 372);
            addItemBu.Name = "addItemBu";
            addItemBu.Size = new Size(112, 34);
            addItemBu.TabIndex = 8;
            addItemBu.Text = "הוספה";
            addItemBu.UseVisualStyleBackColor = true;
            addItemBu.Click += addItemBu_Click_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            panel1.Location = new Point(162, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 440);
            panel1.TabIndex = 1;
            // 
            // picPath
            // 
            picPath.Location = new Point(224, 274);
            picPath.Name = "picPath";
            picPath.Size = new Size(173, 153);
            picPath.SizeMode = PictureBoxSizeMode.Zoom;
            picPath.TabIndex = 14;
            picPath.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(51, 311);
            button1.Name = "button1";
            button1.Size = new Size(155, 30);
            button1.TabIndex = 7;
            button1.Text = "הוספה תמונה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseClick += button1_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(457, 347);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 13;
            label6.Text = "תמונה";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(466, 233);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 11;
            label5.Text = "כמות";
            // 
            // Amount
            // 
            Amount.Anchor = AnchorStyles.None;
            Amount.Location = new Point(224, 233);
            Amount.Name = "Amount";
            Amount.Size = new Size(150, 31);
            Amount.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(415, 178);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 10;
            label4.Text = "מקום בחנות";
            // 
            // placeInShop
            // 
            placeInShop.Anchor = AnchorStyles.None;
            placeInShop.Location = new Point(224, 178);
            placeInShop.Name = "placeInShop";
            placeInShop.Size = new Size(150, 31);
            placeInShop.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(449, 122);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 9;
            label3.Text = "פ\"ר קוד";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(448, 65);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 8;
            label2.Text = "סוג רכב";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(439, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 7;
            label1.Text = "שם מוצר";
            // 
            // parCode
            // 
            parCode.Anchor = AnchorStyles.None;
            parCode.Location = new Point(224, 116);
            parCode.Name = "parCode";
            parCode.Size = new Size(150, 31);
            parCode.TabIndex = 3;
            // 
            // nameItem
            // 
            nameItem.Anchor = AnchorStyles.None;
            nameItem.Location = new Point(224, 18);
            nameItem.Name = "nameItem";
            nameItem.Size = new Size(150, 31);
            nameItem.TabIndex = 1;
            // 
            // typeCar
            // 
            typeCar.Anchor = AnchorStyles.None;
            typeCar.Location = new Point(224, 65);
            typeCar.Name = "typeCar";
            typeCar.Size = new Size(150, 31);
            typeCar.TabIndex = 2;
            // 
            // addItems
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 539);
            Controls.Add(panel1);
            Name = "addItems";
            Text = "הוספת מוצר";
            FormClosing += addItems_FormClosing;
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
    }
}