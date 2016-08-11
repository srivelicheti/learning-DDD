using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.Models.Provider
{
    public class SiteRateModel
    {
        [Required]
        public int MinAge { get; set; }
        [Required]
        public int MaxAge { get; set; }
        [Required]
        public decimal Rate { get; set; }
    }
}
