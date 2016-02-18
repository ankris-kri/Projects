using System;

namespace PhoneDirectory
{
    class ErrorDto
    {
        public bool isError { get; set; }
        public string description { get; set; }

        public ErrorDto()
        {
            isError = false;
        }
    }
}
