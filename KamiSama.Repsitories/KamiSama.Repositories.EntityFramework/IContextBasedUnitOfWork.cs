using System.Data.Entity;

namespace KamiSama.Repositories
{
	public interface IContextBasedUnitOfWork<_ContextType>
		where _ContextType : DbContext
    {
		_ContextType GetContext();
    }
}
