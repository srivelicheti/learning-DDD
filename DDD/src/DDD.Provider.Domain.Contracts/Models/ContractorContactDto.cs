using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Contracts.Models
{
    public class ContractorContactDto
    {
        public string EinNumber { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactAlternatePhoneNumber { get; set; }
        public string ContactEmail { get; set; }
    }
}
