---
last-checked-utc: 2026-08-15T01:00:03Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, complete public XML summaries and primary-constructor parameters, CRUD contracts, context and result shapes, evaluation boundary, publication state, useful exact-full-name examples, and DTO/example exemptions were reviewed against current source at the recorded root version.

## Description

Provider-neutral CRUD contracts, DTOs, search models, and evaluation-shaped data for policy actions, rules, and lists.
It does not provide a policy evaluator, condition parser, action handler contract or dispatcher, authorization integration, transport, controller, or endpoint.

## How to use

**Publication mismatch:** `10.0.0` below is the current workspace/root documentation version and remains required in repository documentation. NuGet returned no published package or version for any of the four current PolicyEngine package IDs when reviewed.

```shell
dotnet add package KamiSama.Modules.PolicyEngine.Abstractions --version 10.0.0
```

Depend on `IAddPolicyAction`, `IUpdatePolicyAction`, `IDeletePolicyAction`, `IFindPolicyActionById`, and `IListPolicyActions`, with equivalent contracts for rules and lists, when callers should not reference EF Core. `PolicyContext` supplies ordinal string fact keys and mutable action/diagnostic outputs, `PolicyConditionResult` supplies three-valued outcomes, and `ResolvedPolicyAction` describes later handler work. A host-owned evaluator must parse condition source, load definitions and relationships, populate results, dispatch actions, and enforce authorization.

## Scope audit

Requests and DTOs manage only action, rule, and list definitions. There are no public contracts for list-item or rule/action-assignment CRUD. `ConfigurationSource` and `ConditionSource` are opaque strings; the abstractions neither validate nor execute them. Search-model `All` properties are mutable shared instances.

## Example decisions

`PolicyContext`, `PolicyEvaluationDiagnostic`, `ResolvedPolicyAction`, and all fifteen CRUD feature interfaces have exact-full-name useful examples. Records, enums, and simple request/DTO/search data are exempt from class-level examples under the documentation workflow; their XML parameter descriptions remain complete.
