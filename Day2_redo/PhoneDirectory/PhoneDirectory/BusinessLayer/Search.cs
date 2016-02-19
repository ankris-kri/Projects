using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class Search
    {
        public PhoneDirectoryRepository phoneRepository { get; set; }
        public KeypadMapping numToNameMapping { get; set; }

        public Search()
        {
            phoneRepository = new PhoneDirectoryRepository();
            numToNameMapping = new KeypadMapping();
        }
        public List<PhoneEntry> SearchPhoneDirectory(string searchBy, string inputString)
        {
            string searchName="";
            string searchNumber="";       
            if (searchBy == "Number")
            {
                searchName = numToNameMapping.StringGenerator(inputString);
                searchNumber = inputString;
            }
            if(searchBy=="Name")
            {
                searchName = inputString;
                searchNumber =" ";        
            }

            return phoneRepository.Search(searchNumber, searchName);
        }
    }
}
