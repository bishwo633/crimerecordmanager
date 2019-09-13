using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class Crime
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string CrimesName { get; set; }
        [StringLength(400)]
        public string Description{ get; set; }
        public string Location { get; set; }
    }
}