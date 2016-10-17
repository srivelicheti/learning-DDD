using System;
using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.Query;
using DDD.Domain.Common.Services;
using DDD.Provider.Common.DTOs;
using DDD.Provider.DataModel;
using DDD.Provider.Domain.CommandHandlers;
//using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.CommandValidators;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using DDD.Provider.Messages.Commands;
using Microsoft.AspNetCore.Http;
using NServiceBus;
using StructureMap;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace DDD.Provider.Domain
{
    public static class IocBootStrapper
    {
        public static IContainer ConfigureIocContainer(IContainer container, IEndpointInstance bus)
        {
            ConfigureFrameworkServices(container);
            container.Configure(x => x.ForSingletonOf<IEndpointInstance>().Use(() => bus));
            //container.Configure(x => x.ForSingletonOf<DomainEventBus>());
            container.Configure(x => x.For<IContainer>().Use(container));
            //container.Configure(x => x.For<ICommandBus>().Use<IocContainerCommandBus>());
            container.Configure(x => x.For<IQueryProcessor>().Use<QueryProcessor>());
            RegisterCommandHandlers(container);
            RegisterRepositories(container);
            RegisterDbContexts(container);
            RegisterServices(container);
            return container;
        }

        private static void ConfigureFrameworkServices(IContainer container)
        {
            var services = new ServiceCollection();
            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<ProviderDbContext>(op =>
               op.UseSqlServer(@"Data Source=.\SQL2016;Initial Catalog=POC_DDD;Integrated Security=False;User ID=srvelicheti;Password=Secret@123;MultipleActiveResultSets=true;Trusted_Connection=true;")
               );

            container.Populate(services);
        }

        private static void RegisterCommandHandlers(IContainer container)
        {
            container.Configure(x => x.ForConcreteType<AddNewContractorCommandHandler>());
            container.Configure(x => x.ForConcreteType<AddNewSiteCommandHandler>());
            container.Configure(x => x.ForConcreteType<UpdateContractorCommandHandler>());
        }

        private static void RegisterRepositories(IContainer container)
        {
            container.Configure(x => x.ForConcreteType<ContractorRepository>());
        }

        public static void RegisterCommandValidators(IContainer container)
        {
            container.Configure(x => x.For<ICommandValidator<AddNewContractorCommand>>().Use<AddNewContractorCommandValidator>());
        }
      
        private static void RegisterDbContexts(IContainer container)
        {
            container.Configure(x => x.ForConcreteType<ProviderDbContext>());
        }

        private static void RegisterServices(IContainer container)
        {
            container.Configure(x => x.For<IMciService>().Use<MockMciService>());
            container.Configure(x => x.For<IContractorSuffixGenerator>().Use<ContractorSuffixGenerator>());
        }
    }
}
