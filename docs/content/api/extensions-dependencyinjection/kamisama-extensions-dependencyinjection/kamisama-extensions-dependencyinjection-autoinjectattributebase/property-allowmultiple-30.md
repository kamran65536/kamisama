# AllowMultiple

[Back to AutoInjectAttributeBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L30)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttributeBase`

Kind: `Property`

## Description

Gets or sets whether the registration is always appended instead of added only when the service contract and key are absent. Set it to when multiple implementations of the same service must be resolvable.

## Declaration

```csharp
public bool AllowMultiple { get; set; } = false;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `bool` value. |

## Example

No concise standalone example is available yet.

