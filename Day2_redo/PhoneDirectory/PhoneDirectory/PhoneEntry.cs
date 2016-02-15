using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class PhoneEntry
    {
        public string name;
        public long number;
        public PhoneEntry(String nameArg, long numberArg)
        {
            name = nameArg;
            number = numberArg;
        }
    }
}
