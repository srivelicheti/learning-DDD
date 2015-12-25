using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
       
    }

    public class IocContainerCommandBus : ICommandBus
    {
        private IContainer _container;
        public IocContainerCommandBus(IContainer container)
        {
            _container = container;
        }

        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _container.TryGetInstance<ICommandHandler<TCommand>>();
            if (handler != default(ICommandHandler<TCommand>))
            {
                handler.Execute(command);
                return new CommandResult { IsCommandReceivedSuccessfully = true, CommandId = command.ID };
            }
            else
                throw new CommandHandlerNotFoundException(command.GetType());
            //throw new NotImplementedException();
        }
    }
}
