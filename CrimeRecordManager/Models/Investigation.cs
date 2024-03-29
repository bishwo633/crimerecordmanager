﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrimeRecordManager.Models
{
    public class Investigation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(300)]
        [Required]
        public string InvestigationDetails { get; set; }
        [DataType(DataType.Date)]
        public DateTime InvestigationStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime InvestigationEndDate { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}