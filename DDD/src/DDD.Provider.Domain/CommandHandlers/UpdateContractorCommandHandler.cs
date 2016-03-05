using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Common.Models.Provider;
using DDD.Domain.Common.Command;
using DDD.Domain.Common.Event;
using DDD.Provider.Domain.Commands;
using DDD.Provider.Domain.Entities;
using DDD.Provider.Domain.Repositories;

namespace DDD.Provider.Domain.CommandHandlers
{
    public class UpdateContractorCommandHandler : ICommandHandler<UpdateContractorCommand>
    {
        private DomainEventBus _eventBus;
        private ContractorRepository _contractorRepo;

        public UpdateContractorCommandHandler(DomainEventBus eventBus, ContractorRepository contractorRepository)
        {
            _eventBus = eventBus;
            _contractorRepo = contractorRepository;
        }

        public void Execute(UpdateContractorCommand command)
        {
            try
            {
                var contractor = _contractorRepo.GetContractorByEin(command.Contractor.EinNumber);
                UpdateContractor(contractor,command.Contractor);
                _contractorRepo.Save();
                _eventBus.PublishQueuedPostCommitEvents();
                _eventBus.Publish(new CommandCompletedEvent(command.Id, DateTime.UtcNow));
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new CommandFailedEvent(command.Id, ex, DateTime.UtcNow));
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
