using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    [Table("Hospital")]
    public class Hospital
    {
       
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }

        public virtual ICollection<Physician> Physicians { get; set; }
    }
}