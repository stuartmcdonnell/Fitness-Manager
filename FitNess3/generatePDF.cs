using iTextSharp;
using iTextSharp.text;
using iTextSharp.awt;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System.Resources;
namespace FitNess3
{
    class generatePDF
    {


        public void ExportToPdf(DataTable datatable, string newpdf, int calories, int protein, int carbs, int fat)
        {

            try
            {
                //OPEN READER

                Document doc = new Document(PageSize.A4);
                //CLOSE READER

                //WRITER
                FileStream fs = new FileStream(newpdf+"/DietPlan.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                //WRITER CLOSE

                
              // Image overlay = Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/overlay.png");
                System.Drawing.Image resourceoverlay = System.Drawing.Image.FromHbitmap(FitNess3.Properties.Resources.overlay.GetHbitmap());
                Image overlay = Image.GetInstance(resourceoverlay, System.Drawing.Imaging.ImageFormat.Png);

               

                overlay.SetAbsolutePosition(0, 0);
                overlay.ScaleAbsoluteHeight(doc.PageSize.Height);
                overlay.ScaleAbsoluteWidth(doc.PageSize.Width);
                doc.Add(overlay);


                //SET FONT
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
                iTextSharp.text.Font font6 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15);
                //FINISH FONT

                //ADDING TABLE
                PdfPTable table = new PdfPTable(3);

                PdfPCell timecell = new PdfPCell(new Phrase("TIME", font6));
                PdfPCell foodcell = new PdfPCell(new Phrase("FOOD", font6));
                PdfPCell notescell = new PdfPCell(new Phrase("NOTES", font6));


                timecell.PaddingBottom = 3f;
                foodcell.PaddingBottom = 3f;
                notescell.PaddingBottom = 3f;

                foodcell.Colspan = 1;
                timecell.Colspan = 1;
                notescell.Colspan = 1;
                table.AddCell(timecell);
                table.AddCell(foodcell);
                table.AddCell(notescell);

                foreach (DataRow r in datatable.Rows) {

                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                }
                Paragraph tablep = new Paragraph();


                float[] widths = new float[] {15f,40f, 20f};
                table.SetWidths(widths);

                tablep.Add(table);
                tablep.SpacingBefore = 150f;
                tablep.SpacingAfter = 50f;

                doc.Add(tablep);


                Paragraph p = new Paragraph();
                p.Font = font5;
                p.Add("CALORIES: "+calories.ToString()+"    PROTEIN (g): "+protein.ToString()+Environment.NewLine+"    CARBS (g): "+carbs.ToString()+"    FAT (g): "+fat.ToString());
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);


                //TABLE FINISHED


                doc.Close();
                System.Windows.Forms.MessageBox.Show("Plan Saved To: " + newpdf);
            }
            catch (Exception exc) {
                //MessageBox.Show(exc.ToString());
            }

        }



    }
}
