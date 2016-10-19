using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Provider.Api.Contracts.Models.Site
{
    public class SiteHolidayModel
    {
        [Required]
        public DateTime HolidayDate { get; set; }
        [Required]
        public  string HolidayName { get; set; }
    }
}