using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class ContractorStatus : Enumeration<ContractorStatus,string>
    {
        public static readonly ContractorStatus Open = new ContractorStatus("O", "Open");

        public static readonly ContractorStatus Closed = new ContractorStatus("C", "Closed");

        private ContractorStatus(string value, string displayName) : base(value, displayName) { }
    }
}
