using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Query;
using DDD.Provider.DataModel;
using DDD.Provider.QueryStack.Contractor.Queries;

namespace DDD.Provider.QueryStack.Contractor.QueryHandlers
{
    public class CheckIfContractorExistsQueryHandler: IQueryHandler<CheckIfContractorExistsQuery,bool>
    {
        private ProviderDbContext _dbContext;

        public CheckIfContractorExistsQueryHandler(ProviderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Handle(CheckIfContractorExistsQuery query)
        {
            if (query.EinNumber.Length == 9)
            {
                return _dbContext.Contractor.Any(x => x.EinNumber.StartsWith(query.EinNumber));
            }
            else
            {
                return _dbContext.Contractor.Any(x => x.EinNumber == query.EinNumber);
            }
        }
    }
}
