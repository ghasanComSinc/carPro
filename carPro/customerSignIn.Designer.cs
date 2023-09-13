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
            itemToCustomer = new DataGridView();
            picItems = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItems).BeginInit();
            SuspendLayout();
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
            itemToCustomer.Location = new Point(5, 163);
            itemToCustomer.Name = "itemToCustomer";
            itemToCustomer.ReadOnly = true;
            itemToCustomer.RightToLeft = RightToLeft.Yes;
            itemToCustomer.RowHeadersWidth = 62;
            itemToCustomer.RowTemplate.Height = 33;
            itemToCustomer.Size = new Size(949, 378);
            itemToCustomer.TabIndex = 0;
            itemToCustomer.MouseMove += itemToCustomer_MouseMove;
            // 
            // picItems
            // 
            picItems.Location = new Point(29, 4);
            picItems.Name = "picItems";
            picItems.Size = new Size(173, 153);
            picItems.SizeMode = PictureBoxSizeMode.Zoom;
            picItems.TabIndex = 15;
            picItems.TabStop = false;
            // 
            // customerSignIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 553);
            Controls.Add(picItems);
            Controls.Add(itemToCustomer);
            Name = "customerSignIn";
            Text = "ממשק לקוח";
            FormClosed += customerSignIn_FormClosed;
            Load += customerSignIn_Load;
            ((System.ComponentModel.ISupportInitialize)itemToCustomer).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView itemToCustomer;
        private PictureBox picItems;
    }
}