# AddSingleton<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:56](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L56)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Creates and registers one singleton NSubstitute instance. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService AddSingleton<TService>()
    where TService : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TService` | The substitutable class or interface to register. |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `TService` | The registered singleton substitute. |

## Example

```csharp
ISystemClock clock = builder.AddSingleton<ISystemClock>();
```

