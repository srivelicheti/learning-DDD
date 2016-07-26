define(["knockout", "lodash", "models/BaseViewModel", "services/contractorService"], function (ko, _, BaseViewModel, ContractorService) {

    var addValidations = function() {
        this.ContractorName.extend({ required: true });
        this.EinNumber.extend({ minLength: 9, maxLength: 9, required: true });
        this.errors = ko.validation.group(this);
    };

    var contractorViewModel = function () {
        var self = this;
        this.ContractorName = null;
        this.EinNumber = null;
        this.DoingBusinessAs = null;
        this.ContractStartDate = null;
        this.ContractEndDate = null;
        this.Type = null;
        this.AddressLine1 = null;
        this.AddressLine2 = null;
        this.City = null;
        this.StateCode = null;
        this.ZipCode = null;
        this.ZipExtension = null;
        this.PhoneNumber = null;
        this.AlternatePhoneNumber = null;
        this.Email = null;
        //this.Address = new AddressViewModel();
        this.ContactFirstName = null;
        this.ContactLastName = null;
        this.ContactPhoneNumber = null;
        this.ContactAlternatePhoneNumber = null;
        this.ContactEmail = null;
        this.ContractorExistsWithSameEin = false;
        this.AddDuplicateContractorOverride = false;

        BaseViewModel.call(this, arguments);
        addValidations.call(this);
        
        this.EinNumber.subscribe(function () {
            self.CheckForExistingContractor();
        });
    };
    contractorViewModel.prototype.AddContractor = function() {
        if (this.errors().length > 0)
            alert("Fix errors");
        else {
            var checkContractorPromise = ContractorService.IsExistingContractor(this.EinNumber());
            checkContractorPromise.then(function() {
                ContractorService.AddNewContractor(ko.mapping.toJS(this));
            });

        }
    };

    contractorViewModel.prototype.CheckForExistingContractor = function () {
        var self = this;
        var checkContractorPromise = ContractorService.IsExistingContractor(this.EinNumber());
        checkContractorPromise.then(function (isExistingContractor) {
            console.log("Exisgint: " +isExistingContractor);
            console.log(self);
            if (isExistingContractor)
                self.ContractorExistsWithSameEin(true);
            else {
                self.ContractorExistsWithSameEin(false);
            }
        });
    };

    _.extend(contractorViewModel.prototype, BaseViewModel.prototype,
   {
       initialize: function () { }
   });

    

    return contractorViewModel;
});