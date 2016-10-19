using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Contracts.Models
{
    public class ContractorDetailDto
    {
        public string EinNumber { get; set; }
        public string ContractorName { get; set; }
        public string DoingBusinessAs { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
