using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
// using Microsoft.AspNetCore.Cors;

namespace cosec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [EnableCors("AllowLocalhost4200")]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileUploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("sampledoc")]
        // [EnableCors("AllowLocalhost4200")]
        public IActionResult GetSampleDoc()
        {
            // Construct the full path to the file
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "sample_doc.docx");

            // Check if file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Get the file's content
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Return the file with the appropriate content type
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "sample_doc.docx");
        }
    }
}
