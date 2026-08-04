using Microsoft.EntityFrameworkCore;
using KamiSama.Modules.Ticketing.Features.Tickets;

namespace KamiSama.Modules.Ticketing.Repositories.Implementations;

[AutoInjectScoped<ITicketRepository>]
internal class TicketRepository(TicketingDbContext context) : GenericRepository<Ticket, TicketSearchModel, TicketingDbContext>(context), ITicketRepository
{
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
	public Task<Ticket?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.FindAsync(x => x.Id == id, cancellationToken);
	public Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
		=> base.AnyAsync(x => x.Id == id, cancellationToken);
	public Task<TicketComment?> FindTicketCommentByCommentIdAsync(Guid commentId, CancellationToken cancellationToken)
		=> base.Context.TicketComments.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);
	public Task<TicketAttachment?> FindTicketAttachmentByAttachmentIdAsync(Guid attachmentId, CancellationToken cancellationToken)
		=> base.Context.TicketAttachments.FirstOrDefaultAsync(x => x.Id == attachmentId, cancellationToken);
}
