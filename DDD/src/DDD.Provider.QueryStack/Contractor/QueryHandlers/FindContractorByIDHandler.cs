using DDD.Domain.Common.Query;
using DDD.Provider.DataModel;
using DDD.Provider.QueryStack.Contractor.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.Common.DTOs;

namespace DDD.Provider.QueryStack.Contractor.QueryHandlers
{
    public class FindContractorByIdHandler : IQueryHandler<FindContractorByIdQuery, ContractorDto>
    {
        private ProviderDbContext _dbContext;

        public FindContractorByIdHandler(ProviderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ContractorDto Handle(FindContractorByIdQuery query)
        {
            var contractor = _dbContext.Contractor.FirstOrDefault(x => x.Id == query.Id);
            return AutoMapper.Mapper.Map<DataModel.ContractorState, ContractorDto>(contractor);
        }
    }
}
