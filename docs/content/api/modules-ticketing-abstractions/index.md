# KamiSama.Modules.Ticketing.Abstractions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provider-neutral Ticketing feature contracts, requests, DTOs, search models, statuses, priorities, and comment sides. Reference this package from callers or alternative implementations that should not depend on EF Core, ASP.NET Core module setup, or a database provider.

## How to use

```shell
dotnet add package KamiSama.Modules.Ticketing.Abstractions --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet exposed `10.0.11` as the latest package when this surface was reviewed; `10.0.0` itself was not available.

Inject only the Ticketing feature contracts needed by an application service or controller after a concrete implementation has registered them:

```csharp
using KamiSama.Extensions.Paging;
using KamiSama.Modules.Ticketing.Features.Tickets;

public sealed class TicketsController(IListTickets listTickets, IFindTicketById findTicket)
{
    public Task<PagedResult<TicketListItemDto>> ListAsync(Guid authorId, CancellationToken token)
        => listTickets.ListAsync(
            new TicketSearchModel(1, 20, null, null, authorId, [TicketStatus.Open], null, "updatedat"),
            token);

    public Task<TicketDto> FindAsync(Guid id, CancellationToken token)
        => findTicket.FindByIdAsync(id, token);
}
```

This package contains contracts and data shapes only: it registers no services, controllers, endpoints, persistence, content storage, validation pipeline, authentication, or authorization. Alternative implementations define query and mutation semantics. Current Core permits unchanged ticket status, open or reopened to resolved, and resolved to reopened or closed; invalid transitions produce HTTP 409. Core ignores `TicketSearchModel.TicketCategoryId`; its comment update accepts both a method key and `UpdateTicketCommentRequest.CommentId` but uses only the request identifier. Treat request author identifiers and comment sides as untrusted input at an authenticated endpoint boundary.

## Namespaces

- [KamiSama.Modules.Ticketing.DataTypes](kamisama-modules-ticketing-datatypes/index.md) (3 types)
- [KamiSama.Modules.Ticketing.Features.TicketCategories](kamisama-modules-ticketing-features-ticketcategories/index.md) (13 types)
- [KamiSama.Modules.Ticketing.Features.Tickets](kamisama-modules-ticketing-features-tickets/index.md) (18 types)

## Types

- [KamiSama.Modules.Ticketing.DataTypes.TicketCommentSide](kamisama-modules-ticketing-datatypes/kamisama-modules-ticketing-datatypes-ticketcommentside/index.md) - Identifies whether a ticket comment is attributed to the user or operator side. The value is supplied by comment callers except for the initial user comment created with a ticket.
- [KamiSama.Modules.Ticketing.DataTypes.TicketPriority](kamisama-modules-ticketing-datatypes/kamisama-modules-ticketing-datatypes-ticketpriority/index.md) - Identifies the urgency assigned to a ticket. Core stores the numeric value and uses it as the default primary list ordering.
- [KamiSama.Modules.Ticketing.DataTypes.TicketStatus](kamisama-modules-ticketing-datatypes/kamisama-modules-ticketing-datatypes-ticketstatus/index.md) - Defines the open, reopened, resolved, and closed workflow states. Core permits unchanged status, open or reopened to resolved, and resolved to reopened or closed; closed is terminal.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.AddTicketCategoryRequest](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-addticketcategoryrequest/index.md) - Supplies the name for a new ticket category. Core checks the name for a case-insensitive duplicate before saving.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IAddTicketCategory](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-iaddticketcategory/index.md) - Creates a ticket category and returns its persisted representation. Core rejects an existing case-insensitive name before insertion.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IDeleteTicketCategory](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ideleteticketcategory/index.md) - Deletes a ticket category identified by a `Guid`. Implementations determine relationship and missing-category behavior.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IExistsTicketCategoryById](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-iexiststicketcategorybyid/index.md) - Tests whether a ticket category exists for a `Guid` identifier. Implementations define the underlying lookup behavior.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IExistsTicketCategoryByName](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-iexiststicketcategorybyname/index.md) - Tests whether a ticket category exists for a name. Core&apos;s repository performs a case-insensitive exact comparison.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IFindTicketCategoryById](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ifindticketcategorybyid/index.md) - Finds a ticket category by its `Guid` identifier. Implementations determine missing-category behavior.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IFindTicketCategoryByName](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ifindticketcategorybyname/index.md) - Finds a ticket category by name. Core performs a case-insensitive exact comparison.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IListTicketCategories](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ilistticketcategories/index.md) - Lists a page of ticket categories matching name and ordering criteria. Implementations define persistence and exact filtering semantics.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.IUpdateTicketCategory](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-iupdateticketcategory/index.md) - Updates a ticket category identified by a `Guid`. Core replaces the name and rejects a case-insensitive name owned by another category.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategoryDto](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ticketcategorydto/index.md) - Carries the complete public representation of a ticket category. The current shape is the same as the list-item representation.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategoryListItemDto](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ticketcategorylistitemdto/index.md) - Carries the category fields returned in ticket-category list results and nested ticket data. It contains no ticket collection.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.TicketCategorySearchModel](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-ticketcategorysearchmodel/index.md) - Carries paging, optional name filtering, and ordering for ticket-category lists. Core performs a case-insensitive exact name comparison and recognizes `id`, `name`, `createdat`, and `updatedat` ordering tokens.
- [KamiSama.Modules.Ticketing.Features.TicketCategories.UpdateTicketCategoryRequest](kamisama-modules-ticketing-features-ticketcategories/kamisama-modules-ticketing-features-ticketcategories-updateticketcategoryrequest/index.md) - Supplies the replacement name for an existing ticket category. The target category identifier is passed separately to the update feature.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddAttachmentToTicketCommentRequest](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addattachmenttoticketcommentrequest/index.md) - Supplies an existing comment, claimed author, and external content identifiers to attach. Core requires author-id equality and rejects content identifiers already present on that comment.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddTicketCommentRequest](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addticketcommentrequest/index.md) - Supplies a ticket identifier and the data for a new comment with optional attachment references. Current Core accepts the requested side and author without checking ticket editability or caller identity.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddTicketRequest](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addticketrequest/index.md) - Supplies the data used to open a ticket, create its initial user-side comment, and attach external content references. Core requires the category to exist and forces the initial status to `TicketStatus.Open`.
- [KamiSama.Modules.Ticketing.Features.Tickets.IAddAttachmentToTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iaddattachmenttoticketcomment/index.md) - Adds content references to an existing ticket comment. Implementations determine ownership and duplicate-content behavior.
- [KamiSama.Modules.Ticketing.Features.Tickets.IAddCommentToTicket](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iaddcommenttoticket/index.md) - Adds a comment and optional attachments to an existing ticket. Implementations determine side and author authorization.
- [KamiSama.Modules.Ticketing.Features.Tickets.IAddTicket](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iaddticket/index.md) - Creates a ticket with an initial user comment and optional attachment content identifiers. Implementations determine identifier generation and persistence behavior.
- [KamiSama.Modules.Ticketing.Features.Tickets.IFindTicketById](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ifindticketbyid/index.md) - Finds a ticket and its category, comments, and attachments by identifier. Implementations determine missing-ticket and loading behavior.
- [KamiSama.Modules.Ticketing.Features.Tickets.IListTickets](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ilisttickets/index.md) - Lists a page of tickets using text, author, status, priority, category, and ordering criteria. Implementations are not required to support every optional criterion.
- [KamiSama.Modules.Ticketing.Features.Tickets.IRemoveAttachementFromTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iremoveattachementfromticketcomment/index.md) - Removes a ticket attachment by attachment identifier. The misspelling in this public contract name is retained by the current API.
- [KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iupdateticketcomment/index.md) - Defines comment update through a method key plus a request that contains another comment identifier. Current Core uses only the request identifier, so callers must not assume the key selects or validates the target.
- [KamiSama.Modules.Ticketing.Features.Tickets.IUpdateTicketState](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-iupdateticketstate/index.md) - Defines keyed replacement of a ticket's title, status, and priority. Core validates the requested workflow transition before changing or saving the tracked ticket and reports invalid transitions as HTTP 409 conflicts.
- [KamiSama.Modules.Ticketing.Features.Tickets.TicketAttachmentDto](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ticketattachmentdto/index.md) - Carries a stored attachment reference without binary content. Resolve &lt;paramref name=&quot;ContentId&quot;/&gt; through the host application&apos;s content service.
- [KamiSama.Modules.Ticketing.Features.Tickets.TicketCommentDto](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ticketcommentdto/index.md) - Carries one ticket comment, its author and side, attachment references, and timestamps. Attachment values contain external content identifiers rather than content bytes.
- [KamiSama.Modules.Ticketing.Features.Tickets.TicketDto](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ticketdto/index.md) - Carries a complete ticket aggregate with category, comments, and attachment references. Core mapping relies on the corresponding EF Core navigations being available.
- [KamiSama.Modules.Ticketing.Features.Tickets.TicketListItemDto](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ticketlistitemdto/index.md) - Carries the ticket fields returned by list operations without category, comment, or attachment data. Use a find operation when the complete aggregate is required.
- [KamiSama.Modules.Ticketing.Features.Tickets.TicketSearchModel](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-ticketsearchmodel/index.md) - Carries ticket paging, text, category, author, status, priority, and ordering criteria. Current Core ignores the category identifier and recognizes only `priority`, `status`, and `updatedat` ordering tokens.
- [KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketCommentRequest](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-updateticketcommentrequest/index.md) - Carries the actual comment identifier, claimed author identifier, and replacement text used by Core. Core ignores the separate update-method key and authorizes only by equality with the stored author identifier.
- [KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketStateRequest](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-updateticketstaterequest/index.md) - Carries replacement title, status, and priority values. Core accepts unchanged status, open or reopened to resolved, and resolved to reopened or closed; every other transition produces an HTTP 409 conflict.
