using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.UI.ViewModels
{
    public class AddNewContractorViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string ContractorName { get; set; }
        public string DoingBusinessAs { get; set; }
        [Required]
        public string EinNumber { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateCode { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string ZipExntension { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        [Required]
        public string ContactAlternatePhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        
       
        
       
    }
}
