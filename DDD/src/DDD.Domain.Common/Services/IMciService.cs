using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Services
{
    public interface IMciService
    {
        bool IsRegisterdIndividual(string ssn);
    }

    public class MockMciService : IMciService
    {
        public bool IsRegisterdIndividual(string ssn)
        {
            return true;
        }
    }
}
