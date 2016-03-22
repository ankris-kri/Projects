using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicianApplication.Models;

namespace PhysicianApplication.Service
{
    public class DeleteService
    {
        
        public void DeleteForID(Guid id)
        {
            using (var context = new DataFetchContext())
            {
                var PhysicianList = context.Physicians.ToList<Physician>();
                context.Physicians.Remove(PhysicianList.First(a => a.ID == id));
                context.SaveChanges();
            }
        }
    }
}