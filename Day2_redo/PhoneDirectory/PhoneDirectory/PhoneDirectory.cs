using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class PhoneDirectory
    {
        public string name;
        public long number;
        public PhoneDirectory(String _LocalName, long _LocalNumber)
        {
            name = _LocalName;
            number = _LocalNumber;
        }
    }
}
