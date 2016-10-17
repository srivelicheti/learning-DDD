using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Provider.Common.Models;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Repositories;
using NServiceBus;
using DDD.Provider.Messages.Commands;
using DDD.Provider.Domain.Contracts.Models;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class UpdateContractorCommandHandler : IHandleMessages<UpdateContractorCommand>
    {
        //private IBus _eventBus;
        private ContractorRepository _contractorRepo;

        public UpdateContractorCommandHandler(/*IBus eventBus,*/ ContractorRepository contractorRepository)
        {
            //_eventBus = eventBus;
            _contractorRepo = contractorRepository;
        }

        public Task Handle(UpdateContractorCommand command, IMessageHandlerContext messageContext)
        {
            try
            {
                var contractor = _contractorRepo.GetContractorByEin(command.Contractor.EinNumber);
                UpdateContractor(contractor,command.Contractor);
                _contractorRepo.Save();
                //_eventBus.PublishQueuedPostCommitEvents();
                messageContext.Publish(new CommandCompletedEvent(command.Id, DateTime.UtcNow));
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                messageContext.Publish(new CommandFailedEvent(command.Id, ex, DateTime.UtcNow));
                throw;
                //TODO: Log exception
            }
        }

        private void UpdateContractor(Contractor contractor, UpdateContractorModel updatedModel)
        {
            contractor.UpdateName(updatedModel.ContractorName);
            contractor.UpdateDointBusinessAsName(updatedModel.DoingBusinessAs);
            contractor.UpdateContactDetails(updatedModel.ContactFirstName,updatedModel.ContactLastName,updatedModel.Email,updatedModel.PhoneNumber,updatedModel.AlternatePhoneNumber);
            contractor.UpdateAddress(updatedModel.AddressLine1,updatedModel.AddressLine2,updatedModel.City,updatedModel.StateCode,updatedModel.ZipCode);
            contractor.UpdatePhoneDetails(updatedModel.PhoneNumber,updatedModel.AlternatePhoneNumber);
            contractor.UpdateEmail(updatedModel.Email);
            contractor.RenewContract(updatedModel.ContractStartDate,updatedModel.ContractEndDate);
        }
    }
}
