define(["jquery", "knockout", "q", "appConfig", "postal", "appMain"], function ($, knockout, q, appConfig, postal) {
    "use strict";
    var addSite = function addSiteFunc(addSiteModel) {
        console.log("To implelment add site service");
        console.log(addSiteModel);
        var url = appConfig.apiBaseUrl + "/api/Site";
        var siteDetails = addSiteModel.SiteDetails;
        var address = addSiteModel.SiteDetails.Address;
        var contact = addSiteModel.SiteDetails.ContactDetail;
        var data = {
            SiteName: siteDetails.SiteName,
            SiteNumber: siteDetails.SiteNumber,
            SiteTypeCode: siteDetails.SiteType,
            SiteFacitlityTypeCode: parseInt(siteDetails.SiteFacilityType),
            LicensingStatusCode:"X", //TODO: Implement the functionality. 
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
        };

        return q($.ajax({
            url: url,
            method: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(data)
        }));
    }

    return {
        addSite:addSite
    };
});