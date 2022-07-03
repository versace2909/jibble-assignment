using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<GenericResponse<int>> AddEmployeeAsync(Employee employee);
        Task<GenericResponse<int>> AddEmployeesAsync(IList<Employee> employee);
        Task<GenericResponse<int>> UpdateEmployeeAsync(EmployeeDTO employee);
        Task BulkInsertAsync(IEnumerable<Employee> employees);
        Task<GenericResponse<EmployeeDTO>> GetEmployeesAsync(DataSourceRequest request);
    }
}