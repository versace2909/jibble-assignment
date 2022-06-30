using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee employee);
        Task AddEmployees(IList<Employee> employee);
        Task UpdateEmployee(Employee employee);
    }
}