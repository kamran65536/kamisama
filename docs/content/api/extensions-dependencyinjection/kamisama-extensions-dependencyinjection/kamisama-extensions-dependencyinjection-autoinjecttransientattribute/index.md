# AutoInjectTransientAttribute

<a id="autoinjecttransientattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectTransientAttribute.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L8)

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

[AutoInjectTransient<IMessageFactory>]
public sealed class MessageFactory : IMessageFactory;
```

## Constructors

### AutoInjectTransientAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L17)

Initializes a new `AutoInjectTransientAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectTransientAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The `serviceType` value passed to this member. |

### AutoInjectTransientAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L23)

Initializes a new `AutoInjectTransientAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectTransientAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-14.md) | Exposes the `ServiceType` value on `AutoInjectTransientAttribute`. Read or set it as part of configuring or using the type. |

