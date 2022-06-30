using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class FileUploadRequest
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}