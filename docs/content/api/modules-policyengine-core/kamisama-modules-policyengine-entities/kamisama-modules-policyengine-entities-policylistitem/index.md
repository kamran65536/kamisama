# PolicyListItem

<a id="policylistitem"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyListItem.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/PolicyListItem.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents a polymorphic value entry contained by a policy list. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract class PolicyListItem
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [CreatedAt](property-createdat-21.md) | Gets or sets the item&apos;s UTC creation timestamp. Use it with the surrounding package APIs when composing application code. |
| [Id](property-id-11.md) | Gets or sets the persisted item identifier. Use it with the surrounding package APIs when composing application code. |
| [PolicyList](property-policylist-16.md) | Gets or sets the required parent policy list. Use it with the surrounding package APIs when composing application code. |
| [UpdatedAt](property-updatedat-26.md) | Gets or sets the item&apos;s UTC last-update timestamp. Use it with the surrounding package APIs when composing application code. |

