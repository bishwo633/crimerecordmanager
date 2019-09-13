using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class WitnessDetails
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string WitnessName { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}