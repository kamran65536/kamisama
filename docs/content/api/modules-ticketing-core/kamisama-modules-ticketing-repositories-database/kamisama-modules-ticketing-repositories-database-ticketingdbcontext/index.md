# TicketingDbContext

<a id="ticketingdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L9)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Database`

Kind: `Class`

## Description

Provider-neutral EF Core context consumed by Ticketing repositories and startup initialization. It exposes tracked aggregate sets; a concrete provider must be registered under the configured keyed context for normal module use.

## Declaration

```csharp
public class TicketingDbContext : DbContext
```

## Example

```csharp
using IServiceScope scope = app.Services.CreateScope();
TicketingDbContext context = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();
List<Ticket> open = await context.Tickets.AsNoTracking()
    .Where(ticket => ticket.Status == TicketStatus.Open)
    .ToListAsync(cancellationToken);
```

## Constructors

### TicketingDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L25)

Initializes the provider-neutral context with options typed for `TicketingDbContext`. Use this constructor when configuring the base context directly.

```csharp
public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<TicketingDbContext>` | `-` | The EF Core options for this context. |

### TicketingDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L33)

Initializes the base context with provider-specific options supplied by a derived context. Provider packages use this constructor from their concrete context types.

```csharp
protected TicketingDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The provider-specific EF Core options. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [TicketAttachments](property-ticketattachments-18.md) | Gets or sets the tracked attachment-reference set used for direct attachment lookup. |
| [TicketCategories](property-ticketcategories-14.md) | Gets or sets the tracked category set used by Core repositories. |
| [TicketComments](property-ticketcomments-16.md) | Gets or sets the tracked comment set used for direct comment lookup. |
| [Tickets](property-tickets-12.md) | Gets or sets the tracked ticket aggregate set used by Core repositories. |

