using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class BusinessLayer
    {
        Repository repository = new Repository();
        public Result Search(String _enteredstring = "")
        {
            int _number;
            if (_enteredstring == "")
                return repository.SearchAll();
            else if (int.TryParse(_enteredstring, out _number))
            {
                return repository.SearchByNumber(_number);
            }
            else
            {
                return repository.SearchByName(_enteredstring);
            }
        }
        public Error Add(PhoneDirectory phonedirectory)
        {
            Error error = Validate(phonedirectory.number);
            if (error.iserror == false)
            {
                return repository.Add(phonedirectory);
            }
            return error;
        }
        public Error Validate(long _number)
        {
            Error error = new Error();
            if (_number.ToString().Length != 10)
            {
                error.iserror = true;
                error.description = "number should be of length 10";
            }
            else
                error.iserror = false;
            return error;
        }
    }
}
