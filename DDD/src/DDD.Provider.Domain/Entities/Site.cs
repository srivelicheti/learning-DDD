using DDD.Domain.Common;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Enums;
using DDD.Provider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Entities
{
    public class Site : Entity, IAggregateRoot
    {
        //private long _siteID;
        //private string _siteName;

        public SiteStatus Status { get; private set; }
        public string SiteName { get; private set; }
        public int SiteId { get; private set; }
        public SiteFacilityType SiteFacitlityType { get; private set; }
        public DateTimeRange ContractDuration { get; private set; }
        public PhoneNumber PrimaryPhoneNumber { get; private set; }
        public Contact ContactDetails { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public string CountyCode { get; private set; }
        public string CountyServedCode { get; private set; }
        public LicenceStatus LicencingStatus { get; private set; }
        public IEnumerable<SiteHoliday> Holidays { get; private set; }

        public SiteType SiteType { get; private set; }

        public Site(Guid id, int siteId, string siteName, SiteStatus status, SiteFacilityType siteFacitlityType, SiteType siteType,
            DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, Address address, string email,
            string countyCode, string countyServedCode, LicenceStatus licenceStatus, IEnumerable<SiteHoliday> holidays) : base(id)
        {
            SiteId = siteId;
            SiteName = siteName;
            Status = status;
            SiteFacitlityType = siteFacitlityType;
            SiteType = siteType;
            ContractDuration = contractDuration;
            PrimaryPhoneNumber = primaryPhoneNumber;
            ContactDetails = contactDetails;
            Address = address;
            Email = email;
            CountyCode = countyCode;
            CountyServedCode = countyServedCode;
            LicencingStatus = licenceStatus;
            Holidays = holidays;
        }

        public Site(int siteId, string siteName, SiteStatus status, SiteFacilityType siteFacitlityType, SiteType siteType,
            DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, Address address, string email,
            string county, string countyServed, LicenceStatus licenceStatus, IEnumerable<SiteHoliday> holidays) : this(GuidHelper.NewSequentialGuid(), siteId, siteName, status, siteFacitlityType, siteType, contractDuration, primaryPhoneNumber, contactDetails, address, email, county, countyServed, licenceStatus, holidays)
        { }

    }
}
