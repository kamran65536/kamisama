# PolicyEvaluationDiagnosticSeverity

<a id="policyevaluationdiagnosticseverity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Abstractions/Contexts/PolicyEvaluationDiagnostic.cs#L27)

Namespace: `KamiSama.Modules.PolicyEngine.Contexts`

Kind: `Enum`

## Description

Specifies the severity of a policy evaluation diagnostic. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public enum PolicyEvaluationDiagnosticSeverity
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Enum members

| Member | Description |
| --- | --- |
| [Error](enum-member-error-42.md) | Indicates an evaluation condition that prevented an intended result. Use it with the surrounding package APIs when composing application code. |
| [Information](enum-member-information-32.md) | Indicates diagnostic information that does not represent a problem. Use it with the surrounding package APIs when composing application code. |
| [Warning](enum-member-warning-37.md) | Indicates a recoverable or potentially unintended evaluation condition. Use it with the surrounding package APIs when composing application code. |

