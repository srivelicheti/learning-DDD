using DDD.Domain.Common.Command;
using DDD.Domain.Common.Services;
using DDD.Provider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Common.Extensions;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Messages.Commands;

namespace DDD.Provider.Domain.CommandValidators
{
    
    //public class IsValidSelfArrangedContractorValidator : ICommandValidator<AddNewContractorCommand>
    //{
    //    private IMciService _mciService;

    //    public IsValidSelfArrangedContractorValidator(IMciService mciService)
    //    {
    //        _mciService = mciService;
    //    }
    //    IEnumerable<ValidationError> ICommandValidator<AddNewContractorCommand>.Validate(AddNewContractorCommand command)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //TODO: Research more if the command validations should be split into multiple validations or if it should be a single class
    //Doesn't it violate SRP if left in a single class
    //Also research if these Validations should be done inside Entity, if so do I pass the dependencies into the Entity method
    public class AddNewContractorCommandValidator : ICommandValidator<AddNewContractorCommand>
    {
        private readonly ContractorRepository _contractorRepo;
        private readonly IMciService _mciService;

        public AddNewContractorCommandValidator(IMciService mciService, ContractorRepository contractorRepo)
        {
            _mciService = mciService;
            _contractorRepo = contractorRepo;
        }
        IEnumerable<ValidationError> ICommandValidator<AddNewContractorCommand>.Validate(AddNewContractorCommand command)
        {
            var contractorDetail = command.Contractor;
            if (contractorDetail.Type == ContractorType.SelfArranged.Value)
            {
                if (!_mciService.IsRegisterdIndividual(contractorDetail.EinNumber))
                    yield return new ValidationError(ValidationErrorCodes.ContractorCodes.SelfArrangedContractorNotFound, $"ContractorCodes with SSN { contractorDetail.EinNumber.FormatAndMaskSsn()} not found in the MCI database");

                var existingContractor = _contractorRepo.GetContractorEinsStartingWith(command.Contractor.EinNumber, ContractorType.SelfArranged);
                if (existingContractor.Count > 0)
                    yield return new ValidationError(ValidationErrorCodes.ContractorCodes.SelfArrangedContractorAlreadyRegistered, $"Self-Arranged ContractorCodes with SSN {contractorDetail.EinNumber.FormatAndMaskSsn()} is already registered");

            }

            throw new NotImplementedException();
        }
    }
}
