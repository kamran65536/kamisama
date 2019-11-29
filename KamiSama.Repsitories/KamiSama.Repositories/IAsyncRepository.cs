using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KamiSama.Repositories
{
	public interface IAsyncRepository<_EntityType> : IRepository<_EntityType>
	{
		Task AddAsync(_EntityType item);
		Task UpdateAsync(_EntityType item);
		Task DeleteAsync(_EntityType item);
		Task<_EntityType> FindAsync(Expression<Func<_EntityType, bool>> predicate);
	}
}
