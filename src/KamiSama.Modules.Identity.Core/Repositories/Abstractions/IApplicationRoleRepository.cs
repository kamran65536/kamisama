using KamiSama.Extensions.Paging;
namespace KamiSama.Modules.Identity.Repositories.Abstractions;

public interface IApplicationRoleRepository
{
    Task AddAsync(ApplicationRole appRole, CancellationToken cancellationToken);
    Task DeleteAsync(ApplicationRole appRole, CancellationToken cancellationToken);
    Task<ApplicationRole?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task UpdateAsync(ApplicationRole appRole, CancellationToken cancellationToken);
    Task<PagedResult<ApplicationRole>> ListAsync(SearchModel searchModel, CancellationToken cancellationToken);
}