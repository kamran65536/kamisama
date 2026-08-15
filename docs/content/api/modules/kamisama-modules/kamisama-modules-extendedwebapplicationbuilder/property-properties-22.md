# Properties

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L22)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Property`

## Description

Gets the shared host-builder property dictionary from the underlying builder. Use it with the surrounding package APIs when composing application code.

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

