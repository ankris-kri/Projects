using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    [Table("Specialty")]
    public class Specialty
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }

        public virtual ICollection<Physician> Physicians { get; set; }
    }
}