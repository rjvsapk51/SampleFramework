using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeeHive.L30.Domain.SL20.Entities
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("employeename")]
        public string EmployeeName { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("middlename")]
        public string MiddleName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("salutation")]
        public string Salutation { get; set; }
        [Column("phonenumber")]
        public long? PhoneNumber { get; set; }
        [Column("joindate")]
        public DateTime? JoinDate { get; set; }

    }
}
