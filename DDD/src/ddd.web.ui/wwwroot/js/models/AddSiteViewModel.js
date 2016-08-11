define(["knockout", "lodash", "models/AddressViewModel", "models/ContactDetailViewModel", "models/BaseViewModel", "services/siteService","pager"],
    function (ko, _, AddressViewModel, ContactDetailViewModel, BaseViewModel,siteService,pager) {
        function SiteHoliday(holidayName, holidayDate) {
            this.holidayName = ko.observable(holidayName);
            this.holidayDate = ko.observable(holidayDate);
        }

        function SiteRate(minAge, maxAge, rate) {
            this.minAge = ko.observable(minAge);
            this.maxAge = ko.observable(maxAge);
            this.rate = ko.observable(rate);
        }

        function SiteDetails(siteNumber, siteName, contractorEin, contractStartDate, contractEndDate, siteType, siteFacitlityType, addressDetails, phoneNumber, contactDetails) {
            this.SiteNumber = ko.observable(siteNumber);
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
            SiteHolidays: ko.observableArray(),
            SiteRates: ko.observableArray(),
            AddSiteHoliday: function (holidayName, holidayDate) {
                holidayDate = holidayDate | "";
                holidayName = holidayName | "";
                this.SiteHolidays.push(new SiteHoliday(holidayName, holidayDate));
            },
            AddSiteRate: function (minAge, maxAge, rate) {
                minAge = minAge | "";
                maxAge = maxAge | "";
                rate = rate | "";
                this.SiteRates.push(new SiteRate(minAge, maxAge, rate));
            },
            AddSite: function() {
                siteService.addSite(ko.mapping.toJS({
                    SiteDetails: this.SiteDetails,
                    SiteHolidays: this.SiteHolidays,
                    SiteRates: this.SiteRates
                }));
            }
        };

    });