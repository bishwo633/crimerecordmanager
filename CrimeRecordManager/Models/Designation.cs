using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Name")]
        public string DesignationName { get; set; }

        public string Description { get; set; }
    }
}