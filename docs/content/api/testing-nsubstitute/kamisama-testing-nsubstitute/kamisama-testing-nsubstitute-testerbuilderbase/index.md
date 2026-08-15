# TesterBuilderBase

<a id="testerbuilderbase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Testing.NSubstitute](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Testing.NSubstitute/TesterBuilderBase.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L11)

Namespace: `KamiSama.Testing.NSubstitute`

Kind: `Class`

## Description

Builds a target service in a DI scope and substitutes unresolved parameters from the first public constructor. Registrations accumulate, captured substitutes do not follow normal scoped or transient instance semantics, and created providers and scopes are not disposed.

## Declaration

```csharp
public class TesterBuilderBase
```

## Example

```csharp
using KamiSama.Testing.NSubstitute;
using NSubstitute;

public sealed class ProductServiceTestsBuilder : TesterBuilderBase
{
    public IProductRepository Repository { get; }

    public ProductServiceTestsBuilder()
    {
        Repository = AddScoped<IProductRepository>();
        AddOption<ProductOptions>(options => options.PageSize = 20);
    }

    public ProductService Build() => BuildService<ProductService>();
}

var builder = new ProductServiceTestsBuilder();
builder.Repository.Find(42).Returns(new Product(42, "Keyboard"));
ProductService service = builder.Build();
ILogger<ProductService> logger = builder.For<ILogger<ProductService>>();
```

## Constructors

### TesterBuilderBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Testing.NSubstitute/TesterBuilderBase.cs#L24)

Initializes an empty test builder. Use it with the surrounding package APIs when composing application code.

```csharp
protected TesterBuilderBase();
```

## Parameters

This member does not declare parameters.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddOption<TOption>](method-addoption-toption-32.md) | Adds an options configuration delegate to the service collection. The delegate runs when &lt;typeparamref name=&quot;TOption&quot;/&gt; is resolved through the options infrastructure. |
| [AddScoped<TService>](method-addscoped-tservice-43.md) | Creates one NSubstitute instance using the supplied constructor arguments and registers that same instance through a scoped factory. Use it with the surrounding package APIs when composing application code. |
| [AddSingleton<TService>](method-addsingleton-tservice-56.md) | Creates and registers one singleton NSubstitute instance. Use it with the surrounding package APIs when composing application code. |
| [AddTransient<TService>](method-addtransient-tservice-69.md) | Creates one NSubstitute instance and registers a transient factory that returns that same captured instance on every resolution. Use it with the surrounding package APIs when composing application code. |
| [BuildService<TService>](method-buildservice-tservice-91.md) | Selects the first public constructor reported by reflection, probes its parameters through a temporary provider, and registers scoped substitutes for unresolved parameter types before building the target in a new scope. Use it with the surrounding package APIs when composing application code. |
| [For<T>](method-for-t-83.md) | Resolves a required service from the most recently built final scope. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Services](property-services-16.md) | Gets the mutable service collection used for explicit registrations, generated substitutes, and target services. Use it with the surrounding package APIs when composing application code. |
| [ServiceScope](property-servicescope-20.md) | Gets the most recently created final scope. The property is uninitialized until `BuildService{TService}` succeeds and an earlier scope is not disposed when replaced. |

