using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common
{
    public interface ICommandHandler
    { }
    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
