define(["knockout", "lodash", "models/BaseViewModel"], function (ko, _, BaseViewModel) {

    var vm = function(addLine1,addLine2,city,statecode,county,zipCode,zipExtn) {
        this.AddressLine1 = ko.observable(addLine1 | "");
        this.AddressLine2 = ko.observable(addLine2 | "");
        this.City = ko.observable(city | "");
        this.StateCode = ko.observable(statecode | "");
        this.County = ko.observable(county | "");
        this.PhoneNumber =  ko.observable("");
        this.Email = ko.observable("");
        this.ZipCode = ko.observable(zipCode | "");
        this.ZipExtension = ko.observable(zipExtn | "");

       // BaseViewModel.call(this, arguments);
    };
    
    _.extend(vm.prototype, BaseViewModel.prototype,
    {
        initialize: function() {}
    });
    return vm;
});