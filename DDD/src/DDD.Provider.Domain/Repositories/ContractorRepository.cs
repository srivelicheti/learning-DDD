using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Enums;

namespace DDD.Provider.Domain.Repositories
{
    public class ContractorRepository
    {
        private DomainEventBus _eventBus;
        public ContractorRepository(DomainEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task AddContractor(Entities.Contractor contractor)
        {
            using (var ctx = new ProviderDbContext())
            {
                contractor.DbState.FirstInsertedBy = "TODO";
                contractor.DbState.FirstInsertedDateTime = DateTime.UtcNow;
                contractor.DbState.LastSavedBy = "TODO";
                contractor.DbState.LastSavedDateTime = DateTime.UtcNow;
                ctx.Add(contractor.DbState);
                _eventBus.QueueForPostCommit(new NewContractorAdded(DateTime.UtcNow, contractor.Id, contractor.EinNumber, _eventBus));
                await ctx.SaveChangesAsync();
                _eventBus.PublishQueuedPostCommitEvents();
            }
        }

        public Entities.Contractor GetContractor(Guid id)
        {
            using (var ctx = new ProviderDbContext())
            {
                var cont = ctx.Contractor.FirstOrDefault(x => x.Id == id);
                if (cont == null)
                    throw new ArgumentException($"Contractor with ${id} not found in database");
                return new Contractor(cont);
            }
        }

        public bool IsContractorExistingWithEin(string einNumber)
        {
            using (var ctx = new ProviderDbContext())
            {
                return ctx.Contractor.Any(x => x.EinNumber == einNumber);
            }
        }

        public List<string> GetContractorEinsStartingWith(string einSsn, ContractorType type)
        {
            using (var context = new ProviderDbContext())
            {
                var contractorType = type.Value;
                return context.Contractor.Where(x => x.EinNumber.StartsWith(einSsn) && x.Type == contractorType).Select(x => x.EinNumber).ToList();
            }
        }
    }
}
