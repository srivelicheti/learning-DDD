using DDD.Common.DTOs.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Web.Api.Models.Provider;

namespace DDD.Web.Api.App_Start
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
