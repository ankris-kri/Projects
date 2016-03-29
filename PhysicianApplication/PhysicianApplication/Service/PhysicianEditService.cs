using PhysicianApplication.Contracts;
using PhysicianApplication.DAL;
using PhysicianApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Service
{
    public class PhysicianEditService : IPhysicianEditService
    {
        DataFetchContext context;

        public PhysicianEditService()
        {
            context = new DataFetchContext();
            
        }

        public void Edit(Physician _physicianEntry)
        {
            using (context = new DataFetchContext())
            {
                context.Physicians.Attach(_physicianEntry);
                context.Entry<Physician>(_physicianEntry).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Create(Physician _physicianEntry)
        {
            using (context = new DataFetchContext())
            {
                _physicianEntry.ID = Guid.NewGuid();
                context.Physicians.Add(_physicianEntry);
                context.Entry<Physician>(_physicianEntry).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}