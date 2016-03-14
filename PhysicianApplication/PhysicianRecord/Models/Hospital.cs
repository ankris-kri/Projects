using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianRecord.Models
{
    [Table("Hospital")]
    public class Hospital
    {
        public int HospitalID { get; set; }
        public String HospitalName { get; set; }
    }
}