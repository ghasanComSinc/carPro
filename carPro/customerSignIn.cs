using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using Image = System.Drawing.Image;

using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace carPro
{
    public partial class CustomerSignIn : Form
    {
        readonly MySqlConnection connection = new("server=localhost;user=root;database=carshop;password=");
        //readonly MySqlConnection connection = new("server=sql12.freesqldatabase.com;user=sql12650296;database=sql12650296;password=QadX7ERzXj");

        MySqlCommand MyCommand2;
        float sum = 0;
        public string nameCustumer;
        int amount = 0;
        string parcod;
        int rowIndex;

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
        }
        private void CustomerSignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
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
        DataTable dataTable = new();
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document document;
        //readonly static string path = @"C:\Users\ASUS\Desktop\VarelaRound-Regular.ttf";
        readonly static string path = @"D:\autocar_path\VarelaRound-Regular.ttf";
        //readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(@"D:\autocar_path\VarelaRound-Regular.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

        Font tableFont;

        private void CustomerSignIn_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            try
            {
                string strFun;
                strFun = "SELECT `name` FROM `usertable` WHERE `phoneNumber`=" + nameCustumer;
                connection.Open();
                MyCommand2 = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(MyCommand2);
                adapter = new(MyCommand2);
                DataTable dataTable1 = new();
                adapter.Fill(dataTable1);
                phoneNumber.Text += nameCustumer;
                DataRow row = dataTable1.Rows[0];
                customerName.Text += row["name"];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CustomerSignIn_FormClosed(null, null);
                connection.Close();
            }

            TabControl1_SelectedIndexChanged(sender, e);
            /* the load of the data orders*/

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
                amountSale.Text = "0";
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
                try
                {
                    string strFun = "SELECT COUNT(*) FROM `paytable`;";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    _ = int.TryParse(MyCommand2.ExecuteScalar().ToString(), out int count);
                    count += 1;
                    connection.Close();
                    strFun = "INSERT INTO paytable(`phoneNumber`, `orderId`, `price`, `status`) VALUES" +
                        "(@phoneNumber,@orderId,@price,@status)";
                    MyCommand2 = new(strFun, connection);
                    connection.Open();
                    MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                    MyCommand2.Parameters.AddWithValue("@orderId", count);
                    MyCommand2.Parameters.AddWithValue("@price", sum);
                    MyCommand2.Parameters.AddWithValue("@status", "בטיפול");
                    MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                    connection.Close();
                    for (int i = 0; i < forSale.Rows.Count; i++)
                    {
                        strFun = "INSERT `orders`(`phoneNumber`, `parCode`, `orderId`, `amount`, `stauts`, `timeOrder`, `dateOrder`) VALUES" +
                                        "(@phoneNumber,@parCode,@orderId,@amount,@stauts,@timeOrder,@dateOrder)";
                        MyCommand2 = new(strFun, connection);
                        connection.Open();
                        MyCommand2.Parameters.AddWithValue("@phoneNumber", nameCustumer);
                        MyCommand2.Parameters.AddWithValue("@parCode", forSale.Rows[i].Cells[2].Value);
                        MyCommand2.Parameters.AddWithValue("@orderId", count);
                        MyCommand2.Parameters.AddWithValue("@amount", forSale.Rows[i].Cells[3].Value);
                        MyCommand2.Parameters.AddWithValue("@stauts", "בטיפול");
                        MyCommand2.Parameters.AddWithValue("@timeOrder", DateTime.Now.ToLongTimeString());
                        MyCommand2.Parameters.AddWithValue("@dateOrder", DateTime.Now.ToShortDateString());
                        MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                        connection.Close();
                    }

                    MessageBox.Show("שמרת הזמנה התבצעה בהצלחה ,מספר הזמנה שלכה הוא " + count);
                    //CustomerSignIn_FormClosed(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
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
                try
                {
                    string strFun;
                    strFun = "SELECT * FROM `orders` " +
                        $"WHERE `phoneNumber`={nameCustumer} AND `orderId`={dataGridView1.Rows[e.RowIndex].Cells[1].Value}";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    DataTable dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
                    orderDe.DataSource = dataTable;
                    //the number off the custmer to be used in the logo style
                    string phoneNumber = orderDe.Columns[0].ToString();
                    orderDe.Columns[0].Visible = false; //the number of customer  
                    // we can add the name of the prodact insted of the phone number in this taple?
                    orderDe.Columns[1].HeaderText = "ברקוד";
                    orderDe.Columns[2].HeaderText = "מספר הזמנה";
                    orderDe.Columns[3].HeaderText = "כמות";
                    orderDe.Columns[4].HeaderText = "סטטוס הזמנה";
                    orderDe.Columns[5].HeaderText = "שעת הזמנה";
                    orderDe.Columns[6].HeaderText = "תאריך ושעת הזמנה";
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
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
                try
                {
                    string strFun = "SELECT * FROM `items`ORDER BY BINARY `typeCar` ASC;";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    MySqlDataAdapter adapter = new(MyCommand2);
                    DataTable dataTable1 = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable1);
                    dataTable = dataTable1;
                    // Bind the DataTable to the DataGridView
                    itemToCustomer.DataSource = dataTable;
                    EmtpyItems();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    CustomerSignIn_FormClosed(null, null);
                    connection.Close();
                }
            }
            itemToCustomer.Refresh();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tab_PDF.TabCount;)
                tab_PDF.TabPages.Remove(tab_PDF.TabPages[0]);
            if (tabControl1.SelectedIndex == 0)
                try
                {
                    MySqlDataAdapter adapter = new(MyCommand2);
                    string strFun = "SELECT * FROM `items` WHERE `available`=\"פעיל\"   ORDER BY BINARY `typeCar` ASC";
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);
                    adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
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
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    CustomerSignIn_FormClosed(null, null);
                    connection.Close();
                }
            else if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    tab_PDF.TabPages.Add(tabPage4);
                    string strFun;

                    strFun = "SELECT * FROM `payTable` WHERE `phoneNumber` = " + nameCustumer;
                    connection.Open();
                    MyCommand2 = new MySqlCommand(strFun, connection);

                    MySqlDataAdapter adapter1 = new(MyCommand2);
                    DataTable dataTable = new();

                    // Fill the DataTable with the query results
                    adapter1.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "מספר הזמנה";
                    dataGridView1.Columns[2].HeaderText = "מחיר תשלום";
                    dataGridView1.Columns[3].HeaderText = "מצב הזמנה";
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                tab_PDF.TabPages.Add(tabPage5);

            }


        }

        private void PDF_Button_order_Click(object sender, EventArgs e)
        {
            SavePdfFile(dataGridView1, "test", 0);
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
                document= new iTextSharp.text.Document();
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
                Font font = new Font(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
                Paragraph title = new Paragraph(titleStr, font);
                PdfPCell cell = new PdfPCell(title);
                cell.Border = 0; // Remove cell borders if needed
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                saveTablePdf = new PdfPTable(1);
                saveTablePdf.AddCell(cell);
                document.Add(saveTablePdf);
                /*creat title in pdf*/
                if (fileNum == 0)
                    SaveTableFont(data.ColumnCount);
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
                    for (int i = 0; i < data.ColumnCount; i++)
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
                        for (int j = 0; j < data.ColumnCount; j++)
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
