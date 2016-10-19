using AutoMapper;
using DDD.Provider.Api.Contracts.DTOs;
using DDD.Provider.Api.Contracts.Models.Contractor;
using DDD.Provider.Api.Contracts.Models.Site;
using DDD.Provider.DataModel;

namespace DDD.Web.Api
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ContractorState, ContractorDto>();
            Mapper.CreateMap<AddNewContractorModel,ContractorDto>();
            Mapper.CreateMap<SiteHolidayModel, SiteHolidayDto>();
            Mapper.CreateMap<SiteRateModel, SiteRateDto>();
            Mapper.CreateMap<AddNewSiteModel, SiteDto>();
            Mapper.CreateMap<AddNewContractorModel, DDD.Provider.Domain.Contracts.DTOs.ContractorDto>();
            Mapper.CreateMap<ContractorState, DDD.Provider.Domain.Contracts.DTOs.ContractorDto>();

            Mapper.CreateMap<SiteHolidayModel, DDD.Provider.Domain.Contracts.DTOs.SiteHolidayDto>();
            Mapper.CreateMap<SiteRateModel, DDD.Provider.Domain.Contracts.DTOs.SiteRateDto>();
            Mapper.CreateMap<AddNewSiteModel, DDD.Provider.Domain.Contracts.DTOs.SiteDto>();
        }
    }
}
