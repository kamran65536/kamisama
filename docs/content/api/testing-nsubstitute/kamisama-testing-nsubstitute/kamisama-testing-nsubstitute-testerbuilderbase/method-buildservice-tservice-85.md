# BuildService<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:85](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L85)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Builds the dependency for service, if a dependency is not present, it will be mocked automatically. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService BuildService<TService>()
    where TService : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TService` |  |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `TService` | Returns a `TService` value. |

## Example

No concise standalone example is available yet.

