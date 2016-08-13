define(["jquery", "knockout", "q", "appConfig", "postal", "appMain"], function($,knockout,q,appConfig,postal) {
    var addSite = function addSiteFunc(addSiteModel) {
        console.log("To implelment add site service");
        console.log(addSiteModel);
        var url = appConfig.apiBaseUrl + "/api/Site";
        var siteDetails = addSiteModel.SiteDetails;
        var address = addSiteModel.SiteDetails.Address;
        var contact = addSiteModel.SiteDetails.ContactDetail;
        return q($.ajax({
            url: url,
            method: "POST",
            data: {
                SiteName: siteDetails.SiteName,
                SiteNumber: siteDetails.SiteNumber,
                SiteTypeCode: siteDetails.SiteType,
                FacitlityTypeCode: siteDetails.SiteFacitlityType,
                ContractStartDate: siteDetails.ContractStartDate,
                ContractEndDate: siteDetails.ContractEndDate,
                LicenceNumber: siteDetails.LicenceNumber,
                AddressLine1: address.AddressLine1,
                AddressLine2: address.AddressLine2,
                City: address.City,
                StateCode: address.StateCode,
                CountyCode: address.County,
                ZipCode: address.ZipCode,
                ZipExtenson: address.ZipExtenson,
                PhoneNumber: siteDetails.PhoneNumber,
                CountyServed: siteDetails.CountyServed,
                SiteEmailText: siteDetails.SiteEmail,
                ContactFirstName: contact.FirstName,
                ContactLastName: contact.LastName,
                ContactPhoneNumber: contact.PhoneNumber,
                ContactEmailText: contact.Email,
                SiteHolidays: addSiteModel.SiteHolidays,
                SiteRates: addSiteModel.SiteRates
            }
        }));
    }

    return {
        addSite:addSite
    };
});