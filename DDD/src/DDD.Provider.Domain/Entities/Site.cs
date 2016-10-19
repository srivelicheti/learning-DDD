using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Common.Extensions;
using DDD.Domain.Common;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Contracts.Enums;
using DDD.Provider.Domain.ValueObjects;
using NServiceBus;
using VO = DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Entities
{
    public class Site : Entity, IAggregateRoot
    {
        private readonly List<SiteHoliday> _holidays = new List<SiteHoliday>();
        private readonly List<SiteRate> _rates = new List<SiteRate>();

        public SiteStatus Status { get; private set; }
        public string SiteName { get; private set; }
        public int SiteNumber { get; private set; }
        public SiteFacilityType SiteFacitlityType { get; private set; }
        public DateTimeRange ContractDuration { get; private set; }
        public PhoneNumber PrimaryPhoneNumber { get; private set; }
        public Contact ContactDetails { get; private set; }
        public VO.Address Address { get; private set; }
        public string Email { get; private set; }
        public string CountyCode { get; private set; }
        public string CountyServedCode { get; private set; }
        public LicenceStatus LicencingStatus { get; private set; }
        public IReadOnlyCollection<SiteHoliday> Holidays => _holidays.AsReadOnly();

        public IReadOnlyCollection<SiteRate> SiteRates => _rates.AsReadOnly();

        public SiteType SiteType { get; private set; }

        internal SiteState DbState { get; private set; }

        //TODO: See how we can avoid injecting EventBus into the Domain entities
        public Site(Guid id, int siteNumber, string siteName, SiteStatus status, SiteFacilityType siteFacitlityType, SiteType siteType,
            DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, VO.Address address, string email,
            string countyCode, string countyServedCode, LicenceStatus licenceStatus, IEnumerable<SiteHoliday> holidays, IEnumerable<SiteRate> rates/*, IBus bus*/) : base(id/*, bus*/)
        {
            SiteNumber = siteNumber;
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
            InitializeDbState();
            holidays.ForEach(AddNewHoliday);
            rates.ForEach(AddNewSiteRate);
            
        }

        private void InitializeDbState()
        {
            DbState = new SiteState
            {
                Id = Id,
                AddressLine1 = Address.AddressLine1,
                AddressLine2 = Address.AddressLine2,
                AlternatePhoneNumber = null,
                City = Address.City,
                ContactAlternatePhoneNumber = ContactDetails.AlternatePhoneNumber,
                ContactEmail = ContactDetails.Email,
                ContactFirstName = ContactDetails.Name.FirstName,
                ContactLastName = ContactDetails.Name.LastName,
                ContactPhoneNumber = ContactDetails.PhoneNumber,
                SiteFacilityTypeCode = SiteFacitlityType.Value.ToString(),
                LicencingStatusCode = LicencingStatus.Value,
                SiteName = SiteName,
                SiteNumber = SiteNumber,
                SiteTypeCode = SiteType.Value,
                StateCode = Address.StateCode,
                ZipCode = Address.ZipCode,
                CountyCode = CountyCode,
                CountyServedCode = CountyServedCode,
                Email = Email,
                PhoneNumber = PrimaryPhoneNumber,
                ContractStartDate = ContractDuration.Start,
                ContractEndDate = ContractDuration.End,
                FirstInsertedBy = "TODO",
                FirstInsertedDateTime = DateTime.UtcNow,
                LastSavedBy = "TODO",
                LastSavedDateTime = DateTime.UtcNow,
                StatusCode = Status.Value
            };
        }

        public Site(int siteId, string siteName, SiteStatus status, SiteFacilityType siteFacitlityType, SiteType siteType,
            DateTimeRange contractDuration, PhoneNumber primaryPhoneNumber, Contact contactDetails, VO.Address address, string email,
            string county, string countyServed, LicenceStatus licenceStatus, IEnumerable<SiteHoliday> holidays, IEnumerable<SiteRate> rates/*, IBus eventBus*/)
            : this(GuidHelper.NewSequentialGuid(), siteId, siteName, status, siteFacitlityType, siteType, contractDuration, primaryPhoneNumber, contactDetails, address, email, county, countyServed, licenceStatus, holidays, rates/*, eventBus*/)
        { }

        internal Site(SiteState siteState/*, IBus bus*/) : base(siteState.Id/*, bus*/)
        {
            SiteName = siteState.SiteName;
            SiteNumber = siteState.SiteNumber;
            Id = siteState.Id;
            Address = new VO.Address(siteState.AddressLine1, siteState.AddressLine2, siteState.City, siteState.StateCode, siteState.ZipCode);
            ContactDetails = new Contact(new Name(siteState.ContactFirstName, siteState.ContactLastName), siteState.ContactPhoneNumber, siteState.ContactAlternatePhoneNumber, siteState.ContactEmail);
            ContractDuration = new DateTimeRange(siteState.ContractStartDate, siteState.ContractEndDate);
            CountyCode = siteState.CountyCode;
            CountyServedCode = siteState.CountyServedCode;
            Email = siteState.Email;
            LicencingStatus = siteState.LicencingStatusCode;
            PrimaryPhoneNumber = siteState.PhoneNumber;
            SiteFacitlityType = siteState.SiteFacilityTypeCode;
            SiteType = siteState.SiteTypeCode;
            Status = siteState.StatusCode;
            _holidays = siteState.SiteHoliday.Select(x => new SiteHoliday(x.HolidayDate, x.HolidayName)).ToList();
            _rates =
                siteState.SiteRate.Select(
                    x =>
                        new SiteRate(x.AgeCode, x.RegularCareDailyRate.GetValueOrDefault(),
                            x.RegularCareWeeklyRate.GetValueOrDefault(), x.EffectiveDate/*, bus*/)).ToList();

            DbState = siteState;
        }

        public void AddNewHoliday(SiteHoliday holiday)
        {
            if (this.Holidays.Count() >= 10)
            {
                //TODO: Implement Business rule violation that site can't have more than 10 holidays
            }
            if (_holidays.Any(x => x.HolidayDate.Date == holiday.HolidayDate.Date))
            {
                //TODO: Business rule violation duplicate holiday
            }
            _holidays.Add(holiday);
            DbState.SiteHoliday.Add(holiday.DbState);
        }

        public void RemoveSiteHoliday(DateTime holidayDate)
        {
            var holiday = _holidays.FindIndex(x => x.HolidayDate.Date == holidayDate.Date);
            if (holiday == -1)
            {
                //TODO: Check if holiday exists for this site, else throw exception
            }
            _holidays.RemoveAt(holiday);
            var dbHol = DbState.SiteHoliday.First(x => x.HolidayDate.Date == holidayDate.Date);
            DbState.SiteHoliday.Remove(dbHol);
        }

        public void AddNewSiteRate(SiteRate rate)
        {
            //TODO: Implement rules to make sure Aggregate root is always in valid state
            _rates.Add(rate);
            DbState.SiteRate.Add(rate.DbState);
        }

        public void RemoveSiteRate(SiteRate rate)
        {
            //TODO: Implement rules to make sure Aggregate root is always in valid state
            var index = _rates.FindIndex(x => x.AgeCode == rate.AgeCode);
            if(index == -1)
                throw new InvalidOperationException($"Rate with Age code {rate.AgeCode} not found for Site {this.SiteNumber}");

            _rates.RemoveAt(index);
            var dbRate = DbState.SiteRate.First(x => x.AgeCode == rate.AgeCode);
            DbState.SiteRate.Remove(dbRate);
        }

    }
}
