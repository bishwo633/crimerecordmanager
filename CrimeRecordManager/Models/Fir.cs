using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class Fir
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string LocationDetails { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public DateTime CrimeDate { get; set; }
        [Required]
        public int CrimeDetailId { get; set; }
        public virtual CrimeDetail CrimeDetail { get; set; }

    }
}