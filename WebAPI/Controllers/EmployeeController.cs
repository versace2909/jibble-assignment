using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IReadCSVService _readCsvService;

        public EmployeeController(IReadCSVService readCsvService)
        {
            _readCsvService = readCsvService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadCsv([FromForm]FileUploadRequest model)
        {
            var x = await _readCsvService.ReadCSV(model);
            return Ok("");
        }
        
        [HttpGet]
        public JsonResult GetEmployee()
        {
            return new JsonResult(new { id = 1, name = "John" });
        }
    }
}