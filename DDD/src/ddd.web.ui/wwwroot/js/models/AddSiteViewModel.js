define(["knockout", "lodash", "models/AddressViewModel", "models/ContactDetailViewModel", "models/BaseViewModel", "services/siteService","services/contractorService" ,"pager"],
    function (ko, _, AddressViewModel, ContactDetailViewModel, BaseViewModel, siteService, contractorService, pager) {

        var addSiteValidations = function () {
            this.ExistingContractor.extend({
                validation: {
                    validator: function (val) {
                        return val;
                    },
                    Message: "Please add to existing contractor"
                }
            });
        };

        function SiteHoliday(holidayName, holidayDate) {
            this.holidayName = ko.observable(holidayName).extend({ required: true });
            this.holidayDate = ko.observable(holidayDate).extend({ required: true });
        }

        function SiteRate(minAge, maxAge, rate) {
            this.minAge = ko.observable(minAge).extend({ required: true });
            this.maxAge = ko.observable(maxAge).extend({ required: true });
            this.rate = ko.observable(rate).extend({ required: true });
        }

        function SiteDetails(siteNumber, siteName, contractorEin, contractStartDate, contractEndDate, siteType, siteFacitlityType, addressDetails, countyServed, phoneNumber, siteEmail, contactDetails) {
            this.SiteNumber = ko.observable(siteNumber).extend({ required: true });
            this.SiteName = ko.observable(siteName).extend({ required: true });
            this.ContractorEin = ko.observable(contractorEin).extend({ required: true });
            this.ContractStartDate = ko.observable(contractStartDate).extend({ required: true });
            this.ContractEndDate = ko.observable(contractEndDate);
            this.SiteType = ko.observable(siteType);
            this.SiteFacilityType = ko.observable(siteFacitlityType);
            this.Address = addressDetails;
            this.CountyServed = ko.observable(countyServed);
            this.PhoneNumber = ko.observable(phoneNumber);
            this.SiteEmail = ko.observable(siteEmail);
            this.ContactDetail = contactDetails;
            this.ExistingContractor = ko.observable(false);
            addSiteValidations.call(this);
            this.errors = ko.validation.group(this);
            this.IsInValidState = ko.computed(function () {
                return this.errors().length === 0;
            }, this);
            var self = this;
            this.ContractorEin.subscribe(function () {
                self.CheckForExistingContractor();
            });
        }
        SiteDetails.prototype.CheckForExistingContractor = function () {
            var self = this;
            var checkContractorPromise = contractorService.IsExistingContractor(this.EinNumber());
            checkContractorPromise.then(function (isExistingContractor) {
                if (isExistingContractor)
                    self.ExistingContractor(true);
                else {
                    self.ExistingContractor(false);
                }
            });
        };

        var addressViewModel = new AddressViewModel("300 Sterling Pkwy", "", "Mechanicsburg", "PA", "DP", 17051, "");
        var vm = {
            SiteDetails: new SiteDetails(
                "7892549",
                "Boys N Girls of Wilming",
                "123456789",
                "2016-08-31", "2019-08-31",
                "ON",
                "17",
                addressViewModel,
                "CS",
                "714-459-1234",
                "siteemail@email.com",
                new ContactDetailViewModel("LN", "FN", "717-456-7894", "test@gmail.com")),
            SiteHolidays: ko.observableArray([new SiteHoliday("TNG", "11/25/2016"), new SiteHoliday("X-Mas", "12/25/2016")]),
            SiteRates: ko.observableArray([new SiteRate(0, 2, 60), new SiteRate(3, 18, 30)]),
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
            AddSite: function () {
                siteService.addSite(ko.mapping.toJS({
                    SiteDetails: this.SiteDetails,
                    SiteHolidays: this.SiteHolidays,
                    SiteRates: this.SiteRates
                }));
            }
        };
        window.SVM = vm;
        return vm;

    });