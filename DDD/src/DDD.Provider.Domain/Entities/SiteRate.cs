namespace DDD.Provider.Domain.Entities
{
    public class SiteRate
    {
        public SiteRate(int minAge, int maxAge, decimal normalDailyRate, decimal specialNeedsDailyRate)
        {
            MinAge = minAge;
            MaxAge = maxAge;
            NormalDailyRate = normalDailyRate;
            SpecialNeedsDailyRate = specialNeedsDailyRate;
        }

        public decimal SpecialNeedsDailyRate { get; set; }

        public decimal NormalDailyRate { get; set; }

        public int MaxAge { get; set; }

        public int MinAge { get; set; }
    }
}