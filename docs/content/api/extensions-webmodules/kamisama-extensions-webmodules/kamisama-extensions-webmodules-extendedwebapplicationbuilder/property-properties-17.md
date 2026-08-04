# Properties

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L17)

Type: `KamiSama.Extensions.WebModules.ExtendedWebApplicationBuilder`

Kind: `Property`

## Description

Exposes the `Properties` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public IDictionary<object, object> Properties => (internalBuilder as IHostApplicationBuilder).Properties;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `IDictionary<object, object>` value. |

## Example

No concise standalone example is available yet.

