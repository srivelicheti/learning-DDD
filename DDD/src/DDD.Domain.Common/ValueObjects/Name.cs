using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Name(Name fullName)
          : this(fullName.FirstName, fullName.LastName)
        {
        }

        protected Name()
        {
        }


        public string FirstName { get; }

        public string LastName { get; }

        public string AsFormattedName()
        {
            return FirstName + " " + LastName;
        }

        public Name WithChangedFirstName(string firstName)
        {
            return new Name(firstName, LastName);
        }

        public Name WithChangedLastName(string lastName)
        {
            return new Name(FirstName, lastName);
        }

        public override string ToString()
        {
            return "Name [firstName=" + FirstName + ", lastName=" + LastName + "]";
        }
    }
}
