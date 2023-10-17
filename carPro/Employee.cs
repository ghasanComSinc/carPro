using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Image = System.Drawing.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace carPro
{
    public partial class Employee : Form
    {
        public string employName;//phone
        public bool man = false;
        readonly MySqlConnection connection = new("server=localhost;user=root;database=carshop;password=");
        MySqlCommand command;
        DataTable dataTable;
        /*pdfFile*/
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document doc;
        readonly static string path = @"C:\Users\ASUS\Desktop\VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        // iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(@"D:\autocar_path\VarelaRound-Regular.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font tableFont;

        public Employee()
        {
            InitializeComponent();
            tab_PDF.SizeMode = TabSizeMode.Fixed;
            tab_PDF.ItemSize = new Size(0, 1);
            tab_PDF.Appearance = TabAppearance.FlatButtons;
        }
        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            employeName.Text = "ברוך הבאה עובד יקר ";
            tabControl1.TabPages.Remove(tabPage2);
            try
            {
                tab_PDF.SelectedIndex = 0;
                string strFun;
                strFun = "SELECT * FROM `paytable` WHERE `status`=\"בטיפול\"";
                connection.Open();
                command = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(command);
                dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                orders.DataSource = dataTable;
                orders.Columns[0].HeaderText = "מספר טלפון";
                orders.Columns[1].HeaderText = "מזה הזמנה";
                orders.Columns[2].HeaderText = "לתשלום";
                orders.Columns[2].HeaderText = "מצב";
                orders.Columns[3].Visible = false;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Employee_FormClosed(null, null);
                connection.Close();
            }
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
            //7 10
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
            try
            {
                string strFun;
                strFun = "SELECT * FROM `orders` join `items` ON `orders`.`parCode` = `items`.`parCode`" +
                    $"WHERE `phoneNumber`={orders.Rows[index].Cells[0].Value} AND `orderId`='{orders.Rows[index].Cells[1].Value}'";
                connection.Open();
                command = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(command);
                dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                connection.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
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
                    try
                    {
                        string strFun = "UPDATE `items` SET   `amount`=@amountIt WHERE `parCode`=@id";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        MySqlDataAdapter adapter = new(command);
                        float amount = float.Parse(itemsInOrder.Rows[i].Cells[14].Value.ToString()) - float.Parse(itemsInOrder.Rows[i].Cells[3].Value.ToString());
                        command.Parameters.AddWithValue("@amountIt", amount.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                        strFun = "UPDATE `orders` SET `stauts`=@statusIt WHERE `phoneNumber`=@idCustm AND `orderId`=@id AND `parCode`=@par";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        adapter = new(command);
                        command.Parameters.AddWithValue("@statusIt", "בוצעה בהצלחה");
                        command.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[0].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[2].Value.ToString());
                        command.Parameters.AddWithValue("@par", itemsInOrder.Rows[i].Cells[10].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    try
                    {
                        String strFun = "UPDATE `orders` SET  `stauts`=@statusIt WHERE `phoneNumber`=@idCustm AND `orderId`=@id AND `parCode`=@par";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        MySqlDataAdapter adapter = new(command);
                        command.Parameters.AddWithValue("@statusIt", "בוטלה");
                        command.Parameters.AddWithValue("@idCustm", itemsInOrder.Rows[i].Cells[0].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[2].Value.ToString());
                        command.Parameters.AddWithValue("@par", itemsInOrder.Rows[i].Cells[10].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
            }
            return flag;
        }
        private void PayBu_Click(object sender, EventArgs e)
        {
            string strFun;
            if (UpdateItems() == false)
                strFun = "UPDATE `paytable` SET `status`= 'בוטלה' WHERE `phoneNumber`=@id AND `orderId`=@orderId";
            else
                strFun = "UPDATE `paytable` SET `status`= 'בוצעה בהצלחה' WHERE `phoneNumber`=@id AND `orderId`=@orderId";
            try
            {
                connection.Open();
                command = new MySqlCommand(strFun, connection);
                MySqlDataAdapter adapter = new(command);
                command.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[0].Value.ToString());
                command.Parameters.AddWithValue("@orderId", itemsInOrder.Rows[0].Cells[2].Value.ToString());
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("הזמנה בוצעתה בהצלחה");
                Employee_Load(sender, e);
                Label2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < itemsInOrder.Rows.Count; i++)
            {
                if (itemsInOrder.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                {
                    try
                    {
                        string strFun = "UPDATE `orders` SET `amount`=@amountS WHERE `phoneNumber`=@id AND `parCode`=@par AND `orderId`=@idOr";
                        connection.Open();
                        command = new MySqlCommand(strFun, connection);
                        command.Parameters.AddWithValue("@amountS", itemsInOrder.Rows[i].Cells[14].Value.ToString());
                        command.Parameters.AddWithValue("@id", itemsInOrder.Rows[i].Cells[0].Value);
                        command.Parameters.AddWithValue("@par", itemsInOrder.Rows[i].Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@idOr", itemsInOrder.Rows[i].Cells[2].Value.ToString());
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("עדכון מוצר התבציע בהצלחה");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
            }
            ////////////////////////////////////////////
            try
            {
                FillDetItem(0);
                string strFun1 = "UPDATE `paytable` SET `price`=@price WHERE `phoneNumber`=@id AND `orderId`=@orderId";
                connection.Open();
                command = new MySqlCommand(strFun1, connection);
                command.Parameters.AddWithValue("@price", Regex.Match(pay.Text.ToString(), @"\d+").Value);
                command.Parameters.AddWithValue("@id", itemsInOrder.Rows[0].Cells[0].Value);
                command.Parameters.AddWithValue("@orderId", itemsInOrder.Rows[0].Cells[2].Value.ToString());
                command.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.     
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
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
                Location = new System.Drawing.Point(this.Location.X, this.Location.Y),
                Size = this.Size
            };
            this.Hide();   
            cust.ShowDialog();
            this.Show();
            Employee_Load(sender, e);

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
        private void FillFileDe(DataGridView data)
        {
            for (int j = 0; j < data.ColumnCount; j++)
            {
                if (data.Columns[j].Visible == true)
                    saveTablePdf.AddCell(new Phrase(data.Columns[j].HeaderText, tableFont));
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    if (data.Rows[i].Cells[j].Visible == true)
                        saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[j].Value.ToString(), tableFont));
                }
            }
        }
        private void PDF_Button_order_Click(object sender, EventArgs e)
        {
            saveFileFromEmploye.FileName = string.Empty;
            saveFileFromEmploye.Filter = "PDF Files|*.pdf";
            if (saveFileFromEmploye.ShowDialog() == DialogResult.OK)
            {
                doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(saveFileFromEmploye.FileName, FileMode.Create));
                doc.Open();
                /*put image*/
                //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:\\autopatr\\images.jpeg");
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\source\\repos\\carPro\\carPro\\plus.png");
                img.ScaleToFit(200f, 200f); // Adjust the width and height as needed
                img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                doc.Add(img);
                /*put image*/
                /*creat title in pdf*/
                Font font = new(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
                Paragraph title = new("הזמנות", font);
                PdfPCell cell = new(title)
                {
                    Border = 0, // Remove cell borders if needed
                    RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                saveTablePdf = new PdfPTable(1);
                saveTablePdf.AddCell(cell);
                doc.Add(saveTablePdf);
                /*creat title in pdf*/
                SaveTableFont(3);
                float[] widthOfTable = new float[3];
                for (int i = 0; i < widthOfTable.Length; i++)
                {
                    widthOfTable[i] = 20f;
                }
                saveTablePdf.SetWidths(widthOfTable);
                FillFileDe(orders);
                doc.Add(saveTablePdf);
                doc.Close();
                MessageBox.Show("הפעולה הסתימה בהצלחה");
            }
        }
        private void PDF_Button_all_orders_Click(object sender, EventArgs e)
        {
            saveFileFromEmploye.FileName = string.Empty;
            saveFileFromEmploye.Filter = "PDF Files|*.pdf";
            if (saveFileFromEmploye.ShowDialog() == DialogResult.OK)
            {
                doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(saveFileFromEmploye.FileName, FileMode.Create));
                doc.Open();
                /*creat title in pdf*/
                Font font = new(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
                Paragraph title = new("פרטי הזמנה ", font);
                PdfPCell cell = new(title)
                {
                    Border = 0, // Remove cell borders if needed
                    RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                saveTablePdf = new PdfPTable(1);
                saveTablePdf.AddCell(cell);
                doc.Add(saveTablePdf);
                /*creat title in pdf*/
                tableFont = new Font(tableFont1, 12)
                {
                    Color = BaseColor.BLACK
                };
                saveTablePdf = new PdfPTable(1)
                {
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    DefaultCell = { BorderWidth = 0 },
                    RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
                };
                saveTablePdf.AddCell(new Phrase(itemsInOrder.Columns[0].HeaderText + ":" + itemsInOrder.Rows[0].Cells[0].Value.ToString(), tableFont));
                saveTablePdf.AddCell(new Phrase(itemsInOrder.Columns[2].HeaderText + ":" + itemsInOrder.Rows[0].Cells[2].Value.ToString(), tableFont));
                doc.Add(saveTablePdf);
                saveTablePdf = new iTextSharp.text.pdf.PdfPTable(9)
                {
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
                };
                FillFileDe(itemsInOrder);
                doc.Add(saveTablePdf);
                doc.Close();
                MessageBox.Show("הפעולה הסתימה בהצלחה");
            }
        }
    }
}

