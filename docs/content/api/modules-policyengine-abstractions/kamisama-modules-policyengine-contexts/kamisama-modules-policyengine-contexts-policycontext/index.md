# PolicyContext

<a id="policycontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyContext.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Contexts`

Kind: `Class`

## Description

Carries ordinally keyed runtime facts together with mutable resolved-action and diagnostic collections. These packages define the data shape but provide no service that evaluates or populates it.

## Declaration

```csharp
public class PolicyContext
```

## Example

```csharp
var context = new PolicyContext();
context.Facts["subject.country"] = "US";
// A host-supplied evaluator must inspect facts and populate Actions and EvaluationDiagnostics.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Actions](property-actions-20.md) | Gets the actions resolved by policy evaluation in application order. Use it with the surrounding package APIs when composing application code. |
| [EvaluationDiagnostics](property-evaluationdiagnostics-25.md) | Gets the diagnostics produced while evaluating policies. Use it with the surrounding package APIs when composing application code. |
| [Facts](property-facts-15.md) | Gets the flat collection of typed facts available to policy evaluation. Use it with the surrounding package APIs when composing application code. |

