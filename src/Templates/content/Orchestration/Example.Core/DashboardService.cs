using Example.Abstractions;
using KamiSama.Extensions.DependencyInjection;

namespace Example.Core;

[AutoInjectScoped<IGetDashboardSummary>]
public sealed class DashboardService : IGetDashboardSummary
{
    public Task<DashboardSummary> GetAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(new DashboardSummary("Example", DateTimeOffset.UtcNow));
}
