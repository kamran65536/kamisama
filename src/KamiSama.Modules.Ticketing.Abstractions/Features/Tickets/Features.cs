using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Ticketing.Features.Tickets;

public interface IListTickets : IListFeature<TicketListItemDto, TicketSearchModel>;
public interface IAddTicket : IAddFeature<AddTicketRequest, TicketDto>;
public interface IUpdateTicketState : IUpdateFeature<UpdateTicketStateRequest, Guid>;
public interface IFindTicketById : IFindByIdFeature<TicketDto, Guid>;
public interface IAddCommentToTicket : IAddFeature<AddTicketCommentRequest, TicketDto>;
public interface IUpdateTicketComment : IUpdateFeature<UpdateTicketCommentRequest, Guid>;
public interface IAddAttachmentToTicketComment : IAddFeature<AddAttachmentToTicketCommentRequest, TicketDto>;
public interface IRemoveAttachementFromTicketComment : IDeleteFeature<Guid>;
