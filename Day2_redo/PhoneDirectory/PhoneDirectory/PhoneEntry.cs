using System;

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
