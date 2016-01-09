using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class SiteRate
    {
        public Guid ID { get; set; }
        public int AgeCode { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string FirstInsertedByID { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public string LastSavedByID { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public bool LogicalDeleteIndicator { get; set; }
        public decimal? RegularCareDailyRate { get; set; }
        public decimal? RegularCareWeeklyRate { get; set; }
        public Guid SiteID { get; set; }
        public decimal? SpecialCareDailyRate { get; set; }
        public decimal? SpecialCareWeeklyRate { get; set; }

        public virtual Site Site { get; set; }
    }
}
