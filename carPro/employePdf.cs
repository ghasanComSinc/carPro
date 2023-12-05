﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using Font = iTextSharp.text.Font;
namespace carPro
{
    internal class EmployePdf
    {
        /*pdfFile*/
        private PdfPTable saveTablePdf;
        private iTextSharp.text.Document doc;
        readonly static string path = @"VarelaRound-Regular.ttf";
        readonly iTextSharp.text.pdf.BaseFont tableFont1 = iTextSharp.text.pdf.BaseFont.CreateFont(path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font tableFont;
        public EmployePdf()
        {
        }
        /// <summary>
        /// Fills the PdfPTable with header and cell data from the provided DataGridView.
        /// </summary>
        /// <param name="data">The DataGridView containing the data to be added to the PDF table.</param>
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
        /// <summary>
        /// Sets up the font and PdfPTable for the PDF document based on the specified column count.
        /// </summary>
        /// <param name="count">The number of columns in the PdfPTable.</param>
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
        /// <summary>
        /// Generates a PDF document containing details of all orders and saves it to the specified file path.
        /// </summary>
        /// <param name="filePath">The path where the PDF file will be saved.</param>
        /// <param name="orders">The DataGridView containing the order details.</param>
        public void AddPdfSale(string filePath ,DataGridView orders)
        {
            doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            /*put image*/
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:\\autopatr\\images.jpeg");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\Desktop\\123.jpg");
            img.ScaleToFit(600f, 100f); // Adjust the width and height as needed
            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
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
        /// <summary>
        /// Generates a PDF document containing details of items in a specific order and saves it to the specified file path.
        /// </summary>
        /// <param name="filePath">The path where the PDF file will be saved.</param>
        /// <param name="itemsInOrder">The DataGridView containing the details of items in a specific order.</param>
        public void AddPdfItemInSale(string filePath, DataGridView itemsInOrder)
        {
            doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            /*put image*/
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:\\autopatr\\images.jpeg");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\ASUS\\Desktop\\123.jpg");
            img.ScaleToFit(600f, 100f); // Adjust the width and height as needed
            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            doc.Add(img);
            /*put image*/
            tableFont = new Font(tableFont1, 12)
            {
                Color = BaseColor.BLACK
            };
            saveTablePdf = new PdfPTable(1)
            {
                HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                DefaultCell = { BorderWidth = 0 },
                RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
            };
            saveTablePdf.AddCell(new Phrase(itemsInOrder.Columns[0].HeaderText + ":" + itemsInOrder.Rows[0].Cells[0].Value.ToString(), tableFont));
            saveTablePdf.AddCell(new Phrase(itemsInOrder.Columns[2].HeaderText + ":" + itemsInOrder.Rows[0].Cells[2].Value.ToString(), tableFont));
            doc.Add(saveTablePdf);
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
            saveTablePdf = new iTextSharp.text.pdf.PdfPTable(9)
            {
                HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT,
                RunDirection = iTextSharp.text.pdf.PdfWriter.RUN_DIRECTION_RTL
            };
            float[] widthOfTable = new float[saveTablePdf.NumberOfColumns];
            for (int i = 0; i < widthOfTable.Length; i++)
            {
                if (i == 5 || i == 6)
                    widthOfTable[i] = 70f;
                else if (i == 3 || i == 0)
                    widthOfTable[i] = 80f;
                else if (i == 7||i==2||i==4)
                    widthOfTable[i] = 40f;
                else
                    widthOfTable[i] = 60f;
            }
            saveTablePdf.SetTotalWidth(widthOfTable);
            saveTablePdf.LockedWidth = true;


            FillFileDe(itemsInOrder);
            doc.Add(saveTablePdf);
            doc.Close();
            MessageBox.Show("הפעולה הסתימה בהצלחה");
        }
    }
}