using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class ContractorType : Enumeration<ContractorType>
    {
        public static ContractorType Contracted = new ContractorType(0, "Contracted");

        public static ContractorType SelfArranged = new ContractorType(0, "Self-Arranged");
        private ContractorType(int value, string displayName) : base(value, displayName) { }
    }
}
