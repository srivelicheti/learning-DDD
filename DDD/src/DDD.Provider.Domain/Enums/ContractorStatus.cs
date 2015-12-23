using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class ContractorStatus : Enumeration<ContractorStatus>
    {
        public static readonly ContractorStatus Open = new ContractorStatus(0, "Open");

        public static readonly ContractorStatus Closed = new ContractorStatus(2, "Closed");

        private ContractorStatus(int value, string displayName) : base(value, displayName) { }
    }
}
