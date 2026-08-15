# KamiSama.Modules.Locations.Entities

[Back to KamiSama.Modules.Locations.Core](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [City](kamisama-modules-locations-entities-city/index.md) | Class | EF Core city entity with a required name and required virtual parent-province navigation. It exposes no separate public province-id property. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Entities/City.cs#L9) |
| [Province](kamisama-modules-locations-entities-province/index.md) | Class | EF Core province entity with a required 100-character name and a virtual city collection. The model restricts deletion while related cities remain. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Entities/Province.cs#L9) |
