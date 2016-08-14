using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string AddressLine1 { get; private set; }

        public string AddressLine2 { get; private set; }

        public string City { get; private set; }

        public string StateCode { get; private set; }

        public string ZipCode { get; private set; }
        public Address(string addressLine1, string addressLine2, string city, string stateCode, string zipCode,string countyCode)
        {
            Claim.ValidateNotNull(addressLine1, nameof(addressLine1));
            Claim.ValidateNotNull(city,nameof(city));
            Claim.ValidateNotNull(zipCode,nameof(zipCode));
            Claim.ValidateNotNull(stateCode,nameof(stateCode));
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.StateCode = stateCode;
            this.ZipCode = zipCode;
            this.CountyCode = countyCode;
        }

        public string CountyCode { get; private set; }

        public Address(string addressLine1, string city, string state, string zipCode) : this(addressLine1, string.Empty, city, state, zipCode,string.Empty)
        {

        }

        public Address(string addressLine1,string addressLine2 ,string city, string stateCode, string zipCode) : this(addressLine1, addressLine2, city, stateCode, zipCode, string.Empty)
        {

        }

    }
}
