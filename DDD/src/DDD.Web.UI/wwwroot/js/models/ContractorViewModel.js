define(["knockout", "lodash", "models/BaseViewModel", "models/AddressViewModel"], function (ko, _, BaseViewModel, AddressViewModel) {
    var contractorViewModel = function() {
        this.EinNumber = null;
        this.Name = null;
        this.StartDate = null;
        this.EndDate = null;
        this.Address = new AddressViewModel();
        this.ContactFirstName = null;
        this.ContactLastName = null;
        this.ContactPhoneNumber = null;
        BaseViewModel.call(this, arguments);
    };

    _.extend(contractorViewModel.prototype, BaseViewModel.prototype,
   {
       initialize: function () { }
   });
    return contractorViewModel;
});