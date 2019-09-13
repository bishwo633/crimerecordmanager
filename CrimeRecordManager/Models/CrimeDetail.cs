using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class CrimeDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string CrimeType { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [Required]
        public int CrimeId { get; set; }
        public virtual Crime Crime { get; set; }
    }
}