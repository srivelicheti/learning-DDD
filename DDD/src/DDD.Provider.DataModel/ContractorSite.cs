using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class ContractorSite
    {
        public Guid Id { get; set; }
        public string ArrangedCareTypeCode { get; set; }
        public bool AttendanceEntryIndicator { get; set; }
        public Guid ContractorId { get; set; }
        public string FirstInsertedById { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public string LastSavedById { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public DateTime RelationshipEffectiveDate { get; set; }
        public DateTime? RelationshipEndDate { get; set; }
        public string RelationshipStatusCode { get; set; }
        public Guid SiteId { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Site Site { get; set; }
    }
}
