using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Common.Models
{
    public class UpdateContractorDetailModel
    {
        public string EinSsn { get; set; }
        public string Name { get; set; }
        public string DoingBusinessAs { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
