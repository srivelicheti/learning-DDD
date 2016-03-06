using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZIPCode { get; set; }
        public string ZipExtension { get; set; }
        public string CountyCode { get; set; }

    }
}
