using DDD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Enums
{
    public class LicenceStatus : Enumeration<LicenceStatus,string>
    {
        public static readonly LicenceStatus Licenced = new LicenceStatus("L", "Licenced");
        public static readonly LicenceStatus Exempted = new LicenceStatus("E", "Exempted");

        private LicenceStatus(string value, string displayName) : base(value, displayName) { }

        public static implicit operator string(LicenceStatus status)
        {
            return status.Value;
        }

        public static implicit operator LicenceStatus(string code)
        {
            if (code == LicenceStatus.Licenced.Value)
                return LicenceStatus.Licenced;
            else if (code == LicenceStatus.Exempted.Value)
                return LicenceStatus.Exempted;
            else
                throw new InvalidCastException($"{code} is not a valid value for LicenceStatus enumeration");
        }
    }
}
