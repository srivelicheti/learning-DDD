using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.Query;
using DDD.Domain.Common.Services;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.CommandHandlers;
//using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.CommandValidators;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using DDD.Provider.Messages.Commands;
using DDD.Provider.QueryStack.Contractor.Queries;
using DDD.Provider.QueryStack.Contractor.QueryHandlers;
using Microsoft.AspNet.Http;
using NServiceBus;
using StructureMap;

namespace DDD.Web.Api
{
    public static class IocBootstrapper
    {
        public static IContainer ConfigureIocContainer(IContainer container , IBus bus)
        {
            container.Configure(x => x.ForSingletonOf<IBus>().Use(() => bus));
            //container.Configure(x => x.ForSingletonOf<DomainEventBus>());
            container.Configure(x => x.For<IContainer>().Use(container));
            //container.Configure(x => x.For<ICommandBus>().Use<IocContainerCommandBus>());
            container.Configure(x => x.For<IQueryProcessor>().Use<QueryProcessor>());
            RegisterCommandHandlers(container);
            RegisterRepositories(container);
            RegisterQueryHandlers(container);
            RegisterDbContexts(container);
            RegisterServices(container);
            return container;
        }


        private static void RegisterCommandHandlers(IContainer container)
        {
            //container.Configure(x => x.For<ICommandHandler<AddNewContractorCommand>>().Use<AddNewContractorCommandHandler>());
            //container.Configure(x => x.For<ICommandHandler<UpdateContractorCommand>>().Use<UpdateContractorCommandHandler>());
            //return container;
            // container.ForGenericType(typeof(ICommandHandler<DDD.Provider.Domain.Commands.AddNewContractorCommand>)
        }

        private static void RegisterRepositories(IContainer container)
        {
            container.Configure(x => x.ForConcreteType<ContractorRepository>());
        }

        public static void RegisterCommandValidators(IContainer container)
        {
            container.Configure(x => x.For<ICommandValidator<AddNewContractorCommand>>().Use<AddNewContractorCommandValidator>());
        }

        private static void RegisterQueryHandlers(IContainer container) {
            container.Configure(x => x.For<IQueryHandler<FindContractorByIdQuery, ContractorDto>>().Use<FindContractorByIdHandler>());
            container.Configure(x => x.For<IQueryHandler<FindContractorByEinQuery, ContractorDto>>().Use<FindContractorByEinQueryHandler>());
            container.Configure(x => x.ForConcreteType<FindContractorByEinQueryHandler>());
        }

        private static void RegisterDbContexts(IContainer container) {
            container.Configure(x => x.ForConcreteType<ProviderDbContext>());
        }

        private static void RegisterServices(IContainer container)
        {
            container.Configure(x => x.For<IMciService>().Use<MockMciService>());
            container.Configure(x => x.For<IContractorSuffixGenerator>().Use<ContractorSuffixGenerator>());
        }
    }
}
