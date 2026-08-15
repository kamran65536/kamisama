# IListPlans

<a id="ilistplans"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Abstractions/Features/Plans/Features.cs#L8)

Namespace: `KamiSama.Modules.ServicePlans.Features.Plans`

Kind: `Interface`

## Description

Defines paged plan listing. Core filters by exact case-normalized name, period, and enabled state, then recognizes `id`, `name`, `computationunits`, `ratelimit`, `periodtype`, `durationindays`, `isenabled`, `createdat`, and `updatedat` ordering tokens.

## Declaration

```csharp
public interface IListPlans : IListFeature<PlanListItemDto, PlanSearchModel>;
```

## Example

```csharp
PagedResult<PlanListItemDto> plans = await listPlans.ListAsync(
    new PlanSearchModel(1, 20, null, SubscriptionPeriodType.Monthly, true, "name"), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

