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
        public static readonly SiteType OutOfHomeNonRelative = new SiteType("ON", "Out of home Non-Relative");
        private SiteType(string value, string displayName) : base(value, displayName) { }

        public static implicit operator SiteType(string code)
        {
            if (code == "I")
                return SiteType.InHomeRelative;
			else if (code =="O")
				return SiteType.OutOfHomeRelative;
			else if(code == "N")
				return SiteType.InHomeNonRelative;
			else if (code == "ON")
				return SiteType.OutOfHomeNonRelative;
            else
                throw new Exception("TODO mapping");
        }
    }
}
