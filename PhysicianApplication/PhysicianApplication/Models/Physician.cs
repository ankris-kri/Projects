using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    [Table("Physician")]
    public class Physician
    {
        public Guid ID { get; set; }
        [Required][RegularExpression("^[a-zA-Z0-9]+[a-zA-Z0-9 ]*",ErrorMessage="No special characters")]
        public String Name { get; set; }
        [Required][Range(26, 79)]
        public int Age { get; set; }
        [Required][RegularExpression("^[a-zA-Z0-9]{4,10}$", ErrorMessage = "No special characters")]
        public String NPI { get; set; }
        public int HospitalID { get; set; }
        public int SpecialtyID { get; set; }
        [Required][RegularExpression(@"[1-9][0-9]*(.[0-9]{1,2})?",ErrorMessage="enter a valid number")]
        public decimal ConsultationCharge { get; set; }
    }
}