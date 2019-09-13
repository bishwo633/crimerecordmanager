using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Name")]
        public string DepartmentName { get; set; }

        public string Description { get; set; }
    }
}