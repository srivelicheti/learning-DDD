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
        private readonly ContractorRepository _contractorRepository;
        private IContractorSuffixGenerator _contractorSuffixGenerator;
        private readonly DomainEventBus _eventBus;

        public AddNewContractorCommandHandler(ContractorRepository contractorRepository, IContractorSuffixGenerator contractorSuffixGenerator, DomainEventBus eventBus)
        {
            _contractorRepository = contractorRepository;
            _contractorSuffixGenerator = contractorSuffixGenerator;
            _eventBus = eventBus;
        }
        public void Execute(AddNewContractorCommand command)
        {
           
                try
                {
                    var contractorDto = command.Contractor;
                    ContractorStatus status = ContractorStatus.Open;
                    var contractDuration = new DateTimeRange(contractorDto.ContractStartDate, contractorDto.ContractEndDate);
                    var contact = new Contact(new Name(contractorDto.ContactFirstName, contractorDto.ContactLastName), contractorDto.ContactPhoneNumber, contractorDto.ContactAlternatePhoneNumber, contractorDto.ContactEmail);

                    var contractrorAddress = new Address(contractorDto.AddressLine1, contractorDto.AddressLine2, contractorDto.City, contractorDto.StateCode, contractorDto.ZipCode);
                    //TODO: call out service to validate address
                    ContractorType type = contractorDto.Type;
                    var contractorSuffix =
                        _contractorSuffixGenerator.GetContractorSuffixForNewContractor(contractorDto.EinNumber, type);
                    //TODO: User should be sending the GUIDs, leaving it for testing to do auto generated guid
                    var contractor = new Contractor(contractorDto.EinNumber + contractorSuffix, contractorDto.ContractorName, contractorDto.DoingBusinessAs, status, type, contractDuration, contractorDto.PhoneNumber, contact, contractrorAddress, contractorDto.Email);
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
}
