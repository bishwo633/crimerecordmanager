using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class ComplainDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string ComplainBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime ComplainDate { get; set; }
        public string AccusedName { get; set; }
        [StringLength(300)]
        [Required]
        public string ComplainDetails { get; set; }
    }
}