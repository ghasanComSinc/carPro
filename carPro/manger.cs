using MySql.Data.MySqlClient;
using System.Data;
using Image = System.Drawing.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using System.Windows.Forms;
using iText.Kernel.Geom;
using iText.IO.Image;
using Point = System.Drawing.Point;

namespace carPro
{
    public partial class Manger : Form
    {
        public string phone_number;
        readonly MySqlConnection con;
        MySqlCommand MyCommand2;
        DataTable dataTable;
        bool flagImg;
        int index;
        private string oldPar, oldId;
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document doc;
        readonly static string path = @"VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font tableFont;
        readonly MangerDb mangerDb;
        public Manger()
        {
            InitializeComponent();
            ExPDF.SizeMode = TabSizeMode.Fixed;
            ExPDF.ItemSize = new Size(0, 1);
            ExPDF.Appearance = TabAppearance.FlatButtons;
            mangerDb = new();
        }
        private void CheckUser()
        {
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = $"phoneNumber = '{userName.Text}'";
            users.Refresh();
        }
        private void AddU_Click(object sender, EventArgs e)
        {
            CheckUser();
            if (users.Rows.Count == 1)
            {
                MessageBox.Show("משתמש קיים");
            }
            else
            {
                string uName = name.Text;
                string phone = userName.Text;
                string password = pass.Text;
                string stat = status.Text;
                if (uName == "")
                {
                    MessageBox.Show("שם עובד ריק");
                }
                else if (phone == "")
                {
                    MessageBox.Show("שם מספר טלפון ריק");
                }
                else if (password == "")
                {
                    MessageBox.Show("סיסמה ריק");
                }
                else if (stat == "")
                {
                    MessageBox.Show("תפקיד ריק");
                }
                else
                {
                    if (mangerDb.InsertUser(uName, phone, password, stat) == false)
                    {
                        this.Close(); return;
                    }
                    TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
                }
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteItems.Visible = false;
            for (int i = 0; i < ExPDF.TabCount;)
                ExPDF.TabPages.Remove(ExPDF.TabPages[0]);
            if (tab.TabPages.Count == 4 && tab.SelectedIndex != 3)
                tab.TabPages.Remove(tab.TabPages[3]);
            string strFun;
            statusOrder.Visible = false;
            if (tab.SelectedIndex == 0)
            {
                ExPDF.TabPages.Add(ItmesPDF);
                dataTable = mangerDb.ReturnAllTable("SELECT * FROM `items`");
                items.DataSource = dataTable;
                items.Columns[0].HeaderText = "שם מוצר";
                items.Columns[1].HeaderText = "סוג רכב";
                items.Columns[2].HeaderText = "מקום בחנות";
                items.Columns[3].HeaderText = "פר";
                items.Columns[4].HeaderText = "מחיר";
                items.Columns[5].HeaderText = "מחיר קניה";
                items.Columns[6].HeaderText = "תמונה";
                items.Columns[5].Visible = false;//payPrice
                items.Columns[6].Visible = false;//image
                items.Columns[7].HeaderText = "קמות בחנות";
                items.Columns[8].HeaderText = "הערה";
                items.Columns[9].HeaderText = "זמין";
            }
            else if (tab.SelectedIndex == 1)
            {
                ExPDF.TabPages.Add(ExpUserPDF);
                // Bind the DataTable to the DataGridView
                dataTable = mangerDb.ReturnAllTable("SELECT * FROM `UserTable`");
                users.DataSource = dataTable;
                users.Columns[0].HeaderText = "מספר טלפון";
                users.Columns[1].HeaderText = "סיסמה";
                users.Columns[2].HeaderText = "שם";
                users.Columns[3].HeaderText = "תפקיד";
                users.Columns[4].HeaderText = "תאריך התחלה";
                users.Columns[5].HeaderText = "תאריך סיום";
                users.Columns[6].HeaderText = "משתמש פעיל ";
            }
            else if (tab.SelectedIndex == 2)
            {
                ExPDF.TabPages.Add(ordersPDF);
                statusOrder.Visible = true;
                statusOrder.SelectedIndex = 0;
                orders.DataSource = mangerDb.ReturnAllTable("SELECT * FROM `paytable`");
                orders.Columns[0].HeaderText = "מספר טלפון";
                orders.Columns[1].HeaderText = "מזה הזמנה";
                orders.Columns[2].HeaderText = "מחיר";
                orders.Columns[3].HeaderText = "מצב של הזמנה";

            }
        }
        private void Manger_Load(object sender, EventArgs e)
        {
            TabControl1_SelectedIndexChanged(sender, e);
            ExPDF.TabPages.Remove(ordersPDF);
        }
        private void Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                updateU.Visible = true;
                deletU.Visible = true;
                addU.Visible = false;
                name.Text = users.Rows[e.RowIndex].Cells[2].Value.ToString();
                pass.Text = users.Rows[e.RowIndex].Cells[1].Value.ToString();
                userName.Text = users.Rows[e.RowIndex].Cells[0].Value.ToString();
                oldId = userName.Text;
                status.Text = users.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (status.Text == "מנהל")
                    status.SelectedIndex = 0;
                else if (status.Text == "עובד")
                    status.SelectedIndex = 1;
                else
                    status.SelectedIndex = 2;
                index = e.RowIndex;
            }
        }
        private void Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Users_CellContentClick(sender, e);
        }
        private void UpdateU_Click(object sender, EventArgs e)
        {
            string uName = name.Text;
            string userNa = userName.Text;
            string password = pass.Text;
            string stat = status.Text;
            if (uName == "")
            {
                MessageBox.Show("שם עובד ריק");
            }
            else if (userNa == "")
            {
                MessageBox.Show("מספר טלפון ריק");
            }
            else if (password == "")
            {
                MessageBox.Show("סיסמה ריק");
            }
            else if (stat == "")
            {
                MessageBox.Show("תפקיד ריק");
            }
            else
            {
                if (mangerDb.UpdateUser(userNa, password, uName, stat, oldId) == false)
                { this.Close(); return; }
                phone_number = userNa;
            }
            TabControl1_SelectedIndexChanged(sender, e);
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            updateU.Visible = false;
            deletU.Visible = false;
            addU.Visible = true;
            name.Text = "";
            pass.Text = "";
            status.Text = "";
            userName.Text = "";
            userName.ReadOnly = false;
            TabControl1_SelectedIndexChanged(sender, e);
        }
        private void DeletU_Click(object sender, EventArgs e)
        {
            string userNa = userName.Text;
            string stat = status.Text;
            string strFun;
            if (stat == "מנהל" && users.Rows[index].Cells[6].Value.ToString() == "פעיל")
            {
                int count = mangerDb.mangerCount(stat);
                if (count < 0)
                {
                    this.Close(); return;
                }
                else
                if (count == 1)
                {
                    MessageBox.Show("קיים רק מנהיל יחד אי אפשר למחוק"); return;
                }
            }
            if (mangerDb.deletUser(users.Rows[index].Cells[6].Value.ToString(), userNa) == false)
            {
                this.Close(); return;
            }
            TabControl1_SelectedIndexChanged(sender, e);
            Button1_Click_1(sender, e);
        }
        private void SearchItems()
        {
            DataView dataView = dataTable.DefaultView;
            dataView.RowFilter = $"parCode = '{parCode.Text}'"; ;
            items.Refresh();
        }
        private void Add_item_Click(object sender, EventArgs e)
        {
            SearchItems();
            if (items.RowCount == 1)
                MessageBox.Show("מוצר קיים");
            else
            {
                bool priceFlagSale;
                bool priceFlagPay;
                string nameIt = nameItem.Text;
                string carType = typeCar.Text;
                string placeInSh = placeInShop.Text;
                string parC = parCode.Text;
                string comn = comnet.Text;
                MemoryStream ms = new();
                //all the if gona be here !!!
                if (float.TryParse(price.Text, out float salePrice))
                {
                    if (salePrice <= 0 || price.Text == "")
                    {
                        priceFlagSale = true;
                    }
                    else
                    {
                        priceFlagSale = false;
                    }
                }
                else
                {
                    priceFlagSale = true;
                }
                if (float.TryParse(price.Text, out float payPrice))
                {
                    if (payPrice <= 0 || paySale.Text == "")
                    {
                        priceFlagPay = true;
                    }
                    else
                    {
                        priceFlagPay = false;
                    }
                }
                else { priceFlagPay = true; }
                if (nameIt == "")
                {
                    MessageBox.Show("שם מוצר ריק");
                }
                else if (carType == "")
                {
                    MessageBox.Show("סוג רכב ריק");
                }
                else if (priceFlagSale)
                {
                    MessageBox.Show("מחיר מכירה ריק/שלילי");
                }
                else if (priceFlagPay)
                {
                    MessageBox.Show("מחיר קניה ריק/שלילי");
                }
                else if (parC == "")
                {
                    MessageBox.Show("פ'ר קוד ריק");
                }
                else if (placeInSh == "")
                {
                    MessageBox.Show("מקום של מוצר ריק");
                }
                else if (Amount.Text == "")
                {
                    MessageBox.Show("כמות ריק");
                }
                else if (int.TryParse(Amount.Text, out int amou) && amou <= 0)
                {
                    MessageBox.Show("כמות שלילית");
                }
                else if (picPath.Image == null)
                {
                    MessageBox.Show("תמונה ריקה");
                }
                else
                {

                    picPath.Image.Save(ms, picPath.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (mangerDb.insertItem(nameIt, carType, placeInSh, parC, salePrice, payPrice, img, amou, comn) == false)
                    {
                        this.Close(); return;
                    }
                    nameItem.Text = "";
                    typeCar.Text = "";
                    placeInShop.Text = "";
                    parCode.Text = "";
                    price.Text = "";
                    paySale.Text = "";
                    Amount.Text = "";
                    picPath.Controls.Clear();
                    comnet.Text = "";
                }
                TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
            }
        }
        private void PicPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "Image File(*.jpg; *.jpeg;*.gif;*.bmp;*.png;)|*.jpg; *.jpeg;*.gif;*.bmp;*.png;"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picPath.Image = Image.FromFile(ofd.FileName);
                flagImg = true;
            }
        }
        private void Search_box_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = dataTable.DefaultView;
            if (searchItem.Text != "")
            {
                if (searchItem.Text == "פ\"ר קוד")
                    dataView.RowFilter = $"parCode LIKE '%{search_box.Text}%'";
                else if (searchItem.Text == "סוג רכב")
                    dataView.RowFilter = $"typeCar LIKE '%{search_box.Text}%'";
                else
                    dataView.RowFilter = $"nameItmes LIKE '%{search_box.Text}%'";
            }
            items.Refresh();
        }
        private void Items_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = items.HitTest(e.X, e.Y);

            if (hitTestInfo.RowIndex >= 0)
            {
                int rowIndex = hitTestInfo.RowIndex;
                DataGridViewCell selectedCell = items.Rows[rowIndex].Cells[6];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    pictureBox1.Image = Image.FromStream(ms);

                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        private void Items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                deleteItems.Visible = true;
                flagImg = false;
                nameItem.Text = items.Rows[e.RowIndex].Cells[0].Value.ToString();
                typeCar.Text = items.Rows[e.RowIndex].Cells[1].Value.ToString();
                placeInShop.Text = items.Rows[e.RowIndex].Cells[2].Value.ToString();
                parCode.Text = items.Rows[e.RowIndex].Cells[3].Value.ToString();
                oldPar = parCode.Text;
                price.Text = items.Rows[e.RowIndex].Cells[4].Value.ToString();
                paySale.Text = items.Rows[e.RowIndex].Cells[5].Value.ToString();
                Amount.Text = items.Rows[e.RowIndex].Cells[7].Value.ToString();
                DataGridViewCell selectedCell = items.Rows[e.RowIndex].Cells[6];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    using MemoryStream ms = new(imageData);
                    picPath.Image = Image.FromStream(ms);
                }
                comnet.Text = items.Rows[e.RowIndex].Cells[8].Value.ToString();
                add_item.Visible = false;
                updateItems.Visible = true;
                index = e.RowIndex;
            }
        }
        private void ClearItmesDetla()
        {
            nameItem.Text = "";
            typeCar.Text = "";
            placeInShop.Text = "";
            parCode.Text = "";
            price.Text = "";
            paySale.Text = "";
            Amount.Text = "";
            picPath.Image = null;
            add_item.Visible = true;
            updateItems.Visible = false;
            comnet.Text = "";
            parCode.ReadOnly = false;
        }
        private void UpdateItems_Click(object sender, EventArgs e)
        {
            bool priceFlagSale;
            bool priceFlagPay;
            string nameIt = nameItem.Text;
            string carType = typeCar.Text;
            string placeInSh = placeInShop.Text;
            string parC = parCode.Text;
            string comn = comnet.Text;
            MemoryStream ms;
            byte[] img = null;
            //all the if gona be here !!!
            if (flagImg)
            {
                ms = new();
                picPath.Image.Save(ms, picPath.Image.RawFormat);
                img = ms.ToArray();
            }
            else
            {
                DataGridViewCell selectedCell = items.Rows[index].Cells[7];
                if (selectedCell.Value != null && selectedCell.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])selectedCell.Value;
                    ms = new(imageData);
                    picPath.Image = Image.FromStream(ms);
                }
            }
            if (float.TryParse(price.Text, out float salePrice))
            {
                if (salePrice <= 0 || price.Text == "")
                {
                    priceFlagSale = true;
                }
                else
                {
                    priceFlagSale = false;
                }
            }
            else
            {
                priceFlagSale = true;
            }
            if (float.TryParse(paySale.Text, out float payPrice))
            {
                if (payPrice <= 0 || paySale.Text == "")
                {
                    priceFlagPay = true;
                }
                else
                {
                    priceFlagPay = false;
                }
            }
            else { priceFlagPay = true; }
            if (nameIt == "")
            {
                MessageBox.Show("שם מוצר ריק");
            }
            else if (carType == "")
            {
                MessageBox.Show("סוג רכב ריק");
            }
            else if (priceFlagSale)
            {
                MessageBox.Show("מחיר מכירה ריק/שלילי");
            }
            else if (priceFlagPay)
            {
                MessageBox.Show("מחיר קניה ריק/שלילי");
            }
            else if (parC == "")
            {
                MessageBox.Show("פ'ר קוד ריק");
            }
            else if (placeInSh == "")
            {
                MessageBox.Show("מקום של מוצר ריק");
            }
            else if (Amount.Text == "")
            {
                MessageBox.Show("כמות ריק");
            }
            else if (int.TryParse(Amount.Text, out int amou) && amou < 0)
            {
                MessageBox.Show("כמות שלילית");
            }
            else if (picPath.Image == null)
            {
                MessageBox.Show("תמונה ריקה");
            }
            else if (comn == "")
            {
                MessageBox.Show("פרטים של מוצר ריק");
            }
            //all the if's end's here
            else
            {
                if (mangerDb.updateItem(flagImg, nameIt, carType, placeInSh, parC, salePrice, payPrice, img, amou, comn, oldPar) == false)
                { this.Close(); return; }
                TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
                ClearItmesDetla();
            }
        }
        private void Items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Items_CellContentClick(sender, e);
        }
        private void SinC_Click(object sender, EventArgs e)
        {
            CustomerSignIn cust = new()
            {
                PhoneNum = phone_number,
                Location = new System.Drawing.Point(this.Location.X, this.Location.Y),
                Size = this.Size
            };
            this.Hide();
            cust.ShowDialog();
            this.Show();
            Manger_Load(sender, e);
        }
        private void SinEm_Click(object sender, EventArgs e)
        {
            Employee employee = new()

            {
                employName = phone_number
            };
            this.Hide();

            employee.ShowDialog();
            this.Show();
            Manger_Load(sender, e);
        }
        private void StatusOrder_SelectedItemChanged(object sender, EventArgs e)
        {
            string strFun;
            if (statusOrder.SelectedIndex == 0)
            {
                strFun = "SELECT * FROM `paytable`";
            }
            else if (statusOrder.SelectedIndex == 1)
            {
                strFun = "SELECT * FROM `paytable` WHERE `status`=\"בוצעה בהצלחה\"";
            }
            else if (statusOrder.SelectedIndex == 2)
            {
                strFun = "SELECT * FROM `paytable` WHERE `status`=\"בטיפול\"";
            }
            else
            {
                strFun = "SELECT * FROM `paytable` WHERE `status`=\"בוטלה\"";
            }
            dataTable = mangerDb.returnSaleWithSta(strFun);
            if (dataTable == null)
            {
                this.Close(); return;
            }
            orders.DataSource = dataTable;
            orders.Columns[0].HeaderText = "מספר טלפון";
            orders.Columns[1].HeaderText = "מזה הזמנה";
            orders.Columns[2].HeaderText = "מחיר";
            orders.Columns[3].HeaderText = "מצב";
        }
        private void Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tab.TabPages.Add(ordersD);
            tab.SelectedIndex = 3;
            dataTable = mangerDb.returnItemSale(orders.Rows[e.RowIndex].Cells[0].Value.ToString(), orders.Rows[e.RowIndex].Cells[1].Value.ToString());
            orderD.DataSource = dataTable;
            orderD.Columns[0].HeaderText = "מספר טלפון";
            orderD.Columns[0].Visible = false;
            orderD.Columns[1].HeaderText = "פר";
            orderD.Columns[2].HeaderText = "מזה הזמנה";
            orderD.Columns[2].Visible = false;
            orderD.Columns[3].HeaderText = "כמות רצויה";
            orderD.Columns[4].HeaderText = "מצב של מוצר";//status
            orderD.Columns[5].HeaderText = "שעת קניה";
            orderD.Columns[6].HeaderText = "תאריך קניה";
            orderD.Columns[7].HeaderText = "שם מוצר";
            orderD.Columns[8].HeaderText = "סוג רכב";
            orderD.Columns[9].HeaderText = "מיקום בחנות";
            orderD.Columns[10].Visible = false;//parcode
            orderD.Columns[11].HeaderText = "מחיר";
            orderD.Columns[12].Visible = false;//paypri
            orderD.Columns[13].Visible = false;//pic
            orderD.Columns[14].Visible = false;// "קמות בחנות";
            orderD.Columns[15].HeaderText = "הערה על מוצר";
            orderD.Columns[16].Visible = false;// "מצב של מוצר";
            ExPDF.TabPages.Add(ordersDe);
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
        //1=ספרת מלי
        //0=משתמשים,הזמנות
        private void SavePdfFile(DataGridView data, string titleStr, int fileNum)
        {
            saveFileFromManger.FileName = string.Empty;
            saveFileFromManger.Filter = "PDF Files|*.pdf";
            if (saveFileFromManger.ShowDialog() == DialogResult.OK)
            {
                doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(saveFileFromManger.FileName, FileMode.Create));
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
                Paragraph title = new(titleStr, font);
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
                doc.Add(saveTablePdf);
                doc.Close();
                MessageBox.Show("הפעולה הסתימה בהצלחה");
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            SavePdfFile(items, "דוח ספרת מלי ", 1);
        }
        private void ExPDFOr_Click(object sender, EventArgs e)
        {
            SavePdfFile(orders, "דוח של הזמנות", 0);
        }
        private void PDFUser_Click(object sender, EventArgs e)
        {
            SavePdfFile(users, "דוח של משתמשים", 0);
        }
        private void ExPDFDeOr_Click(object sender, EventArgs e)
        {
            saveFileFromManger.FileName = string.Empty;
            saveFileFromManger.Filter = "PDF Files|*.pdf";
            if (saveFileFromManger.ShowDialog() == DialogResult.OK)
            {
                doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(saveFileFromManger.FileName, FileMode.Create));
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
                saveTablePdf.AddCell(new Phrase(orderD.Columns[0].HeaderText + ":" + orderD.Rows[0].Cells[0].Value.ToString(), tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[2].HeaderText + ":" + orderD.Rows[0].Cells[2].Value.ToString(), tableFont));
                doc.Add(saveTablePdf);
                saveTablePdf = new iTextSharp.text.pdf.PdfPTable(6)
                {
                    HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                    RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
                };
                saveTablePdf.AddCell(new Phrase(orderD.Columns[7].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[1].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[3].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[4].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[5].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(orderD.Columns[6].HeaderText, tableFont));
                for (int i = 0; i < orderD.Rows.Count; i++)
                {
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[7].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[1].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[3].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[4].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[5].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(orderD.Rows[i].Cells[6].Value.ToString(), tableFont));
                }
                doc.Add(saveTablePdf);
                doc.Close();
            }
        }
        private void DeleteItems_Click(object sender, EventArgs e)
        {
            if (mangerDb.delItems(items.Rows[index].Cells[9].Value.ToString(), items.Rows[index].Cells[3].Value.ToString()) == false)
            { this.Close(); return; }
            TabControl1_SelectedIndexChanged(sender, e);
            Button1_Click_1(sender, e);
            ClearItmesDetla();
        }
    }
}