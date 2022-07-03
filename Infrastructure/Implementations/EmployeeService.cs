using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Extensions;

namespace Infrastructure.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _dbContext;

        public EmployeeService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddEmployees(IList<Employee> employee)
        {
            await _dbContext.Employees.AddRangeAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateEmployee(EmployeeDTO employee)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GenericResponse<EmployeeDTO>> GetEmployeesAsync(DataSourceRequest request)
        {
            var result = await _dbContext.Employees.Select(x => new EmployeeDTO()
            {
                EmpId = x.EmpId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DoB = x.DoB
            }).ToDataSourceResultAsync(request);

            return result;
        }
    }
}