# For<T>

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:83](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L83)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Method`

## Description

Resolves a required service from the most recently built final scope. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public T For<T>()
    where T : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` | The registered reference type to resolve. |

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `T` | The service resolved from `ServiceScope`. |

## Remarks

Call this method only after `BuildService{TService}` succeeds; otherwise no usable scope exists.

## Example

```csharp
ProductService service = builder.Build();
ILogger<ProductService> logger = builder.For<ILogger<ProductService>>();
```

