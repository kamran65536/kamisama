# ServiceType

[Back to AutoInjectTransientAttribute](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectTransientAttribute.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L16)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectTransientAttribute`

Kind: `Property`

## Description

Gets or sets the service contract used for the transient registration. When it is , the contract is inferred from the implementation type and its interfaces.

## Declaration

```csharp
public new Type? ServiceType { get => base.ServiceType; set => base.ServiceType = value; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `Type?` value. |

## Example

No concise standalone example is available yet.

