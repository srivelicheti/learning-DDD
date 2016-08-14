using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Common.DTOs
{
    public class SiteDto
    {

        public string SiteName { get; set; }

        public int SiteNumber { get; set; }

        public string SiteTypeCode { get; set; }

        public string FacilityTypeCode { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime? ContractEndDate { get; set; }
        public long LicenseNumber { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public string CountyCode { get; set; }

        public string ZipCode { get; set; }

        public string ZipExtension { get; set; }

        public string PhoneNumber { get; set; }

        public string CountyServed { get; set; }

        public string LicensingStatusCode { get; set; }

        public bool WebEnabledIndicator { get; set; }

        public string SiteEmailText { get; set; }


        //[Phone(ErrorMessage = "Site Alternate Phone Number is not valid")]
        //[MaxLength(15)]
        //public string SiteAlternatePhoneNumber { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmailText { get; set; }


        public string EnforcementActionCode { get; set; }

        public List<SiteHolidayDto> SiteHolidays { get; set; }

        public List<SiteRateDto> SiteRates { get; set; }
    }
}
