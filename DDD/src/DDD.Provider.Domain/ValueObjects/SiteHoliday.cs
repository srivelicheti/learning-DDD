using DDD.Domain.Common;
using DDD.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.ValueObjects
{
    public class SiteHoliday : ValueObject<SiteHoliday>
    {
        public SiteHoliday(DateTime holidayDate) : this(holidayDate, "Not-Specified") { }
        public SiteHoliday(DateTime holidayDate, string name)
        {
            HolidayDate = holidayDate;
            Name = name;
        }

        public DateTime HolidayDate { get; private set; }

        public string Name { get; private set; }
    }
}
