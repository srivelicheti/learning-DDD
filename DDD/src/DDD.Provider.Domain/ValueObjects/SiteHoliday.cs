using DDD.Domain.Common;
using DDD.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Provider.DataModel;

namespace DDD.Provider.Domain.ValueObjects
{
    public class SiteHoliday : ValueObject<SiteHoliday>
    {
        public SiteHoliday(DateTime holidayDate) : this(holidayDate, "Not-Specified") { }
        public SiteHoliday(DateTime holidayDate, string name)
        {
            HolidayDate = holidayDate;
            Name = name;
            InitializeDbState();
        }

        internal SiteHoliday (SiteHolidayState holidayState)
        {
            HolidayDate = holidayState.HolidayDate;
            Name = holidayState.HolidayName;
            DbState = holidayState;
        }

        private void InitializeDbState()
        {
            DbState = new SiteHolidayState
            {
                Id = GuidHelper.NewSequentialGuid(),
                HolidayDate = HolidayDate,
                CalendarYearDate = HolidayDate.Year.ToString(),
                HolidayName = Name,
                FirstInsertedDateTime = DateTime.UtcNow,
                FirstInsertedById = "TODO",
                LastSavedDateTime = DateTime.UtcNow,
                LastSavedById = "TODO"

            };
        }

        internal SiteHolidayState DbState { get; private set; }

        public DateTime HolidayDate { get; private set; }

        public string Name { get; private set; }
    }
}
