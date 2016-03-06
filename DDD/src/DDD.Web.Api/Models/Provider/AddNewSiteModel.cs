using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Web.Api.Models.Provider
{
    public class SiteModel
    {
        public int SiteId { get; set; }

        [Required(ErrorMessage = "Status Code is required.")]
        [MaxLength(1)]
        public string StatusCode { get; set; }

        [Required(ErrorMessage = "Site Name is required.")]
        [MaxLength(50)]
        public string SiteName { get; set; }

        [Required(ErrorMessage = "Site Number is required.")]
        //[MaxLength(10)]
        public int SiteNumber { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<DateTime> LicenseStartDate { get; set; }

        //[Required(ErrorMessage = "Address Line  is required.")]
        //[MaxLength(50)]
        //[RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "AddressLine 1 can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string AddressLine1 { get; set; }

        //[Required(ErrorMessage = "City is required.")]
        //[MaxLength(28)]
        //[RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "City can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Status Code is required.")]
        [MaxLength(2)]
        public string StateCode { get; set; }

        //[Required(ErrorMessage = "Zip Code is required.")]
        //[MaxLength(5)]
        //[ZipCode(IsZipExtensionIncluded = false, ErrorMessage = "Zip Code should be of format (00000)")]
        public string ZipCode { get; set; }

        //[MaxLength(4)]
        public string ZIPCodeExtension { get; set; }

        [Phone(ErrorMessage = "Phone Number is not valid")]
        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Contact First Name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"(?!^\d+$).*^[A-Za-z0-9''('')' .@-]*$", ErrorMessage = "Contact First Name can only contain letters, numbers, hyphens, spaces, or apostrophes & all cannot be numeric.")]
        public string ContactFirstName { get; set; }
        [Required]
        [MaxLength(2)]
        public string CountyCode { get; set; }
        [Required]
        [MaxLength(2)]
        public string CountyServed { get; set; }

        [Required]
        public string LicensingStatusCode { get; set; }
        [Required]
        public string WebEnabledIndicator { get; set; }

        [RegularExpression(@"^[A-Za-z0-9''('')' @-]*$", ErrorMessage = "AddressLine 2 can only contain letters, numbers, hyphens, spaces, or apostrophes.")]
        public string AddressLine2 { get; set; }

        [Phone(ErrorMessage = "Site Alternate Phone Number is not valid")]
        [MaxLength(15)]
        public string SiteAlternatePhoneNumber { get; set; }

        [PhoneAttribute(ErrorMessage = "Site Contact Alternate Phone Number is not valid")]
        [MaxLength(15)]
        public string ContactAlternatePhoneNumber { get; set; }

        [MaxLength(30)]
        [EmailAddress(ErrorMessage = "Site Contact Email is not in valid format")]
        public string ContactEmailText { get; set; }

        [Required(ErrorMessage = "Contact Last Name is required.")]
        [MaxLength(50)]
        [RegularExpression(@"(?!^\d+$).*^[A-Za-z0-9''('')' .@-]*$", ErrorMessage = "Contact Last can only contain letters, numbers, hyphens, spaces, or apostrophes & all cannot be numeric.")]
        public string ContactLastName { get; set; }

        [MaxLength(15)]
        [PhoneAttribute(ErrorMessage = "Contact Phone Number is not valid")]
        public string ContactPhoneNumber { get; set; }

        [MaxLength(30)]
        [EmailAddress(ErrorMessage = "Site Email is not in valid format")]
        public string SiteEmailText { get; set; }

        //[DateGreaterThanAttribute("LicenseStartDate")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //[CurrentDate(ErrorMessage = "License Start Date cannot be earlier than today’s date.")]
        public DateTime? LicenseExpirationDate { get; set; }
        public long LicenseNumber { get; set; }
        public long? StarsRatingNumber { get; set; }


        public string SiteTypeCode { get; set; }
        [MaxLength(2)]
        public string EnforcementActionCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? SiteEffectiveDate { get; set; }

        [Required(ErrorMessage = "Site Contract Start Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //[CurrentDate(ErrorMessage = "Site Contract Start Date cannot be earlier than today’s date.")]
        public DateTime SiteContractStartDate { get; set; }

        [Required(ErrorMessage = "Site Contract End Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
       // [DateGreaterThanAttribute("SiteContractStartDate", ErrorMessage = "Site Contract Start Date cannot be after the Site Contract End Date")]
        public DateTime? SiteContractEndDate { get; set; }

        [MaxLength(1)]
        public string LogicalDeleteIndicator { get; set; }

        [MaxLength(2)]
        public string FacilityTypeCode { get; set; }

        public int HistorySequence_NUMB { get; set; }

        public string History_CODE { get; set; }

        public AddressModel Address { get; set; }

        public SiteHolidayModel SiteHoliday { get; set; }
        public List<SiteHolidayModel> Holidays { get; set; }

    }
}
