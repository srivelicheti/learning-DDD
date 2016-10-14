define(["knockout", "jquery", "components/ko-popupalerts/popupalert", "postal"],
    function (ko, $, popupalert, postal) {
        "use strict";
        if (!ko.components.isRegistered('popupalert')) {
            ko.components.register('popupalert', popupalert);
        }


        var alertsContainerId = 0;
        function PopupAlertsViewModel(parameters) {
            var params = parameters || {};
            params.alerts = params.alerts || ko.observableArray();

            this.alerts = params.alerts;
            this.containerId = "alertsContainer_" + (++alertsContainerId);
            var self = this;

            var alertsChannel = postal.channel('popupalerts');
            alertsChannel.subscribe("popup-alert", function (alert) {
                self.alerts.push(alert);
            });
            
        }

        PopupAlertsViewModel.prototype.onClose = function(alert) {
            var alerts = ko.unwrap(this.alerts);
            alerts.splice(alerts.indexOf(alert), 1);
            this.alerts(alerts);
        }

        return {
            template: { require: 'text!components/ko-popupalerts/popupalerts.html' },
            viewModel: PopupAlertsViewModel
        };
      
    });