using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Web.Api.Models.Provider
{
    public class SiteHolidayModel
    {
        [Required]
        public DateTime HolidayDate { get; set; }
        [Required]
        public  string HolidayName { get; set; }
    }
}