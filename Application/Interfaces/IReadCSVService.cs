using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Interfaces
{
    public interface IReadCSVService
    {
        Task<List<EmployeeDTO>> ReadCSV(FileUploadRequest request);
    }
}