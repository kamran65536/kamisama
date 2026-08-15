# PolicyEvaluationDiagnostic

<a id="policyevaluationdiagnostic"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs#L6)

Namespace: `KamiSama.Modules.PolicyEngine.Contexts`

Kind: `Class`

## Description

Carries a machine code, human message, and severity for a separately implemented evaluator. PolicyEngine Core does not create these diagnostics.

## Declaration

```csharp
public class PolicyEvaluationDiagnostic
```

## Example

```csharp
context.EvaluationDiagnostics.Add(new PolicyEvaluationDiagnostic
{
    Code = "missing-fact", Message = "subject.country was not supplied",
    Severity = PolicyEvaluationDiagnosticSeverity.Warning
});
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Code](property-code-11.md) | Gets or sets the machine-readable diagnostic code. Use it with the surrounding package APIs when composing application code. |
| [Message](property-message-16.md) | Gets or sets the human-readable diagnostic message. Use it with the surrounding package APIs when composing application code. |
| [Severity](property-severity-21.md) | Gets or sets the severity of the diagnostic. Use it with the surrounding package APIs when composing application code. |

