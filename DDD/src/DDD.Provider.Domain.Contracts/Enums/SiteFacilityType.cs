using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class SiteFacilityType : Enumeration<SiteFacilityType,int>
    {
        public static readonly SiteFacilityType Center = new SiteFacilityType(17,"Center");
        public static readonly SiteFacilityType FamilyHome = new SiteFacilityType(15, "Family Home");
        public static readonly SiteFacilityType LargeFamilyHome = new SiteFacilityType(16, "Large Family Home");
        public static readonly SiteFacilityType LicenceExcemptCenter = new SiteFacilityType(18, "Licence Exempt Center");
        public static readonly SiteFacilityType LicenceExcemptRelativeCare = new SiteFacilityType(19, "Licence Exempt Relative Care");
        private SiteFacilityType(int code, string value) : base(code, value)
        { }

        public static implicit operator int(SiteFacilityType status)
        {
            return status.Value;
        }

        public static implicit operator string(SiteFacilityType status)
        {
            return status.Value.ToString();
        }

        public static implicit operator SiteFacilityType(int code)
        {
            if (code == SiteFacilityType.Center.Value)
                return SiteFacilityType.Center;
            else if (code == SiteFacilityType.FamilyHome.Value)
                return SiteFacilityType.FamilyHome;
            else if (code == SiteFacilityType.LargeFamilyHome.Value)
                return SiteFacilityType.LargeFamilyHome;
            else if (code == SiteFacilityType.LargeFamilyHome.Value)
                return SiteFacilityType.LicenceExcemptCenter.Value;
            else if (code == SiteFacilityType.LicenceExcemptRelativeCare.Value)
                return SiteFacilityType.LicenceExcemptRelativeCare;
            else
                throw new InvalidCastException($"{code} is not a valid value for SiteFacilityType enumeration");
        }

        public static implicit operator SiteFacilityType(string code)
        {
            int c;
            if (!int.TryParse(code, out c))
            {
                throw new InvalidCastException($"{code} is not a valid value for SiteFacilityType enumeration");
            }
            return c;
        }
    }
}
