using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.CommandValidators
{
    public class ValidationErrorCodes
    {
        public static class ContractorCodes
        {
            public const int SelfArrangedContractorNotFound = 2000;
            public const int SelfArrangedContractorAlreadyRegistered = 2010;
            
        }
    }
}
