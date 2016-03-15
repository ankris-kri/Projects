using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Models
{
    public class DataFetchContext: DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Physician> Physicians { get; set; }

        //public System.Data.Entity.DbSet<PhysicianApplication.Models.DataToView> DataToViews { get; set; }
    }
}