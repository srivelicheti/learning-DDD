using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Common;
using DDD.Domain.Common;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.DataModel;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Extensions;
using Site = DDD.Provider.Domain.Entities.Site;
using NServiceBus;
using VO = DDD.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Data;


namespace DDD.Provider.Domain.Repositories
{
    public class SitesRepository
    {
        private IEndpointInstance _eventBus;
        private readonly ProviderDbContext _dbContext;

        public SitesRepository(IEndpointInstance eventBus, ProviderDbContext dbContext)
        {
            _eventBus = eventBus;
            _dbContext = dbContext;
        }

        public void Add(Site site)
        {
            _dbContext.Site.Add(site.DbState);
        }

        public void UpdateSite(Site site)
        {
            //TODO: Make the change to include SiteState Domain Entity to act as decorater to the SiteState Presistance Entity, this will avoid getting the entity from database twice and lead to better results
            Claim.ValidateNotNull(site, nameof(site));
            Claim.ValidateNotNull(site.Id, $"name of {site} ID");
            var dbSite = _dbContext.Site.Find(site.Id);
            if (dbSite == null)
                throw new Exception($"site with {site.Id} not found in database"); //TODO: Create customexceptiom

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
            UpdateHolidays(site, dbSite);
            dbSite.SiteName = site.SiteName;
            dbSite.SiteNumber = site.SiteNumber;
            dbSite.SiteTypeCode = site.SiteType.Value;
        }

        private void UpdateHolidays(Site site, SiteState dbSiteState)
        {
            var datesToBeRemoved = new List<SiteHolidayState>();
            foreach (var hol in dbSiteState.SiteHoliday)
            {
                if (dbSiteState.SiteHoliday.All(x => x.HolidayDate.Date != hol.HolidayDate.Date))
                    datesToBeRemoved.Add(hol);
            }
            foreach (var removedHol in datesToBeRemoved)
            {
                dbSiteState.SiteHoliday.Remove(removedHol);
                //TODO: Raise an Domain event about the change of holidays or should these be raised by SiteState Aggregate root?
            }
            
            foreach(var item in site.Holidays)
            {
                var existingHoliday = dbSiteState.SiteHoliday.FirstOrDefault(x => x.HolidayDate.Date == item.HolidayDate.Date);
                if (existingHoliday == null)
                {
                    dbSiteState.SiteHoliday.Add(new SiteHolidayState
                    {
                        Id = GuidHelper.NewSequentialGuid(),
                        CalendarYearDate = item.HolidayDate.Year.ToString(),
                        HolidayDate = item.HolidayDate,
                        HolidayName = item.Name,
                        FirstInsertedById = "TODO",
                        FirstInsertedDateTime = DateTime.UtcNow,
                        LastSavedById = "TODO",
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

        public Site GetSite(Guid siteId)
        {
            throw new NotImplementedException();
            //using (var ctx = new ProviderDbContext()) {
            //var site = _dbContext.Site.Include(x => SiteHoliday).Include(x => x.SiteRate).FirstOrDefault(x => x.Id == siteId);
            //if (site == null)
            //    throw new ArgumentException($"Site not found with {siteId}");

            //var contractDuration = new DateTimeRange(site.ContractStartDate, site.ContractEndDate);
            //var contact = new Contact(new Name(site.ContactFirstName, site.ContactLastName), site.ContactPhoneNumber, site.ContactAlternatePhoneNumber, site.ContactEmail);
            //var address = new VO.Address(site.AddressLine1, site.AddressLine2, site.City, site.StateCode, site.ZipCode);
            //var holidays = site.SiteHoliday.Select(x =>
            //{
            //    var hol = new ValueObjects.SiteHoliday(x.HolidayDate, x.HolidayName)
            //    {
            //        TrackingState = TrackingState.Unchanged
            //    };
            //    return hol;
            //});
            //var domainSite = new Site(site.Id, site.SiteNumber, site.SiteName, site.StateCode, site.SiteFacilityTypeCode,site.SiteTypeCode,
            //    contractDuration, site.PhoneNumber, contact, address, site.Email, site.CountyCode, site.CountyServedCode, site.LicencingStatusCode, holidays,_eventBus);

            //return domainSite;

            //}
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
