# KamiSama.Modules.PolicyEngine.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

EF Core data management for policy actions, rules, lists, and their relationships, with scoped CRUD features and modular startup registration. Install one provider, provision the schema separately, and supply evaluation and authorization in the host.

## How to use

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Core --version 10.0.0
```

**Publication mismatch:** `10.0.0` is the current workspace/root documentation version and remains the required repository install command. NuGet returned no published package or version for this package ID when reviewed.

Call `AddPolicyEngineModule(moduleSection, databaseSection, providerCallback)` on an `ExtendedWebApplicationBuilder`, select `postgresql` with `AddPostgresqlPolicyEngineDbContext` or `sqlite` with `AddSqlitePolicyEngineDbContext`, and then call `BuildAsync`. The callback is nullable but required in normal setup unless the host separately registers the exact configured keyed `PolicyEngineDbContext`. Service registration binds the empty `PolicyEngineOptions`, named initialization options, attributed repositories and features, and `__EFMigrationsHistory_PolicyEngine`; post-build setup resolves a custom initializer or the migration-only default.

This package manages policy-action, policy-rule, rule/action-assignment, policy-list, and polymorphic exact/range item entities. Public CRUD contracts cover only action, rule, and list definitions; there is no list-item or rule/action-assignment feature API, and returned list DTOs omit those relationships. There is no policy evaluator, condition parser, action execution, controller, endpoint, authentication, or authorization integration.

**Runtime defects:** the attributed `ListPolicyActions`, `DeletePolicyAction`, `ListPolicyLists`, `DeletePolicyList`, `ListPolicyRules`, and `DeletePolicyRule` classes do not implement their declared service interfaces. Service-provider validation can fail during `BuildAsync`; without validation, resolving those six contracts fails. Name uniqueness uses a case-insensitive read-before-write check with no model-level unique index, and mutations save immediately without a feature-level transaction. Provider packages contain no migrations, so the default migration stage cannot provision PolicyEngine tables; provision a compatible schema separately or supply migrations/custom initialization before using the repositories. Protect every exposed operation with host authentication and authorization.

## Namespaces

- [KamiSama.Modules.PolicyEngine](kamisama-modules-policyengine/index.md) (2 types)
- [KamiSama.Modules.PolicyEngine.Entities](kamisama-modules-policyengine-entities/index.md) (7 types)
- [KamiSama.Modules.PolicyEngine.Repositories.Database](kamisama-modules-policyengine-repositories-database/index.md) (1 types)

## Types

- [KamiSama.Modules.PolicyEngine.PolicyEngineExtendedWebApplicationBuilderExtensions](kamisama-modules-policyengine/kamisama-modules-policyengine-policyengineextendedwebapplicationbuilderextensions/index.md) - Adds PolicyEngine CRUD discovery, keyed provider setup, and post-build initialization. It maps no endpoints and current service validation can fail on six non-assignable feature registrations.
- [KamiSama.Modules.PolicyEngine.PolicyEngineOptions](kamisama-modules-policyengine/kamisama-modules-policyengine-policyengineoptions/index.md) - Represents the currently empty module-options object bound from the PolicyEngine section. Database and initialization values use separate repository options.
- [KamiSama.Modules.PolicyEngine.Entities.ExactPolicyListItem](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-exactpolicylistitem/index.md) - Represents an exact serialized value contained by a policy list. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.PolicyAction](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-policyaction/index.md) - Represents a reusable policy action resolved through a registered action handler. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.PolicyList](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-policylist/index.md) - Represents a typed named list referenced by policy conditions. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.PolicyListItem](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-policylistitem/index.md) - Represents a polymorphic value entry contained by a policy list. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.PolicyRule](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-policyrule/index.md) - Represents an ordered policy rule with a persisted condition expression. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.PolicyRuleAction](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-policyruleaction/index.md) - Represents the ordered assignment of a reusable policy action to a policy rule. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Entities.RangePolicyListItem](kamisama-modules-policyengine-entities/kamisama-modules-policyengine-entities-rangepolicylistitem/index.md) - Represents an inclusive serialized value range contained by a policy list. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Modules.PolicyEngine.Repositories.Database.PolicyEngineDbContext](kamisama-modules-policyengine-repositories-database/kamisama-modules-policyengine-repositories-database-policyenginedbcontext/index.md) - Provider-neutral tracked EF Core context for action, rule, assignment, list, and polymorphic item entities. A concrete keyed provider is required, and current provider packages contain no migrations to provision its schema.
