// This is a file upload controller
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using FileUploadDemo.Models;

namespace FileUploadDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: FileUpload
        // link to postman : http://localhost:5000/apt/fileupload/upload
        // through postman we can upload file
        // in body select form-data and key as file and value as choose file
        // Make sure to set the request type to POST
        // and the URL to http://localhost:5000/api/fileupload/upload
        //
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var filePath = Path.Combine(uploadFolder, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { status = "File uploaded successfully!" });
            }

            return BadRequest(new { status = "No file selected for upload." });
        }
        //We can follow these steps :

        //Step 1: Check if the File was sent
        [HttpPost("uploadfile")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected for upload.");
            }
            else
            {
            }
            //Step 2: Creating a folder to save file if it doesn't exist

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            if (!Directory.Exists(uploadFolder))

            {

                Directory.CreateDirectory(uploadFolder);

            }

            //Step 3: Create the full file path

            var filePath = Path.Combine(uploadFolder, file.FileName);

            //Step 4: Save the file to the folder

            using (var stream = new FileStream(filePath, FileMode.Create))

            {

                await file.CopyToAsync(stream);

            }

            //Step 5: return success message

            return Ok(new { FilePath = filePath });

        }

        //Step 6: Storing File Information in Database
        private readonly Data.ApplicationDbContext _context;
        public FileUploadController(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("uploadandstore")]
        public async Task<IActionResult> UploadAndStoreFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected for upload.");
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var filePath = Path.Combine(uploadFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var storedFile = new StoredFile
            {
                FileName = file.FileName,
                FilePath = filePath,
                FileSize = file.Length,
                UploadDate = DateTime.Now
            };

            _context.StoredFiles.Add(storedFile);
            await _context.SaveChangesAsync();

            return Ok(new { status = "File uploaded and information stored successfully!" });
        }
    }
}
