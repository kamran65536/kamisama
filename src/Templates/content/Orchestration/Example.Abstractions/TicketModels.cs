using System.ComponentModel.DataAnnotations;

namespace Example.Abstractions;

public sealed record TicketSummary(
    Guid Id,
    [property: Required, StringLength(300)] string Subject,
    [property: Required] string Status);

public interface IListAdminTickets
{
    Task<IReadOnlyList<TicketSummary>> ListAsync(CancellationToken cancellationToken = default);
}
