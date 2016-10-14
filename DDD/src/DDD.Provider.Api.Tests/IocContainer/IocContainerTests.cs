//using DDD.Provider.Domain.Repositories;
//using DDD.Web.Api.App_Start;
//using StructureMap;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace DDD.Web.Api.Tests.IocContainer
//{
//    public class IocContainerTests
//    {
//        [Fact]
//        public void Repositories_Must_Be_Once_Per_Resolution_to_the_Container()
//        {
//            var container = new Container();
//            var bus = NServiceBusBootStrapper.Init(container);
           
//            IocBootstrapper.ConfigureIocContainer(container,bus);

//            var repo1 = container.GetInstance<ContractorRepository>();
//            var repo2 = container.GetInstance<ContractorRepository>();

//            Assert.Same(repo1, repo2);
//        }
//    }
//}
