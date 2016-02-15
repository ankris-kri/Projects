using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class BusinessLayer
    {
        PhoneDirectoryRepository repository = new PhoneDirectoryRepository();
        public PhoneEntryDto Search(String _enteredstring)
        {
            return repository.Search(_enteredstring);
        }
        public ErrorDto Add(PhoneEntry phonedirectory)
        {
            ErrorDto error = Validate(phonedirectory.number);
            if (error.isError == false)
            {
                return repository.Add(phonedirectory);
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
