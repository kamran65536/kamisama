# UpdateSubscriberRequest

<a id="updatesubscriberrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L41)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Record`

## Description

Carries replacement values for an existing subscriber. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record UpdateSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L41)

Carries replacement values for an existing subscriber. Use it with the surrounding package APIs when composing application code.

```csharp
public record UpdateSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `ExternalUserId` | `Guid` | `-` | The replacement externally managed user identifier. |
| `IsEnabled` | `bool` | `-` | Whether the subscriber is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

