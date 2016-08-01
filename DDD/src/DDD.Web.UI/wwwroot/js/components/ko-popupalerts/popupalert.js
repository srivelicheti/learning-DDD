define(["knockout","lodash" ,"jquery"], function(ko,_ ,$) {
    var popupAlertId = 0;
    function PopupAlertViewModel(options) {
        var params = options.alert || {};
        this.title = ko.observable(params.title);
        this.messages = ko.observableArray(params.messages);
        this.type = params.alertType;
        this.showCloseButton = params.canBeClosed;
        this.elementId = "popupAlert" + (++popupAlertId);
        var self = this;
        this.componentLoaded = function () {
            $("#" + self.elementId).modal('show');
        }
    }

    return {
        template: { require: 'text!components/ko-popupalerts/popupalert.html' },
        viewModel:PopupAlertViewModel
    };
});