# AddPolicyEngineModule

[Back to PolicyEngineExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/PolicyEngineWebModule.cs:66](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/PolicyEngineWebModule.cs#L66)

Type: `KamiSama.Modules.PolicyEngine.PolicyEngineExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Queues PolicyEngine option binding, attributed CRUD registration, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because six current list/delete feature registrations are non-assignable.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddPolicyEngineModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, Action<IMultiProviderDbContextBuilder<PolicyEngineDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder that queues the module. |
| `moduleSection` | `IConfigurationSection` | `-` | The PolicyEngine section containing the named `initialization` subsection. |
| `databaseSection` | `IConfigurationSection` | `-` | The section containing `provider` and `connection-string` values. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<PolicyEngineDbContext>>?` | `null` | A callback that should register the concrete provider matching the configured provider key. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same extended builder so additional modules can be chained. |

## Remarks

The callback is nullable but is required in a normal host unless the matching keyed `PolicyEngineDbContext` is registered elsewhere. This module does not add a policy evaluator, controllers, endpoints, authentication, or authorization. The current Core assembly also contains six non-assignable list/delete feature registrations that can fail service-provider validation.

## Example

No concise standalone example is available yet.

