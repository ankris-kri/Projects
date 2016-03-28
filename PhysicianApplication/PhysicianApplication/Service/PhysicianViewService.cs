using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicianApplication.Contracts;

namespace PhysicianApplication.Service
{
    public class PhysicianViewService : IPhysicianViewService
    {
        PhysicianEntities context;

        public PhysicianViewService()
        {
            context = new PhysicianEntities();
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