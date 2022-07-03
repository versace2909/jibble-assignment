using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IReadCSVService
    {
        Task<UploadResponse> ReadCSV(IFormFile request);
    }
}