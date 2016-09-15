define(["appConfig", "jquery", "bootstrap", "knockout", "jqueryValidate", "jqueryValUnob", "signalr", "komapping", "kovalidation", "postal", "pager", "select2"],
    function (appConfig, $, bootstrap, ko, jqval, jqvalUnob, signalr, komap, koval, postal) {
        $(function () {
            //TODO: Adding global variables for testing remove them later
            window.ko = ko;
            window.komap = komap;
            $.getScript(appConfig.apiBaseUrl + "/signalr/hubs");
            // alert("test scuces");

            $.support.cors = true;
            // Open a connection to the remote server
            $.connection.hub.url = appConfig.apiBaseUrl;
            var connection = $.hubConnection($.connection.hub.url);
            var chat = connection.createHubProxy('notifications');

            chat.on('messageReceived',
                function (message) {
                    postal.publish({
                        channel: "alerts",
                        topic: "notification-alert",
                        data: {
                            title: 'Info!',
                            message: message,
                            type: 'Info',
                            dismissAfter: 3000
                        }
                    });
                });

            // Turn logging on so we can see the calls in the browser console
            connection.logging = true;

            connection.start();

            ko.validation.init({
                registerExtenders: true,
                messagesOnModified: true,
                insertMessages: true,
                parseInputAttributes: true,
                messageTemplate: null
            }, true);

            ko.components.register("alert", { require: "components/ko-alerts/alert" });
            ko.components.register("alerts", { require: "components/ko-alerts/alerts" });
            ko.components.register("popupalert", { require: "components/ko-popupalerts/popupalert" });
            ko.components.register("popupalerts", { require: "components/ko-popupalerts/popupalerts" });
            ko.components.register("contractorsearch", { require: "components/ko-contractorsearch/contractorsearch" });
            window.postal = postal;
        });
    });