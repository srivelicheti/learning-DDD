define(["knockout", "lodash", "jquery"], function (ko, _, $) {
    "use strict";
    var popupAlertId = 0;
    function PopupAlertViewModel(options) {
        var params = options.alert || {};
        this.title = ko.observable(params.title);
        this.messages = ko.observableArray(params.messages);
        this.type = params.alertType;
        this.showCloseButton = params.canBeClosed;
        this.elementId = "popupAlert" + (++popupAlertId);
        this.buttons = params.buttons;
        var self = this;
        this.componentLoaded = function() {
            $("#" + self.elementId).on('hidden.bs.modal', function () { $("#" + self.elementId).remove() }).modal('show');
            //$("#" + self.elementId);
        };
        this.btnClick = function (btn) {
            btn.action.call(btn.scope);
            if (btn.closeDialog) {
                var jqELement = $("#" + self.elementId);
                jqELement.modal('hide');//.data('bs.modal', null);;//.remove();
                
            }
            
        };
    }

    return {
        template: { require: 'text!components/ko-popupalerts/popupalert.html' },
        viewModel:PopupAlertViewModel
    };
});