using Microsoft.AspNetCore.Mvc;
using WebApplocationBussinessEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace WebAppFirstProject.Controllers
{
    public class PdfTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PdfUploadViewModel model)
        {

            if (model.PdfFile != null && model.PdfFile.Length > 0)
            {
                var fileExtension = System.IO.Path.GetExtension(model.PdfFile.FileName).ToLower();

                if (fileExtension == ".pdf")
                {
                    using (var stream = new MemoryStream())
                    {
                        model.PdfFile.CopyTo(stream);

                       
                        if (IsPdf(stream))
                        {
                            var text = ExtractTextFromPdf(stream);
                            var extractedData = ParsePdfText(text);
                            model.ExtractedData = extractedData;
                        }
                        else
                        {
                            ModelState.AddModelError("", "The uploaded file is not a valid PDF.");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The uploaded file is not a PDF.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please upload a PDF file.");
            }

            return View(model);

        }
        private bool IsPdf(Stream stream)
        {
            var buffer = new byte[5];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(buffer, 0, 5);
            stream.Seek(0, SeekOrigin.Begin);
            var header = System.Text.Encoding.ASCII.GetString(buffer);
            return header == "%PDF-";
        }
        private string ExtractTextFromPdf(Stream pdfStream)
        {
            using (var reader = new PdfReader(pdfStream))
            {
                var text = new StringWriter();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                return text.ToString();
            }
        }

        private PdfData ParsePdfText(string text)
        {
            var data = new PdfData();
            var lines = text.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("First Name:"))
                {
                    data.FirstName = line.Replace("First Name:", "").Trim();
                }
                else if (line.Contains("Last Name:"))
                {
                    data.LastName = line.Replace("Last Name:", "").Trim();
                }
                else if (line.Contains("Mobile:"))
                {
                    data.Mobile = line.Replace("Mobile:", "").Trim();
                }
                else if (line.Contains("Email:"))
                {
                    data.Email = line.Replace("Email:", "").Trim();
                }
                else if (line.Contains("Technical Skills:"))
                {
                    data.TechnicalSkill = line.Replace("Technical Skill:", "").Trim();
                }
            }
            return data;
        }
    }
}
