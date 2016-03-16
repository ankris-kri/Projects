using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    public class DataToView
    {
        public int? ID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String NPI { get; set; }
        public String Hospital { get; set; }
        public String Specialty { get; set; }
        public decimal ConsultationCharge { get; set; }
    }
}