using DDD.Common;
using DDD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Entities
{
    public class Address :ValueObject<Address>
    {
        public string AddressLine1 { get; private set; }

        public string AddressLine2 { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string ZipCode { get; private set; }
        public Address(string addressLine1, string addressLine2, string city, string state ,string zipCode)
        {
            Claim.ValidateNotNull(addressLine1, nameof(addressLine1));
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }

        public Address(string addressLine1, string city, string state, string zipCode) : this(addressLine1,string.Empty,city,state,zipCode)
        {

        }
    }
}
