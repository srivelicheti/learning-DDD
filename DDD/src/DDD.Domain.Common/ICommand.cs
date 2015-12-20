using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common
{
    public interface ICommand
    {
        Guid ID { get; }
    }
    public abstract class Command : ICommand
    {
        public Guid ID { get; private set; }

        public Command(Guid id)
        {
            ID = id;
        }
        public Command() : this(Guid.NewGuid())
        { }
    }
}


