using System;
using System.ComponentModel.DataAnnotations;
using DDD.Common.Validation;
using DDD.Provider.Domain.Enums;

namespace DDD.Web.Api.Models.Provider
{
    public class AddNewContractorModel
    {
        public Guid Id { get; set; }
        [Required]
        public string EinNumber { get; set; }
        [Required]
        public string ContractorName { get; set; }
        [Required]
        public DateTime ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        
        public string DoingBusinessAs { get; set; }
        //[Required]
        //public string Status { get; set; }
        //public string SuffixCode { get; set; }
        [Required]
        [ValidEnum(typeof(ContractorType))]
        public string Type { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string ZipExntension { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        
        public string ContactAlternatePhoneNumber { get; set; }
        
        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        [Phone]
        public string ContactPhoneNumber { get; set; }
        //[Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        
        //public string FirstInsertedBy { get; set; }
        //public DateTime FirstInsertedDateTime { get; set; }
        //public string LastSavedBy { get; set; }
        //public DateTime LastSavedDateTime { get; set; }
        
        [Required]
        public string StateCode { get; set; }
        
        
    }
}
