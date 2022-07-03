using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IReadCSVService _readCsvService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IReadCSVService readCsvService, IEmployeeService employeeService)
        {
            _readCsvService = readCsvService;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<JsonResult> UploadCsv(IFormFile file)
        {
            var result = await _readCsvService.ReadCSV(file);
            return new JsonResult(result);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetEmployeesAsync(DataSourceRequest request)
        {
            var result = await _employeeService.GetEmployeesAsync(request);
            return new JsonResult(result);
        }
    }
}