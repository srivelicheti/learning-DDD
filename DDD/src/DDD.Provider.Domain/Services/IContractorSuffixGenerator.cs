using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Services
{
    public interface IContractorSuffixGenerator
    {
        string GetContractorSuffixForNewContractor(string einNumber);
    }
}
