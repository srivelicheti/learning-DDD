using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    public interface ICommandResult
    {
        Guid CommandId { get; }
        bool IsCommandReceivedSuccessfully { get; set; }
        Exception FailureException { get; set; }


    }

    public interface ICommandResult<out T> : ICommandResult where T :new()
    {
        //Guid CommandId { get; }
        //bool IsCommandReceivedSuccessfully { get; set; }
        //Exception FailureException { get; set; }
        T ResultDetail { get; }
    }

    public class CommandResult : ICommandResult
    {
        public Guid CommandId
        {
            get; set;
        }

        public Exception FailureException
        {
            get;
            set;
        }

        public bool IsCommandReceivedSuccessfully
        {
            get;
            set;
        }
    }
}
