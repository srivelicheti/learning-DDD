﻿//var requireJs = require("require");

//require(['/js/app.config.js'], function (appConfig) {


//});

require.config({
    baseUrl: "/js",
    paths: {
        appConfig: "/js/app.config",
        jquery: "../lib/jquery/dist/jquery",
        ko: "../lib/knockoutjs/dist/knockout",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap",
        jqueryValidate: "../lib/jquery-validation/dist/jquery.validate",
        jqueryValUnob: "../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive",
        signalr: "../lib/signalr/jquery.signalR",
        q: "../lib/q/q",
        appMain: "../js/commonScripts",
        lodash:"../lib/lodash/lodash"
    },

    shim: {
        jQuery: {
            exports: "$"
        },
        bootstrap: {
            deps: ["jquery"]
        },
        jqueryValidate: {
            deps: ["jquery"]
        },
        jqueryValUnob: {
            deps: ["jquery", "jqueryValidate"]
        },
        signalr: {
            deps: ["jquery"]
        },
        q: {
            exports:"q"
        },
        lodash: {
            exports:"_"
        }
    }
});

//require(["appMain"]);

