# PolicyEngineExtendedWebApplicationBuilderExtensions

<a id="policyengineextendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Core/PolicyEngineWebModule.cs:50](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Core/PolicyEngineWebModule.cs#L50)

Namespace: `KamiSama.Modules.PolicyEngine`

Kind: `Class`

## Description

Adds PolicyEngine CRUD discovery, keyed provider setup, and post-build initialization. It maps no endpoints and current service validation can fail on six non-assignable feature registrations.

## Declaration

```csharp
public static class PolicyEngineExtendedWebApplicationBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPolicyEngineModule](method-addpolicyenginemodule-66.md) | Queues PolicyEngine option binding, attributed CRUD registration, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; `BuildAsync` can fail during service validation because six current list/delete feature registrations are non-assignable. |

