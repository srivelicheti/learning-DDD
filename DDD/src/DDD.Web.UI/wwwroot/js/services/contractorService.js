define(["jquery", "ko", "appConfig"],
    function ($, ko, appConfig) {
        var contService = {};

        contService.prototype.isExistingContractor = function (ein) {
            var url = appConfig.apiBaseUrl = "/api/Contractor/" + ein + "/exists";
            $.ajax({
            
            });
        };
    });
