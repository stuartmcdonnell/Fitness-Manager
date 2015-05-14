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


        public void ExportToPdf(DataTable datatable, string newpdf)
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
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15);
                //FINISH FONT

                //ADDING TABLE
                PdfPTable table = new PdfPTable(2);
                PdfPCell foodcell = new PdfPCell(new Phrase("FOOD", font5));
                PdfPCell timecell = new PdfPCell(new Phrase("TIME", font5));

                foodcell.PaddingBottom = 3f;
                timecell.PaddingBottom = 3f;

                foodcell.Colspan = 1;
                timecell.Colspan = 1;
                table.AddCell(foodcell);
                table.AddCell(timecell);

                foreach (DataRow r in datatable.Rows) {

                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                }
                Paragraph tablep = new Paragraph();


                float[] widths = new float[] {50f,10f};
                table.SetWidths(widths);

                tablep.Add(table);
                tablep.SpacingBefore = 150f;

                doc.Add(tablep);

                //TABLE FINISHED


                doc.Close();
                System.Windows.Forms.MessageBox.Show("Plan Saved To: " + newpdf);
            }
            catch (Exception exc) {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }


        }    




    }
}
