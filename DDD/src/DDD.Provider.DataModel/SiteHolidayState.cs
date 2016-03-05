using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class SiteHolidayState
    {
        public Guid Id { get; set; }
        public string CalendarYearDate { get; set; }
        public string FirstInsertedById { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string LastSavedById { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public Guid SiteId { get; set; }

        public virtual SiteState SiteState { get; set; }
    }
}
