using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicianApplication;
using PhysicianApplication.Contracts;
using PhysicianApplication.Models;

namespace PhysicianApplication.Service
{
    public class PhysicianDeleteService : IPhysicianDeleteService
    {
        DataFetchContext context;

        public PhysicianDeleteService()
        {
            context = new DataFetchContext();
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