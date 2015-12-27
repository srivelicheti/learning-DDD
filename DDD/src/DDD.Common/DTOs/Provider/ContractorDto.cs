using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Common.DTOs.Provider
{
    public class ContractorDto
    {
        public Guid ID { get; set; }

        public string EinNumber { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string City { get; set; }
        public string ContactAlternatePhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public string ContractorName { get; set; }
        public DateTime ContractStartDate { get; set; }
        public string DoingBusinessAs { get; set; }
        public string Email { get; set; }
        public string FirstInsertedBy { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public string LastSavedBy { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string StateCode { get; set; }
        public string Status { get; set; }
        public string SuffixCode { get; set; }
        public string Type { get; set; }
        public string ZipCode { get; set; }
        public string ZipExntension { get; set; }
    }
}
