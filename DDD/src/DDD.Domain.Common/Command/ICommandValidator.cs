using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    public interface ICommandValidator<in TCommand> where TCommand : Command
    {
        IEnumerable<ValidationError> Validate(TCommand command);
    }

    public class ValidationError
    {
        public ValidationError(int errorCode, string errorDesc)
        {
            ErrorCode = errorCode;
            ErrorDesc = errorDesc;
        }

        public int ErrorCode { get; private set; }
        public string ErrorDesc { get; private set; }
    }
}
