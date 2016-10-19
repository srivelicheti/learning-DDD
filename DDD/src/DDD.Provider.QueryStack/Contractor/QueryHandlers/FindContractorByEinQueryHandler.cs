using DDD.Domain.Common.Query;
using DDD.Provider.DataModel;
using DDD.Provider.QueryStack.Contractor.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Api.Contracts.DTOs;

namespace DDD.Provider.QueryStack.Contractor.QueryHandlers
{
    public class FindContractorByEinQueryHandler : IQueryHandler<FindContractorByEinQuery, ContractorDto>
    {
        private ProviderDbContext _dbContext;

        public FindContractorByEinQueryHandler(ProviderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ContractorDto Handle(FindContractorByEinQuery query)
        {
            var contractor = _dbContext.Contractor.FirstOrDefault(x => x.EinNumber == query.ContractorEin);

            return AutoMapper.Mapper.Map<DataModel.ContractorState, ContractorDto>(contractor);
        }
    }
}
