require(["jquery", "knockout", "lodash", "models/AddContractorViewModel","postal" ,"appMain"],
    function ($, ko, _, AddContractorViewModel,postal) {
        $(function() {
            var vm = new AddContractorViewModel();

            var tempCont = {
                ContractorName: "TestCont",
                EinNumber: "789415789",
                DoingBusinessAs: "TC",
                ContractStartDate: "07/26/2016",
                ContractEndDate: "07/25/2019",
                Type: "C",
                AddressLine1: "200 Sterling Pkwy",
                AddressLine2: null,
                City: "Mechanicsburg",
                StateCode: null,
                ZipCode: 17050,
                ZipExtension: null,
                PhoneNumber: "7145698852",
                AlternatePhoneNumber: null,
                Email: "TC@TC.com",
                ContactFirstName: "ContactLN",
                ContactLastName: "ContactFN",
                ContactPhoneNumber: "7418529632",
                ContactAlternatePhoneNumber: null,
                ContactEmail: null
            };
            ko.applyBindings(vm);
            //TODO: Temp code for test purpose
            for (var propName in tempCont) {
                var value = tempCont[propName];
                vm[propName](value);
            }

           

            // ko.applyBindings(vm);
            window.CVM = vm;
        });
        
    });