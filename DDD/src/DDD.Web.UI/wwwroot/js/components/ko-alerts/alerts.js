define(['knockout', 'components/ko-alerts/alert', "postal"], function (ko, alert,postal) {
    'use strict';

    if (!ko.components.isRegistered('alert')) {
        ko.components.register('alert', alert);
    }

    /**
     * Alerts view model.
     *
     * @param  {Object}  params         - Component parameters.
     * @param  {Array}   params.alerts  - Alerts observable.
     */
    function AlertsViewModel(params) {
        this.alerts = params.alerts === undefined ? ko.observableArray() : params.alerts;
        var alertsChannel = postal.channel('alerts');
        var self = this;
        alertsChannel.subscribe("notification-alert", function (alert) {
            self.alerts.push(alert);
        });
    }

    /**
     * Removes alert from alerts observable.
     *
     * @param  {Object}  alert  - Array member.
     */
    AlertsViewModel.prototype.onClose = function (alert) { /* (alert, alertViewModel, e) */
        var alerts = ko.unwrap(this.alerts);
        alerts.splice(alerts.indexOf(alert), 1);
        this.alerts(alerts);
    };

    return {
        template: { require: 'text!components/ko-alerts/alerts.html' },
        viewModel: AlertsViewModel
    };

});