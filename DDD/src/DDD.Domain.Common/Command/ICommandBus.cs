using DDD.Domain.Common.Event;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : Command;
       
    }

    public class IocContainerCommandBus : ICommandBus
    {
        private IContainer _container;
        private DomainEventBus _eventBus;

        public IocContainerCommandBus(IContainer container, DomainEventBus eventBus)
        {
            _container = container;
            _eventBus = eventBus;
        }

        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : Command
        {
            var handler = _container.TryGetInstance<ICommandHandler<TCommand>>();
            if (handler != default(ICommandHandler<TCommand>))
            {
                var errors = ValidateCommand(command).ToList();
                if (errors.Count() == 0)
                {
                    handler.Execute(command);
                    return new CommandResult { IsCommandReceivedSuccessfully = true, CommandId = command.ID };
                }
                else
                {
                    _eventBus.Publish(new CommandValidationFailedEvent(command.ID, errors, DateTime.UtcNow));
                    return new CommandResult { IsCommandReceivedSuccessfully = false, CommandId = command.ID };
                }
            }
            else
                throw new CommandHandlerNotFoundException(command.GetType());
            //throw new NotImplementedException();
        }

        public IEnumerable<ValidationError> ValidateCommand<TCommand>(TCommand command) where TCommand : Command
        {
            var handler = _container.TryGetInstance<ICommandValidator<TCommand>>();
            if (handler != default(ICommandValidator<TCommand>))
            {
                return handler.Validate(command);
            }
            else
                return Enumerable.Empty<ValidationError>();
        }
    }
}
