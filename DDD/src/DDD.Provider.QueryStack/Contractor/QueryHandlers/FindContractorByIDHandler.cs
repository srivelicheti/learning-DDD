using DDD.Common.DTOs.Provider;
using DDD.Domain.Common.Query;
using DDD.Provider.DataModel;
using DDD.Provider.QueryStack.Contractor.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.QueryStack.Contractor.QueryHandlers
{
    public class FindContractorByIDHandler : IQueryHandler<FindContractorByIDQuery, ContractorDto>
    {
        private POC_DDDContext _dbContext;

        public FindContractorByIDHandler(POC_DDDContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ContractorDto Handle(FindContractorByIDQuery query)
        {
            var contractor = _dbContext.Contractor.FirstOrDefault(x => x.ID == query.ID);
            return AutoMapper.Mapper.Map<DataModel.Contractor, ContractorDto>(contractor);
        }
    }
}
