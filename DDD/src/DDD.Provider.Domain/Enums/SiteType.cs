using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class SiteType : Enumeration<SiteType,string>
    {
        public static readonly SiteType InHomeRelative = new SiteType("I", "In Home Relative");
        public static readonly SiteType OutOfHomeRelative = new SiteType("O", "Out of home Relative");
        public static readonly SiteType InHomeNonRelative = new SiteType("N", "In Home Non-Relative");
        public static readonly SiteType OutOfHomeNonRelative = new SiteType("I", "Out of home Non-Relative");
        private SiteType(string value, string displayName) : base(value, displayName) { }
    }
}
