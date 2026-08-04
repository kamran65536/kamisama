# AutoInjectTransientAttribute<TService>

<a id="autoinjecttransientattribute-tservice"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectTransientAttribute.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L30)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.

## Declaration

```csharp
public class AutoInjectTransientAttribute<TService>() : AutoInjectTransientAttribute(typeof(TService));
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectTransient<IMessageFactory>]
public sealed class MessageFactory : IMessageFactory;
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L30)

AutoInject Transient Attribute with generic service type. Use it with the surrounding package APIs when composing application code.

```csharp
public class AutoInjectTransientAttribute<TService>() : AutoInjectTransientAttribute(typeof(TService));
```

## Parameters

This member does not declare parameters.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

