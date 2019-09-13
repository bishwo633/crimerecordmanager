using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class ChargeSheet
    {
        [Key]
        public int Id { get; set; }
        [StringLength(300)]
        [Required]
        public string ChargeSheetDetails { get; set; }
        [DataType(DataType.Date)]
        public DateTime ChargeSheetIssueDate { get; set; }
        public string ChargeSheetBy { get; set; }
        [Required]
        public int FirId { get; set; }
        public virtual Fir Fir { get; set; }
    }
}