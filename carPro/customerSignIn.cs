using iText.Layout.Borders;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Text.RegularExpressions;
using Font = iTextSharp.text.Font;
using Image = System.Drawing.Image;

namespace carPro
{
    public partial class CustomerSignIn : Form
    {
        DataTable dataTable;
        float sum = 0;
        public string PhoneNum;
        int amount = 0;
        string parcod;
        int rowIndex;
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document document;
        readonly static string path = @"C:\Users\ASUS\Desktop\VarelaRound-Regular.ttf";
        //readonly static string path = @"D:\autocar_path\VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(@"D:\autocar_path\VarelaRound-Regular.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        readonly CustomerClassDb custDb;
        Font tableFont;
        public CustomerSignIn()
        {
            InitializeComponent();
            forSale.Columns.Add("שם מוצר", "שם מוצר");//0
            forSale.Columns.Add("סוג רכב", "סוג רכב");//1
            forSale.Columns.Add("ברקוד", "ברקוד");//2->3
            forSale.Columns.Add("כמות", "כמות");//3->7
            forSale.Columns.Add("מחיר ליחידה", "מחיר ליחידה");//4->4
            forSale.Columns.Add("סה\"כ מחיר", "סה\"כ מחיר");//5
            forSale.Columns.Add("pic", "");//6
            forSale.Columns[6].Visible = false;
            tab_PDF.SizeMode = TabSizeMode.Fixed;
            tab_PDF.ItemSize = new Size(0, 1);
            tab_PDF.Appearance = TabAppearance.FlatButtons;
            custDb = new();
        }
        private void EmtpyItems()
        {
            for (int i = 0; i < itemToCustomer.Rows.Count; i++)
            {
                if (itemToCustomer.Rows[i].Cells[7].Value.ToString() == "0")
                {
                    itemToCustomer.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void CustomerSignIn_Load(object sender, EventArgs e)
        {
            phoneNumber.Text += PhoneNum;
            string name= custDb.NameCust(PhoneNum);
            if (name != "")
            {
                customerName.Text += name;
                TabControl1_SelectedIndexChanged(sender, e);
            }
            else
                this.Close();
        }
        private void HideItem()
        {
            saleItem.Visible = false;
            sale.Visible = false;
            amountSale.Visible = false;
            plus.Visible = false;
            minus.Visible = false;
        }
        private void ItemToCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = itemToCustomer.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = itemToCustomer.Rows[rowIndex].Cells[6];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    picItems.Image = Image.FromStream(ms);
                    itmesDe.AutoScroll = true;
                    itemsCom.MaximumSize = new System.Drawing.Size(100, 100);
                    itemsCom.Text = itemToCustomer.Rows[rowIndex].Cells[8].Value.ToString();

                    itemsCom.Visible = true;
                }
            }
            else
            {
                picItems.Image = null;
                itemsCom.Visible = false;
            }
        }
        private void ItemToCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = itemToCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[7].Value.ToString(), out amount);
                parcod = itemToCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = "0";
            }
            else
            {
                HideItem();
            }
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && amount >= int.Parse(amountSale.Text))
                amountSale.Text = (int.Parse(amountSale.Text) + 1) + "";
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > 0)
                amountSale.Text = (int.Parse(amountSale.Text) - 1) + "";
        }
        private void AmountSale_TextChanged(object sender, EventArgs e)
        {
            if (amountSale.Text != "" && Regex.IsMatch(amountSale.Text, @"^\d+$") && int.Parse(amountSale.Text) > amount)
            {
                MessageBox.Show("אין במלי הכמות הדרושה");
                amountSale.Text = amount.ToString();
            }
            else if (!Regex.IsMatch(amountSale.Text, @"^\d+$"))
            {
                amountSale.Text = "0";
            }
        }
        private int ChechDoplicatItems()
        {
            for (int i = 0; i < forSale.Rows.Count; i++)
            {
                if (forSale.Rows[i].Cells[2].Value.ToString() == parcod)
                {
                    return i;
                }
            }
            return -1;
        }
        private void Sale_Click(object sender, EventArgs e)
        {
            int rowOld = ChechDoplicatItems();
            if (rowOld == -1)
            {
                if (amountSale.Text != "0")
                {
                    int rowIndexNew = forSale.Rows.Add();
                    // Copy data from selected row in DataGridView1 to the new row in DataGridView2
                    for (int i = 0; i < forSale.Rows[rowIndexNew].Cells.Count; i++)
                    {
                        if (i >= 0 && i < 2 || i == 4 || i == 6)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = itemToCustomer.Rows[rowIndex].Cells[i].Value;
                        }
                        else if (i == 2)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = itemToCustomer.Rows[rowIndex].Cells[3].Value;
                        }
                        else if (i == 3)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = amountSale.Text;
                        }
                        else if (i == 5)
                        {
                            forSale.Rows[rowIndexNew].Cells[i].Value = float.Parse(forSale.Rows[rowIndexNew].Cells[3].Value.ToString()) * float.Parse(forSale.Rows[rowIndexNew].Cells[4].Value.ToString());
                        }
                    }
                    tabPage2.Text = "הזמנה" + "(" + forSale.Rows.Count + ")";
                    sum += float.Parse(forSale.Rows[rowIndexNew].Cells[5].Value.ToString());
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                }
            }
            else
            {
                if (amountSale.Text != "0")
                {
                    //forSale.Rows[rowOld].Cells[5].Value = int.Parse(forSale.Rows[rowOld].Cells[3].Value.ToString()) * int.Parse(forSale.Rows[rowOld].Cells[4].Value.ToString());
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out float num1);
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out float num2);
                    sum -= num1 * num2;
                    forSale.Rows[rowOld].Cells[3].Value = amountSale.Text;
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out num1);
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out num2);
                    sum += num1 * num2;
                    forSale.Rows[rowOld].Cells[5].Value = num1 * num2;
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                }
                else if (amountSale.Text == "0" && tabControl1.SelectedIndex == 1)
                {
                    if ((forSale.Rows.Count - 1) == 0)
                        tabPage2.Text = "הזמנה";
                    else
                        tabPage2.Text = "הזמנה" + "(" + (forSale.Rows.Count - 1) + ")";
                    HideItem();
                    saleItmesIm.Image = null;
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[3].Value.ToString(), out float num1);
                    _ = float.TryParse(forSale.Rows[rowOld].Cells[4].Value.ToString(), out float num2);
                    sum -= num1 * num2;
                    priceToPay.Text = "מחיר לתשלום:" + "\n" + sum + "";
                    forSale.Rows.RemoveAt(rowOld);
                }
            }

        }
        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            HideItem();
        }
        private void ForSale_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = forSale.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = forSale.Rows[rowIndex].Cells[6];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    saleItmesIm.Image = Image.FromStream(ms);
                }
            }
            else
            {
                saleItmesIm.Image = null;
            }
        }
        private void ForSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                saleItem.Visible = true;
                saleItem.Text = forSale.Rows[e.RowIndex].Cells[0].Value.ToString();
                _ = int.TryParse(itemToCustomer.Rows[e.RowIndex].Cells[4].Value.ToString(), out amount);
                parcod = forSale.Rows[e.RowIndex].Cells[2].Value.ToString();
                rowIndex = e.RowIndex;
                sale.Visible = true;
                amountSale.Visible = true;
                plus.Visible = true;
                minus.Visible = true;
                amountSale.Text = forSale.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                HideItem();
            }
        }
        private void SaveSale_Click(object sender, EventArgs e)
        {
            if (forSale.Rows.Count > 0)
            {
                int count = custDb.ReturnCountCus();
                if (count > 0)
                    if (custDb.InsertSaleCus(PhoneNum, count, sum))
                    {
                        for (int i = 0; i < forSale.Rows.Count; i++)
                        {
                            if (!custDb.InsertItemInSale(PhoneNum, forSale, i, count))
                            {
                                this.Close(); return;
                            }
                        }
                    }
                    else
                    { this.Close(); return; }
                else
                { this.Close(); return; }
                MessageBox.Show("שמרת הזמנה התבצעה בהצלחה ,מספר הזמנה שלכה הוא " + count);
            }
            else
            {
                MessageBox.Show("הזמנה ריקה");
            }
        }
        private void ItemToCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemToCustomer_CellContentClick(sender, e);
        }
        private void ForSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ForSale_CellContentClick(sender, e);
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView1_CellContentClick(sender, e);
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControl1.SelectedIndex = 3;
                // Bind the DataTable to the DataGridView
                dataTable= custDb.ReturnSale("SELECT * FROM `orders` " +
                        $"WHERE `phoneNumber`={PhoneNum} AND `orderId`={dataGridView1.Rows[e.RowIndex].Cells[1].Value}");
                if (dataTable == null)
                {
                    this.Close(); return;
                }
                orderDe.DataSource = dataTable;
                orderDe.Columns[0].Visible = false; //the number of customer               
                orderDe.Columns[1].HeaderText = "ברקוד";
                orderDe.Columns[2].HeaderText = "מספר הזמנה";
                orderDe.Columns[3].HeaderText = "כמות";
                orderDe.Columns[4].HeaderText = "סטטוס הזמנה";
                orderDe.Columns[5].HeaderText = "שעת הזמנה";
                orderDe.Columns[6].HeaderText = "תאריך ושעת הזמנה";

            }
        }
        private void SearchItem_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (searchItem.Text != "")
            {
                dataView.RowFilter = $"nameItmes LIKE '%{searchItem.Text}%'";
            }
            else
            {
                    dataTable =custDb.ReturnItem();
                    if(dataTable==null)
                    {
                        this.Close(); return;
                    }
                    // Bind the DataTable to the DataGridView
                    itemToCustomer.DataSource = dataTable;
                    EmtpyItems();         
            }
            itemToCustomer.Refresh();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tab_PDF.TabCount;)
                tab_PDF.TabPages.Remove(tab_PDF.TabPages[0]);
            if (tabControl1.SelectedIndex == 0)
            {
                dataTable = custDb.ReturnItem();
                if (dataTable == null)
                {
                    this.Close(); return;
                }
                // Bind the DataTable to the DataGridView
                itemToCustomer.DataSource = dataTable;
                itemToCustomer.Columns[0].HeaderText = "שם מוצר";
                itemToCustomer.Columns[1].HeaderText = "סוג רכב";
                itemToCustomer.Columns[2].Visible = false;
                itemToCustomer.Columns[3].HeaderText = "ברקוד";
                itemToCustomer.Columns[4].HeaderText = "מחיר ליחידה";
                itemToCustomer.Columns[5].Visible = false;
                itemToCustomer.Columns[6].Visible = false;
                itemToCustomer.Columns[7].HeaderText = "כמות";
                itemToCustomer.Columns[8].Visible = false;// "הערה";
                itemToCustomer.Columns[9].Visible = false;// available;
                EmtpyItems();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                tab_PDF.TabPages.Add(tabPage4);
                dataTable = custDb.ReturnAllSaleForCus("SELECT * FROM `payTable` WHERE `phoneNumber` = " +PhoneNum);
                if (dataTable == null)
                {
                    this.Close(); return;
                }
                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[0].HeaderText = "מספר טלפון";
                dataGridView1.Columns[1].HeaderText = "מספר הזמנה";
                dataGridView1.Columns[2].HeaderText = "מחיר תשלום";
                dataGridView1.Columns[3].HeaderText = "מצב הזמנה";
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                tab_PDF.TabPages.Add(tabPage5);
            }
        }
        private void PDF_Button_order_Click(object sender, EventArgs e)
        {
            SavePdfFile(dataGridView1, "דוח חזמנות", 0);
        }
        private void SaveTableFont(int count)
        {
            tableFont = new Font(tableFont1, 12)
            {
                Color = BaseColor.BLACK
            };
            saveTablePdf = new PdfPTable(count)
            {
                HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
            };
        }
        private void SavePdfFile(DataGridView data, string titleStr, int fileNum)
        {
            saveFileforCustumr.FileName = string.Empty;
            saveFileforCustumr.Filter = "PDF Files|*.pdf";
            if (saveFileforCustumr.ShowDialog() == DialogResult.OK)
            {
                document = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(saveFileforCustumr.FileName, FileMode.Create));
                document.Open();
                /*put image*/
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:\\autopatr\\images.jpeg");
                //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\source\\repos\\carPro\\carPro\\plus.png");
                img.ScaleToFit(200f, 200f); // Adjust the width and height as needed
                img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                document.Add(img);
                /*put image*/
                /*creat title in pdf*/
                Font font = new(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
                Paragraph title = new(titleStr, font);
                PdfPCell cell = new(title)
                {
                    Border = 0, // Remove cell borders if needed
                    RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                saveTablePdf = new PdfPTable(1);
                saveTablePdf.AddCell(cell);
                document.Add(saveTablePdf);
                /*creat title in pdf*/
                if (fileNum == 0)
                    SaveTableFont(3);
                else
                    SaveTableFont(5);
                float[] widthOfTable = new float[saveTablePdf.NumberOfColumns];
                for (int i = 0; i < widthOfTable.Length; i++)
                {
                    if (fileNum == 0)
                        widthOfTable[i] = 20f;
                    else
                    {
                        if (i != 3)
                            widthOfTable[i] = 20f;
                        else
                            widthOfTable[i] = 90f;
                    }
                }
                saveTablePdf.SetWidths(widthOfTable);
                if (fileNum == 0)
                {
                    for (int i = 1; i < data.ColumnCount; i++)
                        saveTablePdf.AddCell(new Phrase(data.Columns[i].HeaderText, tableFont));
                }
                else
                {
                    saveTablePdf.AddCell(new Phrase(data.Columns[0].HeaderText, tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Columns[1].HeaderText, tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Columns[3].HeaderText, tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Columns[5].HeaderText, tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Columns[7].HeaderText, tableFont));
                }
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (fileNum == 0)
                    {
                        for (int j = 1; j < data.ColumnCount; j++)
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[j].Value.ToString(), tableFont));
                    }
                    else
                    {
                        if (data.Rows[i].Cells[9].Value.ToString() == "פעיל")
                        {
                            if (data.Rows[i].Cells[7].Value.ToString() == "0")
                                tableFont = new Font(tableFont1, 12)
                                {
                                    Color = BaseColor.RED
                                };
                            else
                                tableFont = new Font(tableFont1, 12)
                                {
                                    Color = BaseColor.BLACK
                                };
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[0].Value.ToString(), tableFont));
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[1].Value.ToString(), tableFont));
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[3].Value.ToString(), tableFont));
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[5].Value.ToString(), tableFont));
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[7].Value.ToString(), tableFont));
                        }
                    }
                }
                document.Add(saveTablePdf);
                document.Close();
                MessageBox.Show("הפעולה הסתימה בהצלחה");
            }
        }
    }
}