using System;

namespace Domain.Entities
{
    public class Employee : BaseModel
    {
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
    }
}