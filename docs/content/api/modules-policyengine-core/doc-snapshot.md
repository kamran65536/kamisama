---
last-checked-utc: 2026-08-15T01:00:03Z
root-version: 10.0.0
classes-without-examples:
  - KamiSama.Modules.PolicyEngine.PolicyEngineExtendedWebApplicationBuilderExtensions
  - KamiSama.Modules.PolicyEngine.PolicyEngineOptions
  - KamiSama.Modules.PolicyEngine.Entities.PolicyListItem
---

# Documentation Snapshot

The package description, complete public/protected XML summaries, data-management boundary, provider callback and startup lifecycle, entities, features, repositories, context and schema provisioning, publication state, confirmed runtime defects, exact-full-name examples, and exemptions were reviewed against current source at the recorded root version.

## Description

EF Core data management for policy actions, rules, lists, rule/action assignments, and polymorphic exact/range list items, with scoped CRUD features and modular startup registration.
It stores definitions but does not evaluate conditions, resolve or execute actions, expose HTTP APIs, or enforce authentication or authorization.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for any of the four current PolicyEngine package IDs when reviewed.

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Core --version 10.0.0
```

Call `AddPolicyEngineModule(moduleSection, databaseSection, providerCallback)` on an `ExtendedWebApplicationBuilder`, then call `BuildAsync`. Set the database provider to `postgresql` and invoke `AddPostgresqlPolicyEngineDbContext`, or set it to `sqlite` and invoke `AddSqlitePolicyEngineDbContext`. The callback is nullable but required in normal setup unless the host separately registers a `PolicyEngineDbContext` under the exact lowercased provider key.

`ConfigureServices` binds the empty `PolicyEngineOptions`, named `DataInitializationOptions`, scans Core for attributed features and repositories, configures the selected keyed context, and sets `__EFMigrationsHistory_PolicyEngine`. After build, the module resolves a custom `IDatabaseInitializer<PolicyEngineDbContext>` or creates the migration-only default and runs selected migration/data/test-data stages. The default data and test-data stages are no-ops.

## Runtime audit

`ListPolicyActions`, `DeletePolicyAction`, `ListPolicyLists`, `DeletePolicyList`, `ListPolicyRules`, and `DeletePolicyRule` are attributed for service interfaces they do not implement. Service-provider validation can fail during `BuildAsync`; without validation, resolving those six interfaces fails. This confirmed behavior is documented and was not changed.

Neither current provider package contains migrations. Consequently, the default `MigrateAsync` startup stage has no PolicyEngine migration operations and cannot provision the action, rule, assignment, list, or item tables. Applications must provide compatible migrations or provision the schema separately before repository use. Startup still requires a configured provider and connection string, and any custom migration path needs database connectivity and schema privileges.

Core maps no controllers, endpoints, or middleware and registers no policy evaluator, action dispatcher, authentication, or authorization. Hosts exposing CRUD features must add endpoint authentication and authorization and must implement evaluation separately. Public CRUD covers action, rule, and list definitions only; no public feature manages `PolicyRuleAction` or `PolicyListItem` rows. Returned DTOs omit those relationships.

Name checks are case-insensitive read-before-write operations with no model-level unique index, so concurrent duplicates remain possible. Repository mutations save immediately and multi-step behavior has no feature-level transaction. Search names are exact case-insensitive matches; recognized ordering tokens are documented on each search model.

## Example decisions

All concrete entities except the abstract `PolicyListItem`, plus `PolicyEngineDbContext`, have exact-full-name useful examples. `PolicyListItem` is covered by its exact and range subtype examples. Empty `PolicyEngineOptions` needs no standalone example. Static `PolicyEngineExtendedWebApplicationBuilderExtensions` is exempt because the package How-to and exact `AddPolicyEngineModule` member documentation cover its only operation. Internal features, repositories, mappings, and module implementation are excluded from public API pages but their behavior and defects are covered above.
