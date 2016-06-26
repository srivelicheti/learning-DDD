define(["jquery", "knockout", "q", "appConfig", "appMain"],
    function ($, ko, q ,appConfig) {
        "use strict";
        var contService = {};

        contService.isExistingContractor = function (ein) {
            var contractorExists = q.defer();
            var url = appConfig.apiBaseUrl + "/api/Contractor/" + ein + "/exists";
            $.ajax({
                url: url,
                method: "GET"
            }).done(function (data, txtStatus, jqXhr) {
                if (jqXhr.status === 200)
                    contractorExists.resolve(true);
                else {
                    contractorExists.resolve(false);
                }
            }).fail(contractorExists.reject);

            return contractorExists.promise;
        };

        return contService;
    });
