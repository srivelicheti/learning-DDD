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
        private EventBus _eventBus;
        private ProviderDbContext _dbContext;

        public SitesRepository(EventBus eventBus, ProviderDbContext dbContext)
        {
            _eventBus = eventBus;
            _dbContext = dbContext;
        }

        public void Add(Provider.Domain.Entities.Site site) {
            throw new NotImplementedException();
        }

        public void UpdateSite(Provider.Domain.Entities.Site site)
        {
            Claim.ValidateNotNull(site,nameof(site));
            Claim.ValidateNotNull(site.ID,$"name of {site} ID");
            var dbSite =_dbContext.Site.Find(site.ID);
            if (dbSite == null)
                throw new Exception($"site with {site.ID} not found in database"); //TODO: Create customexceptiom

        }

        private void UpdateHolidays(Entities.Site site, DataModel.Site dbSite)
        {
            //foreach (var hol in dbSite.SiteHoliday)
            //{
            //    if()
            //}
        }

        public Provider.Domain.Entities.Site GetSite(Guid siteId) {
            //using (var ctx = new ProviderDbContext()) {
                var site = _dbContext.Site.Include(x=> x.SiteHoliday).Include(x => x.SiteRate).FirstOrDefault(x => x.ID == siteId);
                if (site == null)
                    throw new ArgumentException($"Site not found with {siteId}");

                var contractDuration = new DateTimeRange(site.ContractStartDate, site.ContractEndDate.Value);
                var contact = new Contact(new Name(site.ContactFirstName, site.ContactLastName), site.ContactPhoneNumber, site.ContactAlternatePhoneNumber, site.ContactEmail);
                var address = new Address(site.AddressLine1, site.AddressLine2, site.City, site.StateCode, site.ZipCode);
                var holidays = site.SiteHoliday.Select(x => {
                    var hol =new DDD.Provider.Domain.ValueObjects.SiteHoliday(x.HolidayDate,x.HolidayName);
                    hol.State = DDD.Domain.Common.TrackingState.Unchanged;
                    return hol;
                });
                var domainSite = new Provider.Domain.Entities.Site(site.ID,site.SiteNumber ,site.SiteName, site.StateCode, site.SiteFacilityTypeCode,
                    contractDuration, site.PhoneNumber, contact, address, site.Email, site.CountyCode, site.CountyServedCode, site.LicencingStatusCode, holidays);

                return domainSite;

            //}
        }
    }
}
