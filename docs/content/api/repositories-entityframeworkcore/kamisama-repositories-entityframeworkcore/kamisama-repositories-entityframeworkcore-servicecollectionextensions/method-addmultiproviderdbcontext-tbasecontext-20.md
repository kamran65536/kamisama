# AddMultiProviderDbContext<TBaseContext>

[Back to ServiceCollectionExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/ServiceCollectionExtensions.cs#L20)

Type: `KamiSama.Repositories.EntityFrameworkCore.ServiceCollectionExtensions`

Kind: `Method`

## Description

Adds provider-neutral keyed DbContext resolution for a configured database provider. Use it with the surrounding package APIs when composing application code.

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
| `section` | `IConfigurationSection` | `-` | The configuration section containing provider and connection string values. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<TBaseContext>` | A builder that provider packages can extend. |

## Example

No concise standalone example is available yet.

