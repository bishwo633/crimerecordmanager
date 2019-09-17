using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class PoliceStation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string PoliceStationName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Fax { get; set; }
        [Required]
      
        public int ComplaintRegistrationId { get; set; }
        public virtual ComplaintRegistration ComplaintRegistration { get; set; }
    }
}