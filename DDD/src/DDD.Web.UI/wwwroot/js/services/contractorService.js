define(["jquery", "knockout", "q", "appConfig", "komapping" ,"appMain"],
    function ($, ko, q ,appConfig,komapping) {
        "use strict";
        var contService = {};

        var  isExistingContractor = function (ein) {
            var contractorExists = q.defer();
            var url = appConfig.apiBaseUrl + "/api/Contractor/" + ein + "/exists";
            $.ajax({
                    url: url,
                    method: "GET"
                })
                .done(function(data, txtStatus, jqXhr) {
                    if (jqXhr.status === 200)
                        contractorExists.resolve(true);
                    else if (jqXhr.status === 404) {
                        contractorExists.resolve(false);
                    } else {
                        contractorExists.reject();
                    }
                }).fail(function (jqXhr, textStatus, errorThrown) {
                    if (jqXhr.status === 404) {
                        contractorExists.resolve(false);
                    } else {
                        contractorExists.reject();
                    }
                });

            return contractorExists.promise;
        };

        var addNewContractor = function (contractor) {
            console.log("Called Service");
            console.log(contractor);
        }

        return {
            IsExistingContractor: isExistingContractor,
            AddNewContractor : addNewContractor
        };
    });
