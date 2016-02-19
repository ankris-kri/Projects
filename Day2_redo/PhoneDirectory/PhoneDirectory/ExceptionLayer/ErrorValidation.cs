using System;

namespace PhoneDirectory
{
    class ErrorValidation
    {
        public bool isError { get; set; }
        public string description { get; set; }

        public ErrorValidation()
        {
            isError = false;
        }
    }
}
