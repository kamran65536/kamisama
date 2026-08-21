using System.ComponentModel.DataAnnotations;

namespace Example.Abstractions;

public sealed record DashboardSummary(
    [property: Required, StringLength(200)] string Application,
    DateTimeOffset GeneratedAt);

public interface IGetDashboardSummary
{
    Task<DashboardSummary> GetAsync(CancellationToken cancellationToken = default);
}
