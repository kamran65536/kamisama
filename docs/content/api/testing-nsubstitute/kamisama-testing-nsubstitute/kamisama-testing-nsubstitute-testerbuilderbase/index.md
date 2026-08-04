# TesterBuilderBase

<a id="testerbuilderbase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L10)

Namespace: `KamiSama.Testing.NSubstitute`

Kind: `Class`

## Description

DI-first testing helper that builds services and creates NSubstitute mocks for missing dependencies. Derive a small test builder from it to keep unit tests focused on the service under test.

## Declaration

```csharp
public class TesterBuilderBase
```

## Example

```csharp
using KamiSama.Testing.NSubstitute;

public sealed class ProductServiceTestsBuilder : TesterBuilderBase
{
    public ProductService Build() => BuildService<ProductService>();
}
```

## Constructors

### TesterBuilderBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L21)

Initializes a new `TesterBuilderBase` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected TesterBuilderBase();
```

## Parameters

This member does not declare parameters.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddOption<TOption>](method-addoption-toption-27.md) | Configures an Option in the builder. Use it with the surrounding package APIs when composing application code. |
| [AddScoped<TService>](method-addscoped-tservice-38.md) | Adds a scoped service with parameters. Use it with the surrounding package APIs when composing application code. |
| [AddSingleton<TService>](method-addsingleton-tservice-51.md) | Runs the `AddSingleton<TService>` operation on `TesterBuilderBase`. Use it when your code needs this specific behavior from the package. |
| [AddTransient<TService>](method-addtransient-tservice-64.md) | Runs the `AddTransient<TService>` operation on `TesterBuilderBase`. Use it when your code needs this specific behavior from the package. |
| [BuildService<TService>](method-buildservice-tservice-85.md) | Builds the dependency for service, if a dependency is not present, it will be mocked automatically. Use it with the surrounding package APIs when composing application code. |
| [For<T>](method-for-t-78.md) | returns a dependency based object call this method after `BuildService{TService}` method. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Services](property-services-15.md) | internal service collection to use. Use it with the surrounding package APIs when composing application code. |
| [ServiceScope](property-servicescope-19.md) | service scope in which services are added. Use it with the surrounding package APIs when composing application code. |

