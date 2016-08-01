define(["knockout", "lodash", "models/BaseViewModel", "services/contractorService"], function (ko, _, BaseViewModel, ContractorService) {

    var addValidations = function() {
        this.ContractorName.extend({ required: true });
        this.EinNumber.extend({ minLength: 9, maxLength: 9, required: true });
        this.errors = ko.validation.group(this);
        this.ContractorExistsWithSameEin.extend({
            validation: {
                validator: function(val, someotherVal) {
                    if (val === true) {
                        return someotherVal === true;
                    } else {
                        return true;
                    }
                },
                params: this.AddDuplicateContractorOverride,
                Message:"Please check the Add duplicate contractor box if you are adding an existing contractor"
            }
        });

        //this.AddDuplicateContractorOverride.extend({
        //    validation: {
        //        validator: function (val, someotherVal) {
        //            if (val === false) {
        //                return someotherVal === false;
        //            } else {
        //                return someotherVal === true;
        //            }
        //        },
        //        params: this.AddDuplicateContractorOverride,
        //        Message: "Please check the Add duplicate contractor box if you are adding an existing contractor"
        //    }
        //});
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
        this.ContactFirstName = null;
        this.ContactLastName = null;
        this.ContactPhoneNumber = null;
        this.ContactAlternatePhoneNumber = null;
        this.ContactEmail = null;
        this.ContractorExistsWithSameEin = false;
        this.AddDuplicateContractorOverride = false;

        BaseViewModel.call(this, arguments);
        addValidations.call(this);

        this.IsInValidState = ko.computed(function () {
            return this.errors().length === 0;
        }, this);

       
        
        this.EinNumber.subscribe(function () {
            self.CheckForExistingContractor();
        });
    };
    contractorViewModel.prototype.AddContractor = function() {
       
        if (this.errors().length === 0) {
            var self = this;
            var checkContractorPromise = ContractorService.IsExistingContractor(this.EinNumber());
            checkContractorPromise.then(function (isExisting) {
                if(!isExisting)
                    ContractorService.AddNewContractor(ko.mapping.toJS(self));
            });

        }
    };

    contractorViewModel.prototype.CheckForExistingContractor = function () {
        var self = this;
        var checkContractorPromise = ContractorService.IsExistingContractor(this.EinNumber());
        checkContractorPromise.then(function (isExistingContractor) {
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