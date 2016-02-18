using System;
using System.Collections.Generic;

namespace PhoneDirectory
{
    class BusinessLayer
    {
        public PhoneDirectoryRepository repository { get; set; }
        public KeypadDictionary keypadDictionary { get; set; }
        public ErrorDto error { get; set; }

        public BusinessLayer()
        {
            repository = new PhoneDirectoryRepository();
            keypadDictionary = new KeypadDictionary();
            error = new ErrorDto();
        }   
        public List<PhoneEntry> Search(string searchBy ,string inputString)
        {
            string keypadMatch=null;
            if (searchBy == "Number")
                keypadMatch=keypadDictionary.StringGenerator(inputString);
            return repository.Search(searchBy,inputString,keypadMatch);
        }
        public ErrorDto Add(PhoneEntry phoneEntry)
        {
             Validate(phoneEntry.number);
            if (error.isError == false)
            {
                return repository.Add(phoneEntry);
            }
            return error;
        }
        public void Validate(long _number)
        {
            if (_number.ToString().Length != 10)
            {
                error.isError = true;
                error.description = "number should be of length 10";
            }
        }
    }
}
