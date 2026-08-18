using TicketingDataTypes = KamiSama.Modules.Ticketing.DataTypes;
using TicketingFeatures = KamiSama.Modules.Ticketing.Features.Tickets;

namespace Suma.AdminPanel.Services.Tickets;

internal static class TicketMappings
{
	public static TicketingFeatures.TicketSearchModel ToTicketingSearchModel(this TicketSearchModel searchModel)
		=> new(
			0,
			0,
			searchModel.Title,
			default,
			null,
			searchModel.Statuses?.Select(MapStatus).ToArray(),
			searchModel.Priorities?.Select(MapPriority).ToArray(),
			searchModel.OrderBy);

	public static TicketListItemDto ToListItemDto(this TicketingFeatures.TicketListItemDto dto)
		=> new(dto.Title, dto.CreatedAt, dto.Id, MapStatus(dto.Status));

	public static TicketDto ToPanelDto(this TicketingFeatures.TicketDto dto)
		=> new(
			dto.Id,
			dto.AuthorUserId,
			dto.Title,
			MapStatus(dto.Status),
			MapPriority(dto.Priority),
			[.. dto.Comments.Select(ToPanelDto)],
			dto.CreatedAt,
			dto.UpdatedAt);

	private static TicketCommentDto ToPanelDto(TicketingFeatures.TicketCommentDto dto)
		=> new(
			dto.Id,
			dto.AuthorUserId,
			dto.Comment,
			MapSide(dto.Side),
			[.. dto.Attachments.Select(ToPanelDto)],
			dto.CreatedAt,
			dto.UpdatedAt);

	private static TicketAttachmentDto ToPanelDto(TicketingFeatures.TicketAttachmentDto dto)
		=> new(dto.Id, dto.ContentId, dto.AuthorUserId);

	public static TicketingDataTypes.TicketStatus MapStatus(TicketingStatus status)
		=> status switch
		{
			TicketingStatus.Open => TicketingDataTypes.TicketStatus.Open,
			TicketingStatus.Reopened => TicketingDataTypes.TicketStatus.Reopened,
			TicketingStatus.Resolved => TicketingDataTypes.TicketStatus.Resolved,
			TicketingStatus.Closed => TicketingDataTypes.TicketStatus.Closed,
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unsupported ticket status."),
		};

	public static TicketingStatus MapStatus(TicketingDataTypes.TicketStatus status)
		=> status switch
		{
			TicketingDataTypes.TicketStatus.Open => TicketingStatus.Open,
			TicketingDataTypes.TicketStatus.Reopened => TicketingStatus.Reopened,
			TicketingDataTypes.TicketStatus.Resolved => TicketingStatus.Resolved,
			TicketingDataTypes.TicketStatus.Closed => TicketingStatus.Closed,
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unsupported ticket status."),
		};

	public static TicketingDataTypes.TicketPriority MapPriority(TicketPriority priority)
		=> priority switch
		{
			TicketPriority.Low => TicketingDataTypes.TicketPriority.Low,
			TicketPriority.Medium => TicketingDataTypes.TicketPriority.Medium,
			TicketPriority.High => TicketingDataTypes.TicketPriority.High,
			TicketPriority.Critical => TicketingDataTypes.TicketPriority.Critical,
			_ => throw new ArgumentOutOfRangeException(nameof(priority), priority, "Unsupported ticket priority."),
		};

	public static TicketPriority MapPriority(TicketingDataTypes.TicketPriority priority)
		=> priority switch
		{
			TicketingDataTypes.TicketPriority.Low => TicketPriority.Low,
			TicketingDataTypes.TicketPriority.Medium => TicketPriority.Medium,
			TicketingDataTypes.TicketPriority.High => TicketPriority.High,
			TicketingDataTypes.TicketPriority.Critical => TicketPriority.Critical,
			_ => throw new ArgumentOutOfRangeException(nameof(priority), priority, "Unsupported ticket priority."),
		};

	private static TicketCommentSide MapSide(TicketingDataTypes.TicketCommentSide side)
		=> side switch
		{
			TicketingDataTypes.TicketCommentSide.User => TicketCommentSide.User,
			TicketingDataTypes.TicketCommentSide.Operator => TicketCommentSide.Operator,
			_ => throw new ArgumentOutOfRangeException(nameof(side), side, "Unsupported ticket comment side."),
		};
}

