using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Domain.Common.Query
{
    public interface IQueryProcessor
    {

        TResult Process<TResult>(IQuery<TResult> query);

    }

    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IContainer _container;

        public QueryProcessor(IContainer container)
        {
            this._container = container;
        }
        
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType =
                typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
