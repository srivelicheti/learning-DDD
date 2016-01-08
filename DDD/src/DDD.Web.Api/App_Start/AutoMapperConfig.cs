using DDD.Common.DTOs.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<DDD.Provider.DataModel.Contractor, ContractorDto>();
        }
    }
}
