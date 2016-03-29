using PhysicianApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhysicianApplication.DAL
{
    public class DataFetchContext:DbContext
    {
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Physician> Physicians { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
    }
}