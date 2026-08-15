# KamiSama.Testing.NSubstitute

[Back to package index](../index.md)

Version: `10.0.0`

## Description

A DI-first test builder that registers configured substitutes and creates NSubstitute doubles for missing constructor dependencies. Use it to build focused service tests through a scoped Microsoft.Extensions.DependencyInjection container.

## How to use

```shell
dotnet add package KamiSama.Testing.NSubstitute --version 10.0.0
```

Derive a scenario-specific builder, expose configured substitutes, build the target once, and resolve generated dependencies from the resulting scope:

```csharp
using KamiSama.Testing.NSubstitute;
using NSubstitute;

public sealed class ProductServiceTestsBuilder : TesterBuilderBase
{
    public IProductRepository Repository { get; };

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

`BuildService<TService>` inspects only the first public constructor returned by reflection and substitutes only unresolved parameters from that constructor. NSubstitute still requires proxyable interfaces or classes with overridable members. `AddScoped` and `AddTransient` capture one substitute, so their registrations do not create fresh doubles per scope or resolution. Registrations accumulate across builds. The builder does not dispose its temporary providers or scopes, its final provider, replaced scopes, or scoped/transient disposables; keep builders short-lived and do not use this helper when disposal verification matters. Call `For<T>` only after a successful build.

## Namespaces

- [KamiSama.Testing.NSubstitute](kamisama-testing-nsubstitute/index.md) (1 types)

## Types

- [KamiSama.Testing.NSubstitute.TesterBuilderBase](kamisama-testing-nsubstitute/kamisama-testing-nsubstitute-testerbuilderbase/index.md) - Builds a target service in a DI scope and substitutes unresolved parameters from the first public constructor. Registrations accumulate, captured substitutes do not follow normal scoped or transient instance semantics, and created providers and scopes are not disposed.
