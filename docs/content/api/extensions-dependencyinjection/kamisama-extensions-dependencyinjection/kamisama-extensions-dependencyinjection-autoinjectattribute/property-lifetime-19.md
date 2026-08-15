# Lifetime

[Back to AutoInjectAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttribute.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttribute.cs#L19)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttribute`

Kind: `Property`

## Description

Gets or sets the lifetime of the generated service registration. The default lifetime is `ServiceLifetime.Transient`.

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

