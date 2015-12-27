using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class ContractorType : Enumeration<ContractorType,string>
    {
        public static ContractorType Contracted = new ContractorType("C", "Contracted");

        public static ContractorType SelfArranged = new ContractorType("S", "Self-Arranged");
        private ContractorType(string value, string displayName) : base(value, displayName) { }
    }
}
