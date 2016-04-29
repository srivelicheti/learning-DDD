define(["ko", "lodash", "models/BaseViewModel"], function(ko, _, BaseViewModel) {

    var vm = function() {
        this.AddressLine1 = null;
        this.AddressLine2 = null;
        this.City = null;
        this.StateCode = null;
        this.ZipCode = null;
        this.ZipExtension = null;
    };

    _.extend(vm.prototype, BaseViewModel.prototype,
    {
        initialize: function() {}
    });
    return vm;
});