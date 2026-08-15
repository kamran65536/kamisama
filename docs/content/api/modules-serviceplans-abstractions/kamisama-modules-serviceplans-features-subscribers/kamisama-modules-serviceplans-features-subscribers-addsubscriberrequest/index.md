# AddSubscriberRequest

<a id="addsubscriberrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L35)

Namespace: `KamiSama.Modules.ServicePlans.Features.Subscribers`

Kind: `Record`

## Description

Carries caller-supplied values for creating a subscriber. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record AddSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L35)

Carries caller-supplied values for creating a subscriber. Use it with the surrounding package APIs when composing application code.

```csharp
public record AddSubscriberRequest(Guid ExternalUserId, bool IsEnabled);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `ExternalUserId` | `Guid` | `-` | The externally managed user identifier. |
| `IsEnabled` | `bool` | `-` | Whether the new subscriber is enabled. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

