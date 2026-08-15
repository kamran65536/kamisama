# AddScoped<TService>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L43)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Creates one NSubstitute instance using the supplied constructor arguments and registers that same instance through a scoped factory. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public TService AddScoped<TService>(params object[] param)
    where TService : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TService` | The substitutable class or interface to register. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `param` | `object[]` | `-` | Constructor arguments passed to NSubstitute when substituting for a class. |

## Returns

| Type | Description |
| --- | --- |
| `TService` | The substitute captured by the scoped registration. |

## Example

```csharp
IProductRepository repository = builder.AddScoped<IProductRepository>();
```

