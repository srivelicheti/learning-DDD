using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class ContractorSite
    {
        public Guid ID { get; set; }
        public string ArrangedCareTypeCode { get; set; }
        public bool AttendanceEntryIndicator { get; set; }
        public Guid ContractorID { get; set; }
        public string FirstInsertedByID { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public string LastSavedByID { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public DateTime RelationshipEffectiveDate { get; set; }
        public DateTime? RelationshipEndDate { get; set; }
        public string RelationshipStatusCode { get; set; }
        public Guid SiteID { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Site Site { get; set; }
    }
}
