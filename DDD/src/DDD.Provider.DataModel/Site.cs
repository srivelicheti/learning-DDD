using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class Site
    {
        public Site()
        {
            ContractorSite = new HashSet<ContractorSite>();
            SiteHoliday = new HashSet<SiteHoliday>();
            SiteRate = new HashSet<SiteRate>();
        }

        public Guid ID { get; set; }
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
        public DateTime ContractStartDate { get; set; }
        public string CountyCode { get; set; }
        public string CountyServedCode { get; set; }
        public string Email { get; set; }
        public string FirstInsertedBy { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public bool IsWebEnabled { get; set; }
        public string LastSavedBy { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public string LicencingStatusCode { get; set; }
        public int? LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string SiteFacilityTypeCode { get; set; }
        public string SiteName { get; set; }
        public int SiteNumber { get; set; }
        public string SiteTypeCode { get; set; }
        public string StateCode { get; set; }
        public string StatusCode { get; set; }
        public string ZipCode { get; set; }
        public string ZipExtension { get; set; }

        public virtual ICollection<ContractorSite> ContractorSite { get; set; }
        public virtual ICollection<SiteHoliday> SiteHoliday { get; set; }
        public virtual ICollection<SiteRate> SiteRate { get; set; }
    }
}
