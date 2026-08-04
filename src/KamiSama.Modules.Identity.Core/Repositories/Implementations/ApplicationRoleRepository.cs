using KamiSama.Repositories.EntityFrameworkCore;
using KamiSama.Extensions.Paging;
using KamiSama.Modules.Identity.Repositories.Database;

namespace KamiSama.Modules.Identity.Repositories.Implementations;

[AutoInjectScoped<IApplicationRoleRepository>]
internal class ApplicationRoleRepository(KamiSamaIdentityDbContext context) : DbRepository<ApplicationRole, KamiSamaIdentityDbContext>(context), IApplicationRoleRepository
{
    public Task<ApplicationRole?> FindByIdAsync(Guid Id, CancellationToken cancellationToken)
        => base.FindAsync(x => x.Id == Id, cancellationToken);

    public Task<PagedResult<ApplicationRole>> ListAsync(SearchModel searchModel, CancellationToken cancellationToken)
        => Where(x => true).OrderBy(x => x.Id).MakePagedAsync(searchModel, cancellationToken);
}