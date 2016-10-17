using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var container = new Container();
            var bus = NServiceBusBootStrapper.Init(container);
            IocBootStrapper.ConfigureIocContainer(container, bus);
            Console.WriteLine("Bus Started");
            var key = Console.ReadLine();

            while (key != "A")
            {
                if (key == "Stop")
                    bus.Stop().Wait();
                if (key == "Start")
                    bus = NServiceBusBootStrapper.Init(container);
                key = Console.ReadLine();
            }
        }
    }
}
