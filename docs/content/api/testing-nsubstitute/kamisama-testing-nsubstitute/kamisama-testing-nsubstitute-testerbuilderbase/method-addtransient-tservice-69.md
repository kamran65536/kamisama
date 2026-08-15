# AddTransient<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:69](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L69)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Creates one NSubstitute instance and registers a transient factory that returns that same captured instance on every resolution. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService AddTransient<TService>()
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
| `TService` | The substitute captured by the transient registration. |

## Example

```csharp
IProductValidator validator = builder.AddTransient<IProductValidator>();
// Every resolution returns this same captured substitute.
```

