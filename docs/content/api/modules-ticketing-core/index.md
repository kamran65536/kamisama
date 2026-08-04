# KamiSama.Modules.Ticketing.Core

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Ticketing module implementation with entities, repositories, feature services, and web-module setup. Use it with the surrounding package APIs when composing application code.

## Install

```shell
dotnet add package KamiSama.Modules.Ticketing.Core --version 10.0.10
```

## Namespaces

- [KamiSama.Modules.Ticketing](kamisama-modules-ticketing/index.md) (3 types)
- [KamiSama.Modules.Ticketing.Entities](kamisama-modules-ticketing-entities/index.md) (4 types)
- [KamiSama.Modules.Ticketing.Features.Categories](kamisama-modules-ticketing-features-categories/index.md) (8 types)
- [KamiSama.Modules.Ticketing.Features.Tickets](kamisama-modules-ticketing-features-tickets/index.md) (8 types)
- [KamiSama.Modules.Ticketing.Repositories.Abstractions](kamisama-modules-ticketing-repositories-abstractions/index.md) (2 types)
- [KamiSama.Modules.Ticketing.Repositories.Database](kamisama-modules-ticketing-repositories-database/index.md) (1 types)
- [KamiSama.Modules.Ticketing.Repositories.Implementations](kamisama-modules-ticketing-repositories-implementations/index.md) (2 types)

## Types

- [KamiSama.Modules.Ticketing.DtoMappings](kamisama-modules-ticketing/kamisama-modules-ticketing-dtomappings/index.md) - Provides the `DtoMappings` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.ExtendedWebApplicationBuilderExtensions](kamisama-modules-ticketing/kamisama-modules-ticketing-extendedwebapplicationbuilderextensions/index.md) - Provides the `ExtendedWebApplicationBuilderExtensions` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.TicketingModule](kamisama-modules-ticketing/kamisama-modules-ticketing-ticketingmodule/index.md) - ASP.NET Core web-module implementation for `TicketingModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.
- [KamiSama.Modules.Ticketing.Entities.Ticket](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticket/index.md) - Provides the `Ticket` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Entities.TicketAttachment](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketattachment/index.md) - Provides the `TicketAttachment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Entities.TicketCategory](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketcategory/index.md) - Provides the `TicketCategory` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Entities.TicketComment](kamisama-modules-ticketing-entities/kamisama-modules-ticketing-entities-ticketcomment/index.md) - Provides the `TicketComment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.AddTicketCategory](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-addticketcategory/index.md) - Provides the `AddTicketCategory` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.DeleteTicketCategory](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-deleteticketcategory/index.md) - Provides the `DeleteTicketCategory` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.ExistsTicketCategoryById](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-existsticketcategorybyid/index.md) - Provides the `ExistsTicketCategoryById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.ExistsTicketCategoryByName](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-existsticketcategorybyname/index.md) - Provides the `ExistsTicketCategoryByName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.FindTicketCategoryById](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-findticketcategorybyid/index.md) - Provides the `FindTicketCategoryById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.FindTicketCategoryByName](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-findticketcategorybyname/index.md) - Provides the `FindTicketCategoryByName` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.ListTicketCategories](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-listticketcategories/index.md) - Provides the `ListTicketCategories` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Categories.UpdateTicketCategory](kamisama-modules-ticketing-features-categories/kamisama-modules-ticketing-features-categories-updateticketcategory/index.md) - Provides the `UpdateTicketCategory` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddAttachmentToTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addattachmenttoticketcomment/index.md) - Provides the `AddAttachmentToTicketComment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddCommentToTicket](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addcommenttoticket/index.md) - Provides the `AddCommentToTicket` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.AddTicket](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-addticket/index.md) - Provides the `AddTicket` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.FindTicketById](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-findticketbyid/index.md) - Provides the `FindTicketById` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.ListTickets](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-listtickets/index.md) - Provides the `ListTickets` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.RemoveAttachementFromTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-removeattachementfromticketcomment/index.md) - Provides the `RemoveAttachementFromTicketComment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketComment](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-updateticketcomment/index.md) - Provides the `UpdateTicketComment` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Features.Tickets.UpdateTicketState](kamisama-modules-ticketing-features-tickets/kamisama-modules-ticketing-features-tickets-updateticketstate/index.md) - Provides the `UpdateTicketState` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Repositories.Abstractions.ITicketCategoryRepository](kamisama-modules-ticketing-repositories-abstractions/kamisama-modules-ticketing-repositories-abstractions-iticketcategoryrepository/index.md) - Repository implementation or contract for `ITicketCategoryRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Ticketing.Repositories.Abstractions.ITicketRepository](kamisama-modules-ticketing-repositories-abstractions/kamisama-modules-ticketing-repositories-abstractions-iticketrepository/index.md) - Repository implementation or contract for `ITicketRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Ticketing.Repositories.Database.TicketingDbContext](kamisama-modules-ticketing-repositories-database/kamisama-modules-ticketing-repositories-database-ticketingdbcontext/index.md) - Provides the `TicketingDbContext` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.
- [KamiSama.Modules.Ticketing.Repositories.Implementations.TicketCategoryRepository](kamisama-modules-ticketing-repositories-implementations/kamisama-modules-ticketing-repositories-implementations-ticketcategoryrepository/index.md) - Repository implementation or contract for `TicketCategoryRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
- [KamiSama.Modules.Ticketing.Repositories.Implementations.TicketRepository](kamisama-modules-ticketing-repositories-implementations/kamisama-modules-ticketing-repositories-implementations-ticketrepository/index.md) - Repository implementation or contract for `TicketRepository`. Use it behind feature services to keep persistence access behind the KamiSama repository abstraction.
