define(["appConfig", "jquery", "bootstrap", "knockout", "jqueryValidate", "jqueryValUnob", "signalr", "komapping"], function (appConfig, $) {
    $(function () {
        $.getScript(appConfig.apiBaseUrl + "/signalr/hubs");
        // alert("test scuces");

        $.support.cors = true;
        // Open a connection to the remote server
        $.connection.hub.url = appConfig.apiBaseUrl;
        var connection = $.hubConnection($.connection.hub.url);
        var chat = connection.createHubProxy('notifications');

        chat.on('messageReceived', function (message) {
            $('#message').append('<li>' + message + '</li>');
        });

        // Turn logging on so we can see the calls in the browser console
        connection.logging = true;

        connection.start();
    });
});