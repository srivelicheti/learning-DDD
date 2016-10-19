using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Contracts.Models;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    public class UpdateContractorContactDetailCommand :BaseCommand,ICommand
    {
        public UpdateContractorContactDetailCommand(ContractorContactDto contractorContactDetail)
            :base(Guid.NewGuid(),"TODO")
        {
            ContractorContactDetail = contractorContactDetail;
        }

        public ContractorContactDto ContractorContactDetail { get; private set; }
    }
}
