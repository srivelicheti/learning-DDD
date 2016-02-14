using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.Query;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.CommandHandlers;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using DDD.Provider.QueryStack.Contractor.Queries;
using DDD.Provider.QueryStack.Contractor.QueryHandlers;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public static class IocBootstrapper
    {
        public static IContainer ConfigureIocContainer(IContainer container)
        {
            container.Configure(x => x.For<DomainEventBus>().Use<DomainEventBus>());
            container.Configure(x => x.For<IContainer>().Use(container));
            container.Configure(x => x.For<ICommandBus>().Use<IocContainerCommandBus>());
            container.Configure(x => x.For<IQueryProcessor>().Use<QueryProcessor>());
            RegisterCommandHandlers(container);
            RegisterQueryHandlers(container);
            RegisterDbContexts(container);
            return container;
        }


        private static void RegisterCommandHandlers(IContainer container)
        {
            container.Configure(x => x.For<ICommandHandler<DDD.Provider.Domain.Commands.AddNewContractorCommand>>().Use<AddNewContractorCommandHandler>());
            container.Configure(x => x.ForConcreteType<ContractorRepository>());
            container.Configure(x => x.For<IContractorSuffixGenerator>().Use<ContractorSuffixGenerator>());
            //return container;
           // container.ForGenericType(typeof(ICommandHandler<DDD.Provider.Domain.Commands.AddNewContractorCommand>)
        }

        private static void RegisterQueryHandlers(IContainer container) {
            container.Configure(x => x.For<IQueryHandler<FindContractorByIDQuery, ContractorDto>>().Use<FindContractorByIDHandler>());
            container.Configure(x => x.For<IQueryHandler<FindContractorByEinQuery, ContractorDto>>().Use<FindContractorByEinQueryHandler>());
            container.Configure(x => x.ForConcreteType<FindContractorByEinQueryHandler>());
        }

        private static void RegisterDbContexts(IContainer container) {
            container.Configure(x => x.ForConcreteType<ProviderDbContext>());
        }
    }
}
