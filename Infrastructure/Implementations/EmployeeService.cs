using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PostgreSQLCopyHelper;

namespace Infrastructure.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _dbContext;

        public EmployeeService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddEmployees(IList<Employee> employee)
        {
            await _dbContext.Employees.AddRangeAsync(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(EmployeeDTO employee)
        {
            var employeeEnt = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (employee == null)
            {
                throw new Exception("Could not find entity");
            }

            employeeEnt.DateOfBirth = employee.DoB;
            employeeEnt.EmpId = employee.EmpId;
            employeeEnt.FirstName = employee.FirstName;
            employeeEnt.LastName = employee.LastName;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task BulkInsert(IEnumerable<Employee> employees)
        {
            await using var npgSql = new NpgsqlConnection(_dbContext.Database.GetDbConnection().ConnectionString);
            npgSql.Open();
            var copyHelper = new PostgreSQLCopyHelper<Employee>("public", "employees")
                    .MapVarchar("emp_id", x => x.EmpId)
                    .MapVarchar("first_name", x => x.FirstName)
                    .MapVarchar("last_name", x => x.LastName)
                    .MapTimeStamp("date_of_birth", x => x.DateOfBirth)
                    .MapTimeStamp("created_at", x => x.CreatedAt)
                    .MapVarchar("created_by", x => x.CreatedBy);

            await copyHelper.SaveAllAsync(npgSql, employees);
        }

        public async Task<GenericResponse<EmployeeDTO>> GetEmployeesAsync(DataSourceRequest request)
        {
            var result = await _dbContext.Employees.Select(x => new EmployeeDTO()
            {
                EmpId = x.EmpId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DoB = x.DateOfBirth
            }).ToDataSourceResultAsync(request);

            return result;
        }
    }
}