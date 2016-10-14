namespace DDD.Provider.Common.Models
{
    public class UpdateContractorAddressModel
    {
        public string EinSsn { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string ZipExtn { get; set; }
    }
}