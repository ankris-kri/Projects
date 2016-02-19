using System;
using System.Collections.Generic;

namespace PhoneDirectory
{
    class BusinessLayer
    {

        public ErrorValidation validation { get; set; }
        public SearchPhoneRepo businessLayerSearch { get; set; }
        public UpdatePhoneRepo businessLayerAdd { get; set; }

        public BusinessLayer()
        {

            validation = new ErrorValidation();
            businessLayerSearch = new SearchPhoneRepo();
            businessLayerAdd = new UpdatePhoneRepo();
        }
        public List<PhoneEntry> SearchDictionary(string searchBy, string inputString)
        {
            return businessLayerSearch.Search(searchBy, inputString);
            
        }
        public ErrorValidation AddToDictionary(PhoneEntry phoneEntry)
        {
            return businessLayerAdd.Add(phoneEntry);
        }
    }
}