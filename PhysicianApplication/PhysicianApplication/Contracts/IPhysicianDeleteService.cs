using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicianApplication.Contracts
{
    interface IPhysicianDeleteService
    {
        void DeleteForID(Guid id);
    }
}
