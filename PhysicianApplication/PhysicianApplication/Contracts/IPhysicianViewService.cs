using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicianApplication.Contracts
{
    interface IPhysicianViewService
    {
        IEnumerable<Physician> ViewAllPhysicians();
    }
}
