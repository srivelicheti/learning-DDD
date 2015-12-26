using DDD.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.ValueObjects
{
    [DebuggerDisplay("{countryCode} {Number}")]
    public class PhoneNumber : ValueObject<PhoneNumber>
    {
        public string Number { get; private set; }
        public int CountryCode { get; private set; }
        public PhoneNumber(string phoneNumber, int countryCode)
        {
            Claim.ValidateNotNullAndEmpty(phoneNumber, nameof(phoneNumber));
            Claim.IsNumeric(phoneNumber, nameof(phoneNumber));

            //Claim.ValidateNotNullAndEmpty(countryCode, nameof(countryCode));
            //Claim.IsNumeric(countryCode, nameof(countryCode));

            Number = phoneNumber;
            CountryCode = countryCode;
        }

        public PhoneNumber(string phoneNumber) : this(phoneNumber, 1)
        { }

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        public static implicit operator string(PhoneNumber number)
        {
            //Return a formatted phone number
            return string.Format("{0}{1}", number.CountryCode, number.Number);
            //throw new NotImplementedException();
        }
    }
}
