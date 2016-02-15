using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.CommandValidators
{
    public class ValidationErrorCodes
    {
        public static class Contractor
        {
            public static int SELF_ARRANGED_CONTRACTOR_NOT_FOUND = 2000;
        }
    }
}
