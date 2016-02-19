using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class UpdatePhoneRepo
    {
        public SearchPhoneRepo PK_Validation { get; set; }
        public PhoneDirectoryRepository phoneRepo { get; set; }
        public ErrorValidation validation { get; set; }
        public UpdatePhoneRepo()
        {
            phoneRepo = new PhoneDirectoryRepository();
            PK_Validation = new SearchPhoneRepo();
            validation = new ErrorValidation();
        }

        public ErrorValidation Add(PhoneEntry phoneEntry)
        {
            string searchBy="Number";
            string searchNumber= phoneEntry.number.ToString();
            var resultList = PK_Validation.Search(searchBy, searchNumber);
            if (resultList.Any())
            {
                validation.isError = true;
                validation.description = "Number already presents in the Directory";
                return validation;
            }
            return phoneRepo.Add(phoneEntry);
        }
    }
}
