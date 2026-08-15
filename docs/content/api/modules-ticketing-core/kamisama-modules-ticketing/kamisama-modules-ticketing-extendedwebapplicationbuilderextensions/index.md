# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Ticketing.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Ticketing.Core/TicketingModule.cs#L70)

Namespace: `KamiSama.Modules.Ticketing`

Kind: `Class`

## Description

Adds Ticketing service discovery, multi-provider context setup, and named database initialization to an extended builder. A matching provider callback is required in normal hosts; the module maps no controllers or endpoints.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddTicketingModule](method-addticketingmodule-81.md) | Queues Ticketing service discovery, keyed context setup, and post-build database initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because three current category-feature registrations are non-assignable. |

