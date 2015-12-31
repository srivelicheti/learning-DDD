using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
