using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Enums;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewContractorCommandHandler :
        ICommandHandler<AddNewContractorCommand>
    {
        private ICommandValidator<AddNewContractorCommand> _commandValidator;
        private ContractorRepository _contractorRepository;
        private IContractorSuffixGenerator _contractorSuffixGenerator;
        private DomainEventBus _eventBus;

        public AddNewContractorCommandHandler(ContractorRepository contractorRepository, IContractorSuffixGenerator contractorSuffixGenerator, DomainEventBus eventBus, ICommandValidator<AddNewContractorCommand> commandValidator)
        {
            _contractorRepository = contractorRepository;
            _contractorSuffixGenerator = contractorSuffixGenerator;
            _eventBus = eventBus;
            _commandValidator = commandValidator;
        }
        public void Execute(AddNewContractorCommand command)
        {
            if (IsValidCommand(command))
            {
                try
                {
                    var contractorDto = command.Contractor;
                    ContractorStatus status = contractorDto.Status;
                    var contractDuration = new DateTimeRange(contractorDto.ContractStartDate, contractorDto.ContractEndDate);
                    var contact = new Contact(new Name(contractorDto.ContactFirstName, contractorDto.ContactLastName), contractorDto.ContactPhoneNumber, contractorDto.ContactAlternatePhoneNumber, contractorDto.ContactEmail);

                    var contractrorAddress = new Address(contractorDto.AddressLine1, contractorDto.AddressLine2, contractorDto.City, contractorDto.StateCode, contractorDto.ZipCode);
                    //TODO: call out service to validate address
                    var contractor = new Contractor(contractorDto.EinNumber, contractorDto.ContractorName, contractorDto.DoingBusinessAs, status, contractorDto.Type, contractDuration, contractorDto.PhoneNumber, contact, contractrorAddress, contractorDto.Email);
                    _contractorRepository.AddContractor(contractor).Wait();
                    _eventBus.Publish(new CommandCompletedEvent(command.ID, DateTime.UtcNow));
                }
                catch (Exception ex)
                {
                    _eventBus.Publish(new CommandFailedEvent(command.ID, ex, DateTime.UtcNow));
                    //TODO: Log exception
                }
            }
        }

        private bool IsValidCommand(AddNewContractorCommand command)
        {
            var validationErrors = _commandValidator.Validate(command).ToList();
            bool isValid = validationErrors.Count() == 0;
            if (!isValid)
                _eventBus.Publish(new CommandValidationFailedEvent(command.ID, validationErrors, DateTime.UtcNow));
            return isValid;
        }
    }
}
