# Lifetime

[Back to AutoInjectAttributeBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L21)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttributeBase`

Kind: `Property`

## Description

Service Lifetime (default is Transient). Use it with the surrounding package APIs when composing application code.

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

