using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DDD.Common
{
    public static class Claim
    {
        public static void ValidateNotNull(Object argument, string paramName, [CallerMemberName]string memberName = "")
        {
            if (argument == null)
                throw new ArgumentNullException($"{paramName} is passed as null to method {memberName}");
        }

        public static void ValidateNotNullAndEmpty(string argument, string paramName, [CallerMemberName]string memberName = "")
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentNullException($"{paramName} is passed as null to method {memberName}");
        }

        public static void IsNumeric(string argument, string parameterName)
        {

            throw new NotImplementedException();
        }
    }
}
