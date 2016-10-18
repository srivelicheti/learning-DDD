using System;

namespace DDD.Provider.Common.Models
{
    public class RenewContractorContractModel
    {
        public string EinSsn { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}