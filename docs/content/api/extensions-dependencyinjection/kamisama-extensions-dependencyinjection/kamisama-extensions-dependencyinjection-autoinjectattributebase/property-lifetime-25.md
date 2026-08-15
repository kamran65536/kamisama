# Lifetime

[Back to AutoInjectAttributeBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L25)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttributeBase`

Kind: `Property`

## Description

Gets or sets the lifetime used by the generated service registration. The default lifetime is `ServiceLifetime.Transient`.

## Declaration

```csharp
protected ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `ServiceLifetime` value. |

## Example

No concise standalone example is available yet.

