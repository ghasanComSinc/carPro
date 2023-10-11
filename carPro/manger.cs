using iText.Kernel.Pdf;
using iText.StyledXmlParser.Jsoup.Nodes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.Metadata;
using Image = System.Drawing.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace carPro
{
    public partial class Manger : Form
    {
        public string phone_number;
        readonly MySqlConnection con = new("server=localhost;user=root;database=carshop;password=");
        MySqlCommand MyCommand2;
        DataTable dataTable;
        bool flagImg;
        int index;
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document doc;
        public Manger()
        {
            InitializeComponent();
            ExPDF.SizeMode = TabSizeMode.Fixed;
            ExPDF.ItemSize = new Size(0, 1);
            ExPDF.Appearance = TabAppearance.FlatButtons;

        }
        private void Manger_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInForm logIn = new();
            this.Dispose();
            logIn.ShowDialog();
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
                    try
                    {
                        string strFun;

                        strFun = "INSERT INTO `usertable`(`phoneNumber`, `password`, `name`, `status`, `start_date`, `last_date`, `available`) VALUES " +
                                                        "(@phone,@password,@name,@status,@start_date,@last_date,@available)";
                        MyCommand2 = new MySqlCommand(strFun, con);
                        con.Open();
                        MyCommand2.Parameters.AddWithValue("@phone", phone);
                        MyCommand2.Parameters.AddWithValue("@password", password);
                        MyCommand2.Parameters.AddWithValue("@name", uName);
                        MyCommand2.Parameters.AddWithValue("@status", stat);
                        MyCommand2.Parameters.AddWithValue("@start_date", DateTime.Now);
                        MyCommand2.Parameters.AddWithValue("@last_date", "");
                        MyCommand2.Parameters.AddWithValue("@available", "פעיל");
                        MyCommand2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("הוספת משתמשם הצליחה");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                    TabControl1_SelectedIndexChanged(sender, EventArgs.Empty);
                }
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExPDF.TabPages.Remove(ItmesPDF);
            ExPDF.TabPages.Remove(ordersPDF);
            string strFun;
            statusOrder.Visible = false;
            if (tab.SelectedIndex == 0)
            {
                try
                {
                    ExPDF.TabPages.Add(ItmesPDF);
                    strFun = "SELECT * FROM `items`";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
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
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            else if (tab.SelectedIndex == 1)
            {
                try
                {
                    strFun = "SELECT * FROM `UserTable`";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
                    users.DataSource = dataTable;
                    users.Columns[0].HeaderText = "מספר טלפון";
                    users.Columns[1].HeaderText = "סיסמה";
                    users.Columns[2].HeaderText = "שם";
                    users.Columns[3].HeaderText = "תפקיד";
                    users.Columns[4].HeaderText = "תאריך התחלה";
                    users.Columns[5].HeaderText = "תאריך סיום";
                    users.Columns[6].HeaderText = "משתמש פעיל ";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            else if (tab.SelectedIndex == 2)
            {
                ExPDF.TabPages.Add(ordersPDF);
                statusOrder.Visible = true;
                statusOrder.SelectedIndex = 0;
                try
                {
                    strFun = "SELECT * FROM `paytable`";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MySqlDataAdapter adapter = new(MyCommand2);
                    dataTable = new();
                    // Fill the DataTable with the query results
                    adapter.Fill(dataTable);
                    // Bind the DataTable to the DataGridView
                    orders.DataSource = dataTable;
                    orders.Columns[0].HeaderText = "מספר טלפון";
                    orders.Columns[1].HeaderText = "מזה הזמנה";
                    orders.Columns[2].HeaderText = "מחיר";
                    orders.Columns[3].HeaderText = "מצב";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }
        private void Manger_Load(object sender, EventArgs e)
        {
            TabControl1_SelectedIndexChanged(sender, e);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
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
                userName.ReadOnly = true;
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
            try
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
                    string strFun = "UPDATE `usertable` SET `password`=@pass,`name`=@name" +
                                    ",`status`=@status WHERE `phoneNumber`=@phone";
                    con.Open();
                    MyCommand2 = new MySqlCommand(strFun, con);
                    MyCommand2.Parameters.AddWithValue("@pass", password);
                    MyCommand2.Parameters.AddWithValue("@name", uName);
                    MyCommand2.Parameters.AddWithValue("@status", stat);
                    MyCommand2.Parameters.AddWithValue("@phone", userNa);
                    MyCommand2.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                string userNa = userName.Text;
                string stat = status.Text;
                string strFun;
                if (stat == "מנהל" && users.Rows[index].Cells[6].Value.ToString() == "פעיל")
                {
                    strFun = "SELECT COUNT(*) FROM `usertable` WHERE `status`=@manger AND `available`=@act";
                    con.Open();
                    MyCommand2 = new MySqlCommand(strFun, con);
                    MyCommand2.Parameters.AddWithValue("@manger", stat);
                    MyCommand2.Parameters.AddWithValue("@act", "פעיל");
                    int count = Convert.ToInt32(MyCommand2.ExecuteScalar());
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("קיים רק מנהיל יחד אי אפשר למחוק"); return;
                    }
                }

                strFun = "UPDATE `usertable` SET `last_date`= @last,`available`= @av WHERE `phoneNumber`= @phone";
                con.Open();
                MyCommand2 = new MySqlCommand(strFun, con);
                if (users.Rows[index].Cells[6].Value.ToString() == "פעיל")
                {
                    MyCommand2.Parameters.AddWithValue("@last", DateTime.Now);
                    MyCommand2.Parameters.AddWithValue("@av", "לא פעיל");
                }
                else
                {
                    MyCommand2.Parameters.AddWithValue("@last", "");
                    MyCommand2.Parameters.AddWithValue("@av", "פעיל");
                }
                MyCommand2.Parameters.AddWithValue("@phone", userNa);
                MyCommand2.ExecuteNonQuery();
                con.Close();
                TabControl1_SelectedIndexChanged(sender, e);
                Button1_Click_1(sender, e);
            }
            catch
            { }
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
                /* 
                 * else if (comn == "")
                 {
                     MessageBox.Show("פרטים של מוצר ריק");
                 }
                */
                //all the if's end's here
                else
                {
                    try
                    {
                        picPath.Image.Save(ms, picPath.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        string strFun = "INSERT INTO `items`(`nameItmes`, `typeCar`, `placeInShop`, `parCode`, `salePrice`, `payPrice`, `image`, `amount`, `comment`) VALUES " +
                                        "(@nameIt,@typeC,@placeSho,@parCod,@salePri,@payPrice,@image,@amount,@com)";
                        MyCommand2 = new MySqlCommand(strFun, con);
                        con.Open();
                        MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                        MyCommand2.Parameters.AddWithValue("@typeC", carType);
                        MyCommand2.Parameters.AddWithValue("@placeSho", placeInSh);
                        MyCommand2.Parameters.AddWithValue("@parCod", parC);
                        MyCommand2.Parameters.AddWithValue("@salePri", salePrice);
                        MyCommand2.Parameters.AddWithValue("@payPrice", payPrice);
                        MyCommand2.Parameters.AddWithValue("@image", img);
                        MyCommand2.Parameters.AddWithValue("@amount", amou);
                        MyCommand2.Parameters.AddWithValue("@com", comn);
                        MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.
                        MessageBox.Show("הוספת מוצר הצליחה");
                        con.Close();
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
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
                flagImg = false;
                nameItem.Text = items.Rows[e.RowIndex].Cells[0].Value.ToString();
                typeCar.Text = items.Rows[e.RowIndex].Cells[1].Value.ToString();
                placeInShop.Text = items.Rows[e.RowIndex].Cells[2].Value.ToString();
                parCode.Text = items.Rows[e.RowIndex].Cells[3].Value.ToString();
                parCode.ReadOnly = true;
                price.Text = items.Rows[e.RowIndex].Cells[4].Value.ToString();
                paySale.Text = items.Rows[e.RowIndex].Cells[5].Value.ToString();
                Amount.Text = items.Rows[e.RowIndex].Cells[5].Value.ToString();
                price.Text = items.Rows[e.RowIndex].Cells[7].Value.ToString();
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
            else if (comn == "")
            {
                MessageBox.Show("פרטים של מוצר ריק");
            }
            //all the if's end's here
            else
            {
                try
                {
                    string strFun;
                    if (flagImg)
                        strFun = "UPDATE `items` SET `nameItmes`=@nameIt,`typeCar`= @typeC,`placeInShop`= @placeSho,`parCode`= @parCod,`salePrice`=@salePri,`payPrice`=@payPrice,`image`= @images,`amount`= @amounts,`comment`= @com WHERE `parCode`= @parCod ";
                    else
                        strFun = "UPDATE `items` SET `nameItmes`=@nameIt,`typeCar`= @typeC,`placeInShop`= @placeSho,`parCode`= @parCod,`salePrice`=@salePri,`payPrice`=@payPrice,`amount`= @amounts,`comment`= @com WHERE `parCode`= @parCod ";
                    MyCommand2 = new MySqlCommand(strFun, con);
                    con.Open();
                    MyCommand2.Parameters.AddWithValue("@nameIt", nameIt);
                    MyCommand2.Parameters.AddWithValue("@typeC", carType);
                    MyCommand2.Parameters.AddWithValue("@placeSho", placeInSh);
                    MyCommand2.Parameters.AddWithValue("@parCod", parC);
                    MyCommand2.Parameters.AddWithValue("@salePri", salePrice);
                    MyCommand2.Parameters.AddWithValue("@payPrice", payPrice);
                    if (flagImg)
                        MyCommand2.Parameters.AddWithValue("@images", img);
                    MyCommand2.Parameters.AddWithValue("@amounts", amou);
                    MyCommand2.Parameters.AddWithValue("@com", comn);
                    MyCommand2.ExecuteNonQuery();
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("מוצר קיים");
                    con.Close();
                }
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
                nameCustumer = phone_number
            };
            this.Hide();

            cust.ShowDialog();
            this.Show();
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
        }
        private void statusOrder_SelectedItemChanged(object sender, EventArgs e)
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
            try
            {
                MyCommand2 = new MySqlCommand(strFun, con);
                con.Open();
                MySqlDataAdapter adapter = new(MyCommand2);
                dataTable = new();
                // Fill the DataTable with the query results
                adapter.Fill(dataTable);
                // Bind the DataTable to the DataGridView
                orders.DataSource = dataTable;
                orders.Columns[0].HeaderText = "מספר טלפון";
                orders.Columns[1].HeaderText = "מזה הזמנה";
                orders.Columns[2].HeaderText = "מחיר";
                orders.Columns[3].HeaderText = "מצב";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tab.SelectedIndex = 3;
            string strFun = "SELECT * FROM `orders` WHERE `phoneNumber`=@phone AND `orderId`=@orderId";
            try
            {
                MyCommand2 = new MySqlCommand(strFun, con);
                con.Open();
                MySqlDataAdapter adapter = new(MyCommand2);
                dataTable = new();
                // Fill the DataTable with the query results
                MyCommand2.Parameters.AddWithValue("@phone", orders.Rows[e.RowIndex].Cells[0].Value);
                MyCommand2.Parameters.AddWithValue("@orderId", orders.Rows[e.RowIndex].Cells[1].Value);
                adapter.Fill(dataTable);
                // Bind the DataTable to the DataGridView
                orderD.DataSource = dataTable;
                orderD.Columns[0].HeaderText = "מספר טלפון";
                orderD.Columns[1].HeaderText = "פר";
                orderD.Columns[2].HeaderText = "מזה הזמנה";
                orderD.Columns[3].HeaderText = "כמות";
                orderD.Columns[4].HeaderText = "מצב";
                orderD.Columns[5].HeaderText = "שעה";
                orderD.Columns[6].HeaderText = "תאריך";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void AddPhrase(Phrase phrase)
        {
            saveTablePdf.AddCell(phrase);
        }
        private void SaveFile()
        {
            iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Users\ASUS\Desktop\Guttman Myamfix.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font tableFont = new Font(tableFont1, 12)
            {
                Color = BaseColor.BLACK
            };
            saveTablePdf = new iTextSharp.text.pdf.PdfPTable(5)
            {
                HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            };
            saveTablePdf.RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL;
            float[] widthOfTable = new float[5];
            for (int i = 0; i < widthOfTable.Length; i++)
            {
                if (i != 3)
                    widthOfTable[i] = 20f;
                else
                    widthOfTable[i] = 90f;
            }
            saveTablePdf.SetWidths(widthOfTable);
            AddPhrase(new Phrase(items.Columns[0].HeaderText, tableFont));
            AddPhrase(new Phrase(items.Columns[1].HeaderText, tableFont));
            AddPhrase(new Phrase(items.Columns[3].HeaderText, tableFont));
            AddPhrase(new Phrase(items.Columns[5].HeaderText, tableFont));
            AddPhrase(new Phrase(items.Columns[7].HeaderText, tableFont));

            for (int i = 0; i < items.Rows.Count; i++)
            {
                if (items.Rows[i].Cells[7].Value.ToString() == "0")
                    tableFont = new Font(tableFont1, 12)
                    {
                        Color = BaseColor.RED
                    };
                else
                    tableFont = new Font(tableFont1, 12)
                    {
                        Color = BaseColor.BLACK
                    };
                AddPhrase(new Phrase(items.Rows[i].Cells[0].Value.ToString(), tableFont));
                AddPhrase(new Phrase(items.Rows[i].Cells[1].Value.ToString(), tableFont));
                AddPhrase(new Phrase(items.Rows[i].Cells[3].Value.ToString(), tableFont));
                AddPhrase(new Phrase(items.Rows[i].Cells[5].Value.ToString(), tableFont));
                AddPhrase(new Phrase(items.Rows[i].Cells[7].Value.ToString(), tableFont));
            }

            doc.Add(saveTablePdf);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            saveFileFromManger.FileName = string.Empty;
            saveFileFromManger.Filter = "PDF Files|*.pdf";
            if (saveFileFromManger.ShowDialog() == DialogResult.OK)
            {
                doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(saveFileFromManger.FileName, FileMode.Create));
                doc.Open();
                SaveFile();
                doc.Close();
                MessageBox.Show("הפעולה הסתימה בהצלחה");
            }

        }
    }
}
