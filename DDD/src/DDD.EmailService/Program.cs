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
            NServiceBusBootStrapper.Init();
            Console.WriteLine("Bus Started");
            var key = Console.ReadLine();
            while (key != "A")
                key = Console.ReadLine();
        }
    }
}
