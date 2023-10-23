using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
namespace carPro
{
    internal class MangerPdf
    {
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document doc;
        readonly static string path = @"VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font tableFont;

        public MangerPdf()
        {
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
        public void AddFilePdf(string path1,string titleStr,int fileNum,DataGridView data)
        {
            doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(path1, FileMode.Create));
            doc.Open();
            /*put image*/
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:\\autopatr\\images.jpeg");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\Desktop\\123.jpg");
            img.ScaleToFit(600f,100f); // Adjust the width and height as needed
            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
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
        public void AddPdfDeOr(string path1,DataGridView orderD)
        {
            doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(path1, FileMode.Create));
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
            MessageBox.Show("הפעולה הסתימה בהצלחה");
        }
    }
}
