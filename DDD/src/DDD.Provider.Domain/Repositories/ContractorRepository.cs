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
using DDD.Provider.Messages.Events;
using NServiceBus;

namespace DDD.Provider.Domain.Repositories
{
    public class ContractorRepository
    {
        private readonly IEndpointInstance _eventBus;
        private readonly ProviderDbContext _dbContext;

        public ContractorRepository(IEndpointInstance eventBus, ProviderDbContext dbContext)
        {
            _eventBus = eventBus;
            _dbContext = dbContext;
        }

        public void AddContractor(Entities.Contractor contractor)
        {
            contractor.DbState.FirstInsertedBy = "TODO";
            contractor.DbState.FirstInsertedDateTime = DateTime.UtcNow;
            contractor.DbState.LastSavedBy = "TODO";
            contractor.DbState.LastSavedDateTime = DateTime.UtcNow;
            _dbContext.Add(contractor.DbState);
            _eventBus.Publish(new ContractorAdded(DateTime.UtcNow, contractor.Id, contractor.EinNumber));
        }

        public Contractor GetContractor(Guid id)
        {
            var cont = _dbContext.Contractor.FirstOrDefault(x => x.Id == id);
            if (cont == null)
                throw new ArgumentException($"Contractor with ${id} not found in database");
            return new Contractor(cont/*, _eventBus*/);
        }

        public Contractor GetContractorByEin(string einNumber)
        {
            var cont = _dbContext.Contractor.FirstOrDefault(x => x.EinNumber == einNumber);
            if (cont == null)
                throw new ArgumentException($"Contractor with ${einNumber} not found in database");

            return new Contractor(cont/*,_eventBus*/);
        }

        public bool IsContractorExistingWithEin(string einNumber)
        {
            return _dbContext.Contractor.Any(x => x.EinNumber == einNumber);
        }

        public List<string> GetContractorEinsStartingWith(string einSsn, ContractorType type)
        {
            var contractorType = type.Value;
            return _dbContext.Contractor.Where(x => x.EinNumber.StartsWith(einSsn) && x.Type == contractorType).Select(x => x.EinNumber).ToList();
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
