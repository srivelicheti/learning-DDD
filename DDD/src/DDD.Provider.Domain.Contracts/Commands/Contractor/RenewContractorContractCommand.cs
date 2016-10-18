using DDD.Domain.Common.Command;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    public class RenewContractorContractCommand :BaseCommand,ICommand
    {
        public RenewContractorContractCommand(DateTime startDate, DateTime endDate) :base(Guid.NewGuid(),"TODO")
        {
            
        }
    }
}
