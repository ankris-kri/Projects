using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianRecord.Models
{
    [Table("Specialty")]
    public class Specialty
    {
        public int SpecialtyID { get; set; }
        public String SpecialtyName { get; set; }
    }
}