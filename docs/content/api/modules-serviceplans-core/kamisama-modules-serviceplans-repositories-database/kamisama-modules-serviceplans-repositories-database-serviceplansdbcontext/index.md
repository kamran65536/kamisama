# ServicePlansDbContext

<a id="serviceplansdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/Repositories/Database/ServicePlansDbContext.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Repositories/Database/ServicePlansDbContext.cs#L10)

Namespace: `KamiSama.Modules.ServicePlans.Repositories.Database`

Kind: `Class`

## Description

Provider-neutral tracked EF Core context for plans, offers, offer restrictions, subscribers, and subscriptions. Relationships use convention-created shadow foreign keys, and a concrete keyed provider is required.

## Declaration

```csharp
public class ServicePlansDbContext : DbContext
```

## Example

```csharp
using IServiceScope scope = app.Services.CreateScope();
ServicePlansDbContext context = scope.ServiceProvider.GetRequiredService<ServicePlansDbContext>();
List<Plan> enabled = await context.Plans.AsNoTracking()
    .Where(plan => plan.IsEnabled).ToListAsync(cancellationToken);
```

## Constructors

### ServicePlansDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Repositories/Database/ServicePlansDbContext.cs#L41)

Initializes the provider-neutral context with options typed for direct base-context construction. Use it with the surrounding package APIs when composing application code.

```csharp
public ServicePlansDbContext(DbContextOptions<ServicePlansDbContext> options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<ServicePlansDbContext>` | `-` | The EF Core options for this context. |

### ServicePlansDbContext

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/Repositories/Database/ServicePlansDbContext.cs#L49)

Initializes the base context with options created for a derived provider context. Use it with the surrounding package APIs when composing application code.

```csharp
protected ServicePlansDbContext(DbContextOptions options) : base(options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions` | `-` | The non-generic EF Core options supplied by the concrete provider context. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [OfferCountries](property-offercountries-23.md) | Gets or sets the tracked offer-country restriction set; Core exposes no public management feature. |
| [OfferPaymentMethods](property-offerpaymentmethods-27.md) | Gets or sets the tracked offer payment-method set; Core exposes no public management feature. |
| [Offers](property-offers-19.md) | Gets or sets the tracked offer set; Core exposes no public offer feature service. |
| [Plans](property-plans-15.md) | Gets or sets the tracked plan set used by public Core plan features. |
| [Subscribers](property-subscribers-31.md) | Gets or sets the tracked subscriber set used by public Core subscriber features. |
| [Subscriptions](property-subscriptions-35.md) | Gets or sets the tracked subscription set used by public Core subscription features. |

