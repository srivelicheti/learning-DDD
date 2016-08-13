define(["knockout", "lodash", "models/BaseViewModel"], function (ko, _, BaseViewModel) {

    var vm = function(addLine1,addLine2,city,statecode,county,zipCode,zipExtn) {
        this.AddressLine1 = addLine1 | null;
        this.AddressLine2 = addLine2 | null;
        this.City = city | null;
        this.StateCode = statecode | null;
        this.County = county | null;
        this.PhoneNumber =  null;
        this.Email = null;
        this.ZipCode = zipCode | null;
        this.ZipExtension = zipExtn | null;
    };

    _.extend(vm.prototype, BaseViewModel.prototype,
    {
        initialize: function() {}
    });
    return vm;
});