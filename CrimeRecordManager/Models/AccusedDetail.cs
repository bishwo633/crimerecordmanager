using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
   
    public class AccusedDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string AccusedName { get; set; }
        public string OthersDetails { get; set; }
    }
}