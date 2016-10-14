define(["knockout", "lodash", "models/BaseViewModel"], function (ko, _, BaseViewModel) {
    "use strict";
    var vm = function (lastName,firstName,phoneNumber,email) {
        this.LastName = lastName;
        this.FirstName = firstName;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        
    };

    _.extend(vm.prototype, BaseViewModel.prototype,
    {
        initialize: function () { }
    });
    return vm;
});