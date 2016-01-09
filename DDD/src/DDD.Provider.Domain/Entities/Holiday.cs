using DDD.Common;
using DDD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Entities
{
    public class Holiday : Entity
    {
        public Holiday(Guid id, string holidayName, DateTime date):base(id)
        {
            HolidayName = holidayName;
            Date = date;
        }

        public Holiday( string holidayName, DateTime date) : this(GuidHelper.NewSequentialGuid(),holidayName,date)
        {
        }

        public DateTime Date { get; private set; }
        public string HolidayName { get; private set; }

        public void UpdateHolidayName(string newName)
        {
            Claim.ValidateNotNullAndEmpty(newName, nameof(newName));
            this.State = DomainEntityState.Modified;
            HolidayName = newName;
        }

        public bool AreSame(DateTime date) {
            return false;
        }
    }
}
