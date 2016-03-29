using PhysicianApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicianApplication.Contracts
{
    interface IPhysicianEditService
    {
        void Edit(Physician _physicianEntry);
        void Create(Physician _physicianEntry);
    }
}
