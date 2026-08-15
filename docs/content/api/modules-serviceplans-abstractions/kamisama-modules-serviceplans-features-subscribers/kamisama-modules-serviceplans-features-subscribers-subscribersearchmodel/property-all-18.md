# All

[Back to SubscriberSearchModel](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Subscribers/Dtos.cs#L18)

Type: `KamiSama.Modules.ServicePlans.Features.Subscribers.SubscriberSearchModel`

Kind: `Property`

## Description

Gets or sets the shared search model requesting all subscribers without filters. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static new SubscriberSearchModel All { get; set; } = new(default, default, default, default, default);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | A mutable all-records search model; replacing it affects every caller that reads this property. |

## Example

No concise standalone example is available yet.

