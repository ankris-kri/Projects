using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory
{
    class Add
    {
        public PhoneDirectoryRepository phoneRepository { get; set; }

        public Add()
        {
            phoneRepository = new PhoneDirectoryRepository();
        }

        public ErrorValidation AddToDictionary(PhoneEntry phoneEntry)
        {
            return phoneRepository.Add(phoneEntry);
        }
    }
}
