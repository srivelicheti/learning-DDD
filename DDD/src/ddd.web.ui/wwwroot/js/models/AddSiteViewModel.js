define(["knockout", "lodash","models/AddressViewModel","models/ContactDetailViewModel" ,"models/BaseViewModel"], function (ko, _,AddressViewModel,ContactDetailViewModel ,BaseViewModel) {
    function SiteHoliday(holidayName, holidayDate) {
        this.holidayName = ko.observable(holidayName);
        this.holidayDate = ko.observable(holidayDate);
    }

    function SiteRate(minAge, maxAge, rate) {
        this.minAge = ko.observable(minAge);
        this.maxAge = ko.observable(maxAge);
        this.rate = ko.observable(rate);
    }

    function SiteDetails(siteNumber,siteName,contractorEin,contractStartDate,contractEndDate,siteType,siteFacitlityType,addressDetails,phoneNumber,contactDetails) {
        this.SiteNumber =ko.observable(siteNumber);
        this.SiteName = ko.observable(siteName);
        this.ContractorEin = ko.observable(contractorEin);
        this.ContractStartDate = ko.observable(contractStartDate);
        this.ContractEndDate = ko.observable(contractEndDate);
        this.SiteType = ko.observable(siteType);
        this.SiteFacilityType = ko.observable(siteFacitlityType);
        this.Address = addressDetails;
        this.PhoneNumber = ko.observable(phoneNumber);
        this.ContactDetail = contactDetails;
    }

    return {
        SiteDetails: new SiteDetails("",
            "",
            '',
            '',
            '',
            '',
            '',
            new AddressViewModel(),
            '',
            new ContactDetailViewModel()),
        SiteHolidays: ko.observableArray([new SiteHoliday("Thanks Giving","2016-11-25")]),
        SiteRates: ko.observableArray(),
        AddSiteHoliday: function(holidayName, holidayDate) {
            this.SiteHolidays.push(new SiteHoliday("", ""));
        },
        AddSiteRate: function(minAge, maxAge, rate) {
            this.SiteRates.push(new SiteRate(minAge, maxAge, rate));
        }
    };

});