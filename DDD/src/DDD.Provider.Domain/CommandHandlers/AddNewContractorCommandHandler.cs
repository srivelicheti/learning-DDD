using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewContractorCommandHandler :
        ICommandHandler<AddNewContractorCommand>
    {
        public void Execute(AddNewContractorCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
