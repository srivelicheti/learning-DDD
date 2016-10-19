using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Api.Contracts.DTOs
{
    public class SiteHolidayDto
    {
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
    }
}
