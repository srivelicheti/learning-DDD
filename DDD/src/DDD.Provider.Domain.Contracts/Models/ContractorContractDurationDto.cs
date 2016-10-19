using System;

namespace DDD.Provider.Domain.Contracts.Models
{
    public class RenewContractorContractModel
    {
        public string EinSsn { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}