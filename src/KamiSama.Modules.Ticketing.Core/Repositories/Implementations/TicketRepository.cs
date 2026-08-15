using Microsoft.EntityFrameworkCore;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Repositories.Implementations;

[AutoInjectScoped<ITicketRepository>]
internal class TicketRepository(TicketingDbContext context) : GenericRepository<Ticket, TicketSearchModel, TicketingDbContext>(context), ITicketRepository
{
	/// <summary>
	/// Applies Core ticket text, author, status, and priority filters and deterministic ordering.
	/// The current implementation does not apply <see cref="TicketSearchModel.TicketCategoryId"/>.
	/// </summary>
	/// <param name="query">The tracked ticket query to shape.</param>
	/// <param name="searchModel">The requested filters, paging inputs, and ordering token.</param>
	/// <returns>The filtered and ordered query used by the generic repository.</returns>
	protected override IQueryable<Ticket> ApplySearchModel(IQueryable<Ticket> query, TicketSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Comment))
		{
			var _comment = searchModel.Comment.ToLower();
			query = query.Where(t => 
				t.Title.ToLower().Contains(_comment) || 
				t.Comments.Any(c => c.Comment.ToLower().Contains(_comment)));
        }
        if (searchModel.Statuses is not null && searchModel.Statuses.Length > 0)
			query = query.Where(t => searchModel.Statuses.Contains(t.Status));
		if (searchModel.Priorities is not null && searchModel.Priorities.Length > 0)
			query = query.Where(t => searchModel.Priorities.Contains(t.Priority));
		if (searchModel.AuthorUserId != null)
			query = query.Where(t => t.AuthorUserId == searchModel.AuthorUserId || t.Comments.Any(c => c.AuthorUserId == searchModel.AuthorUserId));

        return searchModel.OrderBy?.ToLower() switch
		{
			"priority" => query.OrderBy(t => t.Priority),
			"status" => query.OrderBy(t => t.Status),
			"updatedat" => query.OrderBy(t => t.UpdatedAt),
			_ => query.OrderBy(x => x.Priority).ThenBy(x => x.UpdatedAt),
		};
    }
	/// <summary>Finds the first tracked ticket with the supplied identifier.</summary>
	/// <param name="id">The ticket identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns>The matching ticket, or <see langword="null"/> when absent.</returns>
	public Task<Ticket?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);
	/// <summary>Tests whether a ticket exists with the supplied identifier.</summary>
	/// <param name="id">The ticket identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns><see langword="true"/> when a matching ticket exists; otherwise <see langword="false"/>.</returns>
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
	/// <summary>Finds a tracked ticket comment directly through the context comment set.</summary>
	/// <param name="commentId">The comment identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns>The matching comment, or <see langword="null"/> when absent.</returns>
	public Task<TicketComment?> FindTicketCommentByCommentIdAsync(Guid commentId, CancellationToken cancellationToken)
		=> base.Context.TicketComments.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);
	/// <summary>Finds a tracked ticket attachment directly through the context attachment set.</summary>
	/// <param name="attachmentId">The attachment identifier.</param>
	/// <param name="cancellationToken">The token forwarded to EF Core.</param>
	/// <returns>The matching attachment, or <see langword="null"/> when absent.</returns>
	public Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken)
		=> base.Context.TicketAttachments.FirstOrDefaultAsync(x => x.Id == attachmentId, cancellationToken);
}
