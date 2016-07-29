define(["knockout", "lodash", "postal", "models/BaseViewModel"], function (ko, _) {

    function AlertViewModel (params) {
        var alert = params.alert;

        this.title = alert.title;
        this.message = alert.message;

        this.dismissible = (typeof alert.dismissible !== 'undefined') ? alert.dismissible : true;
        this.classes = {
            'alert-dismissible': this.dismissible
        };

        this.type = alert.type || 'info';
        this.classes['alert-' + alert.type] = true;

        this.visible = ko.observable(true);
        this.onClose = params.onClose || this.onClose;
        var self = this;
        if (alert.dismissAfter) {
            setTimeout(function() {
                self.onClose(self);
            }, alert.dismissAfter);
        }

    };

    AlertViewModel.prototype.onClose = function (alert, e) {
        this.visible(false);
    };

    AlertViewModel.prototype.isDismissible = function(alert, e) {
        return alert.dismissible;
    }

    return {
        template: { require: 'text!components/ko-alerts/alert.html' },
        viewModel: AlertViewModel
    };
    
});