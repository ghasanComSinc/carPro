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
            button1 = new Button();
            label6 = new Label();
            image = new TextBox();
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
            SuspendLayout();
            // 
            // addItemBu
            // 
            addItemBu.Location = new Point(31, 372);
            addItemBu.Name = "addItemBu";
            addItemBu.Size = new Size(112, 34);
            addItemBu.TabIndex = 0;
            addItemBu.Text = "הוספה";
            addItemBu.UseVisualStyleBackColor = true;
            addItemBu.Click += addItemBu_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(image);
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
            // button1
            // 
            button1.Location = new Point(94, 287);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 14;
            button1.Text = "הוספה";
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(466, 292);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 13;
            label6.Text = "תמונה";
            // 
            // image
            // 
            image.Location = new Point(224, 292);
            image.Name = "image";
            image.Size = new Size(150, 31);
            image.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(466, 233);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 11;
            label5.Text = "כמות";
            // 
            // Amount
            // 
            Amount.Location = new Point(224, 233);
            Amount.Name = "Amount";
            Amount.Size = new Size(150, 31);
            Amount.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(415, 178);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 10;
            label4.Text = "מקום בחנות";
            // 
            // placeInShop
            // 
            placeInShop.Location = new Point(224, 178);
            placeInShop.Name = "placeInShop";
            placeInShop.Size = new Size(150, 31);
            placeInShop.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(449, 122);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 9;
            label3.Text = "פ\"ר קוד";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 65);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 8;
            label2.Text = "סוג רכב";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(439, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 7;
            label1.Text = "שם מוצר";
            // 
            // parCode
            // 
            parCode.Location = new Point(224, 116);
            parCode.Name = "parCode";
            parCode.Size = new Size(150, 31);
            parCode.TabIndex = 2;
            // 
            // nameItem
            // 
            nameItem.Location = new Point(224, 18);
            nameItem.Name = "nameItem";
            nameItem.Size = new Size(150, 31);
            nameItem.TabIndex = 6;
            // 
            // typeCar
            // 
            typeCar.Location = new Point(224, 65);
            typeCar.Name = "typeCar";
            typeCar.Size = new Size(150, 31);
            typeCar.TabIndex = 3;
            // 
            // addItems
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 539);
            Controls.Add(panel1);
            Name = "addItems";
            Text = "addItems";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox image;
    }
}