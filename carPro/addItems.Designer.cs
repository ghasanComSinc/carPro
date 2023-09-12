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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // addItemBu
            // 
            addItemBu.Location = new Point(78, 313);
            addItemBu.Name = "addItemBu";
            addItemBu.Size = new Size(112, 34);
            addItemBu.TabIndex = 0;
            addItemBu.Text = "הוספה";
            addItemBu.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(addItemBu);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(162, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 372);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(224, 65);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(224, 233);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(224, 178);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(224, 18);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 6;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(448, 65);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 8;
            label2.Text = "סוג רכב";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(415, 178);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 10;
            label4.Text = "מקום בחנות";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(466, 233);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 11;
            label5.Text = "קמות";
            // 
            // addItems
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private TextBox textBox4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox5;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label5;
    }
}