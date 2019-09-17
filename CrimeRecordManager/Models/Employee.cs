using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = " InchargeName")]
        public string EmployeeName { get; set; }

        public int Age { get; set; }

        public Gender? Gender { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        [Display(Name = "Designation Name")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        [Required]
        [Display(Name = "PoliceStation Name")]
        public int PoliceStationId { get; set; }
        public virtual PoliceStation PoliceStation { get; set; }
    }
}