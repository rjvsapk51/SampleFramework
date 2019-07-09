using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeeHive.L30.Domain.SL20.Entities
{
    [Table("employees")]
    public class Employees
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("employee_code")]
        public string EmployeeCode { get; set; }
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("marital_status")]
        public string MaritalStatus { get; set; }
        [Column("nepali_name")]
        public string NepaliName { get; set; }
        [Column("salutation")]
        public string Salutation { get; set; }
        [Column("middle_name")]
        public string MiddleName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("employee_name")]
        public string EmployeeName { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("join_date")]
        public DateTime? JoinDate { get; set; }
    }
}
