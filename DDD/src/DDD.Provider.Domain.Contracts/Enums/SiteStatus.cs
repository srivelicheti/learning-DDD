using System;
using DDD.Common;

namespace DDD.Provider.Domain.Contracts.Enums
{
    public class SiteStatus : Enumeration<SiteStatus, string>
    {
        public static readonly SiteStatus Active = new SiteStatus("A", "Active");

        public static readonly SiteStatus InActive = new SiteStatus("I", "In-Active");

        private SiteStatus(string value, string displayName) : base(value, displayName) { }

        public static implicit operator string(SiteStatus status)
        {
            return status.Value;
        }

        public static implicit operator SiteStatus(string code)
        {
            if (code == SiteStatus.Active.Value)
                return SiteStatus.Active;
            else if (code == SiteStatus.InActive.Value)
                return SiteStatus.InActive;
            else
                throw new InvalidCastException($"{code} is not a valid value for SiteStatus enumeration");
        }
    }
}
