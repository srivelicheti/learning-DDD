using System;

namespace DDD.Provider.Common.Models
{
    public class RenewContractorContract
    {
        public string EinSsn { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}