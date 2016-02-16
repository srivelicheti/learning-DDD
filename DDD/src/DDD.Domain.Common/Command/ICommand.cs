using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    public interface ICommand
    {
        Guid ID { get; }
    }
    public abstract class Command : ICommand
    {
        public Guid ID { get; private set; }

        public Command(Guid id, string submittedBy):this(id,submittedBy,DateTime.UtcNow)
        {
        }

        public Command(Guid id, string submittedBy, DateTime submittedDateTime)
        {
            ID = id;
            SubmittedBy = submittedBy;
            SubmittedDateTime = submittedDateTime;
        }
        public Command(string submittedBy) : this(Guid.NewGuid(),submittedBy)
        { }

        public Command(string submittedBy,DateTime submittedDateTime) : this(Guid.NewGuid(),submittedBy,submittedDateTime)
        { }

        public string SubmittedBy { get; private set; }

        public DateTime SubmittedDateTime { get; private set; }
    }
}


