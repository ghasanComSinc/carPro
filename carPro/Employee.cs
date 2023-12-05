using System.Data;
using Image = System.Drawing.Image;

namespace carPro
{
    public partial class Employee : Form
    {
        public string employName;//phone
        DataTable dataTable;
        readonly CustomerClassDb customerFun;
        readonly EmployesDb employesDb;
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// Represents the functionality and interface for an employee managing orders.
        /// </summary>
        public Employee()
        {
            InitializeComponent();
            tab_PDF.SizeMode = TabSizeMode.Fixed;
            tab_PDF.ItemSize = new Size(0, 1);
            tab_PDF.Appearance = TabAppearance.FlatButtons;
            customerFun = new();
            employesDb = new();
        }
        /// <summary>
        /// Handles the loading event of the Employee form.
        /// Configures the initial state and loads data for the employee view.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Employee_Load(object sender, EventArgs e)
        {
            orderI.Visible = false;
            phoneNum.Visible = false;
            employeName.Text = "ברוך הבאה עובד יקר ";
            tabControl1.TabPages.Remove(tabPage2);
            tab_PDF.SelectedIndex = 0;
            dataTable = customerFun.ReturnSale("SELECT * FROM `paytable` WHERE `status`=\"בטיפול\""); 
            // Fill the DataTable with the query results
            if (dataTable == null)
            {
                this.Close(); return;
            }
            orders.DataSource = dataTable;
            orders.Columns[0].HeaderText = "מספר טלפון";
            orders.Columns[1].HeaderText = "מזה הזמנה";
            orders.Columns[2].HeaderText = "לתשלום";
            orders.Columns[2].HeaderText = "מצב";
            orders.Columns[3].Visible = false;
        }
        /// <summary>
        /// Handles the TextChanged event of the searchOr TextBox.
        /// Filters orders based on the provided search criteria.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SearchOr_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (search.Text != "" && search.Text != " " && searchOr.Text != "")
            {
                if (search.Text == "מספר טלפון")
                    dataView.RowFilter = $"Convert(phoneNumber, 'System.String') LIKE '%{searchOr.Text}%'";
                else
                {
                    dataView.RowFilter = $"Convert(orderId, 'System.String') LIKE '%{searchOr.Text}%'";
                }
            }
            else
            {
                Employee_Load(sender, e);
            }
            orders.Refresh();
        }
        /// <summary>
        /// Calculates and updates the total amount to be paid for the items in the current order.
        /// Applies background color coding based on item availability.
        /// </summary>
        private void ToPay()
        {
            float sum = 0;
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (float.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) == 0)
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                else if (float.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) >= float.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString()))
                {
                    sum += float.Parse(itemsInOrder.Rows[i].Cells[12].Value.ToString()) * float.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString());
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    itemsInOrder.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    button2.Visible = true;
                }

            }
            pay.Text = "לתשלום :\r\n" + sum;
        }
        /// <summary>
        /// Fills the itemsInOrder DataGridView with details of the selected order.
        /// </summary>
        /// <param name="index">The index of the selected order in the orders DataGridView.</param>
        private void FillDetItem(int index)
        {
            dataTable = customerFun.ReturnSale("SELECT * FROM `orders` join `items` ON `orders`.`parCode` = `items`.`parCode`" +
                $"WHERE `phoneNumber`={orders.Rows[index].Cells[0].Value} AND `orderId`='{orders.Rows[index].Cells[1].Value}'");
            // Fill the DataTable with the query results
            if (dataTable == null)
            {
                this.Close(); return;
            }
            itemsInOrder.DataSource = dataTable;
            itemsInOrder.Columns[0].Visible = false;// "מספר טלפון";
            itemsInOrder.Columns[0].HeaderText = "מספר טלפון";
            itemsInOrder.Columns[1].HeaderText = "פר";
            itemsInOrder.Columns[2].Visible = false;// "מזה הזמנה";
            itemsInOrder.Columns[2].HeaderText = "מזה הזמנה";
            itemsInOrder.Columns[3].HeaderText = "כמות רצויה";
            itemsInOrder.Columns[4].Visible = false;//status
            itemsInOrder.Columns[4].HeaderText = "מצב";
            itemsInOrder.Columns[5].HeaderText = "שעת קניה";
            itemsInOrder.Columns[6].HeaderText = "תאריך קניה";
            itemsInOrder.Columns[7].HeaderText = "שם מוצר";
            itemsInOrder.Columns[8].HeaderText = "סוג רכב";
            itemsInOrder.Columns[9].HeaderText = "מיקום בחנות";
            itemsInOrder.Columns[10].Visible = false;//parcode
            itemsInOrder.Columns[11].HeaderText = "מחיר";
            itemsInOrder.Columns[12].Visible = false;//paypri
            itemsInOrder.Columns[13].Visible = false;//pic
            itemsInOrder.Columns[14].Visible = false;// "קמות בחנות";
            itemsInOrder.Columns[15].HeaderText = "הערה על מוצר";
            itemsInOrder.Columns[16].HeaderText = "מצב של מוצר";
            itemsInOrder.Columns[16].Visible = false;
            ToPay();
            phoneNum.Visible = true;
            orderI.Visible = true;
            phoneNum.Text = "מספר טלפון של לקוח " + " " + itemsInOrder.Rows[0].Cells[0].Value.ToString();
            orderI.Text = "מזה הזמנה" + " " + itemsInOrder.Rows[0].Cells[2].Value.ToString();
        }
        /// <summary>
        /// Handles the CellContentClick event of the Orders DataGridView.
        /// Navigates to the detailed view of the selected order.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tab_PDF.SelectedIndex = 1;
                tabControl1.TabPages.Remove(allOrder);
                tabControl1.TabPages.Add(tabPage2);
                label2.Visible = true;
                panel1.Visible = false;
                FillDetItem(e.RowIndex);
            }
        }
        /// <summary>
        /// Handles the Click event of the Label2 label.
        /// Navigates back to the main view displaying all orders.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            panel1.Visible = true;
            phoneNum.Visible = false;
            orderI.Visible = false;
            for(int i = 0;i<tabControl1.TabPages.Count;)
                tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
            tabControl1.TabPages.Add(allOrder);
            Employee_Load(sender, e);
        }
        /// <summary>
        /// Handles the MouseMove event of the ItemsInOrder DataGridView.
        /// Displays the image of the selected item when hovering over its cell.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ItemsInOrder_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = itemsInOrder.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = itemsInOrder.Rows[rowIndex].Cells[13];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    picItems.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picItems.Image = null;
            }
        }
        /// <summary>
        /// Updates the status of items in the order based on quantity and availability.
        /// </summary>
        /// <returns>True if the update is successful, false otherwise.</returns>
        private bool UpdateItems()
        {
            bool flag = false;
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (float.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) >= float.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString()))
                {
                    if (employesDb.UpdateItmes(itemsInOrder, i) == false || employesDb.UpdateOrder(itemsInOrder, i, "בוצע בהצלחה") == false)
                    {
                        this.Close(); return false;
                    }
                    flag = true;
                }
                else
                {
                    if (employesDb.UpdateOrder(itemsInOrder, i, "בוטלה") == false)
                    { this.Close(); return false; }

                }
            }
            return flag;
        }
        /// <summary>
        /// Handles the Click event of the PayBu button.
        /// Updates the status of items and paytable based on the order's completion status.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void PayBu_Click(object sender, EventArgs e)
        {
            bool flag;
            if (UpdateItems() == false)
                flag = employesDb.UpdatePayTable("UPDATE `paytable` SET `status`= 'בוטלה' WHERE `phoneNumber`=@id AND `orderId`=@orderId", itemsInOrder);
            else
                flag = employesDb.UpdatePayTable("UPDATE `paytable` SET `status`= 'בוצעה בהצלחה' WHERE `phoneNumber`=@id AND `orderId`=@orderId", itemsInOrder);
            if (flag)
            {
                Employee_Load(sender, e);
                Label2_Click(sender, e);
            }
            else
            {
                this.Close(); return;
            }
        }
        /// <summary>
        /// Handles the Click event of the Button2 button.
        /// Updates the quantity of items in the order and refreshes the order details view.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (itemsInOrder.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {
                    if (employesDb.UpdateItemsAmountInOr(itemsInOrder, i) == false)
                    { this.Close(); return; }
                }
            }
            FillDetItem(0);
            if (employesDb.UpdatePaytablePrice(itemsInOrder, pay.Text.ToString()) == false)
            { this.Close(); return; }

            button2.Visible = false;
        }
        /// <summary>
        /// Handles the Click event of the SinC button.
        /// Initiates the customer sign-in process and updates the employee view accordingly.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Orders_CellContentClick(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the SinC button.
        /// Initiates the customer sign-in process and updates the employee view accordingly.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SinC_Click(object sender, EventArgs e)
        {
            CustomerSignIn cust = new()
            {
                PhoneNum = employName,
                Size = this.Size,
                Location = this.Location
            };
            this.Hide();
            cust.ShowDialog();
            employName = cust.PhoneNum;
            this.Show();
            for (int i = 0; i < tabControl1.RowCount;)
                tabControl1.TabPages.RemoveAt(i);
            tabControl1.TabPages.Add(allOrder);

            Employee_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the PDF_Button_order button.
        /// Saves a PDF file containing the details of all orders displayed in the DataGridView.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void PDF_Button_order_Click(object sender, EventArgs e)
        {
            saveFileFromEmploye.FileName = string.Empty;
            saveFileFromEmploye.Filter = "PDF Files|*.pdf";
            if (saveFileFromEmploye.ShowDialog() == DialogResult.OK)
            {
                EmployePdf emPdf = new();
                emPdf.AddPdfSale(saveFileFromEmploye.FileName, orders);
            }
        }
        /// <summary>
        /// Handles the Click event of the PDF_Button_all_orders button.
        /// Saves a PDF file containing the details of all items in the order displayed in the DataGridView.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void PDF_Button_all_orders_Click(object sender, EventArgs e)
        {
            saveFileFromEmploye.FileName = string.Empty;
            saveFileFromEmploye.Filter = "PDF Files|*.pdf";
            if (saveFileFromEmploye.ShowDialog() == DialogResult.OK)
            {
                EmployePdf emPdf = new();
                emPdf.AddPdfItemInSale(saveFileFromEmploye.FileName, itemsInOrder);
            }
        }
    }
}