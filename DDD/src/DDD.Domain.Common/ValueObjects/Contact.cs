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
            throw new NotImplementedException();
        }
    }
}
