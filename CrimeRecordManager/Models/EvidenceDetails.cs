using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class EvidenceDetails
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string EvidenceName { get; set; }
        public string EvidenceType { get; set; }
        [DataType(DataType.Date)]
        public DateTime EvidenceFindingDate { get; set; }
        public string Description { get; set; }
        [Required]
        public int InvestigationId { get; set; }
        public virtual Investigation Investigation { get; set; }
    }
}