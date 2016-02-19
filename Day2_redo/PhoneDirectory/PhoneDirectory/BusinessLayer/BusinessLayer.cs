using System;
using System.Collections.Generic;

namespace PhoneDirectory
{
    class BusinessLayer
    {

        public ErrorValidation validation { get; set; }
        public Search businessLayerSearch { get; set; }
        public Add businessLayerAdd { get; set; }

        public BusinessLayer()
        {

            validation = new ErrorValidation();
            businessLayerSearch = new Search();
            businessLayerAdd = new Add();
        }
        public List<PhoneEntry> SearchDictionary(string searchBy, string inputString)
        {
            return businessLayerSearch.SearchPhoneDirectory(searchBy,inputString);
            
        }
        public ErrorValidation AddToDictionary(PhoneEntry phoneEntry)
        {
            return businessLayerAdd.AddToDictionary(phoneEntry);
        }
    }
}