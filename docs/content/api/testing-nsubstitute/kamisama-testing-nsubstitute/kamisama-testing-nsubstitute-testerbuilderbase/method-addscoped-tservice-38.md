# AddScoped<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L38)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Adds a scoped service with parameters. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService AddScoped<TService>(params object[] param)
    where TService : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TService` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `param` | `object[]` | `-` | The `param` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `TService` | Returns a `TService` value. |

## Example

No concise standalone example is available yet.

