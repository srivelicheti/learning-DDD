using DDD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Entities
{
    public class Contractor : Entity, IAggregateRoot
    {
        public Contractor(Guid id):base(id)
        {
        }
        public System.DateTime ContractEffectiveDate { get;  }
        public System.DateTime ContractExpirationDate { get;  }
        public string StatusCode { get; private set; }
        public string ContractorName { get; private set; }
        public string DoingBusinessAsText { get; private set; }
        public string PhoneNumber { get; private set; }
        public string ContactFirstName { get; private set; }
        public string ContractorTypeCode { get; private set; }
        public string ContractorSuffixCode { get; private set; }
        public string ContractorAlternatePhoneNumber { get; private set; }
        public string ContactAlternatePhoneNumber { get; private set; }
        public string ContactLastName { get; private set; }
        public string ContactPhoneNumber { get; private set; }
        public string FirstInsertedByID { get; private set; }
        public System.DateTime FirstInsertedDateTime { get; private set; }
        public string LastSavedByID { get; private set; }
        public System.DateTime LastSavedDateTime { get; private set; }
        public string LogicalDeleteIndicator { get; private set; }
        public int HistorySequenceNumber { get; private set; }
        public string HistoryCode { get; private set; }
        public string ContractorEmail { get; private set; }
        public string ContactEmail { get; private set; }
        public int AddressId { get; private set; }
        public Nullable<int> CurrentRecordId { get; private set; }

      
    }
}
