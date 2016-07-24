using DDD.Domain.Common.Command;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Common.Models;

namespace DDD.Provider.Messages.Commands
{
    public class UpdateContractorCommand : BaseCommand, ICommand
    {
        public UpdateContractorCommand(UpdateContractorModel contractor) : base(Guid.NewGuid(), "Anonymous")
        {
            //TODO: pass actual user who submitted the command
            Contractor = contractor;
        }

        public UpdateContractorModel Contractor { get; private set; }
    }
}
