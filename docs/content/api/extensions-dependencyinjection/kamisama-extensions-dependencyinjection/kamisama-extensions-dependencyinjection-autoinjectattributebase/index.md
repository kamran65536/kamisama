# AutoInjectAttributeBase

<a id="autoinjectattributebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L9)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Base attribute for convention-based dependency injection registration. Derived attributes use it to register the decorated type against an explicit or inferred service type.

## Declaration

```csharp
public abstract class AutoInjectAttributeBase : Attribute
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

public sealed class AutoInjectPerRequestAttribute : AutoInjectAttributeBase
{
    public AutoInjectPerRequestAttribute(Type serviceType)
    {
        ServiceType = serviceType;
        Lifetime = ServiceLifetime.Scoped;
    }
}

[AutoInjectPerRequest(typeof(IProductService))]
public sealed class ProductService : IProductService;
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyInjection](method-applyinjection-38.md) | Registers the implementation using the configured service type, lifetime, key, and multiple-registration policy. If no service type is configured, the method uses the implementation itself, its sole interface, or throws when multiple interfaces make inference ambiguous. |

### Properties

| Member | Description |
| --- | --- |
| [AllowMultiple](property-allowmultiple-30.md) | Gets or sets whether the registration is always appended instead of added only when the service contract and key are absent. Set it to when multiple implementations of the same service must be resolvable. |
| [Lifetime](property-lifetime-25.md) | Gets or sets the lifetime used by the generated service registration. The default lifetime is `ServiceLifetime.Transient`. |
| [ServiceKey](property-servicekey-15.md) | Gets or sets the key used to create a keyed service registration. A value creates an ordinary unkeyed registration. |
| [ServiceType](property-servicetype-20.md) | Gets or sets the service contract used for registration by a derived attribute. When it is , the contract is inferred from the implementation type and its interfaces. |

