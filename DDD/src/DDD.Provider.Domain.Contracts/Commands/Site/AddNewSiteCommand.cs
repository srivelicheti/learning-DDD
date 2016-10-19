using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Command;
using DDD.Provider.Domain.Contracts.DTOs;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Commands.Site   
{
    public class AddNewSiteCommand : BaseCommand, ICommand
    {
        public AddNewSiteCommand(SiteDto site) : base(GuidHelper.NewSequentialGuid(), "Anonymous")
        {
            Site = site;
        }
        public SiteDto Site { get; private set; }
    }
}
