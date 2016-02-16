using AutoMapper;
using DDD.Common.DTOs.Provider;
using DDD.Provider.DataModel;
using DDD.Web.Api.Models.Provider;

namespace DDD.Web.Api
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Contractor, ContractorDto>();
            Mapper.CreateMap<AddNewContractorModel,ContractorDto>();
        }
    }
}
