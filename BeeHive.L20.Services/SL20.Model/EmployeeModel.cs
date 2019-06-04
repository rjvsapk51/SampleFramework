using System;

namespace BeeHive.L20.Services.SL20.Model
{
    public class EmployeeModel
    {        
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public long? PhoneNumber { get; set; }
        public DateTime? JoinDate { get; set; }

    }
}
