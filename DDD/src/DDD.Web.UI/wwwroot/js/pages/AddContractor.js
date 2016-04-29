require(["jquery", "ko", "lodash", "models/ContractorViewModel", "services/contractorService", "appMain"],
    function ($, ko, _, ContractorViewModel, ContractorService) {
        $(function() {
            var vm = new ContractorViewModel();
            ko.applyBindings(vm);
            window.CVM = vm;
        });
        
    });