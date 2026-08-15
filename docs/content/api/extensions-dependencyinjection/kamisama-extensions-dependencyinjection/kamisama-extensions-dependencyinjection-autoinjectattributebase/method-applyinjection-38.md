# ApplyInjection

[Back to AutoInjectAttributeBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md)

Source: [src/DependencyInjection/AutoInjectAttributeBase.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttributeBase.cs#L38)

Type: `KamiSama.Extensions.DependencyInjection.AutoInjectAttributeBase`

Kind: `Method`

## Description

Registers the implementation using the configured service type, lifetime, key, and multiple-registration policy. If no service type is configured, the method uses the implementation itself, its sole interface, or throws when multiple interfaces make inference ambiguous.

## Declaration

```csharp
public virtual void ApplyInjection(IServiceCollection services, Type type);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The service collection that receives the generated registration. |
| `type` | `Type` | `-` | The attributed implementation type to register. |

## Example

No concise standalone example is available yet.

