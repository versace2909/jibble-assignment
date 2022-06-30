using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Database;

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

        public Task UpdateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}