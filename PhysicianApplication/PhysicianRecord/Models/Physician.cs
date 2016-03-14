using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianRecord.Models
{
    [Table("Physician")]
    public class Physician
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String NPI { get; set; }
        public int HospitalID { get; set; }
        public int SpecialtyID { get; set; }
        public decimal ConsultationCharge { get; set; }
    }
}