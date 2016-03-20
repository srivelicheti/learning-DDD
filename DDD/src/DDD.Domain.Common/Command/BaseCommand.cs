using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Command
{
    //public interface ICommand
    //{
    //    Guid Id { get; }
    //}
    public abstract class BaseCommand : ICommand
    {
        public Guid Id { get; }

        protected BaseCommand(Guid id, string submittedBy):this(id,submittedBy,DateTime.UtcNow)
        {
        }

        protected BaseCommand(Guid id, string submittedBy, DateTime submittedDateTime)
        {
            Id = id;
            SubmittedBy = submittedBy;
            SubmittedDateTime = submittedDateTime;
        }
        protected BaseCommand(string submittedBy) : this(Guid.NewGuid(),submittedBy)
        { }

        protected BaseCommand(string submittedBy,DateTime submittedDateTime) : this(Guid.NewGuid(),submittedBy,submittedDateTime)
        { }

        public string SubmittedBy { get; private set; }

        public DateTime SubmittedDateTime { get; private set; }

        public string CommandName => this.GetType().Name;
    }
}


