using System;
using DDD.Domain.Common.Event;
using NServiceBus;

namespace DDD.Provider.Domain.Contracts.Events
{
    public class NewSiteAdded : BaseEvent, IEvent
    {
        public NewSiteAdded(Guid siteId, int siteNumber) : this(DateTime.UtcNow, Guid.NewGuid(), siteNumber)
        {
        }

        public NewSiteAdded(DateTime eventDateTime, Guid siteId, int siteNumber) : base(Guid.NewGuid(), eventDateTime)
        {
            SiteId = siteId;
            SiteNumber = siteNumber;
        }

        public int SiteNumber { get; private set; }
        public Guid SiteId { get; private set; }

        public override string ToString()
        {
            return $"New Site {SiteId} with Number {SiteNumber} added to the system.";
        }
    }
}
