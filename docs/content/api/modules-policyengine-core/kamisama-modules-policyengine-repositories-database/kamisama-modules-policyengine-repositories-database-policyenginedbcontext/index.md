# PolicyEngineDbContext

<a id="policyenginedbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/Repositories/Database/PolicyEngineDbContext.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Repositories/Database/PolicyEngineDbContext.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Repositories.Database`

Kind: `Class`

## Description

Provider-neutral tracked EF Core context for action, rule, assignment, list, and polymorphic item entities. A concrete keyed provider is required, and current provider packages contain no migrations to provision its schema.

## Declaration

```csharp
public class PolicyEngineDbContext : DbContext
```

## Remarks

A PostgreSQL or SQLite derived context must be registered for normal module resolution. The current provider packages contain no migrations, so this context model alone does not provision a database schema.

## Example

```csharp
using IServiceScope scope = app.Services.CreateScope();
PolicyEngineDbContext context = scope.ServiceProvider.GetRequiredService<PolicyEngineDbContext>();
List<PolicyRule> enabled = await context.PolicyRules.AsNoTracking()
    .Where(rule => rule.IsEnabled).OrderBy(rule => rule.ProcessOrder).ToListAsync(cancellationToken);
```

## Constructors

### PolicyEngineDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Repositories/Database/PolicyEngineDbContext.cs#L40)

Initializes a directly configured provider-neutral context. Use it with the surrounding package APIs when composing application code.

```csharp
public PolicyEngineDbContext(DbContextOptions<PolicyEngineDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PolicyEngineDbContext>` | `-` | The options configured specifically for `PolicyEngineDbContext`. |

### PolicyEngineDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/Repositories/Database/PolicyEngineDbContext.cs#L48)

Initializes a derived provider context with its provider-specific options. Use it with the surrounding package APIs when composing application code.

```csharp
protected PolicyEngineDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The non-generic options created for the derived context. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [PolicyActions](property-policyactions-18.md) | Gets or sets the tracked reusable policy-action definition set used by Core repositories. |
| [PolicyListItems](property-policylistitems-34.md) | Gets or sets the tracked polymorphic exact/range item set; no public Core feature manages it. |
| [PolicyLists](property-policylists-30.md) | Gets or sets the tracked typed policy-list definition set used by Core repositories. |
| [PolicyRuleActions](property-policyruleactions-26.md) | Gets or sets the tracked rule-to-action assignment set; no public Core feature manages it. |
| [PolicyRules](property-policyrules-22.md) | Gets or sets the tracked ordered policy-rule definition set used by Core repositories. |

