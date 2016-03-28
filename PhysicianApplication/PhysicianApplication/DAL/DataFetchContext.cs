using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    public class DataFetchContext: DbContext
    {
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }

        //public System.Data.Entity.DbSet<PhysicianApplication.Models.DataToView> DataToViews { get; set; }
    }
}