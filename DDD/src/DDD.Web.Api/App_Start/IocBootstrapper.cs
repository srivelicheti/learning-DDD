﻿using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Provider.Domain.CommandHandlers;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public class IocBootstrapper
    {
        public static IContainer ConfigureIocContainer(IContainer container)
        {
            container.Configure(x => x.ForSingletonOf<EventBus>().Use<EventBus>());
            container.Configure(x => x.For<IContainer>().Use(container));
            container.Configure(x => x.For<ICommandBus>().Use<IocContainerCommandBus>());
            return RegisterCommandHandlers(container);
        }


        private static IContainer RegisterCommandHandlers(IContainer container)
        {
            container.Configure(x => x.For<ICommandHandler<DDD.Provider.Domain.Commands.AddNewContractorCommand>>().Use<AddNewContractorCommandHandler>());
            container.Configure(x => x.ForConcreteType<ContractorRepository>());
            container.Configure(x => x.For<IContractorSuffixGenerator>().Use<ContractorSuffixGenerator>());
            return container;
           // container.ForGenericType(typeof(ICommandHandler<DDD.Provider.Domain.Commands.AddNewContractorCommand>)
        }
    }
}
