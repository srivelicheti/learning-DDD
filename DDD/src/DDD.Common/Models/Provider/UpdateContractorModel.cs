using System;

namespace DDD.Common.Models.Provider
{
    public class UpdateContractorDetailModel
    {
        public string EinSsn { get; set; }
        public string Name { get; set; }
        public string DoingBusinessAs { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class UpdateContractorContactDetailModel
    {
        public string EinSsn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class RenewContractorContract
    {
        public string EinSsn { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }

    public class UpdateContractorAddressModel
    {
        public string EinSsn { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string ZipExtn { get; set; }
    }


    public class UpdateContractorModel
    {
        public string EinNumber { get; set; }
        public string ContractorName { get; set; }
        public string DoingBusinessAs { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }

        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactAlternatePhoneNumber { get; set; }
        public string ContactEmail { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string ZipExtn { get; set; }
    }
}
