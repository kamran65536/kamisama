# AutoInjectAttributeBase

<a id="autoinjectattributebase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L8)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Base attribute for convention-based dependency injection registration. Derived attributes use it to register the decorated type against an explicit or inferred service type.

## Declaration

```csharp
public abstract class AutoInjectAttributeBase : Attribute
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyInjection](method-applyinjection-32.md) | Add binding to the service. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [AllowMultiple](property-allowmultiple-25.md) | Gets or sets a value indicating whether multiple instances of the associated attribute are allowed. Use it with the surrounding package APIs when composing application code. |
| [Lifetime](property-lifetime-21.md) | Service Lifetime (default is Transient). Use it with the surrounding package APIs when composing application code. |
| [ServiceKey](property-servicekey-13.md) | if present, adds the service as keyed and you should use it by `ServiceProviderKeyedServiceExtensions.GetKeyedServices` methods. Use it with the surrounding package APIs when composing application code. |
| [ServiceType](property-servicetype-17.md) | Service Type, it null the. Use it with the surrounding package APIs when composing application code. |

