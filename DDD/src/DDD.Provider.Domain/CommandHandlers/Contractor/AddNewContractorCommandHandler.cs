using System;
using System.Threading.Tasks;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Contracts.Commands.Contractor;
using DDD.Provider.Domain.Contracts.Enums;
using DDD.Provider.Domain.Contracts.Events;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using NServiceBus;
using VO = DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.CommandHandlers.Contractor
{
    public class AddNewContractorCommandHandler :
        IHandleMessages<AddNewContractorCommand>
    {
        private readonly ContractorRepository _contractorRepository;
        private readonly IContractorSuffixGenerator _contractorSuffixGenerator;
       // private readonly IBus _eventBus;

        public AddNewContractorCommandHandler(ContractorRepository contractorRepository, IContractorSuffixGenerator contractorSuffixGenerator)
        {
            _contractorRepository = contractorRepository;
            _contractorSuffixGenerator = contractorSuffixGenerator;
            //_eventBus = eventBus;
        }
        public async Task Handle(AddNewContractorCommand command, IMessageHandlerContext messageContext)
        {
            try
            {
                var contractorDto = command.Contractor;
                ContractorStatus status = ContractorStatus.Open;
                var contractDuration = new DateTimeRange(contractorDto.ContractStartDate, contractorDto.ContractEndDate);
                var contact = new Contact(new Name(contractorDto.ContactFirstName, contractorDto.ContactLastName), contractorDto.ContactPhoneNumber, contractorDto.ContactAlternatePhoneNumber, contractorDto.ContactEmail);

                var contractrorAddress = new VO.Address(contractorDto.AddressLine1, contractorDto.AddressLine2, contractorDto.City, contractorDto.StateCode, contractorDto.ZipCode);
                ContractorType type = contractorDto.Type;
                var contractorSuffix = _contractorSuffixGenerator.GetContractorSuffixForNewContractor(contractorDto.EinNumber, type);
                //TODO: User should be sending the GUIDs, leaving it for testing to do auto generated guid
                var contractor = new Entities.Contractor(contractorDto.EinNumber + contractorSuffix, contractorDto.ContractorName, contractorDto.DoingBusinessAs, status, type, contractDuration, 
                    contractorDto.PhoneNumber, contact, contractrorAddress, contractorDto.Email);
                _contractorRepository.AddContractor(contractor);
                await _contractorRepository.SaveAsync();
                await Task.WhenAll(messageContext.Publish(new CommandCompletedEvent(command.Id, DateTime.UtcNow)),
                   messageContext.Publish(new ContractorAdded(DateTime.Now,contractor.Id,contractor.EinNumber) { ContractorEin = contractor.EinNumber }));
            }
            catch (Exception ex)
            {
                //TODO: Global Exception logging
                await messageContext.Publish(new CommandFailedEvent(command.Id, ex, DateTime.UtcNow));
                throw;
            }
        }

    }
}
