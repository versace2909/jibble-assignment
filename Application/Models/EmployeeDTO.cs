using System;
using CsvHelper.Configuration.Attributes;

namespace Application.Models
{
    public class EmployeeDTO
    {
        [Ignore]
        public int Id { get; set; }
        [Name("Emp ID")]
        public string EmpId { get; set; }
        [Name("First Name")]
        public string FirstName { get; set; }
        [Name("Last Name")]
        public string LastName { get; set; }
        [Name("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}