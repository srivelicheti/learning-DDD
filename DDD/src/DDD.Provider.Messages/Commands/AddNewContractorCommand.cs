using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Messages.Commands
{
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
