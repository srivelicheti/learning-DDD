using DDD.Provider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Services
{
    interface IContractorService
    {
        bool IsExistingContractor(string einNumber);
    }

    public class ContractorService : IContractorService
    {
        private ContractorRepository _contractorRepo;

        public ContractorService(ContractorRepository contractorRepo)
        {
            _contractorRepo = contractorRepo;
        }
        public bool IsExistingContractor(string einNumber)
        {
            throw new NotImplementedException();
        }
    }
}
