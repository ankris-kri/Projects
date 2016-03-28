using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicianApplication;
using PhysicianApplication.Contracts;

namespace PhysicianApplication.Service
{
    public class PhysicianDeleteService : IPhysicianDeleteService
    {
        PhysicianEntities context;

        public PhysicianDeleteService()
        {
            context = new PhysicianEntities();
        }
        public void DeleteForID(Guid id)
        {
            using (context)
            {
                var PhysicianList = context.Physicians.ToList<Physician>();
                context.Physicians.Remove(PhysicianList.First(a => a.ID == id));
                context.SaveChanges();
            }
        }
    }
}