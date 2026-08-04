# TicketingDbContext

<a id="ticketingdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L5)

Namespace: `KamiSama.Modules.Ticketing.Repositories.Database`

Kind: `Class`

## Description

Provides the `TicketingDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class TicketingDbContext : DbContext
```

## Constructors

### TicketingDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L12)

Initializes a new `TicketingDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<TicketingDbContext>` | `-` | The `options` value passed to this member. |

### TicketingDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/Repositories/Database/TicketingDbContext.cs#L15)

Initializes a new `TicketingDbContext` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected TicketingDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The `options` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [TicketAttachments](property-ticketattachments-10.md) | Exposes the `TicketAttachments` value on `TicketingDbContext`. Read or set it as part of configuring or using the type. |
| [TicketCategories](property-ticketcategories-8.md) | Exposes the `TicketCategories` value on `TicketingDbContext`. Read or set it as part of configuring or using the type. |
| [TicketComments](property-ticketcomments-9.md) | Exposes the `TicketComments` value on `TicketingDbContext`. Read or set it as part of configuring or using the type. |
| [Tickets](property-tickets-7.md) | Exposes the `Tickets` value on `TicketingDbContext`. Read or set it as part of configuring or using the type. |

