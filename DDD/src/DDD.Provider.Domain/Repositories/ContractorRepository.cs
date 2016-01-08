using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.Repositories
{
    public class ContractorRepository
    {
        private EventBus _eventBus;
        public ContractorRepository(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task AddContractor(DDD.Provider.Domain.Entities.Contractor contractor)
        {
            using (var ctx = new POC_DDDContext())
            {
                ctx.Add(new Contractor
                {
                    ID = contractor.ID,
                    ContractorName = contractor.ContractorName,
                    DoingBusinessAs = contractor.DoingBusinessAsText,
                    EinNumber = contractor.EinNumber,
                    PhoneNumber = contractor.PhoneNumber,
                    AlternatePhoneNumber = contractor.ContractorAlternatePhoneNumber,
                    Email = contractor.Email,
                    ContactFirstName = contractor.Contact.Name.FirstName,
                    ContactLastName = contractor.Contact.Name.LastName,
                    ContactPhoneNumber = contractor.Contact.PhoneNumber,
                    ContactAlternatePhoneNumber = contractor.Contact.AlternatePhoneNumber,
                    ContactEmail = contractor.Contact.Email,
                    AddressLine1 = contractor.Address.AddressLine1,
                    AddressLine2 = contractor.Address.AddressLine2,
                    City = contractor.Address.City,
                    StateCode = contractor.Address.State,
                    ContractStartDate = contractor.ContractDuration.Start,
                    ContractEndDate = contractor.ContractDuration.End,
                    Status = contractor.Status.Value,
                    Type = contractor.ContractorType.Value,
                    FirstInsertedBy = "TODO",
                    FirstInsertedDateTime = DateTime.UtcNow,
                    LastSavedBy = "TODO",
                    LastSavedDateTime = DateTime.UtcNow,
                    SuffixCode = contractor.ContractorSuffixCode,
                    ZipCode = contractor.Address.ZipCode,
                    ZipExntension = "TODO"
                });

                await ctx.SaveChangesAsync();
                _eventBus.Publish<NewContractorAdded>(new NewContractorAdded(DateTime.UtcNow, contractor.ID, contractor.EinNumber));
            }
        }

        public Domain.Entities.Contractor GetContractor(Guid id)
        {
            using (var ctx = new POC_DDDContext())
            {
                var cont = ctx.Contractor.FirstOrDefault(x => x.ID == id);
                if (cont == null)
                    throw new ArgumentException($"Contractor with ${id} not found in database");

                var contact = new Contact(new Name(cont.ContactFirstName, cont.ContactLastName), cont.ContactPhoneNumber, cont.ContactAlternatePhoneNumber, cont.ContactEmail);
                var address = new Address(cont.AddressLine1, cont.AddressLine2, cont.City, cont.StateCode, cont.ZipCode);
                return new DDD.Provider.Domain.Entities.Contractor(cont.EinNumber, cont.ContractorName, cont.DoingBusinessAs, cont.StateCode, cont.Type, new DDD.Domain.Common.ValueObjects.DateTimeRange(cont.ContractStartDate, cont.ContractEndDate.Value)
                    , cont.PhoneNumber, contact, address, cont.Email);
            }
        }
    }
}
