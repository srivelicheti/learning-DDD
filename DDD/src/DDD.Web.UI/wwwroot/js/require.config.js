//var requireJs = require("require");

//require(['/js/app.config.js'], function (appConfig) {


//});

require.config({
    baseUrl: "/js",
    paths: {
        appConfig: "/js/app.config",
        jquery: "../lib/jquery/dist/jquery",
        knockout: "../lib/knockoutjs/dist/knockout",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap",
        jqueryValidate: "../lib/jquery-validation/dist/jquery.validate",
        jqueryValUnob: "../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive",
        signalr: "../lib/signalr/jquery.signalR",
        q: "../lib/q/q",
        appMain: "../js/commonScripts",
        lodash: "../lib/lodash/lodash",
        komapping: "../lib/bower-knockout-mapping/dist/knockout.mapping",
        kovalidation: "../lib/knockout-validation/dist/knockout.validation",
        postal: "../lib/postal.js/lib/postal",
        text: "../lib/requirejs-plugins/lib/text",
        pager:"../lib/pagerjs/dist/pager.min"
    },

    shim: {
        jquery: {
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
        },
        knockout: {
            exports:'ko'
        },
        komapping: {
            deps: ["knockout"],
            exports:'mapping'
        },
        kovalidation: {
            deps: ["knockout"]
        },
        pager: {
            deps: ["knockout", "jquery"]
        }
        
    }
});

//require(["appMain"]);

