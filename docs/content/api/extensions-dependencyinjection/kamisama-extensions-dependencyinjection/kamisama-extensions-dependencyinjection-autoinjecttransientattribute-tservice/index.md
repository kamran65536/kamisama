# AutoInjectTransientAttribute<TService>

<a id="autoinjecttransientattribute-tservice"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectTransientAttribute.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L41)

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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectTransientAttribute.cs#L41)

Marks an implementation for automatic transient registration under &lt;typeparamref name=&quot;TService&quot;/&gt;. The generic argument supplies the service contract without a `Type` constructor argument.

```csharp
public class AutoInjectTransientAttribute<TService>() : AutoInjectTransientAttribute(typeof(TService));
```

## Parameters

This member does not declare parameters.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

