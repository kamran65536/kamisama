# AutoInjectTransientAttribute

<a id="autoinjecttransientattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectTransientAttribute.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L9)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.

## Declaration

```csharp
public class AutoInjectTransientAttribute : AutoInjectAttributeBase
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectTransient(typeof(IMessageFactory))]
public sealed class MessageFactory : IMessageFactory;
```

## Constructors

### AutoInjectTransientAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L23)

Initializes a transient registration attribute with an optional explicit service contract. Passing enables service-type inference during assembly scanning.

```csharp
public AutoInjectTransientAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The service contract to register, or to infer it. |

### AutoInjectTransientAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L32)

Initializes a transient registration attribute that infers its service contract during assembly scanning. The container creates a new implementation whenever the service is requested.

```csharp
public AutoInjectTransientAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-16.md) | Gets or sets the service contract used for the transient registration. When it is , the contract is inferred from the implementation type and its interfaces. |

