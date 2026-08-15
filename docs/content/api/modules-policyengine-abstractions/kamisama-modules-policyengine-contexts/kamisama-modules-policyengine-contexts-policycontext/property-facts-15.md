# Facts

[Back to PolicyContext](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs#L15)

Type: `KamiSama.Modules.PolicyEngine.Contexts.PolicyContext`

Kind: `Property`

## Description

Gets the flat collection of typed facts available to policy evaluation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public IDictionary<string, object> Facts { get; } = new Dictionary<string, object>(StringComparer.Ordinal);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `IDictionary<string, object>` value. |

## Remarks

Fact keys are opaque strings, so dots have no path or nesting semantics. An absent key represents a fact that policy evaluation may treat as undefined.

## Example

No concise standalone example is available yet.

