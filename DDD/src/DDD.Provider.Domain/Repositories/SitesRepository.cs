using DDD.Domain.Common.Event;
using DDD.Provider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Provider.Domain.Repositories
{
    public class SitesRepository
    {
        private EventBus _eventBus;
        public SitesRepository(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Add(Site site) {
            throw new NotImplementedException();
        }

        public Site GetSite(Guid siteId) {
            throw new NotImplementedException();
        }
    }
}
