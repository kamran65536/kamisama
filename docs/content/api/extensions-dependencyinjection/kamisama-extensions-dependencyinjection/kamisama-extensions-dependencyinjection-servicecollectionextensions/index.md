# ServiceCollectionExtensions

<a id="servicecollectionextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/ServiceCollectionExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/ServiceCollectionExtensions.cs#L9)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Assembly-scanning extensions for registering implementations decorated with `AutoInjectAttributeBase`. Scan explicit assemblies or use marker types to select one or two assemblies.

## Declaration

```csharp
public static class ServiceCollectionExtensions
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;

var services = new ServiceCollection();
services.AutoAddDependenciesFrom<Program>();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AutoAddDependencies](method-autoadddependencies-18.md) | Scans the selected assemblies and applies every `AutoInjectAttributeBase` found on their declared types. When no assemblies are supplied, all assemblies currently loaded in the application domain are scanned. |
| [AutoAddDependenciesFrom<TAssemblyType>](method-autoadddependenciesfrom-tassemblytype-44.md) | Scans the assembly containing &lt;typeparamref name=&quot;TAssemblyType&quot;/&gt; and applies automatic injection attributes. Use a marker type from the assembly whose attributed implementations should be registered. |
| [AutoAddDependenciesFrom<TAssemblyType1, TAssemblyType2>](method-autoadddependenciesfrom-tassemblytype1-tassemblytype2-54.md) | Scans the assemblies containing both marker types and applies automatic injection attributes from each assembly. Use this overload when attributed implementations are split across two known assemblies. |

