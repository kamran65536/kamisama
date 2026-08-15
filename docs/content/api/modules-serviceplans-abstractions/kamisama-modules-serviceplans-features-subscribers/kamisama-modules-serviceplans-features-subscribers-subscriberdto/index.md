# SubscriberDto

<a id="subscriberdto"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs:29](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L29)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Record`

## Description

Returns a subscriber linked to an externally managed user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record SubscriberDto(Guid Id, Guid ExternalUserId, bool IsEnabled, DateTime CreatedAt, DateTime UpdatedAt);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L29)

Returns a subscriber linked to an externally managed user. Use it with the surrounding package APIs when composing application code.

```csharp
public record SubscriberDto(Guid Id, Guid ExternalUserId, bool IsEnabled, DateTime CreatedAt, DateTime UpdatedAt);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The subscriber identifier. |
| `ExternalUserId` | `Guid` | `-` | The externally managed user identifier. |
| `IsEnabled` | `bool` | `-` | Whether the subscriber is enabled. |
| `CreatedAt` | `DateTime` | `-` | The creation timestamp. |
| `UpdatedAt` | `DateTime` | `-` | The last update timestamp. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

