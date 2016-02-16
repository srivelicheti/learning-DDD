using DDD.Common.DTOs.Provider;
using DDD.Web.Api.Models.Provider;

namespace DDD.Web.Api
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<DDD.Provider.DataModel.Contractor, ContractorDto>();
            AutoMapper.Mapper.CreateMap<AddNewContractorModel,DDD.Common.DTOs.Provider.ContractorDto>();
        }
    }
}
