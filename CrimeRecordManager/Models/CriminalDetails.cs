using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class CriminalDetails
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string CriminalName { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Gender { get; set; }
        [StringLength(300)]
        public string OldRecord { get; set; }
        [Required]
        public int PoliceStationId { get; set; }
        public virtual PoliceStation PoliceStation { get; set; }
        public int CrimeDetailId { get; set; }
        public virtual CrimeDetail CrimeDetail { get; set; }
    }
}