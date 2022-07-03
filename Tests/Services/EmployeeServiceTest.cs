using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;
using Infrastructure.Database;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;

namespace Tests.Services
{
    public class EmployeeServiceTest
    {
        private AppDBContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var _contextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase("BloggingControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new AppDBContext(_contextOptions);
        }
        
        [Test]
        [Order(1)]
        public async Task Add_Employee_Success()
        {
            var employeeService = new EmployeeService(_dbContext);

            var employee = new Employee
            {
                FirstName = "Test",
                LastName = "Test",
                EmpId = "1",
                DateOfBirth = DateTime.Now,
                CreatedAt = DateTime.Now
            };
            var result = await employeeService.AddEmployeeAsync(employee);
            
            Assert.IsTrue(result.Success);
            
            var resultGet = await employeeService.GetEmployeesAsync(new DataSourceRequest()
            {
                PageIndex = 1,
                PageSize = 10
            });
            
            Assert.IsTrue(resultGet.Success);
            Assert.IsTrue(resultGet.Total > 0);
            Assert.IsTrue(resultGet.Results.Count > 0);
        }
        
        [Test]
        [Order(2)]
        public async Task Update_Employee_Success()
        {
            var employeeService = new EmployeeService(_dbContext);
            var employees = await employeeService.GetEmployeesAsync(new DataSourceRequest()
            {
                PageIndex = 1,
                PageSize = 10
            });
            
            var updatedEmployee = employees.Results.FirstOrDefault();
            Assert.IsNotNull(updatedEmployee);
            updatedEmployee.FirstName = "TestUpdate";

            var result = await employeeService.UpdateEmployeeAsync(new EmployeeDTO()
            {
                Id = updatedEmployee.Id,
                FirstName = updatedEmployee.FirstName,
                LastName = updatedEmployee.LastName,
                DateOfBirth = updatedEmployee.DateOfBirth,
            });
            
            Assert.IsTrue(result.Success);

        }
        
        [Test]
        [Order(3)]
        public async Task Add_Employees_Success()
        {
            var employeeService = new EmployeeService(_dbContext);
            
            var result = await employeeService.AddEmployeesAsync(new List<Employee>()
                {
                new Employee
                {
                    FirstName = "Test 3",
                    LastName = "Test 3",
                    EmpId = "3",
                    DateOfBirth = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Employee
                {
                    FirstName = "Test 4",
                    LastName = "Test 4",
                    EmpId = "4",
                    DateOfBirth = DateTime.Now,
                    CreatedAt = DateTime.Now
                }
            });
            
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Result == 2);

        }
    }
}