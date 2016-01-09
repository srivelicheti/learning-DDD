using System;
using System.Collections.Generic;

namespace DDD.Provider.DataModel
{
    public partial class SiteHoliday
    {
        public Guid ID { get; set; }
        public string CalendarYearDate { get; set; }
        public string FirstInsertedByID { get; set; }
        public DateTime FirstInsertedDateTime { get; set; }
        public DateTime HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string LastSavedByID { get; set; }
        public DateTime LastSavedDateTime { get; set; }
        public Guid SiteID { get; set; }

        public virtual Site Site { get; set; }
    }
}
