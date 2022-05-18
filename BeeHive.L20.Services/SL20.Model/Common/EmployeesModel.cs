using System;

namespace BeeHive.L20.Services.SL20.Model
{
    public class EmployeesModel
    {
        public long Id { get; set; }
        public string EmployeeCode { get; set; }
        public int DepartmentId { get; set; }  
        public string Gender { get; set; }      
        public string MaritalStatus { get; set; }
        public string NepaliName { get; set; }
        public string Salutation { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
