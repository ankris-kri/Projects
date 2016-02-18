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
            string searchName="";
            string searchNumber="";       
            if (searchBy == "Number")
            {
                searchName= keypadDictionary.StringGenerator(inputString);
                searchNumber = inputString;
            }
            if(searchBy=="Name")
            {
                searchName = inputString;
                searchNumber =" ";         // if assigned null then which searching, all the datas will be printed
            }

            return repository.Search(searchNumber, searchName);
        }
        public ErrorDto Add(PhoneEntry phoneEntry)
        {
            return repository.Add(phoneEntry);
        }
    }
}