define(["jquery","knockout", "lodash", "postal"], function ($, ko, _, postal) {
    var constSearchElement = 0;
    function ContractorSearchViewModel() {
        this.selectedEin = ko.observable('');
        this.elementId = ++constSearchElement;
        $("#" + this.elemntId).select2();
    }

    return {
        template: { require: 'text!components/ko-contractorSearch/contractorSearch.html' },
        viewModel: ContractorSearchViewModel
    };
});