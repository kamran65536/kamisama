# ExactPolicyListItem

<a id="exactpolicylistitem"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Entities/ExactPolicyListItem.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Entities/ExactPolicyListItem.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Entities`

Kind: `Class`

## Description

Represents an exact serialized value contained by a policy list. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ExactPolicyListItem : PolicyListItem
```

## Example

```csharp
list.Items.Add(new ExactPolicyListItem
{
    PolicyList = list, Value = "203.0.113.10", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Value](property-value-11.md) | Gets or sets the opaque serialized value matched exactly by a separately implemented evaluator. Use it with the surrounding package APIs when composing application code. |

