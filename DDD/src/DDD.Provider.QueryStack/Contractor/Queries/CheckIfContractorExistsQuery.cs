using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Query;

namespace DDD.Provider.QueryStack.Contractor.Queries
{
    public class CheckIfContractorExistsQuery : IQuery<bool>
    {
        public string EinNumber { get; set; }
    }
}
