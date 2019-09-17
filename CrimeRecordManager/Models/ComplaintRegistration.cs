using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class ComplaintRegistration
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string ComplainBy { get; set; }
        public string CitizenshipNo { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime ComplainDate { get; set; }
        
        [StringLength(300)]
        [Required]
        public string ComplainDetails { get; set; }
        public int AccusedDetailId { get; set; }
        public virtual AccusedDetail AccusedDetail { get; set; }
    }
}