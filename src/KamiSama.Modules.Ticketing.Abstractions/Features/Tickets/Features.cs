using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Ticketing.Features.Tickets;

/// <summary>
/// Lists a page of tickets using text, author, status, priority, category, and ordering criteria.
/// Implementations are not required to support every optional criterion.
/// </summary>
public interface IListTickets : IListFeature<TicketListItemDto, TicketSearchModel>;
/// <summary>
/// Creates a ticket with an initial user comment and optional attachment content identifiers.
/// Implementations determine identifier generation and persistence behavior.
/// </summary>
public interface IAddTicket : IAddFeature<AddTicketRequest, TicketDto>;
/// <summary>
/// Updates a ticket title, status, and priority by ticket identifier.
/// Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; other transitions conflict with the current ticket state.
/// Implementations determine authorization.
/// </summary>
public interface IUpdateTicketState : IUpdateFeature<UpdateTicketStateRequest, Guid>;
/// <summary>
/// Finds a ticket and its category, comments, and attachments by identifier.
/// Implementations determine missing-ticket and loading behavior.
/// </summary>
public interface IFindTicketById : IFindByIdFeature<TicketDto, Guid>;
/// <summary>
/// Adds a comment and optional attachments to an existing ticket.
/// Implementations determine side and author authorization.
/// </summary>
public interface IAddCommentToTicket : IAddFeature<AddTicketCommentRequest, TicketDto>;
/// <summary>
/// Updates an existing comment through the common keyed update contract.
/// Implementations determine how the method key and request comment identifier are reconciled.
/// </summary>
public interface IUpdateTicketComment : IUpdateFeature<UpdateTicketCommentRequest, Guid>;
/// <summary>
/// Adds content references to an existing ticket comment.
/// Implementations determine ownership and duplicate-content behavior.
/// </summary>
public interface IAddAttachmentToTicketComment : IAddFeature<AddAttachmentToTicketCommentRequest, TicketDto>;
/// <summary>
/// Removes a ticket attachment by attachment identifier.
/// The misspelling in this public contract name is retained by the current API.
/// </summary>
public interface IRemoveAttachementFromTicketComment : IDeleteFeature<Guid>;
