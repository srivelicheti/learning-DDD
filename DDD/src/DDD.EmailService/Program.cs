using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.EmailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var bus = NServiceBusBootStrapper.Init();
            Console.WriteLine("Bus Started");
            var key = Console.ReadLine();

            while (key != "A")
            {
                if(key == "Stop")
                    bus.Dispose();
                if (key == "Start")
                    bus = NServiceBusBootStrapper.Init();
                key = Console.ReadLine();
            }
            
        }
    }
}
