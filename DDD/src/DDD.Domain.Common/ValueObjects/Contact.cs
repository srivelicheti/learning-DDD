using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.ValueObjects
{
    public class Contact :ValueObject<Contact>
    {
        public Contact(Name name, PhoneNumber phone, PhoneNumber alternatePhone ,string email)
        {
            Claim.ValidateNotNull(name, nameof(name));
            Claim.ValidateNotNull(phone, nameof(PhoneNumber));
            Name = name;
            PhoneNumber = phone;
            AlternatePhoneNumber = alternatePhone;
            Email = email;
        }
        public Name Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public PhoneNumber AlternatePhoneNumber { get; private set; }

        public string Email { get; private set; }
    }
}
