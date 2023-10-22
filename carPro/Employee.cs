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
        public Employee()
        {
            InitializeComponent();
            tab_PDF.SizeMode = TabSizeMode.Fixed;
            tab_PDF.ItemSize = new Size(0, 1);
            tab_PDF.Appearance = TabAppearance.FlatButtons;
            customerFun= new();
            employesDb = new();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            employeName.Text = "ברוך הבאה עובד יקר ";
            tabControl1.TabPages.Remove(tabPage2);
            tab_PDF.SelectedIndex = 0;
            dataTable = customerFun.ReturnAllSaleForCus("SELECT * FROM `paytable` WHERE `status`=\"בטיפול\""); ;
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
        private void FillDetItem(int index)
        {
            dataTable = customerFun.ReturnSale("SELECT * FROM `orders` join `items` ON `orders`.`parCode` = `items`.`parCode`" +
                $"WHERE `phoneNumber`={orders.Rows[index].Cells[0].Value} AND `orderId`='{orders.Rows[index].Cells[1].Value}'");
            // Fill the DataTable with the query results
            if(dataTable==null)
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
        private void Label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            panel1.Visible = true;
            phoneNum.Visible = false;
            orderI.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(allOrder);
            Employee_Load(sender, e);
        }
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
        private void PayBu_Click(object sender, EventArgs e)
        {
            bool flag;
            if (UpdateItems() == false)
                flag=employesDb.UpdatePayTable("UPDATE `paytable` SET `status`= 'בוטלה' WHERE `phoneNumber`=@id AND `orderId`=@orderId",itemsInOrder);
            else
                flag=employesDb.UpdatePayTable("UPDATE `paytable` SET `status`= 'בוצעה בהצלחה' WHERE `phoneNumber`=@id AND `orderId`=@orderId", itemsInOrder);
            if (flag)
            {
                Employee_Load(sender, e);
                Label2_Click(sender, e);
            }
            else
            {
                this.Close();return;
            }
        }
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
        private void Orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Orders_CellContentClick(sender, e);
        }
        private void SinC_Click(object sender, EventArgs e)
        {
            CustomerSignIn cust = new()
            {
                PhoneNum = employName,
                Size=this.Size,
                Location=this.Location
            };
            this.Hide();   
            cust.ShowDialog();
            employName = cust.PhoneNum;
            this.Show();
            Employee_Load(sender, e);
        }
       
      
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