using System.ComponentModel.DataAnnotations;

namespace Example.Abstractions.Examples;

public sealed record ItemDto(Guid Id, [property: Required, StringLength(200)] string Name);

public interface IListItems
{
    Task<IReadOnlyList<ItemDto>> ListAsync(CancellationToken cancellationToken = default);
}
