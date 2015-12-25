using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Commands
{
    public class AddNewContractorCommand : Command
    {
        private ContractorDto _contractor;
        public AddNewContractorCommand(ContractorDto contractor) : base(Guid.NewGuid())
        {
            _contractor = contractor;
        }
    }
}
