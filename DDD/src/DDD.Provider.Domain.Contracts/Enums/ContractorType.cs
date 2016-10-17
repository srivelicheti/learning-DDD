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

        public static implicit operator string(ContractorType type)
        {
            return type.Value;
        }

        public static implicit operator ContractorType(string code)
        {
            if (code == ContractorType.Contracted.Value)
                return ContractorType.Contracted;
            else if (code == ContractorType.SelfArranged.Value)
                return ContractorType.SelfArranged;
            else
                throw new InvalidCastException($"{code} is not a valid value for ContractorType enumeration");
        }
    }
}
