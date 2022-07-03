using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Infrastructure.Constants;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Implementations
{
    public class ReadCsvService : IReadCSVService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public ReadCsvService(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<UploadResponse> ReadCSV(IFormFile request)
        {
            if (!request.FileName.EndsWith(".csv"))
            {
                return new UploadResponse
                {
                    Status = UploadStatusConstants.Error,
                    Message = "File format is not supported"
                };
            }
            
            await using var stream = request.OpenReadStream();
            using TextReader sr = new StreamReader(stream);
            using var csvReader = new CsvReader(sr, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            });

            var csvEmployees = csvReader.GetRecords<EmployeeDTO>();
            
            var employees = _mapper.Map<IEnumerable<Employee>>(csvEmployees);
            await _employeeService.BulkInsert(employees);
            return new UploadResponse
            {
                Name = request.FileName,
                Status = UploadStatusConstants.Done
            };
        }
    }
}