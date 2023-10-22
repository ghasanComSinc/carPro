using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic.ApplicationServices;
using Font = iTextSharp.text.Font;
namespace carPro
{
    internal class PdfCustomer
    {
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document document;
        readonly static string path = @"VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font tableFont;
        public PdfCustomer()
        {
        }
        public void Add_Line_To_PDFTable_CENTER(string line)
        {
            Font font = new(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
            Paragraph title = new(line, font);
            PdfPCell cell = new(title)
            {
                Border = 0, // Remove cell borders if needed
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            saveTablePdf = new PdfPTable(1);
            saveTablePdf.AddCell(cell);
            document.Add(saveTablePdf);
        }
        public void Add_Line_To_PDFTable_RightSide(string line)
        {
            Font font = new(BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED), 12);
            Paragraph title = new(line, font);
            PdfPCell cell = new(title)
            {
                Border = 0, // Remove cell borders if needed
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                HorizontalAlignment = Element.ALIGN_LEFT
            };
            saveTablePdf = new PdfPTable(1);
            saveTablePdf.AddCell(cell);
            document.Add(saveTablePdf);
        }
        public void SaveTableFont(int count)
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
        public void SavePdfFile(string path, string name, DataGridView data, string titleStr, int fileNum)
        { 
            document = new iTextSharp.text.Document();
            document.SetMargins(0, 0, 10f, 10f);
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();
            /*put image*/
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:/Users/ehsan/source/repos/ghasanComSinc/carPro/carPro/123.png");
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\source\\repos\\carPro\\carPro\\plus.png");
            img.ScaleToFit(600f, 100f); // Adjust the width and height as needed
            img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(img);
            /*put image*/

            /*add the number off the customer*/
            string line1 = "לקוח: ";
            line1 += name;
            Add_Line_To_PDFTable_RightSide(line1);

            /*add phone number*/
            line1 = "מספר טלפון: ";
            line1 += data.Rows[0].Cells[0].Value.ToString();
            Add_Line_To_PDFTable_RightSide(line1);

            /*creat title in pdf*/
            Add_Line_To_PDFTable_CENTER(titleStr);

            if (fileNum == 0)
                SaveTableFont(4);
            else
                SaveTableFont(8);
            float[] widthOfTable = new float[saveTablePdf.NumberOfColumns];
            for (int i = 0; i < widthOfTable.Length; i++)
            {
                if (fileNum == 0)
                {
                    if (i == 3)
                        widthOfTable[i] = 5f;
                    else
                        widthOfTable[i] = 30f;
                }
                else
                {
                    if (i == 0 || i == 1 || i == 4)
                        widthOfTable[i] = 22f;
                    else if (i == 5)
                        widthOfTable[i] = 12f;
                    else if (i == 7)
                        widthOfTable[i] = 8f;// # line number
                    else
                        widthOfTable[i] = 30f;
                }
            }
            saveTablePdf.SetWidths(widthOfTable);
            if (fileNum == 0)
            {
                for (int i = 0; i < data.ColumnCount; i++)
                {
                    if (i == 0)
                        saveTablePdf.AddCell(new Phrase("#"));
                    else
                        saveTablePdf.AddCell(new Phrase(data.Columns[i].HeaderText, tableFont));
                }
            }
            else
            {
                saveTablePdf.AddCell(new Phrase("#"));
                saveTablePdf.AddCell(new Phrase(data.Columns[1].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase("כמות", tableFont));
                saveTablePdf.AddCell(new Phrase("סטאטוס", tableFont));
                saveTablePdf.AddCell(new Phrase("חלק", tableFont));
                saveTablePdf.AddCell(new Phrase(data.Columns[8].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase(data.Columns[11].HeaderText, tableFont));
                saveTablePdf.AddCell(new Phrase("ס\"כ מחיר", tableFont));
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (fileNum == 0)
                {
                    for (int j = 0; j < data.ColumnCount; j++)
                        if (j == 0)
                            saveTablePdf.AddCell(new Phrase((i + 1).ToString()));
                        else
                            saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[j].Value.ToString(), tableFont));
                }
                else
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
                    saveTablePdf.AddCell(new Phrase((i + 1).ToString()));
                    saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[1].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[3].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[4].Value.ToString(), tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[7].Value.ToString(), tableFont));
                    string partName = data.Rows[i].Cells[8].Value.ToString();
                    if (partName.Length > 27)
                    {
                        partName = partName[..27];
                    }
                    saveTablePdf.AddCell(new Phrase(partName, tableFont));
                    saveTablePdf.AddCell(new Phrase(data.Rows[i].Cells[11].Value.ToString(), tableFont));
                    int amuntXprice = int.Parse(data.Rows[i].Cells[3].Value.ToString()) * int.Parse(data.Rows[i].Cells[11].Value.ToString());
                    saveTablePdf.AddCell(new Phrase(amuntXprice.ToString(), tableFont));
                }
            }
            document.Add(saveTablePdf);
            document.Close();
            MessageBox.Show("הפעולה הסתימה בהצלחה");
        }
    }
}
