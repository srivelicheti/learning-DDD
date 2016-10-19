namespace DDD.Provider.Domain.Contracts.DTOs
{
    public class SiteRateDto
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal Rate { get; set; }
    }
}