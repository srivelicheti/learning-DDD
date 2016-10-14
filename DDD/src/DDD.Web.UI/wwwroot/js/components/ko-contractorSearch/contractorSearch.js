define(["jquery", "knockout", "lodash", "postal"], function ($, ko, _, postal) {
    "use strict";
    var constSearchElement = 0;
    function ContractorSearchViewModel(currentEin) {
        this.selectedEin = ko.observable(currentEin | null);
        this.elementId = ++constSearchElement;
        $("#" + this.elemntId).select2();
    }

    return {
        template: { require: 'text!components/ko-contractorSearch/contractorSearch.html' },
        viewModel: ContractorSearchViewModel
    };
});