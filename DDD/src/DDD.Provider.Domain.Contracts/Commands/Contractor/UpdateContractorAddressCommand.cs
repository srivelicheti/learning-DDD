using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Command;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    public class UpdateContractorAddressCommand :BaseCommand,ICommand
    {
        public UpdateContractorAddressCommand():base(Guid.NewGuid(),"TODO")
        {
            
        }
    }
}
