# RangePolicyListItem

<a id="rangepolicylistitem"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/RangePolicyListItem.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/RangePolicyListItem.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents an inclusive serialized value range contained by a policy list. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class RangePolicyListItem : PolicyListItem
```

## Example

```csharp
list.Items.Add(new RangePolicyListItem
{
    PolicyList = list, From = "203.0.113.1", To = "203.0.113.254",
    CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [From](property-from-11.md) | Gets or sets the opaque serialized inclusive lower bound. Use it with the surrounding package APIs when composing application code. |
| [To](property-to-16.md) | Gets or sets the opaque serialized inclusive upper bound. Use it with the surrounding package APIs when composing application code. |

