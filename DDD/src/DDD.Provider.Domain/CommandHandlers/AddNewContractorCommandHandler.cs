using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Domain.Common.ValueObjects;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Enums;
using DDD.Provider.Domain.Repositories;
using DDD.Provider.Domain.Services;
using DDD.Provider.Messages.Commands;
using DDD.Provider.Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO = DDD.Domain.Common.ValueObjects;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class AddNewContractorCommandHandler :
        IHandleMessages<AddNewContractorCommand>
    {
        private readonly ContractorRepository _contractorRepository;
        private readonly IContractorSuffixGenerator _contractorSuffixGenerator;
        private readonly IBus _eventBus;

        public AddNewContractorCommandHandler(ContractorRepository contractorRepository, IContractorSuffixGenerator contractorSuffixGenerator, IBus eventBus)
        {
            _contractorRepository = contractorRepository;
            _contractorSuffixGenerator = contractorSuffixGenerator;
            _eventBus = eventBus;
        }
        public void Handle(AddNewContractorCommand command)
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
                var contractor = new Contractor(contractorDto.EinNumber + contractorSuffix, contractorDto.ContractorName, contractorDto.DoingBusinessAs, status, type, contractDuration, 
                    contractorDto.PhoneNumber, contact, contractrorAddress, contractorDto.Email,_eventBus);
                _contractorRepository.AddContractor(contractor);
                _contractorRepository.Save();
               // _eventBus.PublishQueuedPostCommitEvents();
                _eventBus.Publish(new CommandCompletedEvent(command.Id, DateTime.UtcNow));
                _eventBus.Publish(new ContractorAddedEvent { ContractorEin = contractor.EinNumber });
                //var ambientTransaction = System.Transactions.Transaction.Current;
                //var ts = new /*Tr*/
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new CommandFailedEvent(command.Id, ex, DateTime.UtcNow));
                //TODO: Log exception
            }
        }

    }
}
