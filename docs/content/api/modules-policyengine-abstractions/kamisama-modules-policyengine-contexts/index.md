# KamiSama.Modules.PolicyEngine.Contexts

[Back to KamiSama.Modules.PolicyEngine.Abstractions](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [PolicyContext](kamisama-modules-policyengine-contexts-policycontext/index.md) | Class | Carries ordinally keyed runtime facts together with mutable resolved-action and diagnostic collections. These packages define the data shape but provide no service that evaluates or populates it. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs#L6) |
| [PolicyEvaluationDiagnostic](kamisama-modules-policyengine-contexts-policyevaluationdiagnostic/index.md) | Class | Carries a machine code, human message, and severity for a separately implemented evaluator. PolicyEngine Core does not create these diagnostics. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs#L6) |
| [PolicyEvaluationDiagnosticSeverity](kamisama-modules-policyengine-contexts-policyevaluationdiagnosticseverity/index.md) | Enum | Specifies the severity of a policy evaluation diagnostic. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs#L27) |
| [ResolvedPolicyAction](kamisama-modules-policyengine-contexts-resolvedpolicyaction/index.md) | Class | Carries a selected action identifier, handler name, opaque configuration, and order for later application. No included API resolves or executes this data. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/ResolvedPolicyAction.cs#L6) |
