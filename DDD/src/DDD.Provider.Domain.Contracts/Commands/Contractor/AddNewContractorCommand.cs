using DDD.Domain.Common.Command;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Domain.Contracts.DTOs;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    //public class AddNewContractorCommand : , ICommand
    public class AddNewContractorCommand : BaseCommand, ICommand 
    {
        public AddNewContractorCommand(ContractorDto contractor) : base(Guid.NewGuid(), "Anonymous")
        {
            //TODO: pass actual user who submitted the command
            Contractor = contractor;
        }

        public ContractorDto Contractor { get; private set; }
    }
    
}
