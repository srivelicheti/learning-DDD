using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Command;
using DDD.Provider.Common.Models;
using DDD.Provider.Domain.Contracts.Models;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Commands.Contractor
{
    public class UpdateContractorContactDetailCommand :BaseCommand,ICommand
    {
        public UpdateContractorContactDetailCommand(UpdateContractorContactDetailModel updateContractorContactDetail)
            :base(Guid.NewGuid(),"TODO")
        {
            UpdateContractorContactDetail = updateContractorContactDetail;
        }

        public UpdateContractorContactDetailModel UpdateContractorContactDetail { get; private set; }
    }
}
