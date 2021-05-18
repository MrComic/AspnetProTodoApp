using System.Threading.Tasks;

namespace Framework.Core.Domain.Queries
{
    public interface IQueryHandler<TQuery, TData>
         where TQuery : class, IQuery<TData>
    {
        Task<QueryResult<TData>> Handle(TQuery request);
    }
}
