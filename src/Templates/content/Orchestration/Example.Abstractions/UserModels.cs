using System.ComponentModel.DataAnnotations;

namespace Example.Abstractions;

public sealed record UserSummary(Guid Id, [property: Required, StringLength(200)] string DisplayName);

public interface IListAdminUsers
{
    Task<IReadOnlyList<UserSummary>> ListAsync(CancellationToken cancellationToken = default);
}
