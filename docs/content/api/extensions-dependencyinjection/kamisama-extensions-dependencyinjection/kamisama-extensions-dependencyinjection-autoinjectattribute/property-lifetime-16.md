# Lifetime

[Back to AutoInjectAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttribute.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttribute.cs#L16)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttribute`

Kind: `Property`

## Description

Service Lifetime (default is Transient). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public new ServiceLifetime Lifetime { get => base.Lifetime; set => base.Lifetime = value; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `ServiceLifetime` value. |

## Example

No concise standalone example is available yet.

