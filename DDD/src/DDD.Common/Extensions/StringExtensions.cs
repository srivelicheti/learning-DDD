using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Common.Extensions
{
    public static class StringExtensions
    {
        public static string FormatSsn(this string unformattedSsn)
        {
            ThrowIfInvalidSsn(unformattedSsn);
            return unformattedSsn.Insert(5, "-").Insert(3, "-");
        }

        public static string FormatAndMaskSsn(this string unformattedSsn)
        {
            ThrowIfInvalidSsn(unformattedSsn);
            return $"XXX-XX-{unformattedSsn.Skip(5).Take(4)}"; 
        }

        private static void ThrowIfInvalidSsn(string ssn) {
            if (!IsValidSsn(ssn))
                throw new Exception("Invalid SSN");
        }
        private static bool IsValidSsn(string ssn)
        {
           return ssn.Length == 9 && ssn.All(x => { var ascii = (int)x; return ascii >= 49 && ascii <= 57; });
        }
    }
}
