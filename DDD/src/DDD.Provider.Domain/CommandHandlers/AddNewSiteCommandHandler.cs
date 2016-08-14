using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Messages.Commands;
using NServiceBus;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewSiteCommandHandler : IHandleMessages<AddNewSiteCommand>
    {
        public void Handle(AddNewSiteCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
