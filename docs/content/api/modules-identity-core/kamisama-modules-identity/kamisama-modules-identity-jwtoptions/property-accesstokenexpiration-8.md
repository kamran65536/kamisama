# AccessTokenExpiration

[Back to JwtOptions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/JwtOptions.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/JwtOptions.cs#L8)

Type: `KamiSama.Modules.Identity.JwtOptions`

Kind: `Property`

## Description

Exposes the `AccessTokenExpiration` value on `JwtOptions`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public required TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromMinutes(1);
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `TimeSpan` value. |

## Example

No concise standalone example is available yet.

