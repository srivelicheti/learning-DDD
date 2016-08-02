define(["jquery", "knockout", "q", "appConfig", "postal" ,"appMain"],
    function ($, ko, q ,appConfig,postal) {
        "use strict";
       
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
            //postal.publish({
            //    channel: "alerts",
            //    topic: "notification-alert",
            //    data: {
            //        title: 'Error!',
            //        message: 'Add New Contractor Not implemented Yet!',
            //        type: 'danger',
            //        dismissAfter:3000
            //    }
            //});

            var addContractorPromise = q.defer();
           // addContractorPromise.reject();
            var url = appConfig.apiBaseUrl + "/apddi/Contractor/";
            $.ajax({
                url: url,
                method: "Post",
                data: contractor
            }).done(function(data, txtStatus, jqxhr) {
                    addContractorPromise.resolve({
                        commandId:data.commandId
                    });
                })
            .fail(function(jqxhr) {
                    addContractorPromise.resolve("kjdf45-jk88");
                });
            return addContractorPromise.promise;
        }

        return {
            IsExistingContractor: isExistingContractor,
            AddNewContractor : addNewContractor
        };
    });
