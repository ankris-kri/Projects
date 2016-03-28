using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianApplication.Service
{
    public class PhysicianEditService
    {
        PhysicianEntities context;

        public PhysicianEditService()
        { 
           context = new PhysicianEntities();
            
        }


    }
}