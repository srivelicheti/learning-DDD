using AutoMapper;
using DDD.Provider.Common.DTOs;
using DDD.Provider.DataModel;
using DDD.Web.Api.Models.Provider;

namespace DDD.Web.Api
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ContractorState, ContractorDto>();
            Mapper.CreateMap<AddNewContractorModel,ContractorDto>();
        }
    }
}
