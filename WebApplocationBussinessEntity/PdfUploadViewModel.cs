using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplocationBussinessEntity
{
    public class PdfUploadViewModel
    {
        public IFormFile PdfFile { get; set; }
        public PdfData ExtractedData { get; set; }
    }
}
