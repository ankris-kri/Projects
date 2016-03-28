using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicianApplication.Contracts;
using PhysicianApplication.Models;

namespace PhysicianApplication.Service
{
    public class PhysicianViewService : IPhysicianViewService
    {
        DataFetchContext context;

        public PhysicianViewService()
        {
            context = new DataFetchContext();
        }

        public IEnumerable<Physician> ViewAllPhysicians()
        {
            using (context)
            {
                return context.Physicians.Include("Hospital").Include("Specialty").ToList();
            }
        }
    }
}