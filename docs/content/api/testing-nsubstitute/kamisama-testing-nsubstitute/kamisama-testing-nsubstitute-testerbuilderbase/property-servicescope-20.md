# ServiceScope

[Back to TesterBuilderBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L20)

Type: `KamiSama.Testing.NSubstitute.TesterBuilderBase`

Kind: `Property`

## Description

Gets the most recently created final scope. The property is uninitialized until `BuildService{TService}` succeeds and an earlier scope is not disposed when replaced.

## Declaration

```csharp
public IServiceScope ServiceScope { get; private set; } = default !;
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `IServiceScope` value. |

## Example

```csharp
ProductService service = builder.Build();
IServiceProvider scopedServices = builder.ServiceScope.ServiceProvider;
```

