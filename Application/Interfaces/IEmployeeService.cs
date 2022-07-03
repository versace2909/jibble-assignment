using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(Employee employee);
        Task<int> AddEmployees(IList<Employee> employee);
        Task<int> UpdateEmployee(EmployeeDTO employee);
        Task BulkInsert(IEnumerable<Employee> employees);
        Task<GenericResponse<EmployeeDTO>> GetEmployeesAsync(DataSourceRequest request);
    }
}