using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Repositories
{
    public class SitesRepository
    {
        private EventBus _eventBus;
        public SitesRepository(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Add(Site site) {
            throw new NotImplementedException();
        }

        public Site GetSite(Guid siteId) {
            using (var ctx = new ProviderDbContext()) {
                var site = ctx.Site.Include(x=> x.SiteHoliday).Include(x => x.SiteRate).FirstOrDefault(x => x.ID == siteId);
                if (site == null)
                    throw new ArgumentException($"Site not found with {siteId}");

                var contractDuration = new DateTimeRange(site.ContractStartDate, site.ContractEndDate.Value);
                var contact = new Contact(new Name(site.ContactFirstName, site.ContactLastName), site.ContactPhoneNumber, site.ContactAlternatePhoneNumber, site.ContactEmail);
                var address = new Address(site.AddressLine1, site.AddressLine2, site.City, site.StateCode, site.ZipCode);
                //var holidays = site.SiteHoliday.Select(x => new DDD.Domain.Common.ValueObjects)
                var domainSite = new Provider.Domain.Entities.Site(site.ID,site.SiteName,site.StateCode,site.SiteFacilityTypeCode,
                    contractDuration,site.PhoneNumber,contact,address,site.Email,site.CountyCode,site.CountyServedCode,site.LicencingStatusCode)

            }
        }
    }
}
