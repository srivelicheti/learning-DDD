using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using DDD.Domain.Common.ValueObjects;
using DDD.Common;
using Microsoft.Data.Entity.Extensions;

namespace DDD.Provider.Domain.Repositories
{
    public class SitesRepository
    {
        private DomainEventBus _eventBus;
        private ProviderDbContext _dbContext;

        public SitesRepository(DomainEventBus eventBus, ProviderDbContext dbContext)
        {
            _eventBus = eventBus;
            _dbContext = dbContext;
        }

        public void Add(Provider.Domain.Entities.Site site)
        {
            throw new NotImplementedException();
        }

        public void UpdateSite(Provider.Domain.Entities.Site site)
        {
            Claim.ValidateNotNull(site, nameof(site));
            Claim.ValidateNotNull(site.ID, $"name of {site} ID");
            var dbSite = _dbContext.Site.Find(site.ID);
            if (dbSite == null)
                throw new Exception($"site with {site.ID} not found in database"); //TODO: Create customexceptiom

            dbSite.AddressLine1 = site.Address.AddressLine1;
            dbSite.AddressLine2 = site.Address.AddressLine2;
            dbSite.City = site.Address.City;
            dbSite.ContactAlternatePhoneNumber = site.ContactDetails.AlternatePhoneNumber;
            dbSite.ContactEmail = site.ContactDetails.Email;
            dbSite.ContactFirstName = site.ContactDetails.Name.FirstName;
            dbSite.ContactLastName = site.ContactDetails.Name.LastName;
            dbSite.ContactPhoneNumber = site.ContactDetails.PhoneNumber;
            dbSite.ContractStartDate = site.ContractDuration.Start;
            dbSite.ContractEndDate = site.ContractDuration.End;
            dbSite.CountyCode = site.CountyCode;
            dbSite.CountyServedCode = site.CountyServedCode;
            dbSite.Email = site.Email;
            dbSite.IsWebEnabled = true;
            dbSite.LastSavedBy = "TODO";
            dbSite.LastSavedDateTime = DateTime.UtcNow;
            dbSite.LicencingStatusCode = site.LicencingStatus.Value;
            dbSite.PhoneNumber = site.PrimaryPhoneNumber;
            dbSite.SiteFacilityTypeCode = site.SiteFacitlityType.Value.ToString();
            this.UpdateHolidays(site, dbSite);
            dbSite.SiteName = site.SiteName;
            dbSite.SiteNumber = site.SiteID;
             //dbSite.SiteTypeCode = site.typ

        }

        private void UpdateHolidays(Entities.Site site, DataModel.Site dbSite)
        {
            var datesToBeRemoved = new List<SiteHoliday>();
            foreach (var hol in dbSite.SiteHoliday)
            {
                if (!dbSite.SiteHoliday.Any(x => x.HolidayDate.Date == hol.HolidayDate.Date))
                    datesToBeRemoved.Add(hol);
            }
            foreach (var removedHol in datesToBeRemoved)
            {
                dbSite.SiteHoliday.Remove(removedHol);
                //TODO: Raise an Domain event about the change of holidays or should these be raised by Site Aggregate root?
            }
            
            foreach(var item in site.Holidays)
            {
                var existingHoliday = dbSite.SiteHoliday.Where(x => x.HolidayDate.Date == item.HolidayDate.Date).FirstOrDefault();
                if (existingHoliday == null)
                {
                    dbSite.SiteHoliday.Add(new SiteHoliday
                    {
                        ID = GuidHelper.NewSequentialGuid(),
                        CalendarYearDate = item.HolidayDate.Year.ToString(),
                        HolidayDate = item.HolidayDate,
                        HolidayName = item.Name,
                        FirstInsertedByID = "TODO",
                        FirstInsertedDateTime = DateTime.UtcNow,
                        LastSavedByID = "TODO",
                        LastSavedDateTime = DateTime.UtcNow
                    });
                }
                else
                {
                    existingHoliday.LastSavedDateTime = DateTime.UtcNow;
                    existingHoliday.HolidayName = item.Name;
                }

            }
        }

        public Provider.Domain.Entities.Site GetSite(Guid siteId)
        {
            //using (var ctx = new ProviderDbContext()) {
            var site = _dbContext.Site.Include(x => x.SiteHoliday).Include(x => x.SiteRate).FirstOrDefault(x => x.ID == siteId);
            if (site == null)
                throw new ArgumentException($"Site not found with {siteId}");

            var contractDuration = new DateTimeRange(site.ContractStartDate, site.ContractEndDate.Value);
            var contact = new Contact(new Name(site.ContactFirstName, site.ContactLastName), site.ContactPhoneNumber, site.ContactAlternatePhoneNumber, site.ContactEmail);
            var address = new Address(site.AddressLine1, site.AddressLine2, site.City, site.StateCode, site.ZipCode);
            var holidays = site.SiteHoliday.Select(x =>
            {
                var hol = new DDD.Provider.Domain.ValueObjects.SiteHoliday(x.HolidayDate, x.HolidayName);
                hol.TrackingState = DDD.Domain.Common.TrackingState.Unchanged;
                return hol;
            });
            var domainSite = new Provider.Domain.Entities.Site(site.ID, site.SiteNumber, site.SiteName, site.StateCode, site.SiteFacilityTypeCode,site.SiteTypeCode,
                contractDuration, site.PhoneNumber, contact, address, site.Email, site.CountyCode, site.CountyServedCode, site.LicencingStatusCode, holidays);

            return domainSite;

            //}
        }
    }
}
