using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.QueryStack.Contractor.Queries
{
    public class FindContractorByEinQuery : IQuery<ContractorDto>
    {
        public string ContractorEin { get; set; }
    }
}
