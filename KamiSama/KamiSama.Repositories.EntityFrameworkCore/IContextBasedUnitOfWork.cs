using Microsoft.EntityFrameworkCore;

namespace KamiSama.Repositories.EntityFrameworkCore
{
	public interface IContextBasedUnitOfWork<_ContextType>
		where _ContextType : DbContext
    {
		_ContextType GetContext();
    }
}
