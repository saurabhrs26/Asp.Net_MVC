using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventFormProject.Models
{
    public class Employee
    {
        //
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is a required field!")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Employee Address is a required field!")]
        public string EmployeeAddress { get; set; }
        [Required(ErrorMessage = "Employee City is a required field!")]
        public string EmployeeCity { get; set; }
        [Required(ErrorMessage = "Employee Country # is a required field!")]
        public string EmployeeCountry { get; set; }  
        public int EmployeePhone { get; set; }

        [Required(ErrorMessage = "Employee Email is a required field!")]
        public string EmployeeMail { get; set;}
        public string EmployeeSkill { get; set;}
        public string EmployeeAvtar { get; set; }
        public int EmployeeZipcode { get; set; }
    }
}