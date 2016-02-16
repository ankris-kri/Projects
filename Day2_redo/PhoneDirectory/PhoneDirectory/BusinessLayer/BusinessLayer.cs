using System;
using System.Collections.Generic;

namespace PhoneDirectory
{
    class BusinessLayer
    {
        PhoneDirectoryRepository repository = new PhoneDirectoryRepository();
   
        public List<PhoneEntry> Search(String inputstring)
        {
            return repository.Search(inputstring);
        }
        public ErrorDto Add(PhoneEntry phoneEntry)
        {
            ErrorDto error = Validate(phoneEntry.number);
            if (error.isError == false)
            {
                return repository.Add(phoneEntry);
            }
            return error;
        }
        public ErrorDto Validate(long _number)
        {
            ErrorDto error = new ErrorDto();
            if (_number.ToString().Length != 10)
            {
                error.isError = true;
                error.description = "number should be of length 10";
            }
            else
                error.isError = false;
            return error;
        }
    }
}
