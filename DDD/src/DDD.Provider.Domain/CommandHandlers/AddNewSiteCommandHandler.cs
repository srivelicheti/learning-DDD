using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Enums;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.ValueObjects;
using DDD.Provider.Messages.Commands;
using DDD.Provider.Messages.Events;
using NServiceBus;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewSiteCommandHandler : IHandleMessages<AddNewSiteCommand>
    {
        private SitesRepository _siteRepository;
        //private IBus _bus;

        public AddNewSiteCommandHandler(SitesRepository siteRepository/*, IBus bus*/)
        {
            _siteRepository = siteRepository;
            //_bus = bus;
        }
        public async Task Handle(AddNewSiteCommand message, IMessageHandlerContext messageContext)
        {
            var siteDto = message.Site;
            SiteFacilityType facitlType = siteDto.SiteFacitlityTypeCode;
            SiteType siteType = siteDto.SiteTypeCode;
            var contractDuration = new DateTimeRange(siteDto.ContractStartDate, siteDto.ContractEndDate);
            var contact = new Contact(new Name(siteDto.ContactFirstName, siteDto.ContactLastName),
                siteDto.ContactPhoneNumber, null, siteDto.ContactEmailText);
            var address = new DDD.Domain.Common.ValueObjects.Address(siteDto.AddressLine1, siteDto.AddressLine2,
                siteDto.City, "DE", siteDto.ZipCode, siteDto.CountyCode);

            var holidays = siteDto.SiteHolidays.Select(x => new SiteHoliday(x.HolidayDate, x.HolidayName)).ToList();
            var rates = siteDto.SiteRates.Select(x => new SiteRate(x.MinAge, x.Rate, (x.Rate * 1.5m), DateTime.Now));
            var siteEntity = new Site(GuidHelper.NewSequentialGuid(), siteDto.SiteNumber, siteDto.SiteName,
                SiteStatus.Active, facitlType, siteType,
                contractDuration, siteDto.PhoneNumber, contact, address, siteDto.SiteEmailText, siteDto.CountyCode,
                siteDto.CountyServed
                , LicenceStatus.Licenced, holidays,rates);
            
            _siteRepository.Add(siteEntity);
            await _siteRepository.SaveAsync();
            await messageContext.Publish(new NewSiteAdded(siteEntity.Id,siteEntity.SiteNumber));
        }
    }
}
