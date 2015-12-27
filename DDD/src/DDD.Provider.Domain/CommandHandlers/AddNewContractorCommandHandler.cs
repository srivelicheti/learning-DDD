using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewContractorCommandHandler :
        ICommandHandler<AddNewContractorCommand>
    {
        private ContractorRepository _contractorRepository;
        private IContractorSuffixGenerator _contractorSuffixGenerator;
        public AddNewContractorCommandHandler(ContractorRepository contractorRepository, IContractorSuffixGenerator contractorSuffixGenerator)
        {
            _contractorRepository = contractorRepository;
            _contractorSuffixGenerator = contractorSuffixGenerator;
        }
        public void Execute(AddNewContractorCommand command)
        {
            var contractorDto = command.Contractor;
            
            //_contractorRepository.AddContractor();
        }
    }
}
