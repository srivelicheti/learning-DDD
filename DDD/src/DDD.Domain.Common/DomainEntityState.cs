using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common
{
    public enum TrackingState
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
