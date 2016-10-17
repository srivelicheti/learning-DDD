using System;
using System.Diagnostics;
using DDD.Domain.Common;
using DDD.Domain.Common.Event;
using DDD.Provider.DataModel;
using NServiceBus;

namespace DDD.Provider.Domain.Entities
{
    public class SiteRate : Entity
    {
        public SiteRate(int ageCode, decimal normalDailyRate, decimal specialNeedsDailyRate, DateTime effDate/*, IBus bus*/) : base(GuidHelper.NewSequentialGuid()/*, bus*/)
        {
            AgeCode = ageCode;
            NormalDailyRate = normalDailyRate;
            SpecialNeedsDailyRate = specialNeedsDailyRate;
            EffectiveDate = effDate;
            InitializeDbState();
        }

        public DateTime EffectiveDate { get; private set; }

        private void InitializeDbState()
        {
            DbState = new SiteRateState
            {
                Id = Id,
                AgeCode = AgeCode,
                EffectiveDate = EffectiveDate,
                RegularCareDailyRate = NormalDailyRate,
                RegularCareWeeklyRate = NormalDailyRate * 5,
                SpecialCareDailyRate = SpecialNeedsDailyRate,
                SpecialCareWeeklyRate = SpecialNeedsDailyRate * 5,
                FirstInsertedById = "TODO",
                FirstInsertedDateTime = DateTime.UtcNow,
                LastSavedById = "TODO",
                LastSavedDateTime = DateTime.UtcNow,
            };
        }

        internal SiteRateState DbState { get; private set; }

        public decimal SpecialNeedsDailyRate { get; set; }

        public decimal NormalDailyRate { get; set; }

        public int AgeCode { get; set; }
    }
}