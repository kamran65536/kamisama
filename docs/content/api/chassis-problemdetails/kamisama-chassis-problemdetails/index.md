# KamiSama.Chassis.ProblemDetails

[Back to KamiSama.Chassis.ProblemDetails](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [IProblemDetailsDataProvider](kamisama-chassis-problemdetails-iproblemdetailsdataprovider/index.md) | Interface | The interface provides information for problem details. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/IProblemDetailsDataProvider.cs#L9) |
| [KamiSamaProblemDetailsOptions](kamisama-chassis-problemdetails-kamisamaproblemdetailsoptions/index.md) | Class | Options object for configuring how KamiSama converts exceptions into ASP.NET Core `ProblemDetails`. Use it to choose the provider and optional localization behavior. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsOptions.cs#L11) |
| [KamiSamaProblemDetailsProvider](kamisama-chassis-problemdetails-kamisamaproblemdetailsprovider/index.md) | Class | Converts `HttpExceptionBase` to `ProblemDetails`. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/KamiSamaProblemDetailsProvider.cs#L13) |
| [ProblemDetailsExceptionFilter](kamisama-chassis-problemdetails-problemdetailsexceptionfilter/index.md) | Class | Filter for mapping exceptions to problem details. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ProblemDetailsExceptionFilter.cs#L11) |
| [ServiceCollectionExtension](kamisama-chassis-problemdetails-servicecollectionextension/index.md) | Class | Service Collection Extension for adding exception handing to AspNetCore apps. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.ProblemDetails/ServiceCollectionExtension.cs#L11) |
