define(["knockout", "lodash", "postal" ,"models/BaseViewModel"], function (ko, _, postal ,BaseViewModel) {

    var vm = function () {
        this.NotificationText = "";
        this.NotificationType = "";

    };

    _.extend(vm.prototype, BaseViewModel.prototype,
    {
        initialize: function () { }
    });
    return vm;
});