using Example.Abstractions.Examples;
using KamiSama.Extensions.DependencyInjection;

namespace Example.Core.Examples;

[AutoInjectScoped<IListItems>]
public sealed class ListItems : IListItems
{
    public Task<IReadOnlyList<ItemDto>> ListAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<ItemDto>>([]);
}
