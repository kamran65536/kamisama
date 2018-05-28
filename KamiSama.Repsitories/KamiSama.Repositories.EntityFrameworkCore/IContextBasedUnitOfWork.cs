using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories
{
	public interface IContextBasedUnitOfWork<_ContextType>
		where _ContextType : DbContext
    {
		_ContextType GetContext();
    }
}
