using System;

namespace PhoneDirectory
{
    class PhoneEntry
    {
        public string name { get; set; }
        public long number { get; set; }
        public PhoneEntry(String nameArg, long numberArg)
        {
            name = nameArg;
            number = numberArg;
        }
        public bool IsValidNumber()
        {
            if (number.ToString().Length != 10)
                return false;
            else
                return true;
        }
    }
}
