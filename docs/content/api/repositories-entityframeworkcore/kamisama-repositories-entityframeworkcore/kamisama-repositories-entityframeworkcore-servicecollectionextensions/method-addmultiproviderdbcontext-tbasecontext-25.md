# AddMultiProviderDbContext<TBaseContext>

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs#L25)

Type: `KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions`

Kind: `Method`

## Description

Binds database settings and adds scoped resolution of a base DbContext through a configured keyed provider. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<TBaseContext> AddMultiProviderDbContext<TBaseContext>(this IServiceCollection services, IConfigurationSection section)
    where TBaseContext : DbContext;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TBaseContext` | The base DbContext type consumed by application code. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services (extension receiver)` | `IServiceCollection` | `-` | The service collection. |
| `section` | `IConfigurationSection` | `-` | The section containing the `provider` and `connection-string` keys. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<TBaseContext>` | A builder used to set the migration-history table and register one or more concrete provider contexts. |

## Remarks

The configured provider is lowercased for keyed resolution. The installed provider extension must register that exact key. Both the base-context alias and provider contexts are scoped.

## Example

```csharp
IMultiProviderDbContextBuilder<AppDbContext> builder = services
    .AddMultiProviderDbContext<AppDbContext>(configuration.GetSection("Database"));
```

