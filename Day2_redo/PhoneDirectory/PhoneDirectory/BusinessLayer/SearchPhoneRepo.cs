using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class SearchPhoneRepo
    {
        public PhoneDirectoryRepository phoneRepository { get; set; }
        public KeypadMapping numToNameMapping { get; set; }

        public SearchPhoneRepo()
        {
            phoneRepository = new PhoneDirectoryRepository();
            numToNameMapping = new KeypadMapping();
        }
        public List<PhoneEntry> Search(string searchBy, string inputString)
        {
            string searchName;
            string searchNumber;       
            if (searchBy == "Number")
            {
                searchName = numToNameMapping.StringGenerator(inputString);
                searchNumber = inputString;
                return phoneRepository.Search(searchBy, searchName,searchNumber);
            }
            else
            {
                searchName = inputString;
                return phoneRepository.Search(searchBy, searchName);
            }
        }
    }
}
