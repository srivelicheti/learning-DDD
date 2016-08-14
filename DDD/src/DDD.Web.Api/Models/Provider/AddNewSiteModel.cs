using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DDD.Common.Validation;
using DDD.Provider.Domain.Enums;

namespace DDD.Web.Api.Models.Provider
{
    public class AddNewSiteModel
    {

        [Required(ErrorMessage = "Site Name is required.")]
        [MaxLength(50)]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "Site Number is required.")]
        //[MaxLength(10)]
        public int SiteNumber { get; set; }

        [Required(ErrorMessage = "Site Type Code is required.")]
        [ValidEnum(typeof(SiteType))]
        public string SiteTypeCode { get; set; }

        [Required( ErrorMessage = "Facility Type is Required")]
        [ValidEnum(typeof(SiteFacilityType))]
        public int SiteFacitlityTypeCode { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        public DateTime? ContractEndDate { get; set; }
        public long LicenseNumber { get; set; }

        [Required(ErrorMessage = "Address Line  is required.")]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "AddressLine 1 can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string AddressLine1 { get; set; }

        [RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "AddressLine 2 can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(28)]
        [RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "City can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Code is required.")]
        [MaxLength(2)]
        public string StateCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountyCode { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [MaxLength(4)]
        public string ZipExtension { get; set; }

        [Phone(ErrorMessage = "Phone Number is not valid")]
        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        [MaxLength(2)]
        public string CountyServed { get; set; }

        [Required]
        public string LicensingStatusCode { get; set; }
        
        public bool WebEnabledIndicator { get; set; }

        [MaxLength(30)]
        [EmailAddress(ErrorMessage = "Site Email is not in valid format")]
        public string SiteEmailText { get; set; }


        //[Phone(ErrorMessage = "Site Alternate Phone Number is not valid")]
        //[MaxLength(15)]
        //public string SiteAlternatePhoneNumber { get; set; }

        [Required(ErrorMessage = "Contact First Name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"(?!^\d+$).*^[A-Za-z0-9''('')' .@-]*$", ErrorMessage = "Contact First Name can only contain letters, numbers, hyphens, spaces, or apostrophes & all cannot be numeric.")]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "Contact Last Name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"(?!^\d+$).*^[A-Za-z0-9''('')' .@-]*$", ErrorMessage = "Contact Last can only contain letters, numbers, hyphens, spaces, or apostrophes & all cannot be numeric.")]
        public string ContactLastName { get; set; }

        [MaxLength(15)]
        [PhoneAttribute(ErrorMessage = "Contact Phone Number is not valid")]
        public string ContactPhoneNumber { get; set; }

        [MaxLength(30)]
        [EmailAddress(ErrorMessage = "Site Contact Email is not in valid format")]
        public string ContactEmailText { get; set; }


        [MaxLength(2)]
        public string EnforcementActionCode { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime? SiteEffectiveDate { get; set; }
        

        //[MaxLength(1)]
        //public string LogicalDeleteIndicator { get; set; }

        

        
        public List<SiteHolidayModel> SiteHolidays { get; set; }

        public List<SiteRateModel> SiteRates { get; set; }

    }
}
