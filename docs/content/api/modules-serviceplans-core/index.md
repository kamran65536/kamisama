# KamiSama.Modules.ServicePlans.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

ASP.NET Core ServicePlans implementation with EF Core plan, offer, subscriber, and subscription entities, scoped CRUD features, modular registration, and startup initialization. Install one provider, provision the schema separately, and enforce authorization and domain validation in the host.

## How to use

```shell
dotnet add package KamiSama.Modules.ServicePlans.Core --version 10.0.0
```

**Publication mismatch:** `10.0.0` in the required install command is the current workspace/root documentation version. NuGet returned no published package or version for this package ID when reviewed.

Install Core plus the selected provider package. Configure a database section with `provider` and `connection-string`, pass a callback that registers `postgresql` through `AddPostgresqlServicePlansDbContext` or `sqlite` through `AddSqliteServicePlansDbContext`, and finish setup through `BuildAsync`:

```csharp
using KamiSama.Modules;
using KamiSama.Modules.ServicePlans;

IConfigurationSection servicePlans = webBuilder.Configuration.GetSection("ServicePlans");
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddServicePlansModule(
        servicePlans,
        servicePlans.GetSection("database"),
        database => database.AddPostgresqlServicePlansDbContext());
WebApplication app = await builder.BuildAsync(cancellationToken);
```

The nullable provider callback is required in normal setup unless the host separately registers the exact configured keyed `ServicePlansDbContext`. During `BuildAsync`, Core binds the empty `ServicePlansOptions`, named connection and initialization options, scans Core for attributed scoped repositories and features, and selects `__EFMigrationsHistory_ServicePlans`. After build it resolves a custom `IDatabaseInitializer<ServicePlansDbContext>` or a migration-only default and executes the enabled `migrate`, `initialize`, and `test-data` stages. The default seed stages are no-ops.

**Schema limitation:** neither current provider package contains ServicePlans migrations. Enabling `migrate` therefore cannot create these tables from this checkout; provision a compatible schema or supply migrations/custom initialization before using the repositories. Core exposes tracked plan, offer, offer-country, offer-payment-method, subscriber, and subscription entities, but public feature services cover only plans, subscribers, and subscriptions. No public offer CRUD exists.

All current attributed ServicePlans features and repositories are assignable to their declared service contracts. Plan names and subscriber external-user identifiers use case-sensitive or case-normalized read-before-write duplicate checks without model-level unique indexes, so concurrent writes can create duplicates. Mutations save immediately without a feature-level transaction. Searches use translated lowercase equality for plan names, recognize only documented source tokens, and return tracked entities before DTO conversion.

**Security and correctness limitations:** Core maps no controllers, endpoints, middleware, authentication, or authorization. It does not validate positive rates or allowances, date ordering, duration consistency, enum validity, status transitions, subscriber enabled state, plan enabled state, or ownership of supplied subscriber identifiers. Subscription add/update accepts caller-selected usage balances and can reassign both subscriber and plan. Add endpoint authorization and domain validation before exposing these features.

## Namespaces

- [KamiSama.Modules.ServicePlans](kamisama-modules-serviceplans/index.md) (3 types)
- [KamiSama.Modules.ServicePlans.Entities](kamisama-modules-serviceplans-entities/index.md) (6 types)
- [KamiSama.Modules.ServicePlans.Repositories.Database](kamisama-modules-serviceplans-repositories-database/index.md) (1 types)

## Types

- [KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions](kamisama-modules-serviceplans/kamisama-modules-serviceplans-extendedwebapplicationbuilderextensions/index.md) - Adds ServicePlans registration and post-build initialization to an extended builder. A matching provider callback is required in normal setup, and `BuildAsync` cannot provision the module schema from current provider packages.
- [KamiSama.Modules.ServicePlans.ServicePlansOptions](kamisama-modules-serviceplans/kamisama-modules-serviceplans-serviceplansoptions/index.md) - Represents the currently empty object bound from the ServicePlans `options` section. Database and initialization settings use separate repository option types.
- [KamiSama.Modules.ServicePlans.ServicePlansWebModule](kamisama-modules-serviceplans/kamisama-modules-serviceplans-serviceplanswebmodule/index.md) - Registers ServicePlans options, assignable scoped features and repositories, keyed provider setup, and named post-build initialization. It maps no transport or security layer, and current providers contain no ServicePlans migrations.
- [KamiSama.Modules.ServicePlans.Entities.Offer](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-offer/index.md) - Represents an acquisition offer for a subscription plan. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Entities.OfferCountry](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-offercountry/index.md) - Represents a country in which a subscription offer may be acquired. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Entities.OfferPaymentMethod](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-offerpaymentmethod/index.md) - Represents a payment method accepted by a subscription offer. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Entities.Plan](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-plan/index.md) - Represents a reusable subscription definition. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Entities.Subscriber](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-subscriber/index.md) - Represents a subscriber linked to an externally managed user. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Entities.Subscription](kamisama-modules-serviceplans-entities/kamisama-modules-serviceplans-entities-subscription/index.md) - Represents a subscriber&apos;s acquired plan and remaining usage balance. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.ServicePlans.Repositories.Database.ServicePlansDbContext](kamisama-modules-serviceplans-repositories-database/kamisama-modules-serviceplans-repositories-database-serviceplansdbcontext/index.md) - Provider-neutral tracked EF Core context for plans, offers, offer restrictions, subscribers, and subscriptions. Relationships use convention-created shadow foreign keys, and a concrete keyed provider is required.
