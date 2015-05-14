using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNess3
{
    class generateWorkoutPDF
    {

        public void ExportToPdf(DataTable datatable, string newpdf)
        {

            try
            {
                //OPEN READER

                Document doc = new Document(PageSize.A4);
                //CLOSE READER

                //WRITER
                FileStream fs = new FileStream(newpdf + "/WorkoutPlan.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                //WRITER CLOSE


                // Image overlay = Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/overlay.png");
                System.Drawing.Image resourceoverlay = System.Drawing.Image.FromHbitmap(FitNess3.Properties.Resources.WorkoutPlanOverlay.GetHbitmap());
                Image overlay = Image.GetInstance(resourceoverlay, System.Drawing.Imaging.ImageFormat.Png);



                overlay.SetAbsolutePosition(0, 0);
                overlay.ScaleAbsoluteHeight(doc.PageSize.Height);
                overlay.ScaleAbsoluteWidth(doc.PageSize.Width);
                doc.Add(overlay);


                //SET FONT
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15);
                //FINISH FONT

                //ADDING TABLE
                PdfPTable table = new PdfPTable(3);
                PdfPCell exccell = new PdfPCell(new Phrase("EXERCISE", font5));
                PdfPCell desccell = new PdfPCell(new Phrase("DESCRIPTION", font5));
                PdfPCell notescell = new PdfPCell(new Phrase("NOTES", font5));

                exccell.PaddingBottom = 3f;
                desccell.PaddingBottom = 3f;
                notescell.PaddingBottom = 3f;

                exccell.Colspan = 1;
                desccell.Colspan = 1;
                notescell.Colspan = 1;

                table.AddCell(exccell);
                table.AddCell(desccell);
                table.AddCell(notescell);

                foreach (DataRow r in datatable.Rows)
                {

                    table.AddCell(new Phrase(r[5].ToString(), font5));
                    table.AddCell(new Phrase(r[6].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
                Paragraph tablep = new Paragraph();


                float[] widths = new float[] { 50f, 50f, 50f };
                table.SetWidths(widths);

                tablep.Add(table);
                tablep.SpacingBefore = 150f;

                doc.Add(tablep);

                //TABLE FINISHED


                doc.Close();
                System.Windows.Forms.MessageBox.Show("Plan Saved To: " + newpdf);
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }


        }
    }
}
